using ECommerce.Api.Products.Providers;
using System;
using Xunit;

namespace ECommerce.Api.Products.Tests
{
    public class ProductsServiceTest
    {
        [Fact]
        public void GetProductsReturnsAllProducts()
        {
            var productsProvider = new ProductsProvider();
        }
    }
}
