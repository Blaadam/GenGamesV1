//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GenGamesV1
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrder
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerHouseNo { get; set; }
        public string CustomerStreetName { get; set; }
        public string CustomerTown { get; set; }
        public string CustomerPostCode { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductQty { get; set; }
        public decimal OrderCost { get; set; }
        public decimal OrderShippingCost { get; set; }
        public decimal OrderFinalTotal { get; set; }
        public string OrderStatus { get; set; }
    
        public virtual tblCustomer tblCustomer { get; set; }
        public virtual tblProduct tblProduct { get; set; }
    }
}
