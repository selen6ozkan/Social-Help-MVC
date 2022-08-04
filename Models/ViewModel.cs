using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication8.Models
{
    public class ViewModel
    {
        public IEnumerable<blood_donation_table> Blood { get; set; }
        public IEnumerable<business_help_table> Business { get; set; }
        public IEnumerable<clothes_table> Clothes { get; set; }
        public IEnumerable<education_table> Education { get; set; }
        public IEnumerable<events_table> Event { get; set; }
        public IEnumerable<financial_support_table> Financial { get; set; }
        public IEnumerable<shelter_table> Shelter { get; set; }
        public IEnumerable<stationary_table> Stationary { get; set; }
        public IEnumerable<street_animal_table> Animal { get; set; }
        public IEnumerable<supply_table> Supply { get; set; }
        public IEnumerable<users_table> User { get; set; }
        public IEnumerable<user_type_table> Type { get; set; }
        

    }
}