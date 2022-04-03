using System;
using TheMartian.Console.BusinessAbsctraction;
using TheMartian.Console.Business;
using TheMartian.Console.Models;
using TheMartian.Console.Exceptions;

Console.Write("Type matrix range: ");
string input = Console.ReadLine();
string[] matrixInput = input.Split(" ");
int[] matrix = new int[] { int.Parse(matrixInput[0]), int.Parse(matrixInput[1]) };


do
{
    try
    {
        Console.Write("Type position: ");
        string[] positionInput = Console.ReadLine().Split(" ");
        Position position = new Position { CoordinateX = int.Parse(positionInput[0]), CoordinateY = int.Parse(positionInput[1]), Heading = (Headings)Enum.Parse(typeof(Headings), positionInput[2]) };

        SpaceVehicle spaceVehicle = new SpaceVehicle(position, matrix);

        Console.Write("Type moves: ");
        positionInput = Console.ReadLine().Split(" ");
        char[] moves = positionInput[0].ToCharArray();

        RemoteController remoteController = new RemoteController();
        remoteController.SendSignal(spaceVehicle, moves);
        Console.WriteLine(position.ToString());
    }
    catch (DeviceOutOfWorkingAreaException ex)
    {
        Console.WriteLine("The device is out of working area");
    }
} while (true);