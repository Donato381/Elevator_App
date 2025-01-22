using Elevator_app.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_app.Implementations
{
    public class ElevatorManager : IElevatorManager
    {
        private readonly List<IElevator> _elevators;

        public ElevatorManager(int numberOfElevators, int elevatorCapacity)
        {
            _elevators = new List<IElevator>();
            for (int i = 1; i <= numberOfElevators; i++)
            {
                _elevators.Add(new Elevator(i, elevatorCapacity));
            }
        }

        public void RequestElevator(int startingFloor, int destinationFloor, int passengers)
        {
            // Confirm there is enough available capacity, if not send a warning
            if (_elevators.First().Capacity < passengers)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Warning: Not enough capacity for a single elevator: {passengers} people");
                Console.ResetColor();
            }

            // Get closest elevator using the Math.Abs to ensure negative differences do not affect the closest elevator
            foreach (var elevator in _elevators.OrderBy(x => Math.Abs(x.CurrentFloor - startingFloor)))
            {
                // Completed and no more passengers remain
                if (passengers <= 0)
                {
                    break;
                }

                // More passengers than the current elevator can handle
                if (passengers > _elevators.Count * elevator.Capacity)
                {
                    var remainingPassengers = passengers - _elevators.Count * elevator.Capacity; // Remove accomodated passengers from the current passenger pool

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Warning: {remainingPassengers} passenger/s could not be accommodated.");
                    Console.ResetColor();
                }

                // set the current Accommodation to the smallest value. Either the number of passengers or the capacity of the elevator
                int canAccommodate = Math.Min(elevator.Capacity, passengers);

                Console.WriteLine($"Elevator {elevator.Id}: moving to floor {startingFloor} for {canAccommodate} passenger/s then moving floor to {destinationFloor}.");
                elevator.Move(startingFloor);

                // Add passengers to the elevator
                elevator.AddPassengers(canAccommodate);
                passengers -= canAccommodate; // Reduce the number of passengers waiting by the number aboard the elevator
                elevator.Move(destinationFloor); // Move the elevator to the requested floor
            }

            // if at the end of the list of available elevators we still have passengers waiting send the next closest available elevator to complete the job
            if (passengers > 0)
            {
                RequestElevator(startingFloor, destinationFloor, passengers);
            }

        }

        public List<IElevator> Status()
        {
            // Output the current status of the elevators
            foreach (var elevator in _elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id}: status: {elevator.Status} \n current floor: {elevator.CurrentFloor} \n capacity: {elevator.Capacity}.");
            }
            return _elevators;
        }
    }
}
