using EcommerceResponsive.Models;
using EcommerceResponsive.Service.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.Extensions.Caching.Memory;

namespace EcommerceResponsive.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly IConfiguration _config;
        private readonly IMemoryCache _memoryCache;
        public CategoryService(IConfiguration config, IMemoryCache memoryCache) 
        {
            this._config = config;
            this._memoryCache = memoryCache;
        }
        public async Task<ResponseModel> CategoryList(CategoryModel req) 
        {
            ResponseModel result = new ResponseModel();
            HttpClient client = new HttpClient();
            List<CategoryListModel> lstdata = new List<CategoryListModel>();
            try
            {
                string sSearch = "";
                if (!string.IsNullOrEmpty(req.sSearch))
                {
                    sSearch = req.sSearch.Trim().Replace(" ", String.Empty).ToLower();
                }
                if (_memoryCache.TryGetValue(sSearch, out List<CategoryListModel> cacheValue))
                {
                    lstdata = cacheValue;
                }
                else {
                    string url = "https://fakestoreapi.com/products";
                    HttpResponseMessage response = client.GetAsync(url).Result;
                    string str = await response.Content.ReadAsStringAsync();
                    List<ProductListModel> lstProduct = JsonConvert.DeserializeObject<List<ProductListModel>>(str.ToString());
                    lstdata = lstProduct.Select(s => new CategoryListModel
                    {
                        nID = s.id,
                        sName = s.title,
                        sDescription = s.description,
                        nPrice = s.price,
                        sImageUrl = s.image
                    }).ToList();
                    lstdata = lstdata.Where(w => w.sName.Trim().Replace(" ", String.Empty).ToLower().Contains(sSearch)).ToList();
                    var cacheEntryOptions = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60));
                    _memoryCache.Set(sSearch, lstdata, cacheEntryOptions);
                }
                
                result.data = lstdata;
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
    }
}
