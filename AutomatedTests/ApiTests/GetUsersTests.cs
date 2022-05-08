using AutomatedTests.Utils;
using Xunit;

namespace AutomatedTests.ApiTests
{
    public class GetUsersTests
    {
        [Fact]
        public async void GetUsers_HappyFlow_ResponseIsNotEmpty()
        {
            var usersList = await ApiUtils.SendGetUsersRequest();
            Assert.NotNull(usersList);
            Assert.True(usersList.users.Length > 0);
        }
    }
}