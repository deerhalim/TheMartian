namespace TheMartian.Console.Test.BusinessTests;
using TheMartian.Console.Business;
using TheMartian.Console.BusinessAbsctraction;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;
using TheMartian.Console.Models;
using TheMartian.Console.Exceptions;

public class SpaceVehicleTests
{


    private SpaceVehicle CreateSpaceVehicle(Position position, int[] workingArea)
    {
        return new SpaceVehicle(position, workingArea);
    }

    [TestCase(Headings.E, Headings.S, Description = "Move Right From East")]
    [TestCase(Headings.S, Headings.W, Description = "Move Right From South")]
    [TestCase(Headings.W, Headings.N, Description = "Move Right From West")]
    [TestCase(Headings.N, Headings.E, Description = "Move Right From North")]
    public void TurnRightTest(Headings startHeading, Headings expectedHeading)
    {
        Position pos = new Position { Heading = startHeading };
        var vehicle = CreateSpaceVehicle(pos, new int[0]);
        vehicle.TurnRight();
        Assert.AreEqual(expectedHeading, pos.Heading);
    }

    [TestCase(Headings.E, Headings.N, Description = "Move Left From East")]
    [TestCase(Headings.N, Headings.W, Description = "Move Left From North")]
    [TestCase(Headings.W, Headings.S, Description = "Move Left From West")]
    [TestCase(Headings.S, Headings.E, Description = "Move Left From South")]
    public void TurnLeftTest(Headings startHeading, Headings expectedHeading)
    {
        Position pos = new Position { Heading = startHeading };
        var vehicle = CreateSpaceVehicle(pos, new int[0]);
        vehicle.TurnLeft();
        Assert.AreEqual(expectedHeading, pos.Heading);
    }

    [TestCase(50, 50, Headings.E, 51, 50, Description = "Move to east")]
    [TestCase(50, 50, Headings.S, 50, 49, Description = "Move to south")]
    [TestCase(50, 50, Headings.W, 49, 50, Description = "Move to west")]
    [TestCase(50, 50, Headings.N, 50, 51, Description = "Move to north")]
    public void MoveTestWithValidArguments(int coordinateX, int coordinateY, Headings heading, int expectedX, int expectedY)
    {
        Position pos = new Position
        {
            CoordinateX = coordinateX,
            CoordinateY = coordinateY,
            Heading = heading
        };
        var vehicle = CreateSpaceVehicle(pos, new int[] { 100, 100 });
        vehicle.Move();

        Assert.AreEqual(expectedX, pos.CoordinateX);
        Assert.AreEqual(expectedY, pos.CoordinateY);
    }

    [TestCase(1, 0, Headings.E, Description = "Move to east")]
    [TestCase(1, 1, Headings.N, Description = "Move to south")]
    [TestCase(0, 0, Headings.S, Description = "Move to west")]
    [TestCase(0, 1, Headings.W, Description = "Move to north")]
    public void MoveTestWithUnvalidArguments(int coordinateX, int coordinateY, Headings heading)
    {
        Position pos = new Position
        {
            CoordinateX = coordinateX,
            CoordinateY = coordinateY,
            Heading = heading
        };
        var vehicle = CreateSpaceVehicle(pos, new int[] { 1, 1 });
        Assert.Throws<DeviceOutOfWorkingAreaException>(() => vehicle.Move());
    }

}