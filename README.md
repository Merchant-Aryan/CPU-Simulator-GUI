# CPU Scheduling Algorithms Simulator (C# GUI)

A Windows Forms application that visually simulates various CPU scheduling algorithms.

---

## Features

- User-friendly graphical interface
- Supports multiple scheduling algorithms:
  - First-Come First-Served (FCFS)
  - Shortest Job First (SJF)
  - Shortest Remaining Time First (SRTF)
  - Priority Scheduling 
  - Round Robin (RR)
  - Highest Response Ratio Next (HRRT)

- Input custom processes with burst time, arrival time, and priority(if needed)
- Step-by-step visualization of scheduling
- Average waiting time and turnaround time calculations for each process

---

## Prerequisites

- Windows Operating System
- .NET Framework
- Visual Studio (recommended)

---

## Installation

1. Clone the repository:
   ```bash
   git clone https://github.com/Stat1c-Null/CPU-Scheduler-GUI.git

2. Open the solution file CPU-Scheduler-GUI.sln in Visual Studio.

3. Build and run the solution.


## Usage

1. Enter the number of processes

2. Enter process details:

	- Process ID
	- Arrival Time
	- Burst Time
	- Priority (if needed)
	- Select a scheduling algorithm
	- Click Run to simulate
	- View the AWT, ATT, CPU utilization, throughput, 	  and more