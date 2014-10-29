using System.Windows;
using System.Windows.Data;
using Microsoft.Kinect;
using Microsoft.Kinect.Toolkit;
using Microsoft.Samples.Kinect.WpfViewers;
using System.ComponentModel;
using System;
using System.Timers;
using Fizbin.Kinect.Gestures.Segments;

namespace Fizbin.Kinect.Gestures.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private readonly KinectSensorChooser sensorChooser = new KinectSensorChooser();

        private Skeleton[] skeletons = new Skeleton[0];

        
        Timer _clearTimer;

        // skeleton gesture recognizer
        private GestureController gestureController;

        public MainWindow()
        {
            DataContext = this;

            InitializeComponent();
            lista_gestos.Text = "Amigo\nAbacaxi\nTchau\nDançar\nESCREVER+1"; // lista de gestos implementados e reconhecidos

            // initialize the Kinect sensor manager
            KinectSensorManager = new KinectSensorManager();
            KinectSensorManager.KinectSensorChanged += this.KinectSensorChanged;

            // locate an available sensor
            try
            {
                sensorChooser.Start();
            }
            catch (System.IO.IOException)
            {
                //KinectSensorChooserUI
                //MessageBox.Show("Erro, Kinect desligado ou está em uso por outro programa", "Erro");
            }

            // bind chooser's sensor value to the local sensor manager
            var kinectSensorBinding = new Binding("Kinect") { Source = this.sensorChooser };
            BindingOperations.SetBinding(this.KinectSensorManager, KinectSensorManager.KinectSensorProperty, kinectSensorBinding);

			// add timer for clearing last detected gesture
            _clearTimer = new Timer(2000); // 2 segundos?
            _clearTimer.Elapsed += new ElapsedEventHandler(clearTimer_Elapsed);
        }
        
        #region Kinect Discovery & Setup

        private void KinectSensorChanged(object sender, KinectSensorManagerEventArgs<KinectSensor> args)
        {
            if (null != args.OldValue)
                UninitializeKinectServices(args.OldValue);

            if (null != args.NewValue)
                InitializeKinectServices(KinectSensorManager, args.NewValue);
        }

        /// <summary>
        /// Kinect enabled apps should customize which Kinect services it initializes here.
        /// </summary>
        /// <param name="kinectSensorManager"></param>
        /// <param name="sensor"></param>
        private void InitializeKinectServices(KinectSensorManager kinectSensorManager, KinectSensor sensor)
        {
            // Application should enable all streams first.

            // configure the color stream
            kinectSensorManager.ColorFormat = ColorImageFormat.RgbResolution640x480Fps30;
            kinectSensorManager.ColorStreamEnabled = true;

            // configure the depth stream
            kinectSensorManager.DepthStreamEnabled = true;
            //suavidade dos movimentos (animacao entre os frames)
            kinectSensorManager.TransformSmoothParameters =
                new TransformSmoothParameters
                {
                    Smoothing = 0.5f,
                    Correction = 0.5f,
                    Prediction = 0.5f,
                    JitterRadius = 0.05f,
                    MaxDeviationRadius = 0.04f
                };

            // configure the skeleton stream
            sensor.SkeletonFrameReady += OnSkeletonFrameReady;
            kinectSensorManager.SkeletonStreamEnabled = true;

            kinectSensorManager.KinectSensorEnabled = true;

            if (!kinectSensorManager.KinectSensorAppConflict)
            {
                // initialize the gesture recognizer
                gestureController = new GestureController();
                gestureController.GestureRecognized += OnGestureRecognized;

                // register the gestures for this demo
                RegisterGestures();
            }
        }

        /// <summary>
        /// Kinect enabled apps should uninitialize all Kinect services that were initialized in InitializeKinectServices() here.
        /// </summary>
        /// <param name="sensor"></param>
        private void UninitializeKinectServices(KinectSensor sensor)
        {
            // unregister the event handlers
            sensor.SkeletonFrameReady -= OnSkeletonFrameReady;
            gestureController.GestureRecognized -= OnGestureRecognized;
        }

        #endregion Kinect Discovery & Setup

        /// <summary>
        /// Helper function to register all available 
        /// </summary>
        private void RegisterGestures()
        {
            // define the gestures for the demo

            /*IRelativeGestureSegment[] joinedhandsSegments = new IRelativeGestureSegment[20];
            JoinedHandsSegment1 joinedhandsSegment = new JoinedHandsSegment1();
            for (int i = 0; i < 20; i++)
            {
                // gesture consists of the same thing 10 times 
                joinedhandsSegments[i] = joinedhandsSegment;
            }
            gestureController.AddGesture("JoinedHands", joinedhandsSegments);
            */
            IRelativeGestureSegment[] menuSegments = new IRelativeGestureSegment[20];
            MenuSegment1 menuSegment = new MenuSegment1();
            for (int i = 0; i < 20; i++)
            {
                // gesture consists of the same thing 20 times 
                menuSegments[i] = menuSegment;
            }
            gestureController.AddGesture("Menu", menuSegments);

            /*
            IRelativeGestureSegment[] swipeleftSegments = new IRelativeGestureSegment[3];
            swipeleftSegments[0] = new SwipeLeftSegment1();
            swipeleftSegments[1] = new SwipeLeftSegment2();
            swipeleftSegments[2] = new SwipeLeftSegment3();
            gestureController.AddGesture("SwipeLeft", swipeleftSegments);

            IRelativeGestureSegment[] swiperightSegments = new IRelativeGestureSegment[3];
            swiperightSegments[0] = new SwipeRightSegment1();
            swiperightSegments[1] = new SwipeRightSegment2();
            swiperightSegments[2] = new SwipeRightSegment3();
            gestureController.AddGesture("SwipeRight", swiperightSegments);

            //fazer um novo gesto, criar a classe com nome segmento
            IRelativeGestureSegment[] waveRightSegments = new IRelativeGestureSegment[6];
            WaveRightSegment1 waveRightSegment1 = new WaveRightSegment1();
            WaveRightSegment2 waveRightSegment2 = new WaveRightSegment2();
            waveRightSegments[0] = waveRightSegment1;
            waveRightSegments[1] = waveRightSegment2;
            waveRightSegments[2] = waveRightSegment1;
            waveRightSegments[3] = waveRightSegment2;
            waveRightSegments[4] = waveRightSegment1;
            waveRightSegments[5] = waveRightSegment2;
            gestureController.AddGesture("WaveRight", waveRightSegments);

            IRelativeGestureSegment[] waveLeftSegments = new IRelativeGestureSegment[6];
            WaveLeftSegment1 waveLeftSegment1 = new WaveLeftSegment1();
            WaveLeftSegment2 waveLeftSegment2 = new WaveLeftSegment2();
            waveLeftSegments[0] = waveLeftSegment1;
            waveLeftSegments[1] = waveLeftSegment2;
            waveLeftSegments[2] = waveLeftSegment1;
            waveLeftSegments[3] = waveLeftSegment2;
            waveLeftSegments[4] = waveLeftSegment1;
            waveLeftSegments[5] = waveLeftSegment2;
            gestureController.AddGesture("WaveLeft", waveLeftSegments);

            IRelativeGestureSegment[] zoomInSegments = new IRelativeGestureSegment[3];
            zoomInSegments[0] = new ZoomSegment1();
            zoomInSegments[1] = new ZoomSegment2();
            zoomInSegments[2] = new ZoomSegment3();
            gestureController.AddGesture("ZoomIn", zoomInSegments);

            IRelativeGestureSegment[] zoomOutSegments = new IRelativeGestureSegment[3];
            zoomOutSegments[0] = new ZoomSegment3();
            zoomOutSegments[1] = new ZoomSegment2();
            zoomOutSegments[2] = new ZoomSegment1();
            gestureController.AddGesture("ZoomOut", zoomOutSegments);

            IRelativeGestureSegment[] swipeUpSegments = new IRelativeGestureSegment[3];
            swipeUpSegments[0] = new SwipeUpSegment1();
            swipeUpSegments[1] = new SwipeUpSegment2();
            swipeUpSegments[2] = new SwipeUpSegment3();
            gestureController.AddGesture("SwipeUp", swipeUpSegments);

            IRelativeGestureSegment[] swipeDownSegments = new IRelativeGestureSegment[3];
            swipeDownSegments[0] = new SwipeDownSegment1();
            swipeDownSegments[1] = new SwipeDownSegment2();
            swipeDownSegments[2] = new SwipeDownSegment3();
            gestureController.AddGesture("SwipeDown", swipeDownSegments);
            */
            /*
            IRelativeGestureSegment[] obrigadoSegments = new IRelativeGestureSegment[3];
            obrigadoSegments[0] = new obrigadoSegment1();
            obrigadoSegments[1] = new obrigadoSegment2();
            obrigadoSegments[2] = new obrigadoSegment3();
            gestureController.AddGesture("Obrigado", obrigadoSegments);
            */
            /*
            IRelativeGestureSegment[] devagarSegments = new IRelativeGestureSegment[2];
            devagarSegments[0] = new devagarSegment1();
            devagarSegments[1] = new devagarSegment2();
            gestureController.AddGesture("Devagar", devagarSegments);
            */

            IRelativeGestureSegment[] amigoSegments = new IRelativeGestureSegment[6];
            amigoSegment1 amigoSegment1 = new amigoSegment1();
            amigoSegment2 amigoSegment2 = new amigoSegment2();
            amigoSegment3 amigoSegment3 = new amigoSegment3();
            amigoSegments[0] = amigoSegment1;
            amigoSegments[1] = amigoSegment2;
            amigoSegments[2] = amigoSegment3;
            amigoSegments[3] = amigoSegment1;
            amigoSegments[4] = amigoSegment2;
            amigoSegments[5] = amigoSegment3;
            gestureController.AddGesture("Amigo", amigoSegments);
            //varios segments para demorar mais entre reconhecimentos

            IRelativeGestureSegment[] abacaxiSegments = new IRelativeGestureSegment[9];
            abacaxiSegment1 abacaxiSegment1 = new abacaxiSegment1();
            abacaxiSegment2 abacaxiSegment2 = new abacaxiSegment2();
            abacaxiSegment3 abacaxiSegment3 = new abacaxiSegment3();
            abacaxiSegments[0] = abacaxiSegment1;
            abacaxiSegments[1] = abacaxiSegment2;
            abacaxiSegments[2] = abacaxiSegment3;
            abacaxiSegments[3] = abacaxiSegment1;
            abacaxiSegments[4] = abacaxiSegment2;
            abacaxiSegments[5] = abacaxiSegment3;
            abacaxiSegments[6] = abacaxiSegment1;
            abacaxiSegments[7] = abacaxiSegment2;
            abacaxiSegments[8] = abacaxiSegment3;
            gestureController.AddGesture("Abacaxi", abacaxiSegments);

            IRelativeGestureSegment[] tchauSegments = new IRelativeGestureSegment[4];
            tchauSegment1 tchauSegment1 = new tchauSegment1();
            tchauSegment2 tchauSegment2 = new tchauSegment2();
            tchauSegments[0] = tchauSegment1;
            tchauSegments[1] = tchauSegment2;
            tchauSegments[2] = tchauSegment1;
            tchauSegments[3] = tchauSegment2;
            gestureController.AddGesture("Tchau", tchauSegments);

            IRelativeGestureSegment[] dancarSegments = new IRelativeGestureSegment[4];
            dancarSegment1 dancarSegment1 = new dancarSegment1();
            dancarSegment2 dancarSegment2 = new dancarSegment2();
            dancarSegments[0] = dancarSegment1;
            dancarSegments[1] = dancarSegment2;
            dancarSegments[2] = dancarSegment1;
            dancarSegments[3] = dancarSegment2;
            gestureController.AddGesture("Dancar", dancarSegments);
        }

        #region Properties

        public static readonly DependencyProperty KinectSensorManagerProperty =
            DependencyProperty.Register(
                "KinectSensorManager",
                typeof(KinectSensorManager),
                typeof(MainWindow),
                new PropertyMetadata(null));

        public KinectSensorManager KinectSensorManager
        {
            get { return (KinectSensorManager)GetValue(KinectSensorManagerProperty); }
            set { SetValue(KinectSensorManagerProperty, value); }
        }

        /// <summary>
        /// Gets or sets the last recognized gesture.
        /// </summary>
        private string _gesture;
        public String Gesture
        {
            get { return _gesture; }

            private set
            {
                if (_gesture == value)
                    return;

                _gesture = value;

                if (this.PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Gesture"));
            }
        }

        #endregion Properties

        #region Events

        /// <summary>
        /// Event implementing INotifyPropertyChanged interface.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Event Handlers
        

        /// <summary>
        ///
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Gesture event arguments.</param>
        private void OnGestureRecognized(object sender, GestureEventArgs e)
        {
            int palavras_reconhecidas = 0;
            //numero_reconhecidos.Text = palavras_reconhecidas.ToString();
            numero_reconhecidos2.Text = palavras_reconhecidas.ToString();
            switch (e.GestureName)
            {
                
                case "Menu":
                    Gesture = "Menu";
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Menu ";
                    break;
                /*
                case "JoinedHands":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Mãos Juntas ";
                    Gesture = "Mãos Juntas";
                    break;
                */
                /*
                case "WaveRight":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Wave Right\n";
                    Gesture = "Wave Left";
                    break;
                case "WaveLeft":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Wave Left\n";
                    Gesture = "Amigo";
                    break;
                case "SwipeLeft":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Swipe Left\n";
                    Gesture = "Swipe Left";
                    break;
                case "SwipeRight":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Swipe Right\n";
                    Gesture = "Swipe Right";
 					break;
                case "SwipeUp":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Swipe Up\n";
                    Gesture = "Swipe Up";
                    break;
                case "SwipeDown":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Swipe Down\n";
                    Gesture = "Swipe Down";
                    break;
                case "ZoomIn":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Zoom In\n";
                    Gesture = "Zoom In";
                    break;
                case "ZoomOut":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Zoom Out\n";
                    Gesture = "Zoom Out";
                    break;
                    */
                case "Devagar":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Devagar ";
                    Gesture = "Devagar";
                    break;
                case "Amigo":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Amigo ";
                    Gesture = "Amigo";
                    break;
                case "Tchau":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Tchau ";
                    Gesture = "Tchau";
                    break;
                case "Obrigado":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Obrigado ";
                    Gesture = "Obrigado";
                    break;
                case "Casa":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Casa ";
                    Gesture = "Casa"; //provavelmente nao vai dar, ele se perde com as articulacoes
                    break;
                case "Abacaxi":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Abacaxi ";
                    Gesture = "Abacaxi"; //provavelmente nao vai dar, ele se perde com as articulacoes
                    break;
                case "Dancar":
                    palavras_reconhecidas++;
                    lista_reconhecidos.Text += "Dançar ";
                    Gesture = "Dançar"; //provavelmente nao vai dar, ele se perde com as articulacoes
                    break;

                default:
                    break;
            }

            _clearTimer.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame frame = e.OpenSkeletonFrame())
            {
                if (frame == null)
                    return;

                // resize the skeletons array if needed
                if (skeletons.Length != frame.SkeletonArrayLength)
                    skeletons = new Skeleton[frame.SkeletonArrayLength];

                // get the skeleton data
                frame.CopySkeletonDataTo(skeletons);

                foreach (var skeleton in skeletons)
                {
                    // skip the skeleton if it is not being tracked
                    if (skeleton.TrackingState != SkeletonTrackingState.Tracked)
                        continue;

                    // update the gesture controller
                    gestureController.UpdateAllGestures(skeleton);
                }
            }
        }

        /// <summary>
        /// Clear text after some time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void clearTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Gesture = "";
            _clearTimer.Stop();
        }

        #endregion Event Handlers

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {
            if (sensorChooser != null)
            {
                sensorChooser.Stop();
            }
        }

    }
}
