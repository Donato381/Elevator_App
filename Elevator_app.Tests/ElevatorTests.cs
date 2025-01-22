using System;
using Elevator_app;
using Elevator_app.Implementations;

namespace Elevator_app.Tests
{
    [TestFixture]
    public class ElevatorTests
    {
        [Test]
        public void Elevator_AddPassenger_CapacityNotExceeded()
        {
            var elevator = new Elevator(1, 5);

            bool result = elevator.AddPassengers(3);

            Assert.IsTrue(result);
            Assert.That(elevator.Passengers, Is.EqualTo(3));
        }

        [Test]
        public void Elevator_AddPassenger_CapacityExceeded()
        {
            var elevator = new Elevator(1, 5);

            bool result = elevator.AddPassengers(6);

            Assert.IsFalse(result);
        }

        [Test]
        public void Elevator_MovesToCorrectFloor()
        {
            var elevator = new Elevator(1, 5);

            elevator.Move(3);

            Assert.That(elevator.CurrentFloor, Is.EqualTo(3));
        }

        [Test]
        public void Elevator_PassengerResetAtFloor()
        {
            var elevator = new Elevator(1, 5);

            bool result = elevator.AddPassengers(6);

            elevator.Move(3);

            Assert.That(elevator.Capacity, Is.EqualTo(5));
            Assert.That(elevator.Passengers, Is.EqualTo(0));
        }
    }
}