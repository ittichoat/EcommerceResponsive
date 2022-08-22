using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceResponsive.Models
{
    
    public class CategoryModel
    {
        public string sSearch { get; set; }
    }
    public class CategoryListModel
    {
        public int nID { get; set; }
        public string sName { get; set; }
        public string sDescription { get; set; }
        public int nPrice { get; set; }
        public string sPrice { get { return nPrice.ToString("N0"); } }
        public string sImageUrl { get; set; }
    }
}
