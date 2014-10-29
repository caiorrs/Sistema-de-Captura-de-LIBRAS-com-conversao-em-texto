using Microsoft.Kinect;

namespace Fizbin.Kinect.Gestures.Segments
{
    public class devagarSegment1 : IRelativeGestureSegment
    {

        //tentar fazer com switch
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (
                skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.Spine].Position.Y &&
                skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y &&
                skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X
               )
            {

                if (
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X
                   )
                {
                    return GesturePartResult.Succeed;
                }

                //pausa no movimento
                return GesturePartResult.Pausing;
            }

            //falha no gesto
            return GesturePartResult.Fail;
        }
    }

    public class devagarSegment2 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (
                skeleton.Joints[JointType.HandLeft].Position.Y > skeleton.Joints[JointType.HipCenter].Position.Y &&
                skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y &&
                skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X
               )
            {

                if (
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X
                   )
                {
                    return GesturePartResult.Succeed;
                }

                //pausa no movimento
                return GesturePartResult.Pausing;
            }

            //falha no gesto
            return GesturePartResult.Fail;
        }
    }
}