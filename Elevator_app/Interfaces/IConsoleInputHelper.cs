namespace Elevator_app.Interfaces
{
    internal interface IConsoleInputHelper
    {
        Building InitialValues();
        void ProcessInput(Building building);
    }
}