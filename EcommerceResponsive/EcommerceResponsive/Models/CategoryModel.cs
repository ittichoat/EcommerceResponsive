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
        public decimal nPrice { get; set; }
        public string sPrice { get { return nPrice.ToString("N"); } }
        public string sImageUrl { get; set; }
    }
    public class ProductListModel
    {
        public int id { get; set; }
        public string title { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string category { get; set; }
    }
}
