using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Setting
{
    public class PDF
    {

        public bool IsLandScape { get; set; }
        public int NumberOfRowsInPage { get; set; }
        public int NumberOfColumnsInPage { get; set; }
        public int NumberOfRowsInFile { get; set; }
        public bool UsingPartitionApproach { get; set; }

    }
}
