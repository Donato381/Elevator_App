using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elevator_app.Interfaces;

namespace Elevator_app.Implementations
{
    public class Building : IBuilding
    {
        private int Floors { get; set; }
        private IElevatorManager ElevatorManager { get; set; }

        public Building(int floors = 10, int numberOfElevators = 3, int elevatorCapacity = 5)
        {
            Floors = floors;
            ElevatorManager = new ElevatorManager(numberOfElevators, elevatorCapacity);
        }

        public void ElevatorRequest(int startingFloor, int destinationFloor, int numberOfPeople)
        {
            // Validate the foor is acceptable and does not exceed building floors
            if (startingFloor < 0 || startingFloor > Floors || destinationFloor < 0 || destinationFloor > Floors)
            {
                Console.WriteLine("Invalid floor.");
                return;
            }

            ElevatorManager.RequestElevator(startingFloor, destinationFloor, numberOfPeople);
        }

        public void ShowStatus()
        {
            ElevatorManager.Status();
        }
    }
}
