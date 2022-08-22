using EcommerceResponsive.Models;
using EcommerceResponsive.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceResponsive.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IConfiguration _config;
        public CategoryService(IConfiguration config) 
        {
            this._config = config;
        }
        public ResponseModel CategoryList(CategoryModel req) 
        {
            ResponseModel result = new ResponseModel();
            try
            {
                List<CategoryListModel> data = MockCategoryList();
                result.data = data;
                result.status = 200;
                result.message = "Success";
                result.success = true;
            }
            catch (Exception ex) 
            {
                result.status = 500;
                result.message = ex.ToString();
                result.success = false;
            }
            return result;
        }
        private List<CategoryListModel> MockCategoryList() 
        {
            List<CategoryListModel> data = new List<CategoryListModel>() { 
                new CategoryListModel{ 
                    nID = 1,
                    sName = "RTX3090/24GB GIGABYTE GAMING (OC/D6)",
                    sDescription = @"24GB / GDDR6X / 384-bit / 1xHDMI / 3xDisplayPort",
                    nPrice = 50000,
                    sImageUrl = "A0133107OK_BIG_1.jpg"
                },
                new CategoryListModel{
                    nID = 2,
                    sName = "VGA INNO3D GEFORCE GTX 1630 TWIN X2 OC - 4GB GDDR6",
                    sDescription = @"4GB / GDDR6 / 64-bit / 1xDVI / 1xHDMI / 1xDisplayPort",
                    nPrice = 6090,
                    sImageUrl = "A0145852OK_BIG_1.webp"
                },
                new CategoryListModel{
                    nID = 3,
                    sName = "VGA INNO3D GEFORCE GTX 1630 TWIN X2 OC - 4GB GDDR6",
                    sDescription = @"4GB / GDDR6 / 64-bit / 1xDVI / 1xHDMI / 1xDisplayPort",
                    nPrice = 7190,
                    sImageUrl = "A0125099OK_BIG_1.webp"
                },
                new CategoryListModel{
                    nID = 4,
                    sName = "VGA ASUS GEFORCE RTX 2060 DUAL EVO O12G OC - 12GB GDDR6",
                    sDescription = @"12GB / GDDR6 / 192-bit / 1xDVI / 2xHDMI / 1xDisplayPort",
                    nPrice = 12500,
                    sImageUrl = "A0141381OK_BIG_1.webp"
                },
                new CategoryListModel{
                    nID = 5,
                    sName = "VGA ASUS GEFORCE RTX 3080 TI ASUS ROG STRIX O12G",
                    sDescription = @"12GB / GDDR6X / 384-bit / 2xHDMI / 3xDisplayPort",
                    nPrice = 44900,
                    sImageUrl = "A0137052OK_BIG_1.webp"
                },
                new CategoryListModel{
                    nID = 6,
                    sName = "VGA ASUS GEFORCE RTX 3080 TUF O12G GAMING- 12GB GDDR6",
                    sDescription = @"12GB / GDDR6X / 384-bit / 2xHDMI / 3xDisplayPort",
                    nPrice = 31500,
                    sImageUrl = "A0142812OK_BIG_1.webp"
                }
            };
            return data;
        }
    }
}
