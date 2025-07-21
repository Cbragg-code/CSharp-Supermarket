///////////////////////////////////////////////////////////////////////////////
//
//  Author: Christopher Bragg, braggc1@etsu.edu
//  Course: CSCI-2210-001 - Data Structures
//  Assignment: Project 4
//  Description: Represents one item that is in a customers cart 
//  
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationLogic
{
    public class Item
    {
        string name;
        double price;
        
        /// <summary>
        /// constructor for item
        /// </summary>
        /// <param name="name">name of an individual item</param>
        /// <param name="price">price of an individual item</param>
        public Item(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        /// <summary>
        /// getter for the item name
        /// </summary>
        /// <returns>the name of the item</returns>
        public string GetItemName()
        {
            return name;
        }
        /// <summary>
        /// getter for the item name
        /// </summary>
        /// <returns>the price of the item</returns>
        public double GetItemPrice()
        {
            return price;
        }
    }
}