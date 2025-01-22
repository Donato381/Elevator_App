using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elevator_app.Implementations;

namespace Elevator_app.Tests
{
    [TestFixture]
    public class ElevatorManagerTests
    {

        [Test]
        public void Controller_AssignsNearestElevator_WhenCapacityIsSufficient()
        {
            var manager = new ElevatorManager(3, 5);

            manager.RequestElevator(0, 5, 5);

            var elevators = manager.Status();

            Assert.That(elevators[0].CurrentFloor, Is.EqualTo(5));
            Assert.That(elevators[1].CurrentFloor, Is.EqualTo(0));
            Assert.That(elevators[2].CurrentFloor, Is.EqualTo(0));
        }

        [Test]
        public void Controller_SplitsPassengers_WhenCapacityIsInsufficient()
        {
            var manager = new ElevatorManager(2, 5);
            manager.RequestElevator(0, 5, 6);

            var elevators = manager.Status();

            foreach (var elevator in elevators)
            {
                Assert.That(elevator.CurrentFloor, Is.EqualTo(5));
            }
        }
    }
}
