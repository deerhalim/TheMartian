namespace TheMartian.Console.Exceptions;
using System;

public class DeviceOutOfWorkingAreaException : Exception
{
    public DeviceOutOfWorkingAreaException() : base("Device out of working area")
    {

    }
}