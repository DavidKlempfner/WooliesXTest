using Newtonsoft.Json;
using System.Collections.Generic;
using WooliesXTest.Abstract;
using WooliesXTest.Constants;
using WooliesXTest.Enums;
using WooliesXTest.Models;
using System.Linq;

namespace WooliesXTest.Services
{
    public class ProductsService : IProductsService
    {
        IApiHelper _apiHelper;
        IProductsSorter _productsSorter;

        public ProductsService(IApiHelper apiHelper, IProductsSorter productsSorter)
        {
            _apiHelper = apiHelper;
            _productsSorter = productsSorter;
        }

        public List<Product> GetProducts(SortOptions sortOption)
        {
            if (sortOption == SortOptions.Recommended)
            {
                string recommendedProductsUrl = GetRecommendedProductsUrl();
                string jsonString = _apiHelper.GetJsonResponseString(recommendedProductsUrl);
                List<RecommendedProducts> recommendedProducts = JsonConvert.DeserializeObject<List<RecommendedProducts>>(jsonString);
                return recommendedProducts[0].Products;//TODO: fix this
            }
            else
            {
                List<Product> allProducts = GetAllProducts();
                return _productsSorter.SortProducts(allProducts, sortOption);
            }            
        }

        private List<Product> GetAllProducts()
        {                        
            string productsUrl = GetProductsUrl();
            string jsonString = _apiHelper.GetJsonResponseString(productsUrl);
            return JsonConvert.DeserializeObject<List<Product>>(jsonString);
        }

        private string GetProductsUrl()
        {
            return $"{GenericConstants.BaseUrl}/products?token={GenericConstants.Token}";
        }

        private string GetRecommendedProductsUrl()
        {
            return $"{GenericConstants.BaseUrl}/shopperHistory?token={GenericConstants.Token}";
        }
    }
}