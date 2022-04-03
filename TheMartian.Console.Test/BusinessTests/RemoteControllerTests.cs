namespace TheMartian.Console.Test.BusinessTests;
using TheMartian.Console.Business;
using TheMartian.Console.BusinessAbsctraction;
using NUnit.Framework;
using Moq;
using System.Collections.Generic;


public class RemoteControllerTests
{

    private RemoteController remoteController;

    private Mock<ISpaceVehicle> mockSpaceVehicle;

    [SetUp]
    public void SetUp()
    {
        mockSpaceVehicle = new Mock<ISpaceVehicle>();
        remoteController = new RemoteController();
    }

    [TestCase("LMLMMMMM", "TurnLeft,Move,TurnLeft,Move,Move,Move,Move,Move")]
    [TestCase("LRRMLMRMLMRRRM", "TurnLeft,TurnRight,TurnRight,Move,TurnLeft,Move,TurnRight,Move,TurnLeft,Move,TurnRight,TurnRight,TurnRight,Move")]
    [TestCase("MMRMMRMRRM", "Move,Move,TurnRight,Move,Move,TurnRight,Move,TurnRight,TurnRight,Move")]
    [TestCase("RRRRRRMMLMLM", "TurnRight,TurnRight,TurnRight,TurnRight,TurnRight,TurnRight,Move,Move,TurnLeft,Move,TurnLeft,Move")]
    public void SendSignalTests(string inputs, string expectedCalls)
    {
        List<string> calls = new List<string>();
        mockSpaceVehicle.Setup(x => x.Move()).Callback(() =>
        {
            calls.Add("Move");
        }).Verifiable();

        mockSpaceVehicle.Setup(x => x.TurnLeft()).Callback(() =>
        {
            calls.Add("TurnLeft");
        }).Verifiable();

        mockSpaceVehicle.Setup(x => x.TurnRight()).Callback(() =>
        {
            calls.Add("TurnRight");
        }).Verifiable();

        remoteController.SendSignal(mockSpaceVehicle.Object, inputs.ToCharArray());

        Assert.AreEqual(expectedCalls, string.Join(",", calls));
    }



}