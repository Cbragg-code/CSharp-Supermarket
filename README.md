# CSharp-Supermarket

## Overview
This project simulates a **realistic supermarket environment** using **sorting algorithms**, **queues**, and **stacks**. Developed for **CSCI 2210 – Data Structures**, it focuses on managing customer flow, register efficiency, and dynamic customer arrivals.

## Features
- **Randomized simulation** of supermarket flow (customers, registers, items)
- **Customer lifecycle**: arrival, shopping, shortest line selection, checkout
- **Dynamic checkout lines** using **queues**
- **Shopping carts** represented by **stacks**
- **Up to 15 registers**, with a minimum of 5 per simulation
- **Statistics tracking**:
  - Total sales, customers served
  - Longest line, average, min, and max cart totals
- **Realistic pacing** with **Thread.Sleep()** delays between rounds
- **UI Updates** showing register states live during simulation

## Project Structure
- **Item Class**: Item name and price
- **Customer Class**: ID and shopping cart (stack of items)
- **Register Class**: ID, line (queue), sales, customers served
- **Supermarket Class**: Full simulation logic
- **GuiController**: UI updates via IGuiController interface

## How to Run
1. Open the solution in **Visual Studio 2022**
2. Build the project
3. Run the project to launch the simulation GUI

## Notes
- Designed for a **GUI-based simulation** with real-time updates
- Uses **sorting algorithms** and **data structures** to simulate customer behavior
- **Normal distribution** used for customer arrivals to mimic real-world scenarios

## Author
Christopher Bragg
