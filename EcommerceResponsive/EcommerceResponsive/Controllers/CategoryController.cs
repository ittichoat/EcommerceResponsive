using EcommerceResponsive.Models;
using EcommerceResponsive.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace EcommerceResponsive.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IServiceProvider _service;

        public CategoryController(IServiceProvider serviceProvider)
        {
            this._service = serviceProvider;
        }

        [HttpPost]
        [Route("CategoryList")]
        public ResponseModel CategoryList(CategoryModel req)
        {
            var service = _service.GetService<ICategoryService>();
            var res = service.CategoryList(req);
            return res;
        }
    }
}
