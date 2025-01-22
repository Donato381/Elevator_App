namespace Elevator_app.Interfaces
{
    internal interface IConsoleInputHelper
    {
        IBuilding InitialValues();
        void ProcessInput(IBuilding building);
    }
}