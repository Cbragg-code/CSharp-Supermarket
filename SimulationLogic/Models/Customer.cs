///////////////////////////////////////////////////////////////////////////////
//
//  Author: Christopher Bragg, braggc1@etsu.edu
//  Course: CSCI-2210-001 - Data Structures
//  Assignment: Project 4
//  Description: Customer class, represents and has the information of a customer
//  
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationLogic
{
    public class Customer
    {
        private Stack<Item> Cart = new Stack<Item>();
        internal int ID;

        /// <summary>
        /// constructor for the customers arrival time 
        /// </summary>
        /// <param name="ID">unique identifier for a customer </param>
        /// <param name="arrivaltime">arrival time for a customer</param>
        public Customer(int ID)
        {
            this.ID = ID;
            
        }
        /// <summary>
        /// getter for the customers cart
        /// </summary>
        /// <returns>a customers cart</returns>
        public Stack<Item> GetCart()
        {
            return Cart;
        }
        /// <summary>
        /// adds an item to the top of the customers cart(stack) using push
        /// </summary>
        /// <param name="item">the name and price associated with a customers item</param>
        public void AddToCart (Item item)
        {
            Cart.Push (item);
            
        }
        /// <summary>
        /// removes an item from the top of the customers cart
        /// </summary>
        public void RemoveFromCart ()
        {
            Cart.Pop();
        }
    }
}
