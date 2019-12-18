using System;
using Microsoft.Kinect;

namespace KinectCoordinateMapping.Gesture
{
  public class WaveGesture 
  {
    readonly int WINDOW_SIZE = 50;

    int _frameCount = 0;

    float prev_felkar = 0;
    float prev_alkar = 0;

        public event EventHandler<Notes> GestureRecognized;

    public void Update(Skeleton skeleton)
    {
      this._frameCount++;
      if(this._frameCount < 50)
      {
       return;
      }

      this._frameCount = 0;

            Calculate c = new Calculate();
            c.CalculatePosition(skeleton, ref prev_felkar, ref prev_alkar);
            
    }
    
  }
}
