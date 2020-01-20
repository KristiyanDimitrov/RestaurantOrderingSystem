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
            Customer B = new Customer(4, 9); // More People than table capacity
            System.Diagnostics.Debug.WriteLine("PASS 2");
            Customer C = new Customer(22, 3); // Table doesn't exist
            System.Diagnostics.Debug.WriteLine("PASS 3");







        }
    }
}
