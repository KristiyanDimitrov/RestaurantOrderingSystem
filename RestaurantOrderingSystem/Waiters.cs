using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace RestaurantOrderingSystem
{
    class Waiters
    {
        private Waiters(string Name, int Capacity,List<string> Availability)
        {
            this.name = Name;
            this.capacity = Capacity;
            this.availability = Availability;
        }

        public static List<Waiters> WaiterList { get; set; }
        public static XmlDocument WaiterSchedule;

        public string name { get; set; }
        public int capacity { get; set; }
        public List<string> availability { get; set; }


        public string Name {
            get { return name; }
            set
            {
                name = value;
            }
        }
        

        public static void BufferStaff()
        {
            // Load XML file with staff detail
            DateTime today = DateTime.Today;
            string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string mainDir = Path.Combine(Directory.GetParent(projectDirectory).Parent.FullName, @"RestaurantOrderingSystem\Data\Schedule.xml");

            WaiterSchedule = new XmlDocument();
            WaiterSchedule.Load(mainDir);
            XmlNodeList WaitersXML = WaiterSchedule.SelectNodes("/Schedule/Waiters/Waiter");

            Waiters.WaiterList = new List<Waiters>();
            // Create staff instances from XML staff detail
            foreach (XmlNode nod in WaitersXML)
            {
                string name = nod.Attributes["name"].Value;
                Int32.TryParse(nod.Attributes["Capacity"].Value, out int capacity);
                string[] days = nod["Availability"].InnerText.ToString().Split(',');
                List<string> availability = new List<string>(days);


                if (availability.Contains(today.DayOfWeek.ToString())) // Add waiter if working today
                {
                    Waiters tmp = new Waiters(name, capacity, availability);
                    Waiters.WaiterList.Add(tmp);
                } 
               
            }
        }




    }


}
