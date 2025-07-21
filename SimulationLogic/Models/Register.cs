///////////////////////////////////////////////////////////////////////////////
//
//  Author: Christopher Bragg, braggc1@etsu.edu
//  Course: CSCI-2210-001 - Data Structures
//  Assignment: Project 4
//  Description: Registers class, represents a checkout line
//  
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationLogic
{
    public class Register
    {
        private Queue<Customer> Line = new Queue<Customer>();
        internal List<string> CustIDs = new List<string>();
        int ID;

        /// <summary>
        /// constructor for register
        /// </summary>
        /// <param name="ID">specific identifier for a register</param>
        public Register(int ID) 
        { 
            this.ID = ID;  
        }
        /// <summary>
        /// getter for the registers ID
        /// </summary>
        /// <returns>returns the identifier </returns>
        public int GetID()
        {
            return ID;
        }
        /// <summary>
        /// getter for the line a customer is in
        /// </summary>
        /// <returns>the specific line a customer is in</returns>
        public Queue<Customer> GetLine()
        {
            return Line;
        }
        /// <summary>
        /// adds a customer to the end of the line (queue) using Enqueue 
        /// </summary>
        /// <param name="customer">the customer being added to a line</param>
        public void JoinLine (Customer customer)
        {
            Line.Enqueue(customer);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Customer CheckOut()
        {
            return Line.Dequeue();
        }
    }
}
