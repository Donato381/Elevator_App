using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_app.Tests
{
    [TestFixture]
    public class BuildingTests
    {
        [Test]
        public void Building_InvalidFloorRequests()
        {
            var building = new Building(10, 3, 5);

            Assert.DoesNotThrow(() => building.ElevatorRequest(-1, 5, 3));
            Assert.DoesNotThrow(() => building.ElevatorRequest(1, 11, 3));
        }

        [Test]
        public void Building_ProcessesValidRequests()
        {
            var building = new Building(10, 3, 5);

            Assert.DoesNotThrow(() => building.ElevatorRequest(0, 5, 3));
        }
    }
}
