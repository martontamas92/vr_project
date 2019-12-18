namespace KinectCoordinateMapping.Gesture
{
  using System;
  using Microsoft.Kinect;


    public class  Calculate 
    {
        public Calculate() { }


        public void CalculatePosition(Skeleton skeleton, ref float prev_felkar, ref float prev_alkar)
        {
            /*
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
            */
            float felkar = Tangent(
                skeleton.Joints[JointType.ShoulderRight].Position.X,
                skeleton.Joints[JointType.ElbowRight].Position.X,
                skeleton.Joints[JointType.ShoulderRight].Position.Y,
                skeleton.Joints[JointType.ElbowRight].Position.Y
                );
            float alkar =  Tangent(
                skeleton.Joints[JointType.ElbowRight].Position.X,
                skeleton.Joints[JointType.WristRight].Position.X,
                skeleton.Joints[JointType.ElbowRight].Position.Y,
                skeleton.Joints[JointType.WristRight].Position.Y
                );
            float csuklo = Tangent(
                skeleton.Joints[JointType.WristRight].Position.X,
                skeleton.Joints[JointType.HandRight].Position.X,
                skeleton.Joints[JointType.WristRight].Position.Y,
                skeleton.Joints[JointType.HandRight].Position.Y

                );
            int nyitva = (csuklo>30 ? 1 : 0);
            /*
            Console.WriteLine("Shoulder-Elbow Angle: " + felkar + "\n");
            Console.WriteLine("Elbow-Wrist Angle: " + alkar + "\n");
            Console.WriteLine("Wrist-Hand Angle: " + csuklo + "\n");*/

            Console.WriteLine("prev_felkar: " + prev_felkar);
            Console.WriteLine("prev_alkar: " + prev_alkar + "\n");

            CreateCode(felkar - prev_felkar, alkar - prev_alkar, nyitva);
            prev_felkar = felkar;
            prev_alkar = alkar;
        }

        public void CreateCode(float felkar, float alkar, int nyitva)
        {
            string code = "";
            code += "1 " + felkar + "\n";
            code += "2 " + alkar + "\n";
            code += "3 " + nyitva + "\n";
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

}