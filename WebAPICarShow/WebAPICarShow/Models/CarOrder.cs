//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebAPICarShow.Models
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public partial class CarOrder
    {
        public int id { get; set; }
        public Nullable<int> id_Car { get; set; }
        public Nullable<int> id_Client { get; set; }
        public Nullable<int> id_PaymentType { get; set; }
        public System.DateTime dateBuyCar { get; set; }
        public string paymentType { get; set; }

        [JsonIgnore]
        public virtual Car Car { get; set; }
        [JsonIgnore] 
        public virtual Client Client { get; set; }

        [JsonIgnore]
        public virtual PaymentTypes PaymentTypes { get; set; }
    }
}
