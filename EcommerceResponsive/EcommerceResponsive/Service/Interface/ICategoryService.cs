using EcommerceResponsive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EcommerceResponsive.Service.Interface
{
    public interface ICategoryService
    {
        Task<ResponseModel> CategoryList(CategoryModel req);
    }
}
