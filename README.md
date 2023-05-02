# ControlAnElevator
## Summary
This project uses `C#` and the popular `.NET framework` by Microsoft to simulate the actions and animation of an elevator. 

Using an `event driven approach`, a user will interact with a provided graphical user interface and will select the appropriate floor the elevator should go to. The program will respond through the various assigned delegates and event handlers to open and close the elevator doors, change the floor indicators, display the control panel and display the elevator "log". Trips are stored within a `MSAccess database` and is accessed and updated using the command builder in the `Entity Framework`. Other great features include asynchronous operations using `background worker` and the use of the `disconnected database model`.

## Features
- **MSAccess Database Connectivity** - Application instantiates and populates an MSAccess database and uses related Entity Framework functions to update and get changes to the data and database schema so they are concurrent.

- **Disconnected Model** - Application uses a local dataset that it changes in accordance to the input from the user. This dataset is pushed forward and a commit to the database is made when the user chooses to "save" from the save button instead of making a commit after each action. This saves server processing time and reduces unnecessary overhead. 

- **Asynchronous Operations** - Utilizing background worker service to run select operations on a separate thread. Allows user to continue to move the elevator between floors all while saving or loading the log asynchronously.

- **Command Builder** - Abstracts redundant command building processes through the use of OleDB Command Builder. More focus is on application logic rather than connectivity and commands to the database.

- **Paint Tools and Timer** - Uses a timer that periodically checks the condition of the elevator and refreshes the drawings of the doors in correspondance to the current condition. Creates the "animation" effect through the redrawing of elevator doors in the correct location per frame.
