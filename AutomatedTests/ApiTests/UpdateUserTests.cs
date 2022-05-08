using AutomatedTests.Models;
using AutomatedTests.Utils;
using Xunit;

namespace AutomatedTests.ApiTests
{
    public class UpdateUserTests
    {
        [Fact]
        public async void UpdateUser_ExistingUser_SuccessCode200()
        {
            var user = new User
            {
                name = "tal",
                age = "22"
            };
            
            var userResponse = await ApiUtils.SendUpdateUserRequest("1", user);
            Assert.NotNull(userResponse.message);
            Assert.Equal(user.name, userResponse.user.name);
            Assert.Equal(user.age, userResponse.user.age);
        }
        
        [Fact]
        public async void UpdateUser_NonExistingUser_HttpError404()
        {
            var user = new User
            {
                name = "tal",
                age = "11"
            };
            
            await TestUtils.AssertExceptionHttpStatusCode(async () => await ApiUtils.SendUpdateUserRequest("12345", user), 404);
        }
    }
}