using AutomatedTests.Models;
using AutomatedTests.Utils;
using Xunit;

namespace AutomatedTests.ApiTests
{
    public class CreateUserTests
    {
        [Fact]
        public async void CreateUser_HappyFlow_SuccessStatusCode201()
        {
            var user = new User
            {
                name = "tal",
                age = "22"
            };
            
            var response = await ApiUtils.SendCreateUserRequest(user);
            Assert.Equal(201, response.StatusCode);
        }
        
        [Fact]
        public async void CreateUser_NoAgeNoName_StatusCode400()
        {
            var user = new User();
            
            await TestUtils.AssertExceptionHttpStatusCode(async () => await ApiUtils.SendCreateUserRequest(user), 400);
        }
        
        
        [Fact]
        public async void CreateUser_NoAge_StatusCode400()
        {
            var user = new User
            {
                name = "tal"
            };

            await TestUtils.AssertExceptionHttpStatusCode(async () => await ApiUtils.SendCreateUserRequest(user), 400);
        }
        
        [Fact]
        public async void CreateUser_NoName_StatusCode400()
        {
            var user = new User
            {
                age = "22"
            };

            await TestUtils.AssertExceptionHttpStatusCode(async () => await ApiUtils.SendCreateUserRequest(user), 400);
        }
    }
}