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
    
    public partial class sp_orders_status_Result
    {
        public string driver_name { get; set; }
        public string driver_family { get; set; }
        public string driver_mobile { get; set; }
        public int orders_id { get; set; }
        public Nullable<int> customer_id { get; set; }
        public string from_adr { get; set; }
        public string from_name { get; set; }
        public string from_mobile { get; set; }
        public string from_date { get; set; }
        public Nullable<int> from_city { get; set; }
        public string to_name { get; set; }
        public string to_mobile { get; set; }
        public string to_date { get; set; }
        public Nullable<int> to_city { get; set; }
        public Nullable<int> load_type { get; set; }
        public Nullable<int> package_type { get; set; }
        public Nullable<int> load_weight { get; set; }
        public Nullable<int> cartype_id { get; set; }
        public Nullable<int> driver_id { get; set; }
        public string driver_date { get; set; }
        public Nullable<int> order_status { get; set; }
        public string description { get; set; }
        public string customer_name { get; set; }
        public string customer_family { get; set; }
        public string customer_mobile { get; set; }
    }
}
