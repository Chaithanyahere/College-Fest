//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace College_Fest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class register
    {
        public register()
        {
            this.bookings = new HashSet<booking>();
            this.results = new HashSet<result>();
            this.winners = new HashSet<winner>();
        }
    
        public int rid { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string course { get; set; }
        public string year { get; set; }
        public string college { get; set; }
        public string username { get; set; }
        public string pasword { get; set; }
    
        public virtual ICollection<booking> bookings { get; set; }
        public virtual ICollection<result> results { get; set; }
        public virtual ICollection<winner> winners { get; set; }
    }
}