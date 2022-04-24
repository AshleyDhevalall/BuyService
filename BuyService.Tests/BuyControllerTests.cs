using BuyService.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace BuyService.Tests
{
    public class Tests
    {
        [Test]
        public void Buy_Given_Valid_OrderedProduct_Should_Pass()
        {
            // Arrange
            var model = new OrderedProduct {  };
            var handlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            HttpResponseMessage httpresponse = new HttpResponseMessage();

            handlerMock
                .Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync(httpresponse)
                .Verifiable();

            var httpClient = new HttpClient(handlerMock.Object)
            {
                BaseAddress = new Uri("https://www.code4it.dev/")
            };
            
            var mockHttpClientFactory = new Mock<IHttpClientFactory>();
            mockHttpClientFactory.Setup(_ => _.CreateClient("InventoryService")).Returns(httpClient);
            mockHttpClientFactory.Setup(_ => _.CreateClient("ShippingService")).Returns(httpClient);

            var mock = new Mock<ILogger<BuyController>>();
            ILogger<BuyController> logger = mock.Object;

            var controller = new BuyController(mockHttpClientFactory.Object, logger);
            var httpContext = new DefaultHttpContext(); 
            httpContext.Request.Headers.Add("CorrelationId", "ABCDEFGHI");
            controller.ControllerContext.HttpContext = httpContext;

            // Act
            var result = controller.Buy(model);

            // Assert
            var okResult = result as Microsoft.AspNetCore.Mvc.OkResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}