using System.Configuration;
using System.Net.Http.Headers;
using System.Drawing;
using System.Data;
using System.Data.OleDb;
using System.Net;
using System.Data.Common;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ControlAnElevator
{
    // Kyle Keene-Welch, 2101940
    // CIS116-2 Desktop Applications Development and Software Engineering
    // Assignment 1
    // Control an Elevator

    public partial class Form1 : Form
    {
        // Declares elevator status and destination variables.
        private int elevatorStatus;
        private int elevatorDestination;
        
        // Declares variables that define the dataset, database connection, db command, dataadapter and command builder. 
        private DataSet ds = new DataSet();
        private string dbConnection;
        private string dbCommand;
        private OleDbConnection conn;
        private OleDbCommand comm;
        private OleDbDataAdapter adapter;
        private OleDbCommandBuilder builder;

        // Declares background worker variable.
        private System.ComponentModel.BackgroundWorker backgroundWorker1;

        // Declares variables for animating the elevator, its states and the doors.
        private bool isIdle;
        private bool isOpening;
        private bool isClosing;
        private int door1X;
        private int door2X;
        private int doorY;
        private int doorWidth;
        private int doorHeight;

        public Form1()
        {
            // Places components on form and sets their properties.
            InitializeComponent();
        }

        // Called when the form loads.
        private void Form1_Load(object sender, EventArgs e)
        {
            // Set default status and destination to 0.
            elevatorStatus = 0;
            elevatorDestination = 0;

            // Calls method to set control panel location.
            setCtrlPLocation();

            // Enables the corresponding control panel buttons for the floor the elevator is currently on.
            btnRequest0.Enabled = false;
            btnRequest1.Enabled = true;

            // Initializing timer properties and starting timer.
            System.Windows.Forms.Timer tmr = new System.Windows.Forms.Timer();
            tmr.Interval = 100;
            tmr.Tick += new System.EventHandler(tmr_Tick);
            tmr.Start();

            // Initializing database connection, command and adapter.
            dbConnection = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"data source =../../../db/ElevatorDB.accdb";
            dbCommand = "Select * from Trips;";
            conn = new OleDbConnection(dbConnection);
            comm = new OleDbCommand(dbCommand, conn);
            adapter = new OleDbDataAdapter(comm);

            // Loading data into dataset.
            loadData();

            // Updating list with data in dataset.
            updateList();

            // Updating the status labels found on top of each elevator door.
            updateStatusLabels();

            // Initiailizes the command builder with the oleDB adapter.
            builder = new OleDbCommandBuilder(adapter);

            // Initializes the data column TripID in the dataset to increment in every new row.
            ds.Tables[0].Columns["TripID"].AutoIncrement = true;
            ds.Tables[0].Columns["TripID"].AutoIncrementSeed = 1;

            // Sets visibility of the save panel.
            panSave.Visible = false;

            // Intializes the background worker.
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();

            // Allows cancellation and the progress changed event.
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerReportsProgress = true;

            // Sets the background worker delegates to select the appropriate event handler.
            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            backgroundWorker1.ProgressChanged += bgWorker_ProgressChanged;

            // Sets the state of the animation and intializes the values for the points.
            isIdle = true;
            isOpening = false;
            isClosing = false;
            door1X = 214;
            door2X = 282;
            doorY = 55;
            doorWidth = 68;
            doorHeight = 121;

            // Sets the panel paint delegates to select the appropriate event handler.
            pan0.Paint += new PaintEventHandler(pan0_paint);
            pan1.Paint += new PaintEventHandler(pan1_paint);
        }


        // Mouse Enter and Leave Event Handlers. Passes related control to hover function. ~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void btnSave_MouseEnter(object sender, EventArgs e) { colourOnHover(btnSave); }
        private void btnLoad_MouseEnter(object sender, EventArgs e) { colourOnHover(btnLoad); }
        private void btnClear_MouseEnter(object sender, EventArgs e) { colourOnHover(btnClear); }
        private void btnClose_MouseEnter(object sender, EventArgs e) { colourOnHover(btnClose); }
        private void btnDelete_MouseEnter(object sender, EventArgs e) { colourOnHover(btnDelete); }

        private void btnSave_MouseLeave(object sender, EventArgs e) { colourOnHover(btnSave); }
        private void btnLoad_MouseLeave(object sender, EventArgs e) { colourOnHover(btnLoad); }
        private void btnClear_MouseLeave(object sender, EventArgs e) { colourOnHover(btnClear); }
        private void btnClose_MouseLeave(object sender, EventArgs e) { colourOnHover(btnClose); }
        private void btnDelete_MouseLeave(object sender, EventArgs e) { colourOnHover(btnDelete); }

        // Called only when user cursor enters and leaves control.
        private void colourOnHover(Control control)
        {
            // If the colour is already gray, make it white, otherwise gray.
            if (control.BackColor == Color.DarkGray)
            {
                control.BackColor = Color.White;
            }
            else
            {
                control.BackColor = Color.DarkGray;
            }
        }

        // Request and Floor Buttons ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Called when the user clicks on a request or floor button on the control panel. Passes the appropriate floor destination to the move elevator method.
        private void btnRequest0_Click(object sender, EventArgs e)
        {
            moveElevator(0);
        }

        private void btnRequest1_Click(object sender, EventArgs e)
        {
            moveElevator(1);
        }

        private void btnFloor0_Click(object sender, EventArgs e)
        {
            moveElevator(0);
        }

        private void btnFloor1_Click(object sender, EventArgs e)
        {
            moveElevator(1);
        }

        // Form Buttons ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Calls background worker function checking if it is busy.
            bgWorker_IsBusy();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            // Clears the dataset then loads the dataset from the database then updates the list.
            ds.Clear();
            loadData();
            updateList();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Clears the items in the listbox.
            lstEvents.Items.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // Saves to database without asynchronous operation otherwise would close before save.
            saveToDb();
            // Clears system resources used in connection to database.
            conn.Dispose();
            // Closes application.
            Application.Exit();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // If the selected item exists in appropriate boundary.
            if (lstEvents.SelectedIndex > -1)
            {
                // Delete selected index from dataset and remove from list.
                ds.Tables[0].Rows[lstEvents.SelectedIndex].Delete();
                lstEvents.Items.RemoveAt(lstEvents.SelectedIndex);
            }
        }
        
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Provides centralised base for elevator move operations.
        private void moveElevator(int destination)
        {
            // If the floor the elevator is currently on is the same as destination.
            if (checkFloor(destination) == true)
            {
                // Leave method.
                return;
            }

            // Add the trip and its destination as new row in dataset.
            addTrip(destination);

            // Sets the animation state so that it is expected to open in next tick event.
            isIdle = false;
            isOpening = true;

            // Set the destination variable as the required destination.
            elevatorDestination = destination;

            // Depending on destination, enable and disable appropriate request buttons.
            switch (destination)
            {
                case 0:
                    btnRequest0.Enabled = false;
                    btnRequest1.Enabled = true;
                    break;
                case 1:
                    btnRequest1.Enabled = false;
                    btnRequest0.Enabled = true;
                    break;
            }

            // Update list after trip was added to dataset.
            updateList();
        }

        private bool checkFloor(int floor)
        {
            // If elevator status is the same as the provided floor.
            if (elevatorStatus == floor)
            {
                // Provide message box explaining elevator already at floor.
                MessageBox.Show("Elevator already at floor", "Error", MessageBoxButtons.OK);
                // Return that this is true.
                return true;
            }
            // Otherwise false.
            return false;
        }

        private void updateList()
        {
            // Clears the current list.
            lstEvents.Items.Clear();
            
            // For each row in the dataset, add the row to the list.
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                lstEvents.Items.Add(row["TripID"] + " " + row["CurrentDate"] + " " + row["StartingFloor"] + "  -> " + row["FinishingFloor"]);
            }
        }

        private void loadData()
        {
            // Try to load data to the dataset.
            try
            {
                adapter.Fill(ds);
            }
            catch (Exception ex)
            {
                // If exception occurs, show exception in message box.
                MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK);
            }
        }

        private void addTrip(int finFloor)
        {
            // Defines a new datarow in the dataset and assign the appropriate values to the fields.
            DataRow newRow = ds.Tables[0].NewRow();
            newRow["CurrentDate"] = DateTime.Now;
            newRow["StartingFloor"] = elevatorStatus;
            newRow["FinishingFloor"] = finFloor;

            // Add the new row to the dataset.
            ds.Tables[0].Rows.Add(newRow);
        }

        private void updateStatusLabels()
        {
            //Update status labels with the current elevator status.
            lblStatus0.Text = elevatorStatus.ToString();
            lblStatus1.Text = elevatorStatus.ToString();
        }

        private void setCtrlPLocation()
        {
            // Set location relative to elevator position. 
            switch (elevatorStatus)
            {
                case 0:
                    panCtrl.Location = new Point(200, 360);
                    btnFloor0.Enabled = false;
                    btnFloor1.Enabled = true;
                    break;
                case 1:
                    panCtrl.Location = new Point(200, 110);
                    btnFloor0.Enabled = true;
                    btnFloor1.Enabled = false;
                    break;

            }
            // Sets the control panel as visible and brings to front in z order.
            panCtrl.BringToFront();
            panCtrl.Visible = true;
        }

        private void saveToDb()
        {
            // If there are rows in the dataset.
            if (ds.Tables[0].Rows.Count != 0)
            {
                // Try to push changes.
                try
                {
                    // Get the changes and use the update method to generate the required sql commands to implement the retrieved changes.
                    DataSet dataSetChanges = ds.GetChanges();
                    adapter.Update(dataSetChanges);
                    // Commit the changes to the database.
                    ds.Tables[0].AcceptChanges();
                }
                catch (Exception ex)
                {
                    // If exception occurs, display exception in message box.
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                }
            }
        }

        // Elevator Animation ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Timer tick event handler.
        private void tmr_Tick(Object sender, EventArgs e)
        {
            // If the elevator is not idle.
            if (!isIdle)
            {
                // If the elevator is on floor zero refresh the bottom panel, otherwise, refresh the top panel.
                if (elevatorStatus == 0)
                {
                    pan0.Refresh();
                }
                else
                {
                    pan1.Refresh();
                }
            }
        }

        // Panel paint event handlers.
        private void pan0_paint(object sender, PaintEventArgs e)
        {
            // If the elevator is idle, draw the elevator doors once.
            if (isIdle)
            {
                elevatorDoors(pan0);
            }
            // Else if the elevator is opening, open the doors of the floor the elevator is opening on.
            else if (isOpening)
            {
                openDoors(pan0);
            }
            // Else if the elevator is closing, close the doors of the floor the elevator is closing on.
            else if (isClosing)
            {
                closeDoors(pan0);
            }
        }

        private void pan1_paint(object sender, PaintEventArgs e)
        {
            // If the elevator is idle, draw the elevator doors once.
            if (isIdle)
            {
                elevatorDoors(pan1);
            }
            // Else if the elevator is opening, open the doors of the floor the elevator is opening on.
            else if (isOpening)
            {
                openDoors(pan1);
            }
            // Else if the elevator is closing, close the doors of the floor the elevator is closing on.
            else if (isClosing)
            {
                closeDoors(pan1);
            }
        }

        // Pauses the elevator to emulate certain pause points in the process.
        private void elevatorPause()
        {
            // Set the elevator as idle and draw the doors once, sleep, then set is as not idle.
            isIdle = true;
            elevatorDoors(pan0);
            elevatorDoors(pan1);
            Thread.Sleep(3000);
            isIdle = false;
        }

        // Opens the doors of the passed panel.
        private void openDoors(Panel pan)
        {
            // If the width of the doors are not 0.
            if (doorWidth != 0)
            {
                // Decrease by two every refresh. Second door move to right as width decreases. Draw doors.
                doorWidth -= 2;
                door2X += 2;
                elevatorDoors(pan);
            }
            else
            {
                // Set is no longer opening. Pause the elevator to emulate getting in/out then set as closing.
                isOpening = false;
                elevatorPause();
                isClosing = true;
            }
        }

        // Closes the doors of the passed panel.
        private void closeDoors(Panel pan)
        {
            // If the width of the doors are not 68.
            if (doorWidth != 68)
            {
                //Increase by two every refresh. Second door move to left as width increases. Draw doors.
                doorWidth += 2;
                door2X -= 2;
                elevatorDoors(pan);
            }
            else
            {
                // Reset door values. Set as no longer closing.
                door1X = 214;
                door2X = 282;
                doorY = 55;
                doorWidth = 68;
                doorHeight = 121;
                isClosing = false;

                // If the elevator is not on destination floor. Will not loop if already as destination.
                if (elevatorStatus != elevatorDestination)
                {
                    // Pause to emulate travel distance. Set status as destination. Update the status labels and panel. Then loop by setting opening as true.
                    elevatorPause();
                    elevatorStatus = elevatorDestination;
                    updateStatusLabels();
                    setCtrlPLocation();
                    isOpening = true;
                }
                else
                {
                    // If no need to loop, set as idle.
                    isIdle = true;
                }
            }
        }

        // Draws the doors of the passed panel by updated values.
        private void elevatorDoors(Panel pan)
        {
            // Creates new graphics, pen and brush and creates rectangles with their fill of current values. Is updated upon each refresh of the timer.
            Graphics graphics;
            graphics = pan.CreateGraphics();
            Pen blackPen = new Pen(Color.Black, 2);
            SolidBrush grayBrush = new SolidBrush(Color.Gray);
            graphics.FillRectangle(grayBrush, door1X, doorY, doorWidth, doorHeight);
            graphics.FillRectangle(grayBrush, door2X, doorY, doorWidth, doorHeight);
            graphics.DrawRectangle(blackPen, door1X, doorY, doorWidth, doorHeight);
            graphics.DrawRectangle(blackPen, door2X, doorY, doorWidth, doorHeight);
        }

        // Background Worker ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        // Checks to see if bg worker is busy and runs if not.
        private void bgWorker_IsBusy()
        {
            // If background worker is not busy.
            if (!backgroundWorker1.IsBusy)
            {
                // Set the save progress to zero, show save panel and run background worker.
                prgSaveProgress.Value = 0;
                panSave.Visible = true;
                backgroundWorker1.RunWorkerAsync(10);
            }
            else
            {
                // Set cancellation on background worker operation.
                backgroundWorker1.CancelAsync();
            }
        }

        // Called when the background worker is set to perform asynchronous operation.
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Declares arg and percentage and initializes arg with the value of the asynchronous operation.
            BackgroundWorker helperBW = sender as BackgroundWorker;
            int arg = (int)e.Argument;
            int percentage;
            
            // Declares anychanges and initializes with bool that shows whether there are any changes to dataset.
            bool anyChanges = ds.GetChanges() != null;

            // If there are changes.
            if (anyChanges)
            {
                // Show message box with saving message and ok, cancel buttons. Save as result.
                DialogResult result = MessageBox.Show("Saving. Please do not close or remove power from your system.", "Saving", MessageBoxButtons.OKCancel);

                // If result was cancel.
                if (result == DialogResult.Cancel)
                {
                    // Cancellation set.
                    backgroundWorker1.CancelAsync();
                }

                // Perform save to database.
                saveToDb();

                // Loops until i becomes arg.
                for (int i = 0; i < arg; i++)
                {
                    // Thread sleeps for a short amount of time, then updates the percentage value and passes it to reportProgress of the background worker. (ProgressChanged).
                    Thread.Sleep(100);
                    percentage = (i + 1) * 100 / arg;
                    helperBW.ReportProgress(percentage);

                    // If background worker is set to cancel.
                    if (helperBW.CancellationPending)
                    {
                        // Set operation to cancel and provide result.
                        e.Cancel = true;
                        e.Result = i;
                        break;
                    }
                }
                // Set result as arg as operation succeeded.
                e.Result = arg;
            }
            else
            {
                // Provide message box explaining how their are no changes to save.
                MessageBox.Show("There have been no changes to save", "Error", MessageBoxButtons.OK);
            }
        }

        // Called when reportProgress is passed a value.
        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Updates the value of the save progress bar to progress percentage.
            prgSaveProgress.Value = e.ProgressPercentage;
        }

        // Called when background worker has finished.
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // If operation was cancelled.
            if (e.Cancelled)
            {
                // Show message box saying that it was cancelled.
                MessageBox.Show("Save cancelled", "Cancel", MessageBoxButtons.OK);
            }
            // Else if operation had an error.
            else if (e.Error != null)
            {
                // Show error in message box.
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK);
            }
            // Else if operation result is not null.
            else if (e.Result != null)
            {
                // Show save complete in message box.
                MessageBox.Show("Save Complete", "Complete", MessageBoxButtons.OK);
            }
            // Return save panel as no longer visible.
            panSave.Visible = false;
        }
    }
}