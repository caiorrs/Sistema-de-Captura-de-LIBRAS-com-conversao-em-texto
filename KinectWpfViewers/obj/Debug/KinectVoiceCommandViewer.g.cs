﻿#pragma checksum "..\..\KinectVoiceCommandViewer.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8DD977C84B5D81DBCF51B0564630EB8A"
//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.34014
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Samples.Kinect.WpfViewers;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace Microsoft.Samples.Kinect.WpfViewers {
    
    
    /// <summary>
    /// KinectVoiceCommandViewer
    /// </summary>
    public partial class KinectVoiceCommandViewer : Microsoft.Samples.Kinect.WpfViewers.KinectViewer, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\KinectVoiceCommandViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockModeFeedback;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\KinectVoiceCommandViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockCommandFeedback;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\KinectVoiceCommandViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock textBlockActionFeedback;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\KinectVoiceCommandViewer.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal Microsoft.Samples.Kinect.WpfViewers.KinectSpeechCommander kinectSpeechCommander;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/Microsoft.Samples.Kinect.WpfViewers;component/kinectvoicecommandviewer.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\KinectVoiceCommandViewer.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.textBlockModeFeedback = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.textBlockCommandFeedback = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.textBlockActionFeedback = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.kinectSpeechCommander = ((Microsoft.Samples.Kinect.WpfViewers.KinectSpeechCommander)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

