using System;
using System.Collections.Generic;
using System.Linq;
using Elevator_app.Implementations;

namespace Elevator_app
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();
            var input = new ConsoleInputHelper();

            // Get initail values based on user input
            var building = input.InitialValues();

            // Process user commands
            input.ProcessInput(building);
        }
    }
}
