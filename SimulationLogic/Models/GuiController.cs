///////////////////////////////////////////////////////////////////////////////
//
//  Author: Christopher Bragg, braggc1@etsu.edu
//  Course: CSCI-2210-001 - Data Structures
//  Assignment: Project 4
//  Description: Where all of the statistics are updated for the gui interface.
//  additionally, the customer numbers are shown below the register IDs.
//  along with the register IDs, the number of items in the current customers cart are displayed
//  
///////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SimulationLogic
{
    public class GuiController : IGuiController
    {
        /// <summary>
        /// Implements <see cref="IGuiController.UpdateUI(Supermarket, string[], List{string}[], ISupermarketStatistics)"/>
        /// </summary>
        public void UpdateUI(Supermarket supermarket, string[] queueLabels, List<string>[] queueOfCustomers, ISupermarketStatistics supermarketStatistics)
        {
            for (int i = 0; i < 15; i++)
            {
                //updates the gui so that the customer IDs shown under the register they are at
                queueOfCustomers[i] = supermarket.Registers[i].CustIDs;
               
                //updates the gui to show the register's ID : number of items in the current customers cart 
                if (supermarket.Registers[i].GetLine().Count != 0)
                {
                    int itemCount = supermarket.Registers[i].GetLine().Peek().GetCart().Count;
                    string genericString = $"{i + 1}";
                    queueLabels[i] = $"{genericString.PadLeft(2, '0')}: {itemCount}";
                }
            }
            //updating the statistics to the gui
            supermarketStatistics.LongestLine = supermarket.longestLine;
            supermarketStatistics.CustomersArrived = supermarket.customersArrived;
            supermarketStatistics.CustomersDeparted = supermarket.customersServed;
            supermarketStatistics.AverageCustomerTotal = (decimal)supermarket.averageCustomerTotal;
            supermarketStatistics.MinimumCustomerTotal = (decimal)supermarket.miniumCustomerTotal;
            supermarketStatistics.MaximumCustomerTotal = (decimal)supermarket.maximumCustomerTotal;
            supermarketStatistics.TotalSales = (decimal)supermarket.totalSales;
        }
    }
}
