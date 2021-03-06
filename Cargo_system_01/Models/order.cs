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
    
    public partial class order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public order()
        {
            this.bills = new HashSet<bill>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<bill> bills { get; set; }
        public virtual cartype cartype { get; set; }
        public virtual city city { get; set; }
        public virtual city city1 { get; set; }
        public virtual customer customer { get; set; }
        public virtual driver driver { get; set; }
        public virtual loadstatu loadstatu { get; set; }
        public virtual loadtype loadtype { get; set; }
        public virtual packagetype packagetype { get; set; }
    }
}
