//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication8.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class supply_table
    {
        public int supply_id { get; set; }
        public string supply_title { get; set; }
        public string supply_content { get; set; }
        public System.DateTime supply_date { get; set; }
        public string supply_status { get; set; }
        public int user_id { get; set; }
        public int help_type_id { get; set; }
    
        public virtual help_type_table help_type_table { get; set; }
        public virtual users_table users_table { get; set; }
    }
}
