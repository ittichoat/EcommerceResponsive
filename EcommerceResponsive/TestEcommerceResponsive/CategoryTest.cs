using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using EcommerceResponsive.Service;
using Moq;
using EcommerceResponsive.Models;
using Microsoft.Extensions.DependencyInjection;

namespace TestEcommerceResponsive
{
    public class CategoryTest
    {
        [Fact]
        public async Task CategoryList()
        {
            var services = new ServiceCollection();
            services.AddMemoryCache();
            var serviceProvider = services.BuildServiceProvider();
            var memoryCache = serviceProvider.GetService<IMemoryCache>();

            var config = new Mock<IConfiguration>();
            var service = new CategoryService(config.Object, memoryCache);

            CategoryModel req = new CategoryModel() { sSearch = "SSD" };
            var result = await service.CategoryList(req);
            Assert.NotNull(result);
            Assert.Equal(2, ((List<CategoryListModel>)result.data).Count());

            //Check Cache
            result = await service.CategoryList(req);
            Assert.NotNull(result);
            Assert.Equal(2, ((List<CategoryListModel>)result.data).Count());

            req = new CategoryModel() { sSearch = "" };
            result = await service.CategoryList(req);
            Assert.NotNull(result);
            Assert.True(((List<CategoryListModel>)result.data).Count() > 0);
        }
    }
}