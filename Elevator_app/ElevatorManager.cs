using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_app
{
    public class ElevatorManager
    {
        private readonly List<Elevator> _elevators;

        public ElevatorManager(int numberOfElevators, int elevatorCapacity)
        {
            _elevators = new List<Elevator>();
            for (int i = 1; i <= numberOfElevators; i++)
            {
                _elevators.Add(new Elevator(i, elevatorCapacity));
            }
        }

        public void RequestElevator(int startingFloor, int destinationFloor, int passengers)
        {
            if (_elevators.First().Capacity < passengers)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Warning: Not enough capacity for a single elevator: {passengers} people");
                Console.ResetColor();
            }

            foreach (var elevator in _elevators.OrderBy(x => Math.Abs(x.CurrentFloor - startingFloor)))
            {
                if (passengers <= 0)
                {
                    break;
                }

                if (passengers > _elevators.Count * elevator.Capacity)
                {
                    var remainingPassengers = passengers - _elevators.Count * elevator.Capacity;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Warning: {remainingPassengers} passenger/s could not be accommodated.");
                    Console.ResetColor();
                }

                int canAccommodate = Math.Min(elevator.Capacity, passengers);

                Console.WriteLine($"Elevator {elevator.Id}: moving to floor {startingFloor} for {canAccommodate} passenger/s then moving floor to {destinationFloor}.");
                elevator.Move(startingFloor);


                elevator.AddPassengers(canAccommodate);
                passengers -= canAccommodate;
                elevator.Move(destinationFloor);
            }

            if (passengers > 0)
            {
                RequestElevator(startingFloor, destinationFloor, passengers);
            }

        }

        public List<Elevator> Status()
        {
            foreach (var elevator in _elevators)
            {
                Console.WriteLine($"Elevator {elevator.Id}: status: {elevator.Status} \n current floor: {elevator.CurrentFloor} \n capacity: {elevator.Capacity}.");
            }
            return _elevators;
        }
    }
}
