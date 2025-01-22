namespace Elevator_app.Interfaces
{
    public interface IElevatorManager
    {
        void RequestElevator(int startingFloor, int destinationFloor, int passengers);
        List<IElevator> Status();
    }
}