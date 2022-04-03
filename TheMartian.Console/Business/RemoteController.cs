namespace TheMartian.Console.Business;
using TheMartian.Console.BusinessAbsctraction;
using TheMartian.Console.Models;
public class RemoteController
{
    public void SendSignal(ISpaceVehicle rover, char[] moves)
    {
        foreach (char m in moves)
        {
            switch (m)
            {
                case 'L':
                    rover.TurnLeft();
                    break;
                case 'R':
                    rover.TurnRight();
                    break;
                case 'M':
                    rover.Move();
                    break;
            }
        }
    }
}