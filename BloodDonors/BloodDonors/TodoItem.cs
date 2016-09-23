using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodDonors
{
    public class TodoItem
    {
        public TodoItem()
        {
        }

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string BloodType { get; set; }        
    }
}
