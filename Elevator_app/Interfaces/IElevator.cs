using Elevator_app.Enums;

namespace Elevator_app.Interfaces
{
    public interface IElevator
    {
        int Capacity { get; }
        int CurrentFloor { get; }
        int Id { get; }
        int Passengers { get; set; }
        ElevatorStatus Status { get; set; }

        bool AddPassengers(int passengers);
        void Move(int floor);
    }
}