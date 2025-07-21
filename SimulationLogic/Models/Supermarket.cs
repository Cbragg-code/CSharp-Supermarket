///////////////////////////////////////////////////////////////////////////////
//
//  Author: Christopher Bragg, braggc1@etsu.edu
//  Course: CSCI-2210-001 - Data Structures
//  Assignment: Project 4
//  Description: The entire supermarket, where everything is ran to simulate the supermarket 
//  
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimulationLogic
{
    public class Supermarket : ISupermarket
    {
        internal List<Register> Registers = new List<Register>(15);
        internal int longestLine = 0;
        internal int customersArrived = 0;
        internal int customersServed = 0;
        internal double totalSales = 0;
        internal double averageCustomerTotal = 0;
        internal double miniumCustomerTotal = 0;
        internal double maximumCustomerTotal = 0;
        Random random = new Random();
        
        /// <summary>
        /// method that runs the simulation and implements other methods to do so
        /// </summary>
        public void Run()
        {
            int randRegistersOpened = random.Next(5, 15);
            int randCustomers = random.Next(50, 500);
            
            //creating 15 new registers 
            for (int i = 0; i < 15; i++)
            {
                Register reg = new Register(i+1);
                Registers.Add(reg);
            }
            //loop to run the necessary processes for every customer in the supermarket
            while (customersServed < randCustomers)
            {
                if (customersArrived < randCustomers && CustomerArrival(randCustomers, random.NextDouble() * 1.125))
                {
                    Customer customer = new Customer(customersArrived + 1);
                    //updating the number of customers who have arrived
                    customersArrived++;
                    
                    AddItem(customer);
                    Register reg = ShortestLine(randRegistersOpened);
                    reg.JoinLine(customer);

                    //gets the customer IDs and adds them to a list of customer IDs
                    reg.CustIDs.Add($"{customer.ID}");
                    
                    //updating the statistic for longest queue of customers 
                    longestLine = LongestLine();
                }
                CheckoutCustomer();
                
                Thread.Sleep(100); 
            }
        }
        /// <summary>
        /// method that determins the rate at which customers arrive 
        /// </summary>
        /// <param name="randCustomers">the random number of customers that are to be distributed</param>
        /// <param name="chanceOfArrival">the chance of a customer arrving</param>
        /// <returns>returns true if the chance of arrival is lower than the point on the normal distribution and
        /// returns a false if the chance of arrival is greater than the point on the normal distribution</returns>
        public bool CustomerArrival(int randCustomers, double chanceOfArrival)
        {
            double normalDist = Math.Sin(1.57079 * ((double)customersArrived / ((double)randCustomers / 2))) + 1.15;
            if (normalDist >= chanceOfArrival) return true;
            {
                return false;
            }
        }
        /// <summary>
        /// handles adding an item to the customer's cart.
        /// additionally, some of the statistics are updated. totalSales, min, and max. 
        /// </summary>
        /// <param name="customer">the current customer that will be putting items in their cart</param>
        public void AddItem(Customer customer)
        {
            double customerTotal = 0;
            string[] itemArray = { "gum", "apples", "bananas", "oranges", "eggs", "bread",
                "milk","juice", "plates", "cups", "straws", "plates", "napkins", "pizza","waffles",
                "ramen","rolls", "soup","cereal","controller","keyboard","mouse","monitor", "speakers",
                "dvd","video game", "board game","soap","shampoo","towels"};
            int randomIndex = 0;
            double randomPrice = 0;
            
            //random number of items between 5 and 30
            for (int i = 0; i < random.Next(5, itemArray.Length); i++)
            {
                randomIndex = random.Next(0, itemArray.Length);
                randomPrice = random.NextDouble() * (99.5) + .05;   
                Item randomItem = new Item(itemArray[randomIndex], randomPrice);

                //individual customer total is figured
                customerTotal += randomItem.GetItemPrice();
                customer.AddToCart(randomItem);
            }
            //total sales stat is updated
            totalSales += customerTotal;
            
            //min and max total stats are updated 
            if (customersArrived == 1)
            {
                miniumCustomerTotal = customer.GetCart().Count;
            }
            if (customerTotal < miniumCustomerTotal)
            {
                miniumCustomerTotal = customerTotal;
            }
            if (customerTotal > maximumCustomerTotal)
            {
                maximumCustomerTotal = customerTotal;
            }
        }
        /// <summary>
        /// method for finding the shortest line of customers
        /// </summary>
        /// <param name="randRegistersOpen">the random number of registers that are currently open</param>
        /// <returns>returns the register with the shortest line</returns>
        public Register ShortestLine(int randRegistersOpen)
        {
            //needs to be number of registers opened
            //change to update as needed
            Register reg = Registers[0];
            for (int i = 0; i < randRegistersOpen ; i++)
            {
                if (Registers[i].GetLine().Count < reg.GetLine().Count)
                {
                    reg = Registers[i];
                }
            }
            return reg;
        }
        /// <summary>
        /// method for finding the longest queue of customers 
        /// </summary>
        /// <returns>returns the count of the longest queue</returns>
        public int LongestLine()
        {
            Register reg = Registers[0];

            for (int i = 1; i < Registers.Count; i++)
            {
                if (Registers[i].GetLine().Count > reg.GetLine().Count)
                {
                    reg = Registers[i];
                }
            }
            return reg.GetLine().Count;
        }
        /// <summary>
        /// method which handles the process of customer checkout. 
        /// average customer total statistic is also updated within this method.
        /// </summary>
        public void CheckoutCustomer()
        {
            for (int i = 0; i < Registers.Count; i++)
            {
                if (Registers[i].GetLine().Count > 0)
                {
                    //if the customer at the beginning of the line has a cart that is not empty
                    if (Registers[i].GetLine().Peek().GetCart().Count != 0)
                    {
                        //the first customer in the checkout line has an item removed
                        //from their cart until their cart is empty
                        Registers[i].GetLine().Peek().RemoveFromCart();            
                    }
                    else
                    {
                        //removes the customer IDs from the ID list and removes the customer from the line
                        Registers[i].CustIDs.Remove($"{Registers[i].CheckOut().ID}");
                        customersServed++;

                        //updating average customer total statistic 
                        averageCustomerTotal = totalSales / customersServed;
                    }
                }
            }
        }
    }
}