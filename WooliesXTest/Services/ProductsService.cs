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

        public List<Product> GetSortedProducts(SortOptions sortOption)
        {
            List<Product> allProducts = GetAllProducts();
            List<Product> sortedProducts = _productsSorter.SortProducts(allProducts, sortOption);
            return sortedProducts;
        }

        public List<RecommendedProducts> GetRecommendedProducts()
        {
            string recommendedProductsUrl = GetShopperHistoryUrl();
            string jsonString = _apiHelper.GetJsonResponseString(recommendedProductsUrl);
            List<RecommendedProducts> recommendedProducts = JsonConvert.DeserializeObject<List<RecommendedProducts>>(jsonString);
            return recommendedProducts;
        }

        private List<Product> GetAllProducts()
        {
            string productsUrl = GetProductsUrl();
            string jsonString = _apiHelper.GetJsonResponseString(productsUrl);
            return JsonConvert.DeserializeObject<List<Product>>(jsonString);
        }

        private string GetProductsUrl()
        {
            return GetUrl(GenericConstants.BaseUrl, "products", GenericConstants.Token);
        }

        private string GetShopperHistoryUrl()
        {
            return GetUrl(GenericConstants.BaseUrl, "shopperHistory", GenericConstants.Token);
        }

        private string GetUrl(string baseUrl, string resourceName, string token)
        {
            return $"{baseUrl}/{resourceName}?token={token}";
        }
    }
}