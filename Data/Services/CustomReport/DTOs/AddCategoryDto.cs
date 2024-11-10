using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.CustomReport.DTOs
{
    public class AddCategoryDto
    {
        public string name { get; set; }
        public int ParentId { get; set; }
    }
}
