using Microsoft.Kinect;

namespace Fizbin.Kinect.Gestures.Segments
{
    public class amigoSegment1 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (skeleton.Joints[JointType.HandRight].Position.Y >= skeleton.Joints[JointType.ElbowRight].Position.Y)
            {

                if (
                    skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.Spine].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderCenter].Position.X && //
                    skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                    skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.HipLeft].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ElbowLeft].Position.Y
                    //mao esquerda deve estar ao lado da perna esquerda da pessoa                    
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

    public class amigoSegment2 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (skeleton.Joints[JointType.HandRight].Position.Y >= skeleton.Joints[JointType.ElbowRight].Position.Y)
            {

                if (
                    skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.Spine].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderCenter].Position.X && //
                    skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                    skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.HipLeft].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ElbowLeft].Position.Y
                    //mao esquerda deve estar ao lado da perna esquerda da pessoa                    
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

    public class amigoSegment3 : IRelativeGestureSegment
    {
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (skeleton.Joints[JointType.HandRight].Position.Y >= skeleton.Joints[JointType.ElbowRight].Position.Y)
            {

                if (
                    skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.Spine].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.Y < skeleton.Joints[JointType.ShoulderCenter].Position.Y &&
                    skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderCenter].Position.X && //
                    skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ShoulderLeft].Position.X &&
                    skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ShoulderRight].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.HipLeft].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ElbowLeft].Position.Y
                    //mao esquerda deve estar ao lado da perna esquerda da pessoa                    
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