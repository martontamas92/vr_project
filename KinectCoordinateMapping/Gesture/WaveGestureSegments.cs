namespace KinectCoordinateMapping.Gesture
{
  using System;
  using Microsoft.Kinect;

  /// <summary>
  /// Represents a single gesture segment which uses relative positioning of body parts to detect a gesture.
  /// </summary>
  public interface IGestureSegment
  {
        /// <summary>
        /// Updates the current gesture.
        /// </summary>
        /// <param name="skeleton">The skeleton.</param>
        /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
        Notes Update(Skeleton skeleton);

        
    }


    public class  Calculate 
    {
        public Calculate() { }
        public void CalculatePosition(Skeleton skeleton)
        {
           

            Console.WriteLine("\n Joints");
            Console.WriteLine("ShoulderRight X: " + skeleton.Joints[JointType.ShoulderRight].Position.X);
            Console.WriteLine("ShoulderRight Y: " + skeleton.Joints[JointType.ShoulderRight].Position.Y);
            Console.WriteLine("ShoulderRight Z: " + skeleton.Joints[JointType.ShoulderRight].Position.Z);
            
            Console.WriteLine("ElbowRight X: " + skeleton.Joints[JointType.ElbowRight].Position.X);
            Console.WriteLine("ElbowRight Y: " + skeleton.Joints[JointType.ElbowRight].Position.Y);
            Console.WriteLine("ElbowRight Z: " + skeleton.Joints[JointType.ElbowRight].Position.Z);

            Console.WriteLine("WristRight X: " + skeleton.Joints[JointType.WristRight].Position.X);
            Console.WriteLine("WristRight Y: " + skeleton.Joints[JointType.WristRight].Position.Y);
            Console.WriteLine("WristRight Z: " + skeleton.Joints[JointType.WristRight].Position.Z);

            float felkar = Tangent(
                skeleton.Joints[JointType.ShoulderRight].Position.X,
                skeleton.Joints[JointType.ElbowRight].Position.X,
                skeleton.Joints[JointType.ShoulderRight].Position.Y,
                skeleton.Joints[JointType.ElbowRight].Position.Y
                );
            float alkar = Tangent(
                
                skeleton.Joints[JointType.ElbowRight].Position.X,
                skeleton.Joints[JointType.WristRight].Position.X,
                skeleton.Joints[JointType.ElbowRight].Position.Y,
                skeleton.Joints[JointType.WristRight].Position.Y
                
                );
            Console.WriteLine("Shoulder-Elbow Angle: " + felkar + "\n");
            Console.WriteLine("Elbow-Wrist Angle: " + alkar + "\n");
            CreateCode(felkar,alkar);
            


        }

        public void CreateCode(float tg1, float tg2)
        {
            string code = "";
            code += "1 " + tg1 + "\n";
            code += "2 " + tg2 + "\n";
            code += "3 " + "0" + "\n";
            code += "\n";

            Console.WriteLine("A kód: \n " + code);
            
        }

        public float Tangent(float X1, float X2, float Y1, float Y2)
        {
            float tg = (Y2-Y1)/(X2 - X1);

            //return (float)Math.Atan(tg);
            Console.WriteLine("tg: " + tg);
            return (float)(Math.Atan(tg) * (180 / Math.PI));
           
        }
    }

    
  public class WaveGesture_Also_Do : IGestureSegment
  {

    private readonly double treshhold_Y = 0.055;
    private readonly double treshhold_X = 0.08;
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
    public Notes Update(Skeleton skeleton)
    {
           // Console.WriteLine(skeleton);
            // Hand above elbow
            if (Math.Abs(skeleton.Joints[JointType.ShoulderRight].Position.Y -
          skeleton.Joints[JointType.ElbowRight].Position.Y) <= this.treshhold_Y &&
          Math.Abs(skeleton.Joints[JointType.ElbowRight].Position.Y -
          skeleton.Joints[JointType.WristRight].Position.Y) <= this.treshhold_Y)
      {
        // Hand right of elbow
        if (skeleton.Joints[JointType.ShoulderRight].Position.X <=
          skeleton.Joints[JointType.ElbowRight].Position.X &&
          skeleton.Joints[JointType.ElbowRight].Position.X <=
          skeleton.Joints[JointType.WristRight].Position.X)
        {

          // Other hand
          if (Math.Abs(skeleton.Joints[JointType.ShoulderLeft].Position.X -
          skeleton.Joints[JointType.ElbowLeft].Position.X) <= this.treshhold_X &&
          Math.Abs(skeleton.Joints[JointType.ElbowLeft].Position.X -
          skeleton.Joints[JointType.WristLeft].Position.X) <= this.treshhold_X)
          {
            // Hand right of elbow
            if (skeleton.Joints[JointType.ShoulderLeft].Position.Y >=
              skeleton.Joints[JointType.ElbowLeft].Position.Y &&
              skeleton.Joints[JointType.ElbowLeft].Position.Y >=
              skeleton.Joints[JointType.WristLeft].Position.Y)
            {
                            
              return Notes.DoL;
            }
          }
        }
      }
      // Hand dropped
      return Notes.None;
    }
  }

  public class WaveGestureFa : IGestureSegment
  {
    private readonly double treshhold_Y = 0.055;
    private readonly double treshhold_X = 0.08;
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
    public Notes Update(Skeleton skeleton)
    {
      // Hand above elbow
      if (Math.Abs(skeleton.Joints[JointType.ShoulderLeft].Position.Y -
          skeleton.Joints[JointType.ElbowLeft].Position.Y) <= this.treshhold_Y &&
          Math.Abs(skeleton.Joints[JointType.ElbowLeft].Position.Y -
          skeleton.Joints[JointType.WristLeft].Position.Y) <= this.treshhold_Y)
      {
        // Hand right of elbow
        if (skeleton.Joints[JointType.ShoulderLeft].Position.X >=
          skeleton.Joints[JointType.ElbowLeft].Position.X &&
          skeleton.Joints[JointType.ElbowLeft].Position.X >=
          skeleton.Joints[JointType.WristLeft].Position.X)
        {

          // Other hand
          if (Math.Abs(skeleton.Joints[JointType.ShoulderRight].Position.X -
          skeleton.Joints[JointType.ElbowRight].Position.X) <= this.treshhold_X &&
          Math.Abs(skeleton.Joints[JointType.ElbowRight].Position.X -
          skeleton.Joints[JointType.WristRight].Position.X) <= this.treshhold_X)
          {
            // Hand right of elbow
            if (skeleton.Joints[JointType.ShoulderRight].Position.Y >=
              skeleton.Joints[JointType.ElbowRight].Position.Y &&
              skeleton.Joints[JointType.ElbowRight].Position.Y >=
              skeleton.Joints[JointType.WristRight].Position.Y)
            {
              return Notes.Fa;
            }
          }
        }
      }
      // Hand dropped
      return Notes.None;
    }
  }

  public class WaveGesture_Felso_Do : IGestureSegment
  {
    private readonly double treshhold_Y = 0.055;
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
    public Notes Update(Skeleton skeleton)
    {
      // Hand above elbow
      // Hand above elbow
      if (Math.Abs(skeleton.Joints[JointType.ShoulderRight].Position.Y -
          skeleton.Joints[JointType.ElbowRight].Position.Y) <= this.treshhold_Y &&
          Math.Abs(skeleton.Joints[JointType.ElbowRight].Position.Y -
          skeleton.Joints[JointType.WristRight].Position.Y) <= this.treshhold_Y)
      {
        // Hand right of elbow
        if (skeleton.Joints[JointType.ShoulderRight].Position.X <=
          skeleton.Joints[JointType.ElbowRight].Position.X &&
          skeleton.Joints[JointType.ElbowRight].Position.X <=
          skeleton.Joints[JointType.WristRight].Position.X)
        {
          if (Math.Abs(skeleton.Joints[JointType.ShoulderLeft].Position.Y -
              skeleton.Joints[JointType.ElbowLeft].Position.Y) <= this.treshhold_Y &&
              Math.Abs(skeleton.Joints[JointType.ElbowLeft].Position.Y -
              skeleton.Joints[JointType.WristLeft].Position.Y) <= this.treshhold_Y)
          {
            // Hand right of elbow
            if (skeleton.Joints[JointType.ShoulderLeft].Position.X >=
                skeleton.Joints[JointType.ElbowLeft].Position.X &&
                skeleton.Joints[JointType.ElbowLeft].Position.X >=
                skeleton.Joints[JointType.WristLeft].Position.X)
            {
              return Notes.DoF;
            }
          }
        }
      }

      // Hand dropped
      return Notes.None;
    }
  }

  public class WaveGestureRe : IGestureSegment
  {
    private readonly double treshhold_Y = 0.055;
    private readonly double treshhold_X = 0.08;

    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
    public Notes Update(Skeleton skeleton)
    {
      // Hand above elbow
      if (Math.Abs(skeleton.Joints[JointType.ShoulderRight].Position.Y -
          skeleton.Joints[JointType.ElbowRight].Position.Y) <= this.treshhold_Y &&
          skeleton.Joints[JointType.ShoulderRight].Position.Y <
          skeleton.Joints[JointType.WristRight].Position.Y)
      {
        // Hand right of elbow
        if (skeleton.Joints[JointType.ShoulderRight].Position.X <=
          skeleton.Joints[JointType.ElbowRight].Position.X &&
          Math.Abs(skeleton.Joints[JointType.ElbowRight].Position.X -
          skeleton.Joints[JointType.WristRight].Position.X) < this.treshhold_X)
        {
          // Other hand
          if (Math.Abs(skeleton.Joints[JointType.ShoulderLeft].Position.X -
          skeleton.Joints[JointType.ElbowLeft].Position.X) <= this.treshhold_X &&
          Math.Abs(skeleton.Joints[JointType.ElbowLeft].Position.X -
          skeleton.Joints[JointType.WristLeft].Position.X) <= this.treshhold_X)
          {
            // Hand right of elbow
            if (skeleton.Joints[JointType.ShoulderLeft].Position.Y >=
              skeleton.Joints[JointType.ElbowLeft].Position.Y &&
              skeleton.Joints[JointType.ElbowLeft].Position.Y >=
              skeleton.Joints[JointType.WristLeft].Position.Y)
            {
              return Notes.Re;
            }
          }
        }
      }

      // Hand dropped
      return Notes.None;
    }
  }

  public class WaveGestureMi : IGestureSegment
  {
    private readonly double treshhold_Y = 0.055;
    private readonly double treshhold_X = 0.08;

    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
    public Notes Update(Skeleton skeleton)
    {
      // Hand above elbow
      if (Math.Abs(skeleton.Joints[JointType.ShoulderLeft].Position.Y -
          skeleton.Joints[JointType.ElbowLeft].Position.Y) <= this.treshhold_Y &&
          skeleton.Joints[JointType.ShoulderLeft].Position.Y <
          skeleton.Joints[JointType.WristLeft].Position.Y)
      {
        // Hand right of elbow
        if (skeleton.Joints[JointType.ShoulderLeft].Position.X >=
          skeleton.Joints[JointType.ElbowLeft].Position.X &&
          Math.Abs(skeleton.Joints[JointType.ElbowLeft].Position.X -
          skeleton.Joints[JointType.WristLeft].Position.X) < this.treshhold_X)
        {
          // Other hand
          if (Math.Abs(skeleton.Joints[JointType.ShoulderRight].Position.X -
          skeleton.Joints[JointType.ElbowRight].Position.X) <= this.treshhold_X &&
          Math.Abs(skeleton.Joints[JointType.ElbowRight].Position.X -
          skeleton.Joints[JointType.WristRight].Position.X) <= this.treshhold_X)
          {
            // Hand right of elbow
            if (skeleton.Joints[JointType.ShoulderRight].Position.Y >=
              skeleton.Joints[JointType.ElbowRight].Position.Y &&
              skeleton.Joints[JointType.ElbowRight].Position.Y >=
              skeleton.Joints[JointType.WristRight].Position.Y)
            {
              return Notes.Mi;
            }
          }
        }
      }

      // Hand dropped
      return Notes.None;
    }
  }

  public class WaveGestureLa : IGestureSegment
  {
    private readonly double treshhold_X = 0.08;
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
    public Notes Update(Skeleton skeleton)
    {
      // Hand above elbow
      if (skeleton.Joints[JointType.ShoulderRight].Position.Y <
          skeleton.Joints[JointType.ElbowRight].Position.Y &&
          skeleton.Joints[JointType.ElbowRight].Position.Y <
          skeleton.Joints[JointType.WristRight].Position.Y &&
          skeleton.Joints[JointType.Head].Position.Y <
          skeleton.Joints[JointType.ElbowRight].Position.Y)
      {

        // Other hand
        if (Math.Abs(skeleton.Joints[JointType.ShoulderLeft].Position.X -
        skeleton.Joints[JointType.ElbowLeft].Position.X) <= this.treshhold_X &&
        Math.Abs(skeleton.Joints[JointType.ElbowLeft].Position.X -
        skeleton.Joints[JointType.WristLeft].Position.X) <= this.treshhold_X)
        {
          // Hand right of elbow
          if (skeleton.Joints[JointType.ShoulderLeft].Position.Y >=
            skeleton.Joints[JointType.ElbowLeft].Position.Y &&
            skeleton.Joints[JointType.ElbowLeft].Position.Y >=
            skeleton.Joints[JointType.WristLeft].Position.Y)
          {
            return Notes.La;
          }
        }
      }

      // Hand dropped
      return Notes.None;
    }
  }

  public class WaveGestureTi : IGestureSegment
  {
    private readonly double treshhold_X = 0.08;
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
    public Notes Update(Skeleton skeleton)
    {
      // Hand above elbow
      if (skeleton.Joints[JointType.ShoulderLeft].Position.Y <
          skeleton.Joints[JointType.ElbowLeft].Position.Y &&
          skeleton.Joints[JointType.ElbowLeft].Position.Y <
          skeleton.Joints[JointType.WristLeft].Position.Y &&
          skeleton.Joints[JointType.Head].Position.Y <
          skeleton.Joints[JointType.ElbowLeft].Position.Y)
      {
        // Other hand
        if (Math.Abs(skeleton.Joints[JointType.ShoulderRight].Position.X -
        skeleton.Joints[JointType.ElbowRight].Position.X) <= this.treshhold_X &&
        Math.Abs(skeleton.Joints[JointType.ElbowRight].Position.X -
        skeleton.Joints[JointType.WristRight].Position.X) <= this.treshhold_X)
        {
          // Hand right of elbow
          if (skeleton.Joints[JointType.ShoulderRight].Position.Y >=
            skeleton.Joints[JointType.ElbowRight].Position.Y &&
            skeleton.Joints[JointType.ElbowRight].Position.Y >=
            skeleton.Joints[JointType.WristRight].Position.Y)
          {
            return Notes.Ti;
          }
        }
      }

      // Hand dropped
      return Notes.None;
    }
  }

  public class WaveGestureSzo : IGestureSegment
  {
    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton.</param>
    /// <returns>A GesturePartResult based on whether the gesture part has been completed.</returns>
    public Notes Update(Skeleton skeleton)
    {
      // Hand above elbow
      if (skeleton.Joints[JointType.ShoulderLeft].Position.Y <
          skeleton.Joints[JointType.ElbowLeft].Position.Y &&
          skeleton.Joints[JointType.ElbowLeft].Position.Y <
          skeleton.Joints[JointType.WristLeft].Position.Y &&
          skeleton.Joints[JointType.Head].Position.Y <
          skeleton.Joints[JointType.ElbowLeft].Position.Y &&
          skeleton.Joints[JointType.ShoulderRight].Position.Y <
          skeleton.Joints[JointType.ElbowRight].Position.Y &&
          skeleton.Joints[JointType.ElbowRight].Position.Y <
          skeleton.Joints[JointType.WristRight].Position.Y &&
          skeleton.Joints[JointType.Head].Position.Y <
          skeleton.Joints[JointType.ElbowRight].Position.Y)
      {
        return Notes.So;
      }

      // Hand dropped
      return Notes.None;
    }
  }
}