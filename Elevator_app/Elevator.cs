using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elevator_app.Enums;

namespace Elevator_app
{
    public class Elevator
    {
        public int Id { get; }
        public int CurrentFloor { get; private set; } = 0;
        public int Capacity { get; }
        public int Passengers { get; set; } = 0;
        public ElevatorStatus Status { get; set; }

        public Elevator(int id, int capacity)
        {
            Id = id;
            this.Capacity = capacity;
            Passengers = 0;
            Status = ElevatorStatus.AVAILABLE;
        }

        public void Move(int floor)
        {
            // Set the status based on whether we are going up or down
            Status = CurrentFloor < floor ? ElevatorStatus.MOVING_UP : ElevatorStatus.MOVING_DOWN;           
            
            Console.WriteLine($"Elevator {Id}: {Status.ToString()} from: {CurrentFloor} to: {floor}.");
            CurrentFloor = floor; // set the current floor of the elevator 
            ClearElevator(); // Empty the elevator of passengers
        }

        public bool AddPassengers(int passengers)
        {
            // Ensure there is enough capacity
            if(passengers > Capacity)
                return false;
            else
            {
                Passengers = passengers;
                return true;
            }
            
        }

        private void ClearElevator()
        {
            // If the elevator moved floor without anyone onbaord we dont need to output a message about passengers leaving
            if (Passengers > 0)
            {
                Console.WriteLine($"Elevator {Id}: {Passengers} passenger/s leave at: {CurrentFloor}.");
                Console.WriteLine($"Elevator {Id}: is now on floor {CurrentFloor}");
            }
            Passengers = 0; // Assume all passengers are getting off

            Status = ElevatorStatus.AVAILABLE; // Reset the current status to available
        }
    }
}
