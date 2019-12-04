using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using KinectCoordinateMapping.Gesture;

namespace KinectCoordinateMapping.SoundPlayer
{
  public class Playerke
  {
    private Notes lastNode;
    [DllImport("kernel32.dll")]
    public static extern bool Beep(int freq, int dur);

    public readonly static double Dol = 32;
    public readonly static double Re = 32 * Math.Pow(1.0595, 2);
    public readonly static double Mi = 32 * Math.Pow(1.0595, 4);
    public readonly static double Fa = 32 * Math.Pow(1.0595, 5);
    public readonly static double Sol = 32 * Math.Pow(1.0595, 7);
    public readonly static double La = 32 * Math.Pow(1.0595, 9);
    public readonly static double Si = 32 * Math.Pow(1.0595, 11);
    public readonly static double Dof = 32 * Math.Pow(1.0595, 12);

    int dur = 600;

    public static void AsyncBeep(int Frequence, int Duree)
    {
      Thread p;
      Beeper b = new Beeper(Frequence, Duree);
      p = new Thread(new ThreadStart(b.Beeping));
      p.Start();
    }

    private class Beeper
    {
      public int Frequence;
      public int Duree;

      public void Beeping()
      {
        Beep(this.Frequence, this.Duree);
      }

      public Beeper(int Frequence, int Duree)
      {
        this.Frequence = Frequence;
        this.Duree = Duree;
      }
    }

    public Playerke()
    {
      lastNode = Notes.None;
    }

    private void dol()
    {
       MediaPlayer plyr = new MediaPlayer();
        plyr.Open(new Uri("../../Resources/dol.wav", UriKind.Relative));
      plyr.Play();
      Thread.Sleep(300);

    }

    private void re()
    {
      MediaPlayer plyr = new MediaPlayer();
      plyr.Open(new Uri("../../Resources/re.wav", UriKind.Relative));
      plyr.Play();
      Thread.Sleep(300);

    }

    private void mi()
    {
      MediaPlayer plyr = new MediaPlayer();
      plyr.Open(new Uri("../../Resources/mi.wav", UriKind.Relative));
      plyr.Play();
   

    }

    private void fa()
    {
       MediaPlayer plyr = new MediaPlayer();
        plyr.Open(new Uri("../../Resources/fa.wav", UriKind.Relative));
      plyr.Play();


    }

    private void szol()
    {
      MediaPlayer plyr = new MediaPlayer();
      plyr.Open(new Uri("../../Resources/szol.wav", UriKind.Relative));
      plyr.Play();

    }

    private void la()
    {
      MediaPlayer plyr = new MediaPlayer();
      plyr.Open(new Uri("../../Resources/la.wav", UriKind.Relative));
      plyr.Play();


    }

    private void ti()
    {
      MediaPlayer plyr = new MediaPlayer();
      plyr.Open(new Uri("../../Resources/ti.wav", UriKind.Relative));
      plyr.Play();


    }


    private void dof()
    {
      MediaPlayer plyr = new MediaPlayer();
      plyr.Open(new Uri("../../Resources/dof.wav", UriKind.Relative));
      plyr.Play();
      Thread.Sleep(300);

    }

    public void play(Notes notes)
    {
      if (notes == lastNode)
      {
        return;
      }
      System.Diagnostics.Debug.WriteLine("" + notes);
      lastNode = notes;

      switch (notes)
      {
        case Notes.DoL:
          //dol();
          //new Thread(new ThreadStart(dol)).Start();
          // p1.Start();
          AsyncBeep((int)(Dol * Math.Pow(2, 4)), dur);
          break;
        case Notes.Re:
          //Thread p2;
          //p2 = new Thread(new ThreadStart(re));
          //p2.Start();
          AsyncBeep((int)(Re * Math.Pow(2, 4)), dur);
          break;
        case Notes.Mi:
          //Thread p3;
          //p3 = new Thread(new ThreadStart(mi));
          //p3.Start();
          AsyncBeep((int)(Mi * Math.Pow(2, 4)), dur);
          break;
        case Notes.Fa:
          //Thread p4;
          //p4 = new Thread(new ThreadStart(fa));
          //p4.Start();
          AsyncBeep((int)(Fa * Math.Pow(2, 4)), dur);
          break;
        case Notes.So:
          //Thread p5;
          //p5 = new Thread(new ThreadStart(szol));
          //p5.Start();
          AsyncBeep((int)(Sol * Math.Pow(2, 4)), dur);
          break;
        case Notes.La:
          //Thread p6;
          //p6 = new Thread(new ThreadStart(la));
          //p6.Start();
          AsyncBeep((int)(La * Math.Pow(2, 4)), dur);
          break;
        case Notes.Ti:
          //Thread p7;
          //p7 = new Thread(new ThreadStart(ti));
          //p7.Start();
          AsyncBeep((int)(Si * Math.Pow(2, 4)), dur);
          break;
        case Notes.DoF:
          //Thread p8;
          //p8 = new Thread(new ThreadStart(dof));
          //p8.Start();
          AsyncBeep((int)(Dof * Math.Pow(2, 4)), dur);
          break;
        case Notes.None:
          break;
        default:
          break;
      }
    }
  }
}
