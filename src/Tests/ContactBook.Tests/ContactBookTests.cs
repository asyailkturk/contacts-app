using ContactBook.API.Controllers;
using ContactBook.API.Entities;
using ContactBook.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Xunit;

namespace ContactBook.Tests
{
    public class ContactBookTests
    {

        private readonly IContactRepository _repo;
        private readonly ContactController _controller;

        public ContactBookTests()
        {
            _repo = new ContactBookServiceFake();
            _controller = new ContactController(_repo);
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
            var items = Assert.IsType<List<Contact>>(result.Value);
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
            Assert.IsType<Contact>(okResult.Value);
            Assert.Equal(testGuid, (okResult.Value as Contact).Id);
        }
        #endregion

        #region Create

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var companyMissingItem = new Contact()
            {
                FirstName = "Asya",
                LastName = "Ilkturk"
            };
            _controller.ModelState.AddModelError("Company", "Required");
            // Act
            var badResponse = _controller.Create(companyMissingItem).Result;
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var testItem = new Contact()
            {
                FirstName = "Asya",
                LastName = "Ilkturk",
                Company = "Company"
            };
            // Act
            var createdResponse = _controller.Create(testItem).Result;
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var testItem = new Contact()
            {
                FirstName = "Test Name",
                LastName = "Test Lastname",
                Company = "Company"
            };
            // Act
            var createdResponse = _controller.Create(testItem).Result as CreatedAtActionResult;
            var item = createdResponse.Value as Contact;
            // Assert
            Assert.IsType<Contact>(item);
            Assert.Equal("Test Name", item.FirstName);
        }
        #endregion

        #region Delete

        [Fact]
        public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid().ToString();
            // Act
            var badResponse = _controller.Delete(notExistingGuid);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse.Result);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingGuid = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200";
            // Act
            var noContentResponse = _controller.Delete(existingGuid);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse.Result);
        }

        [Fact]
        public void Remove_ExistingGuidPassed_RemovesOneItem()
        {
            // Arrange
            var existingGuid = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200";
            // Act
            var okResponse = _controller.Delete(existingGuid);
            // Assert
            Assert.Equal(2, _repo.GetAsync().Result.Count);
        }
        #endregion

        #region Add Contact Info

        [Fact]
        public void AddContactInfo_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var existingGuid = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200";
            var typeMissingItem = new CommunicationInfo()
            {
                Detail = "Detail"
            };
            _controller.ModelState.AddModelError("InfoType", "Required");
            // Act
            var badResponse = _controller.AddContactInfo(existingGuid, typeMissingItem).Result;
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void AddContactInfo_ExistingObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var existingGuid = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200";
            var exissingItem = new CommunicationInfo()
            {
                Detail = "asya.ilkturk@gmail.com",
                InfoType = CommunationInfoType.Email
            };
            // Act
            var badResponse = _controller.AddContactInfo(existingGuid, exissingItem).Result;
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }

        [Fact]
        public void AddContactInfo_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var existingGuid = "33704c4a-5b87-464c-bfb6-51971b4d18ad";
            var testItem = new CommunicationInfo()
            {
                Detail = "johndoe@gmail.com",
                InfoType = CommunationInfoType.Email
            };

            // Act
            var noContentResponse = _controller.AddContactInfo(existingGuid,testItem).Result;
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }

        [Fact]
        public void AddContactInfo_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var existingGuid = "33704c4a-5b87-464c-bfb6-51971b4d18ad";
            var testItem = new CommunicationInfo()
            {
                Detail = "johndoe@gmail.com",
                InfoType = CommunationInfoType.Email
            };
            // Act
            var noContentResponse = _controller.AddContactInfo(existingGuid, testItem).Result as NoContentResult;

            // Assert
            Assert.Equal("johndoe@gmail.com", _repo.GetAsync(existingGuid).Result.CommunicationInfo.Find(x => x.InfoType == CommunationInfoType.Email).Detail);
        }
        #endregion

        #region Delete Contact Info

        [Fact]
        public void DeleteContactInfo_NotExistingGuidPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var notExistingGuid = Guid.NewGuid().ToString();
            // Act
            var badResponse = _controller.Delete(notExistingGuid);
            // Assert
            Assert.IsType<NotFoundResult>(badResponse.Result);
        }

        [Fact]
        public void DeleteContactInfo_ExistingGuidPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingGuid = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200";
            // Act
            var noContentResponse = _controller.DeleteContactInfo(existingGuid);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse.Result);
        }

        [Fact]
        public void DeleteContactInfo_ExistingGuidPassed_ClearsContactInfo()
        {
            // Arrange
            var existingGuid = "ab2bd817-98cd-4cf3-a80a-53ea0cd9c200";
            // Act
            _ = _controller.DeleteContactInfo(existingGuid);
            // Assert
            Assert.Empty(_repo.GetAsync("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200").Result.CommunicationInfo);
        }
        #endregion

    }
}