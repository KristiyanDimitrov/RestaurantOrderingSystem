using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantOrderingSystem
{
    class Customer
    {

        public Customer(int CustomerNumber, int TableNumber = -1)
        {
            this._customerNumber = CustomerNumber;
            _tableNumber =  FindTable(CustomerNumber, TableNumber);
            _allocatedWaiter = AllocateWaiter();

        }

        private int FindTable(int customerNumber, int TableNumber = -1) // If table number provided see if it's available. If not provided try to find a table
        {
            if (TableNumber > 0 && TableNumber > tables.Values.Count)
                throw new Exception("Table doesn't exsist");       
            else if (TableNumber > 0 && takenTables.Contains(TableNumber))
                throw new Exception("Table already taken");
            else if (TableNumber > 0 && !takenTables.Contains(TableNumber) && tables[TableNumber] < customerNumber)
                throw new Exception("Table not big enough!");
            else if (TableNumber > 0 && !takenTables.Contains(TableNumber) )
                return TableNumber;


            for (int i = 0; i <= tables.Count; i++)
            {
                if (takenTables.Contains(1) || tables[i] > customerNumber)
                    continue;
                 else if (tables[i] <= customerNumber)
                    takenTables.Add(i);

                return i;

            }
            throw new Exception("No Available Tables");
        }

        private Waiters AllocateWaiter ()
        {
            int maxCapacity = 0;
            int waiterID = -1;

            for (int i = 0; i < Waiters.WaiterList.Count; i++)
            {
                if (Waiters.WaiterList[i].capacity > maxCapacity)
                {
                    maxCapacity = Waiters.WaiterList[i].capacity;
                    waiterID = i;
                }               
            }
            if (waiterID != -1)
            {
                Waiters.WaiterList[waiterID].capacity = Waiters.WaiterList[waiterID].capacity - 1;
                return Waiters.WaiterList[waiterID];
            }
            else
                throw new Exception("No Available Waiter");

        }

        public void PayBill()
        {
            _allocatedWaiter.capacity = _allocatedWaiter.capacity + 1;
            takenTables.Remove(_tableNumber);
        }

        public static List<int> takenTables = new List<int>();
        public static Dictionary<int, int> tables = new Dictionary<int, int>()
            { {1, 4},{2, 4},{3, 4},{4, 4},{5, 6},{6, 6},{7, 6},{8, 8},{9, 3},{10, 2} }; // Table Numbers and their capacity
        public static List<Customer> currentCustomers = new List<Customer>();

        private int _tableNumber { get; set; }
        private int _customerNumber { get; set; }
        private Waiters _allocatedWaiter { get; set; }
    }
}
