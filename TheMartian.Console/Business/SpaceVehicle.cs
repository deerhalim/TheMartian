namespace TheMartian.Console.Business;
using TheMartian.Console.BusinessAbsctraction;
using TheMartian.Console.Models;
using TheMartian.Console.Exceptions;
public class SpaceVehicle : ISpaceVehicle
{
    private Position Position { get; set; }
    private int[] WorkingArea { get; set; }
    private int HeadingCalculater { get; set; }

    public SpaceVehicle(Position position, int[] workingArea)
    {
        this.Position = position;
        this.WorkingArea = workingArea;
        this.HeadingCalculater = (int)position.Heading;
    }

    public void Move()
    {

        switch (Position.Heading)
        {
            case Headings.N:
                ValidateMovement(WorkingArea[0], Position.CoordinateY, 1);
                Position.CoordinateY++;
                break;
            case Headings.E:
                ValidateMovement(WorkingArea[1], Position.CoordinateX, 1);
                Position.CoordinateX++;
                break;
            case Headings.S:
                ValidateMovement(WorkingArea[0], Position.CoordinateY, -1);
                Position.CoordinateY--;
                break;
            case Headings.W:
                ValidateMovement(WorkingArea[1], Position.CoordinateX, -1);
                Position.CoordinateX--;
                break;
        }
    }

    public void TurnRight()
    {
        HeadingCalculater++;
        if (HeadingCalculater == 4)
        {
            HeadingCalculater = 0;
        }

        Position.Heading = (Headings)HeadingCalculater;
        //Position.Heading = (Headings)(HeadingCalculater % 4);
    }

    public void TurnLeft()
    {
        HeadingCalculater--;
        if (HeadingCalculater == -1)
        {
            HeadingCalculater = 3;
        }

        Position.Heading = (Headings)HeadingCalculater;
        //Position.Heading = (Headings)(Math.Abs(4 - Math.Abs((int)HeadingCalculater)) % 4);
    }

    private void ValidateMovement(int areaBorder, int position, int direction)
    {
        int newPoint = position + direction;
        bool isNegative = newPoint * -1 > 0;

        if ((isNegative && newPoint < areaBorder) || (!isNegative && newPoint > areaBorder))
        {
            throw new DeviceOutOfWorkingAreaException();
        }
    }
}
