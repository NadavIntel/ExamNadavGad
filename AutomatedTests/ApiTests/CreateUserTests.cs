using AutomatedTests.Models;
using AutomatedTests.Utils;
using Xunit;

namespace AutomatedTests.ApiTests
{
    public class CreateUserTests
    {
        [Fact]
        //Create user happy flow success status code 201
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
        //Create user no age no name status code 400
        public async void CreateUser_NoAgeNoName_StatusCode400()
        {
            var user = new User();
            
            await TestUtils.AssertExceptionHttpStatusCode(async () => await ApiUtils.SendCreateUserRequest(user), 400);
        }
        
        
        [Fact]
        //Create user no age status code 400
        public async void CreateUser_NoAge_StatusCode400()
        {
            var user = new User
            {
                name = "tal"
            };

            await TestUtils.AssertExceptionHttpStatusCode(async () => await ApiUtils.SendCreateUserRequest(user), 400);
        }
        
        [Fact]
        //Create user no name status code 400
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