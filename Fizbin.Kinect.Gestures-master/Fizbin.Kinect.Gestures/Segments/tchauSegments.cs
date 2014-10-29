using Microsoft.Kinect;

namespace Fizbin.Kinect.Gestures.Segments
{
    public class tchauSegment1 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y
               )
            {
         
                if (skeleton.Joints[JointType.HandRight].Position.X > skeleton.Joints[JointType.ElbowRight].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ElbowLeft].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.HipLeft].Position.X
                   )
         
                {
                    return GesturePartResult.Succeed;
                }

         
                return GesturePartResult.Pausing;
            }

         
            return GesturePartResult.Fail;
        }
    }

    public class tchauSegment2 : IRelativeGestureSegment
    {
        /// <summary>
        /// Checks the gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>GesturePartResult based on if the gesture part has been completed</returns>
        public GesturePartResult CheckGesture(Skeleton skeleton)
        {

            if (skeleton.Joints[JointType.HandRight].Position.Y > skeleton.Joints[JointType.ElbowRight].Position.Y
               )
            {

                if (skeleton.Joints[JointType.HandRight].Position.X < skeleton.Joints[JointType.ElbowRight].Position.X &&
                    skeleton.Joints[JointType.HandLeft].Position.Y < skeleton.Joints[JointType.ElbowLeft].Position.Y &&
                    skeleton.Joints[JointType.HandLeft].Position.X < skeleton.Joints[JointType.HipLeft].Position.X
                   )
         
                {
                    return GesturePartResult.Succeed;
                }

         
                return GesturePartResult.Pausing;
            }

         
            return GesturePartResult.Fail;
        }
    }
}