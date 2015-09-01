﻿namespace VehiclePark.Interfaces
{
    public interface ICommandExecutor
    {
        string ExecuteCommand(ICommand command);
    }
}
