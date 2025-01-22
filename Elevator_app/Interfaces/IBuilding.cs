namespace Elevator_app.Interfaces
{
    public interface IBuilding
    {
        void ElevatorRequest(int startingFloor, int destinationFloor, int numberOfPeople);
        void ShowStatus();
    }
}