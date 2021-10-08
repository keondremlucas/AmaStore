using System;
using Xunit;
using FluentAssertions;
using Lib;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Warehouse;
using System.Threading.Tasks;
using Moq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Test
{
    public class WarehouseControllerTest
    {
        private WarehouseController _controller;
        private Mock<IWarehouseRepository> _mockRepository;
        private DefaultHttpContext _httpContext;

        public WarehouseControllerTest()
        {
            _mockRepository = new Mock<IWarehouseRepository>();
            _httpContext = new DefaultHttpContext();
            _controller = new WarehouseController(_mockRepository.Object)
            {ControllerContext = new ControllerContext() { HttpContext = _httpContext } };

        }

        [Fact]
        public async Task ShouldCreateProduct()
        {
            var dto = new ProductDto() {ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
            var result = await _controller.NewProduct(dto);
            var createdActionResult = result as CreatedAtActionResult;
            createdActionResult.StatusCode.Should().Be(201);
            createdActionResult.ActionName.Should().Be("GetOneProduct");
            createdActionResult.RouteValues["Id"].Should().NotBeNull();
        }

        [Fact]
         public async Task ShouldGetOneProduct()
        {   int Id = 1;
            _mockRepository.Setup(obj => obj.GetOneProductAsync(Id)).Returns(Task.FromResult(new Product() {Id = Id , ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1} ));
            var result = await _controller.GetOneProduct(Id);
            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(200);
            (okResult.Value as Product).Id.Should().Be(1);
            _mockRepository.Verify(obj => obj.GetOneProductAsync(Id));
            
        }

        [Fact]
        public async Task ShouldGetAllProducts()
        {   
            var result = await _controller.GetAllProducts();
            var okResult = result as OkObjectResult;
            okResult.StatusCode.Should().Be(200);
            _mockRepository.Verify(obj => obj.GetAllProductsAsync());
            
        }

        [Fact]
        public async Task ShouldCheckProductQuantity()
        {  int Id = 1;
           var product = new Product() {Id = Id , ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
           _mockRepository.Setup(obj => obj.CheckProductQuantity(product)).Returns(1);
           _mockRepository.Setup(obj => obj.GetOneProductAsync(Id)).Returns(Task.FromResult(product));
           

            var result = await _controller.GetOneProduct(Id);
            var result2 = await _controller.CheckProductQuantity(Id);

            var okResult = result as OkObjectResult;
            var okResult2 = result2 as OkObjectResult;;

            okResult.StatusCode.Should().Be(200);
            okResult2.StatusCode.Should().Be(200);

            _mockRepository.Verify(obj => obj.GetOneProductAsync(Id));
            _mockRepository.Verify(obj => obj.CheckProductQuantity(product));
            
        }

        [Fact]
        public async Task ShouldCheckIfProductExists()
        {  int Id = 1;
           var product = new Product() {Id = Id , ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
           _mockRepository.Setup(obj => obj.CheckProductExists(product)).Returns(2);
           _mockRepository.Setup(obj => obj.GetOneProductAsync(Id)).Returns(Task.FromResult(product));
           

            var result = await _controller.GetOneProduct(Id);
            var result2 = await _controller.CheckExists(Id);

            var okResult = result as OkObjectResult;
            var okResult2 = result2 as OkObjectResult;;

            okResult.StatusCode.Should().Be(200);
            okResult2.StatusCode.Should().Be(200);

            _mockRepository.Verify(obj => obj.GetOneProductAsync(Id));
            _mockRepository.Verify(obj => obj.CheckProductExists(product));
            
        }

         [Fact]
        public async Task ShouldUpdateProductQuantity()
        {  int Id = 1;
           var product = new Product() {Id = Id , ProductName = "Iphone", Cost = 500.00M, Weight = 7, Quantity = 1};
           _mockRepository.Setup(obj => obj.UpdateProduct(product,2));
           _mockRepository.Setup(obj => obj.GetOneProductAsync(Id)).Returns(Task.FromResult(product));
           

            var result = await _controller.GetOneProduct(Id);
            var result2 = await _controller.UpdateProduct(Id,2);

            var okResult = result as OkObjectResult;
            var okResult2 = result2 as OkObjectResult;;

            okResult.StatusCode.Should().Be(200);
            okResult2.StatusCode.Should().Be(200);

            _mockRepository.Verify(obj => obj.GetOneProductAsync(Id));
            _mockRepository.Verify(obj => obj.UpdateProduct(product,2));
            
        }
    }
}