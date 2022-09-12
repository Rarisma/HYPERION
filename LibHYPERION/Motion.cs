using System.Net;

namespace LibHYPERION;

public class Motion
{
    /// <summary>
    /// Moves wheels, takes an X and Y values between -1.00 and 1.00
    /// Example an X Value of 1 will make the wheels turn towards the right.
    /// A Y value of 1 will make it go forward and vice versa.
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    void Move(float X, float Y)
    {
        if (X > 0.3) // Right
        {
            if (Y > 0.5) //Up Right
            {
                new WebClient().DownloadString("http://192.168.4.1/MoveFRT");
                Thread.Sleep(200);
            }
            else //Down right
            {
                new WebClient().DownloadString("http://192.168.4.1/MoveRRT");
                Thread.Sleep(200);
            }
        }
        else if (X < -0.3) //Left
        {
            if (Y > 0.5) //Up Left
            {
                new WebClient().DownloadString("http://192.168.4.1/MoveFLT");
                Thread.Sleep(200);
            }
            else
            {
                new WebClient().DownloadString("http://192.168.4.1/MoveRLT");
                Thread.Sleep(200);
            }
        }
        else
        {
            if (Y == 0) //stop moving
            {
                new WebClient().DownloadString("http://192.168.4.1/DontMove");
                Thread.Sleep(200);
            }
            else if (Y > 0.5) //move up
            {
                new WebClient().DownloadString("http://192.168.4.1/MoveFOR");
                Thread.Sleep(200);
            }
            else if (Y < -0.5)
            {
                new WebClient().DownloadString("http://192.168.4.1/MoveREV");
                Thread.Sleep(200);
            }
        }
    }
}