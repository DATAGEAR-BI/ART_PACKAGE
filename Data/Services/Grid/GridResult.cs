
using System.Linq;

namespace Data.Services.Grid
{
    public class GridResult<T>
    {
        public int total { get; set; }
        public IQueryable<T>? data { get; set; }
    }
}
