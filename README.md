# Running the elevator application:
Upon running the Elevator application you will be prompted to enter 3 values:
* The Buildings number of floors (default set to 10)
* The number of elevators within the building (default set to 3)
* Maximum elevator capacity (default set to 5)

Once the custom or default values have been defined you will then be promted to either:
* Request an elevator
* View the status of all the elevators

# Request an elevator:
To request an elevator you need to provide the following information:
* The starting floor (Where the request was made)
* The destination floor (Where the elevator should move to)
* The number of people currently waiting for an elevator

This information must be parsed in the following comma delimited format: starting floor, destination floor, number of people IE: 0, 3, 5 <br>
This will request an elevator on floor 0 to take 5 people to floor 3

# Exceeding the capacity:
Requesting an elevator for too many passengers will result in multiple elevators being sent to the requested floor
* In this example requesting an elevator (of capacity 5) for 6 people will result in 2 elevators being sent
* In this example requesting an elevator (of capacity 5) for 16 people will result in all 3 elevators being sent and the first elevator returning to pickup the final passanger. 

In this way the elevators will continue to move from selected floor to destination floor until the final passenger has been accounted for.

# Checking the elevator status:
You can check the current status of all elevators by typing 'status' into the console. <br>
This will output the current floor and availability of all the elevators in the building: <br>

```
Elevator 1: status: AVAILABLE
 current floor: 5
 capacity: 5.
Elevator 2: status: AVAILABLE
 current floor: 3
 capacity: 5.
Elevator 3: status: AVAILABLE
 current floor: 0
 capacity: 5.
 ```

