using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace RestaurantOrderingSystem
{
    class Interface
    {
        static void Main(string[] args)
        {
            

            Waiters.BufferStaff();

            Waiters.WaiterList.ForEach(el => System.Diagnostics.Debug.WriteLine(el.Name));


            Customer A = new Customer(3, 8); // Normal
            System.Diagnostics.Debug.WriteLine("PASS 1");

            try
            {
                System.Diagnostics.Debug.WriteLine("PASS 2");
                Customer B = new Customer(4, 9); // More People than table capacity
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR--------2");
                System.Diagnostics.Debug.WriteLine(e);
            }

            try
            {
                System.Diagnostics.Debug.WriteLine("PASS 3");
                Customer C = new Customer(3, 22); // Table doesn't exist
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("ERROR----------3");
                System.Diagnostics.Debug.WriteLine(e);
            }
            Console.WriteLine("TEST");







        }
    }
}
