using AutomatedTests.Utils;
using Flurl.Http;
using Xunit;

namespace AutomatedTests.ApiTests
{
    public class GetUserByIdTests
    {
        [Fact]
        //Get user by id erxisting user response is not empty
        public async void GetUserById_ExistingUser_ResponseIsNotEmpty()
        {
            var userId = "1";
            var userResponse = await ApiUtils.SendGetUserByIdRequest(userId);
            Assert.NotNull(userResponse);
            Assert.Equal(userResponse.user.id, userId);
        }
        
        [Fact]
        //Get User by Id Non existing User_Http error 404
        public async void GetUserById_NonExistingUser_HttpError404()
        {
            await TestUtils.AssertExceptionHttpStatusCode(async () => await ApiUtils.SendGetUserByIdRequest("12345"), 404);
        }
    }
}