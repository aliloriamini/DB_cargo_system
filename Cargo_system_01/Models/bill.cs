//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Cargo_system_01.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bill
    {
        public int bills_id { get; set; }
        public Nullable<int> price { get; set; }
        public Nullable<int> tax { get; set; }
        public Nullable<int> vosoli { get; set; }
        public string date_bank { get; set; }
        public Nullable<int> orders_id { get; set; }
    
        public virtual order order { get; set; }
    }
}
