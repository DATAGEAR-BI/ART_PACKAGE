﻿using System;
using System.Collections.Generic;

namespace Data.Data.DGINTFRAUD
{
    public partial class ArtDgamlHierarchicalTransaction
    {
        public string? Employee_Number { get; set; }
        public string? Customer_ID { get; set; }
        public string? Employee_Name { get; set; }
        public string? Role { get; set; }
        public string? Staff_Relative_Ind { get; set; }
        public string? Department { get; set; }
        public string? Division { get; set; }
        public string? Job { get; set; }
        public string? Grad { get; set; }
        public string? Status { get; set; }
        public string? Transaction_Reference { get; set; }
        public string? Transaction_Type { get; set; }
        public long? Transaction_Date { get; set; }
        public decimal Base_Amount_EGP { get; set; }
        public decimal Equivalent_Amount { get; set; }
        public string? Equivalent_Currency { get; set; }
    }
}