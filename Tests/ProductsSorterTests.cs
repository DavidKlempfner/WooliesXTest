using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using WooliesXTest.Abstract;
using WooliesXTest.Models;
using WooliesXTest.Services;
using System.Linq;
using WooliesXTest.Enums;
using WooliesXTest.Controllers;

namespace Tests
{
    [TestClass]
    public class ProductsSorterTests
    {
        private List<Product> _products = new List<Product>
        {
            new Product { Name = "Test Product A", Price = 99.99M, Quantity = 0.0M },
            new Product { Name = "Test Product C", Price = 101.99M, Quantity = 0.0M },
            new Product { Name = "Test Product B", Price = 10.99M, Quantity = 0.0M }
        };

        [TestMethod]
        public void GivenListOfProductsWhenSortedLowExpectCorrectOrder()
        {
            //Arrange            
            IProductsSorter productsSorter = new ProductsSorter();

            //Act
            List<Product> sortedProducts = productsSorter.SortProducts(_products, SortOptions.Low);

            //Assert
            Assert.IsNotNull(sortedProducts);
            Assert.IsTrue(sortedProducts.Any());
            Assert.IsTrue(sortedProducts.First().Price < sortedProducts[1].Price);
            Assert.IsTrue(sortedProducts[1].Price < sortedProducts.Last().Price);
        }

        [TestMethod]
        public void GivenListOfProductsWhenSortedHighExpectCorrectOrder()
        {
            //Arrange            
            IProductsSorter productsSorter = new ProductsSorter();

            //Act
            List<Product> sortedProducts = productsSorter.SortProducts(_products, SortOptions.High);

            //Assert
            Assert.IsNotNull(sortedProducts);
            Assert.IsTrue(sortedProducts.Any());
            Assert.IsTrue(sortedProducts.First().Price > sortedProducts[1].Price);
            Assert.IsTrue(sortedProducts[1].Price > sortedProducts.Last().Price);
        }

        [TestMethod]
        public void GivenListOfProductsWhenSortedAscendingExpectCorrectOrder()
        {
            //Arrange            
            IProductsSorter productsSorter = new ProductsSorter();

            //Act
            List<Product> sortedProducts = productsSorter.SortProducts(_products, SortOptions.Ascending);

            //Assert
            Assert.IsNotNull(sortedProducts);
            Assert.IsTrue(sortedProducts.Any());
            Assert.IsTrue(sortedProducts.First().Name.CompareTo(sortedProducts[1].Name) < 0);
            Assert.IsTrue(sortedProducts[1].Name.CompareTo(sortedProducts.Last().Name) < 0);
        }

        [TestMethod]
        public void GivenListOfProductsWhenSortedDescendingExpectCorrectOrder()
        {
            //Arrange            
            IProductsSorter productsSorter = new ProductsSorter();

            //Act
            List<Product> sortedProducts = productsSorter.SortProducts(_products, SortOptions.Descending);

            //Assert
            Assert.IsNotNull(sortedProducts);
            Assert.IsTrue(sortedProducts.Any());
            Assert.IsTrue(sortedProducts.First().Name.CompareTo(sortedProducts[1].Name) > 0);
            Assert.IsTrue(sortedProducts[1].Name.CompareTo(sortedProducts.Last().Name) > 0);
        }
    }
}