//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPMS.ENTITIES
{
    using System;
    using System.Collections.Generic;
    
    public partial class DailyCashSaleDenomination
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int DenominationTypeId { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public byte[] CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
    
        public virtual DenominationType DenominationType { get; set; }
    }
}
