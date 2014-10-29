//fazer um novo gesto em cima desse
using Microsoft.Kinect;

namespace Fizbin.Kinect.Gestures.Segments
{
    public class abacaxiSegment1 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y)
            {

                if (
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ElbowRight].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderCenter].Position.X
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

    public class abacaxiSegment2 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y)
            {

                if (
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ElbowRight].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderCenter].Position.X
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

    public class abacaxiSegment3 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y)
            {

                if (
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ElbowRight].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.X > skeleton.Joints[JointType.ShoulderCenter].Position.X
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