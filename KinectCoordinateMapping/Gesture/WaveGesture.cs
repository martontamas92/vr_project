using System;
using Microsoft.Kinect;

namespace KinectCoordinateMapping.Gesture
{
  public class WaveGesture 
  {
    readonly int WINDOW_SIZE = 50;

    IGestureSegment[] segments;

    int _currentSegment = 0;
    int _frameCount = 0;

    public event EventHandler<Notes> GestureRecognized;

    public WaveGesture()
    {
      System.Diagnostics.Debug.WriteLine("WaveGesture constructor!");

      WaveGesture_Also_Do waveAlso_Left_Do = new WaveGesture_Also_Do();
      WaveGestureRe waveLeftRe = new WaveGestureRe();
      WaveGestureMi waveLeftMi = new WaveGestureMi();
      WaveGestureFa waveRightFa = new WaveGestureFa();
      WaveGesture_Felso_Do waveFelso_Do = new WaveGesture_Felso_Do();
      WaveGestureSzo waveSzo = new WaveGestureSzo();
      WaveGestureLa waveLeftLa = new WaveGestureLa();
      WaveGestureTi waveRightTi = new WaveGestureTi();

      this.segments = new IGestureSegment[]
      {
           waveAlso_Left_Do,
           waveRightFa,
           waveLeftRe,
           waveLeftMi,
           waveSzo,
           waveLeftLa,
           waveRightTi,
           waveFelso_Do,
      };
    }

    /// <summary>
    /// Updates the current gesture.
    /// </summary>
    /// <param name="skeleton">The skeleton data.</param>
    public void Update(Skeleton skeleton)
    {
      this._frameCount++;
      if(this._frameCount < 10)
      {
       return;
      }

      this._frameCount = 0;

      System.Diagnostics.Debug.WriteLine("" + this._currentSegment + " " + this._frameCount);

            /*  
        foreach (var gestureSegment in this.segments)
        {
          Notes result = gestureSegment.Update(skeleton);
          if (result != Notes.None)
          {
            GestureRecognized(this, result);
            return;
          }
        } */
            Calculate c = new Calculate();
            c.CalculatePosition(skeleton);
            
      //GestureRecognized(this, Notes.None);
    }
    
  }
}
