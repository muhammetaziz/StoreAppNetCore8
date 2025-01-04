using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.Data.Concrete
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }=string.Empty;
        public string CategoryDescription { get; set; }= string.Empty;
        public int ProductID { get; set; }

    }
}
