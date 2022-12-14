using Microsoft.AspNetCore.Mvc;
using Report.API.Controllers;
using Report.API.Entities;
using Report.API.Service.Interfaces;
using Xunit;

namespace Report.Tests
{
    public class ReportTests
    {

        private readonly IReportService _repo;
        private readonly ReportController _controller;

        public ReportTests()
        {
            _repo = new ReportServiceFake();
            _controller = new ReportController(_repo);
        }

        #region Get

        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult =  _controller.Get().Result;

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result as OkObjectResult);
        }

        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var result = _controller.Get().Result.Result as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<ReportResult>>(result.Value);
            Assert.Equal(3, items.Count);
        }

        #endregion

        #region GetbyId

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsOkResult()
        {
            // Arrange
            var testGuid = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200";
            // Act
            var okResult = _controller.Get(testGuid);
            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result.Result as OkObjectResult);
        }

        [Fact]
        public void GetById_ExistingGuidPassed_ReturnsRightItem()
        {
            // Arrange
            var testGuid = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200";
            // Act
            var okResult = _controller.Get(testGuid).Result.Result as OkObjectResult;
            // Assert
            Assert.IsType<ReportResult>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as ReportResult).Id);
        }
        #endregion

        #region Create


        [Fact]
        public void AddReportRequest_ReturnsCreatedResponse()
        {

            // Act
            var okResponse = _controller.CreateReportRequest().Result;
            // Assert
            Assert.IsType<OkResult>(okResponse);
        }

        [Fact]
        public void AddReportRequest_ReturnedResponseHasCreatedItem()
        {

            // Act
            var okResponse = _controller.CreateReportRequest().Result;
            var item = _repo.GetAsync().Result.LastOrDefault();
            // Assert
            Assert.IsType<OkResult>(okResponse);
            Assert.IsType<ReportResult>(item);
            Assert.Equal(Status.Prepraring, item.Status);
        }
        #endregion


    }
}