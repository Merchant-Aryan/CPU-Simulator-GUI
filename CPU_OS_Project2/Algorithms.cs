using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpuSchedulingWinForms
{
    public static class Algorithms
    {
        public static void fcfsAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int npX2 = np * 2;

            double[] bp = new double[np]; // Burst time
            double[] wtp = new double[np]; // Waiting time
            double[] tat = new double[np]; // Turnaround time
            double[] rt = new double[np]; // Response time
            string[] output1 = new string[npX2];
            double twt = 0.0, awt; // total waiting time, average waiting time
            double ttat = 0.0, atat; // total turnaround time, average turnaround time
            double totalCompletionTime = 0.0; // For throughput
            double throughput;
            int num;

            DialogResult result = MessageBox.Show("First Come First Serve Scheduling ", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                    Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time: ",
                                                       "Burst time for P" + (num + 1),
                                                       "",
                                                       -1, -1);

                    bp[num] = Convert.ToInt64(input);
                }

                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        wtp[num] = 0;
                    }
                    else
                    {
                        wtp[num] = wtp[num - 1] + bp[num - 1];
                    }
                }

                for (num = 0; num <= np - 1; num++)
                {
                    tat[num] = wtp[num] + bp[num]; // Turnaround time
                    rt[num] = wtp[num]; // Response time (same as waiting time in FCFS)

                    twt += wtp[num];
                    ttat += tat[num];
                }

                // Optional: Show Turnaround Time and Response Time for each process
                for (num = 0; num <= np - 1; num++)
                {
                    MessageBox.Show(
                        "P" + (num + 1) + ":\n" +
                        "Burst Time = " + bp[num] + "\n" +
                        "Waiting Time = " + wtp[num] + "\n" +
                        "Turnaround Time = " + tat[num],
                        "Process Details",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else if (result == DialogResult.No)
            {
                // Form switch code if needed
            }

            awt = twt / np;
                atat = ttat / np;

                totalCompletionTime = tat[np - 1]; // last process's completion time = total time
                throughput = np / totalCompletionTime;

            // Calculate Total Busy Time
            double totalBusyTime = 0.0;
            for (int i = 0; i < np; i++)
            {
                totalBusyTime += bp[i];
            }

            // CPU Utilization
            double cpuUtilization = (totalBusyTime / totalCompletionTime) * 100;

            MessageBox.Show("Average waiting time for " + np + " processes = " + awt + " sec(s)", "Average Waiting Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show("Average turnaround time for " + np + " processes = " + atat + " sec(s)", "Average Turnaround Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show("Throughput = " + throughput + " process(es) per second", "Throughput", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show("CPU Utilization = " + cpuUtilization + " %", "CPU Utilization", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static void sjfAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int npX2 = np * 2;

            double[] bp = new double[np]; // Burst time
            double[] wtp = new double[np]; // Waiting time
            double[] tat = new double[np]; // Turnaround time
            int[] pid = new int[np]; // Process IDs
            string[] output1 = new string[npX2];
            double twt = 0.0, awt; // total waiting time, average waiting time
            double ttat = 0.0, atat; // total turnaround time, average turnaround time
            double totalCompletionTime = 0.0; // For throughput
            double throughput;
            int num;

            DialogResult result = MessageBox.Show("Shortest Job First (Non-Preemptive) Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (num = 0; num <= np - 1; num++)
                {
                    string input =
                    Microsoft.VisualBasic.Interaction.InputBox("Enter Burst time: ",
                                                       "Burst time for P" + (num + 1),
                                                       "",
                                                       -1, -1);

                    bp[num] = Convert.ToDouble(input);
                    pid[num] = num + 1; // Initialize process IDs (P1, P2, P3, ...)
                }

                for (int i = 0; i < np - 1; i++)
                {
                    for (int j = i + 1; j < np; j++)
                    {
                        if (bp[i] > bp[j])
                        {
                            double temp = bp[i];
                            bp[i] = bp[j];
                            bp[j] = temp;

                            int tempID = pid[i];
                            pid[i] = pid[j];
                            pid[j] = tempID;
                        }
                    }
                }

                for (num = 0; num <= np - 1; num++)
                {
                    if (num == 0)
                    {
                        wtp[num] = 0;
                    }
                    else
                    {
                        wtp[num] = wtp[num - 1] + bp[num - 1];
                    }
                }

                for (num = 0; num <= np - 1; num++)
                {
                    tat[num] = wtp[num] + bp[num]; 

                    twt += wtp[num];
                    ttat += tat[num];
                }

                // Show Turnaround Time and Response Time for each process
                for (num = 0; num <= np - 1; num++)
                {
                    MessageBox.Show(
                        "P" + pid[num] + ":\n" +
                        "Burst Time = " + bp[num] + "\n" +
                        "Waiting Time = " + wtp[num] + "\n" +
                        "Turnaround Time = " + tat[num],
                        "Process Details",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else if (result == DialogResult.No)
            {
                // Form switch code if needed
            }

            awt = twt / np;
            atat = ttat / np;

            totalCompletionTime = tat[np - 1]; // Last process's completion time
            throughput = np / totalCompletionTime;

            // Calculate Total Busy Time
            double totalBusyTime = 0.0;
            for (int i = 0; i < np; i++)
            {
                totalBusyTime += bp[i];
            }

            // CPU Utilization
            double cpuUtilization = (totalBusyTime / totalCompletionTime) * 100;

            MessageBox.Show("Average waiting time for " + np + " processes = " + awt + " sec(s)", "Average Waiting Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show("Average turnaround time for " + np + " processes = " + atat + " sec(s)", "Average Turnaround Time", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show("Throughput = " + throughput + " process(es) per second", "Throughput", MessageBoxButtons.OK, MessageBoxIcon.None);
            MessageBox.Show("CPU Utilization = " + cpuUtilization + " %", "CPU Utilization", MessageBoxButtons.OK, MessageBoxIcon.None);
        }

        public static void priorityAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);

            DialogResult result = MessageBox.Show("Priority Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                double[] burstTime = new double[np];
                int[] priority = new int[np];
                int[] arrivalTime = new int[np];
                bool[] isCompleted = new bool[np];

                double[] waitingTime = new double[np];
                double[] turnaroundTime = new double[np];

                double totalWaitingTime = 0, totalTurnaroundTime = 0;
                double totalBurstTime = 0;
                int currentTime = 0, completed = 0;

                // Arrival tyms
                for (int i = 0; i < np; i++)
                {
                    string inputArrival = Microsoft.VisualBasic.Interaction.InputBox($"Enter arrival time for P{i + 1}:", "Arrival Time", "", -1, -1);
                    arrivalTime[i] = Convert.ToInt32(inputArrival);
                }

                // Then ask burst times
                for (int i = 0; i < np; i++)
                {
                    string inputBurst = Microsoft.VisualBasic.Interaction.InputBox($"Enter burst time for P{i + 1}:", "Burst Time", "", -1, -1);
                    burstTime[i] = Convert.ToDouble(inputBurst);
                    totalBurstTime += burstTime[i]; // accumulate total burst time
                }

                // Then ask priorities
                for (int i = 0; i < np; i++)
                {
                    string inputPriority = Microsoft.VisualBasic.Interaction.InputBox($"Enter priority for P{i + 1} (lower number = higher priority):", "Priority", "", -1, -1);
                    priority[i] = Convert.ToInt32(inputPriority);
                }

                // Scheduling processes based on arrival time and priority
                while (completed != np)
                {
                    int idx = -1;
                    int highestPriority = int.MaxValue;

                    //Finds process with highest priority among arrived processes
                    for (int i = 0; i < np; i++)
                    {
                        if (arrivalTime[i] <= currentTime && !isCompleted[i])
                        {
                            if (priority[i] < highestPriority || (priority[i] == highestPriority && arrivalTime[i] < arrivalTime[idx]))
                            {
                                highestPriority = priority[i];
                                idx = i;
                            }
                        }
                    }

                    if (idx != -1)
                    {
                        
                        waitingTime[idx] = currentTime - arrivalTime[idx];
                        if (waitingTime[idx] < 0) waitingTime[idx] = 0; 

                        currentTime += (int)burstTime[idx];
                        turnaroundTime[idx] = waitingTime[idx] + burstTime[idx];

                        isCompleted[idx] = true;
                        completed++;

                        totalWaitingTime += waitingTime[idx];
                        totalTurnaroundTime += turnaroundTime[idx];

                        MessageBox.Show($"P{idx + 1}:\nWaiting Time = {waitingTime[idx]} sec\nTurnaround Time = {turnaroundTime[idx]} sec",
                            $"Process P{idx + 1} Metrics", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        // No process has arrived yet
                        currentTime++;
                    }
                }

                double averageWaitingTime = totalWaitingTime / np;
                double averageTurnaroundTime = totalTurnaroundTime / np;

                // Throughput = Number of Processes / Total Time Taken
                double throughput = (double)np / currentTime;

                // CPU Utilization = (Total Burst Time / Total Time Taken) * 100
                double cpuUtilization = (totalBurstTime / currentTime) * 100;

                MessageBox.Show($"Average Waiting Time (AWT): {averageWaitingTime:F2} sec", "Average Waiting Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"Average Turnaround Time (ATT): {averageTurnaroundTime:F2} sec", "Average Turnaround Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"Throughput: {throughput:F2} processes/sec", "Throughput", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"CPU Utilization: {cpuUtilization:F2} %", "CPU Utilization", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public static void roundRobinAlgorithm(string userInput)
        {
            int np = Convert.ToInt16(userInput);
            int i, counter = 0;
            double total = 0.0;
            double timeQuantum;
            double waitTime = 0, turnaroundTime = 0;
            double averageWaitTime, averageTurnaroundTime;

            // Correctly size the arrays according to np
            double[] arrivalTime = new double[np];
            double[] burstTime = new double[np];
            double[] temp = new double[np];
            int x = np;

            DialogResult result = MessageBox.Show("Round Robin Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                for (i = 0; i < np; i++)
                {
                    string arrivalInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time: ",
                                                               "Arrival time for P" + (i + 1),
                                                               "",
                                                               -1, -1);

                    arrivalTime[i] = Convert.ToDouble(arrivalInput); // Fixed: ToDouble is better for decimal times

                    string burstInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter burst time: ",
                                                               "Burst time for P" + (i + 1),
                                                               "",
                                                               -1, -1);

                    burstTime[i] = Convert.ToDouble(burstInput);

                    temp[i] = burstTime[i];
                }

                string timeQuantumInput =
                            Microsoft.VisualBasic.Interaction.InputBox("Enter time quantum: ", "Time Quantum",
                                                               "",
                                                               -1, -1);

                timeQuantum = Convert.ToDouble(timeQuantumInput);
                Helper.QuantumTime = timeQuantumInput;

                double startTime = 0;
                double endTime = 0;
                double totalIdleTime = 0;
                double lastExecutionTime = 0;

                for (total = 0, i = 0; x != 0;)
                {
                    if (temp[i] <= timeQuantum && temp[i] > 0)
                    {
                        if (arrivalTime[i] > total)
                        {
                            totalIdleTime += (arrivalTime[i] - total);
                            total = arrivalTime[i];
                        }

                        total += temp[i];
                        temp[i] = 0;
                        counter = 1;
                        endTime = total;
                    }
                    else if (temp[i] > 0)
                    {
                        if (arrivalTime[i] > total)
                        {
                            totalIdleTime += (arrivalTime[i] - total);
                            total = arrivalTime[i];
                        }

                        temp[i] -= timeQuantum;
                        total += timeQuantum;
                        endTime = total;
                    }

                    if (temp[i] == 0 && counter == 1)
                    {
                        x--;
                        MessageBox.Show("Turnaround time for Process " + (i + 1) + " : " + (total - arrivalTime[i]), "Turnaround Time", MessageBoxButtons.OK);
                        MessageBox.Show("Wait time for Process " + (i + 1) + " : " + (total - arrivalTime[i] - burstTime[i]), "Wait Time", MessageBoxButtons.OK);
                        turnaroundTime += (total - arrivalTime[i]);
                        waitTime += (total - arrivalTime[i] - burstTime[i]);
                        counter = 0;
                    }

                    // ⚡ This was your crash: accessing arrivalTime[i+1] blindly
                    // FIX:
                    if (i == np - 1)
                    {
                        i = 0;
                    }
                    else if (arrivalTime[i + 1] <= total)
                    {
                        i++;
                    }
                    else
                    {
                        i = 0;
                    }
                }

                averageWaitTime = waitTime / np;
                averageTurnaroundTime = turnaroundTime / np;

                // CPU Utilization and Throughput
                double cpuUtilization = ((endTime - totalIdleTime) * 100.0) / endTime;
                double throughput = np / endTime; // processes per second

                MessageBox.Show("Average wait time: " + averageWaitTime.ToString("F2") + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("Average turnaround time: " + averageTurnaroundTime.ToString("F2") + " sec(s)", "", MessageBoxButtons.OK);
                MessageBox.Show("CPU Utilization: " + cpuUtilization.ToString("F2") + "%", "CPU Utilization", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("Throughput: " + throughput.ToString("F2") + " processes/sec", "Throughput", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        //The SRTF algo that is preemptive, always picks the hortest remaining tym at every moment
        //Also if new process arrives with a shorter burst time than the current running one then it'll reempts
        public static void SRTFfAlgorithm(string userInput)
        {
            //To validate how many processes
            short np;
            if (!Int16.TryParse(userInput, out np))
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[] burstTime = new double[np];
            double[] remainingTime = new double[np];
            double[] waitingTime = new double[np];
            double[] turnaroundTime = new double[np];
            int[] arrivalTime = new int[np]; 
            bool[] isStarted = new bool[np];
            double[] responseTime = new double[np];

            double totalWaitingTime = 0.0, totalTurnaroundTime = 0.0, totalResponseTime = 0.0;
            int completed = 0, currentTime = 0, shortest = -1;
            double minRemaining = double.MaxValue;
            bool foundProcess = false;
            int totalIdleTime = 0;

            DialogResult result = MessageBox.Show("Shortest Remaining Time First (SRTF) Scheduling", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
            {
                //Input burst times and arrival times
                for (int i = 0; i < np; i++)
                {
                    //BT
                    string inputBurst = Microsoft.VisualBasic.Interaction.InputBox("Enter burst time for P" + (i + 1) + ": ", "Burst Time", "", -1, -1);
                    burstTime[i] = Convert.ToDouble(inputBurst);
                    remainingTime[i] = burstTime[i];

                    //AT
                    string inputArrival = Microsoft.VisualBasic.Interaction.InputBox("Enter arrival time for P" + (i + 1) + ": ", "Arrival Time", "", -1, -1);
                    arrivalTime[i] = Convert.ToInt32(inputArrival);
                }

                //As long asn not all of the processes are finished
                while (completed != np)
                {
                    minRemaining = double.MaxValue;
                    foundProcess = false;

                    // Finding the process with the shortest remaining time at current time
                    for (int i = 0; i < np; i++)
                    {
                        // Only consider processes that have arrived
                        if (arrivalTime[i] <= currentTime && remainingTime[i] > 0 && remainingTime[i] < minRemaining)
                        {
                            minRemaining = remainingTime[i];
                            shortest = i;
                            foundProcess = true;
                        }
                    }

                    //If no process is found, increment current time and idle time
                    if (!foundProcess)
                    {
                        currentTime++;
                        totalIdleTime++;
                        continue;
                    }

                    
                    remainingTime[shortest]--;

                    // If the process is finished, calculate waiting and turnaround times
                    if (remainingTime[shortest] == 0)
                    {
                        completed++;
                        int finishTime = currentTime + 1;
                        turnaroundTime[shortest] = finishTime - arrivalTime[shortest]; 
                        waitingTime[shortest] = turnaroundTime[shortest] - burstTime[shortest];

                        // Avoid negative waiting times
                        if (waitingTime[shortest] < 0)
                            waitingTime[shortest] = 0;
                    }
                    currentTime++;
                }

                // Calculate total waiting time, turnaround time, and response time
                for (int i = 0; i < np; i++)
                {
                    totalWaitingTime += waitingTime[i];
                    totalTurnaroundTime += turnaroundTime[i];
                    totalResponseTime += responseTime[i];

                    
                    MessageBox.Show($"P{i + 1}:\nWaiting Time = {waitingTime[i]} sec\nTurnaround Time = {turnaroundTime[i]} sec\nResponse Time = {responseTime[i]} sec",
                                     $"Process P{i + 1} Metrics", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                double averageWaitingTime = totalWaitingTime / np;
                double averageTurnaroundTime = totalTurnaroundTime / np;
                double averageResponseTime = totalResponseTime / np;
                double cpuUtilization = ((currentTime - totalIdleTime) * 100.0) / currentTime;
                double throughput = np / (double)currentTime; // Processes per second

                // final metrics
                MessageBox.Show($"Average Waiting Time (AWT): {averageWaitingTime:F2} sec", "Average Waiting Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"Average Turnaround Time (ATT): {averageTurnaroundTime:F2} sec", "Average Turnaround Time", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"Throughput: {throughput:F2} processes/sec", "Throughput", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"CPU Utilization: {cpuUtilization:F2}%", "CPU Utilization", MessageBoxButtons.OK, MessageBoxIcon.Information);  // <-- (Add this line)
            }
        }

        public static void HRRNAlgorithm(string userInput)
        {
            short np;
            if (!Int16.TryParse(userInput, out np))
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            char[] processName = new char[np];
            int[] arrivalTime = new int[np];
            int[] burstTime = new int[np];
            int[] waitingTime = new int[np];
            int[] turnaroundTime = new int[np];
            float[] normalizedTurnaroundTime = new float[np];
            bool[] isComplete = new bool[np];
            float[] responseRatio = new float[np];

            int totalWaitingTime = 0;
            int totalTurnaroundTime = 0;
            int totalBurstTime = 0; 

            for (int i = 0, c = 0; i < np; i++, c++)
            {
                processName[i] = (char)('A' + c);

                string arrivalInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter Arrival Time for Process {processName[i]}:", "Arrival Time", "0");
                if (!int.TryParse(arrivalInput, out arrivalTime[i]))
                {
                    MessageBox.Show("Invalid Arrival Time. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    i--; // Re-ask
                    continue;
                }

                string burstInput = Microsoft.VisualBasic.Interaction.InputBox($"Enter Burst Time for Process {processName[i]}:", "Burst Time", "1");
                if (!int.TryParse(burstInput, out burstTime[i]))
                {
                    MessageBox.Show("Invalid Burst Time. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    i--; // Re-ask
                    continue;
                }

                isComplete[i] = false;
                totalBurstTime += burstTime[i]; //Adding BT for througput and CPU utilization
            }

            // Sort processes by arrival time
            for (int i = 0; i < np - 1; i++)
            {
                for (int j = i + 1; j < np; j++)
                {
                    if (arrivalTime[i] > arrivalTime[j])
                    {
                        int temp = arrivalTime[i];
                        arrivalTime[i] = arrivalTime[j];
                        arrivalTime[j] = temp;

                        temp = burstTime[i];
                        burstTime[i] = burstTime[j];
                        burstTime[j] = temp;

                        char tempChar = processName[i];
                        processName[i] = processName[j];
                        processName[j] = tempChar;
                    }
                }
            }

            int currentTime = 0;
            int completedProcesses = 0;
            double averageWaitingTime = 0;
            double averageTurnaroundTime = 0;
            int completionTime = 0; 

            Console.WriteLine("Process\tArrival\tBurst\tWaiting\tTurnaround\tNormalized TT");

            // Schedule starts
            while (completedProcesses < np)
            {
                float highestResponseRatio = -1;
                int processId = -1;

                // Calculate response ratio and find the highest
                for (int i = 0; i < np; i++)
                {
                    if (arrivalTime[i] <= currentTime && !isComplete[i])
                    {
                        responseRatio[i] = (currentTime - arrivalTime[i] + burstTime[i]) / (float)burstTime[i];
                        if (responseRatio[i] > highestResponseRatio)
                        {
                            highestResponseRatio = responseRatio[i];
                            processId = i;
                        }
                    }
                }

                if (processId != -1)
                {
                    currentTime += burstTime[processId];
                    completionTime = currentTime; // Update completion time after each process
                    waitingTime[processId] = currentTime - arrivalTime[processId] - burstTime[processId];
                    turnaroundTime[processId] = currentTime - arrivalTime[processId];
                    normalizedTurnaroundTime[processId] = (float)turnaroundTime[processId] / burstTime[processId];
                    isComplete[processId] = true;

                    completedProcesses++;

                    totalWaitingTime += waitingTime[processId];
                    totalTurnaroundTime += turnaroundTime[processId];

                    Console.WriteLine($"{processName[processId]}\t{arrivalTime[processId]}\t{burstTime[processId]}\t" +
                                      $"{waitingTime[processId]}\t{turnaroundTime[processId]}\t{normalizedTurnaroundTime[processId]:F2}");
                }
                else
                {
                    currentTime++;
                }
            }

            averageWaitingTime = totalWaitingTime / (double)np;
            averageTurnaroundTime = totalTurnaroundTime / (double)np;

            // CPU Utilization and Throughput
            double cpuUtilization = (totalBurstTime / (double)completionTime) * 100;
            double throughput = np / (double)completionTime;

            // Build final result with individual waiting and turnaround times
            string finalResult = "";
            for (int i = 0; i < np; i++)
            {
                finalResult += $"Process {processName[i]}: Waiting Time = {waitingTime[i]} sec, Turnaround Time = {turnaroundTime[i]} sec\n";
            }

            finalResult += "\nAverage Waiting Time: " + averageWaitingTime.ToString("F2") + " sec\n";
            finalResult += "Average Turnaround Time: " + averageTurnaroundTime.ToString("F2") + " sec\n";
            finalResult += "CPU Utilization: " + cpuUtilization.ToString("F2") + " %\n";
            finalResult += "Throughput: " + throughput.ToString("F2") + " processes/sec";

            MessageBox.Show(finalResult, "HRRN Scheduling Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}