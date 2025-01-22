using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elevator_app.Interfaces;

namespace Elevator_app.Implementations
{
    internal class ConsoleInputHelper : IConsoleInputHelper
    {
        public void ProcessInput(IBuilding building)
        {
            // Await user commands then process as needed
            while (true)
            {
                Console.WriteLine("Enter starting floor, destination floor, and number of people waiting (format: starting,destination,people), type 'status' to see elevator status, or type 'exit' to quit:");
                var input = Console.ReadLine();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Enter starting floor, destination floor, and number of people waiting (format: starting,destination,people), type 'status' to see elevator status, or type 'exit' to quit:");
                }

                if (input == "exit")
                {
                    break;
                }

                if (input == "status")
                {
                    building.ShowStatus();
                    continue;
                }
                try
                {
                    var parts = input?.Split(',');
                    if (parts != null && parts.Length == 3 && int.TryParse(parts[0], out var startingFloor) && int.TryParse(parts[1], out var destinationFloor) && int.TryParse(parts[2], out var numberOfPeople))
                    {
                        building.ElevatorRequest(startingFloor, destinationFloor, numberOfPeople);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Incorrect request formatting");
                        Console.ResetColor();
                    }
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Incorrect request formatting: {ex.Message}");
                    Console.ResetColor();
                }
            }
        }

        public IBuilding InitialValues()
        {
            // Get the starting values of our building, defaults have been provided

            Console.WriteLine("Enter number of floors in the building (default 10):");
            var floors = int.TryParse(Console.ReadLine(), out var inputFloors) ? inputFloors : 10;
            Console.WriteLine($"Floors set to: {floors}");

            Console.WriteLine("Enter number of elevators (default 3):");
            var elevators = int.TryParse(Console.ReadLine(), out var inputElevators) ? inputElevators : 3;
            Console.WriteLine($"Elevators set to: {elevators}");

            Console.WriteLine("Enter maximum capacity of each elevator (default 5):");
            var capacity = int.TryParse(Console.ReadLine(), out var inputCapacity) ? inputCapacity : 5;
            Console.WriteLine($"Elevator capacity set to: {capacity}");

            return new Building(floors, elevators, capacity);
        }
    }
}
