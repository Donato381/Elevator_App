using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_app
{
    public class Building
    {
        private int Floors { get; set; }
        private ElevatorManager ElevatorManager { get; set; }

        public Building(int floors = 10, int numberOfElevators = 3, int elevatorCapacity = 5)
        {
            Floors = floors;
            ElevatorManager = new ElevatorManager(numberOfElevators, elevatorCapacity);
        }

        public void ElevatorRequest(int startingFloor, int destinationFloor, int numberOfPeople)
        {
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
