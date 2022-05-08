using System.Linq;
using AutomatedTests.Models;
using AutomatedTests.Utils;
using Newtonsoft.Json;
using Xunit;

namespace AutomatedTests.ApiTests
{
    public class SanityFlowsTests
    {
        [Fact]
        public async void SanityFlowTest()
        {
            // Get all users
            var usersListBefore = await ApiUtils.SendGetUsersRequest();

            string userId = (usersListBefore.users.Length + 1).ToString();
            // Create new user
            var user = new User
            {
                id = userId,
                name = "tal",
                age = "22"
            };
            await ApiUtils.SendCreateUserRequest(user);
            
            // Get all users again and check that the user was added
            var usersListAfter = await ApiUtils.SendGetUsersRequest();
            
            Assert.Equal(usersListBefore.users.Length + 1, usersListAfter.users.Length);
            Assert.Equal(JsonConvert.SerializeObject(user), JsonConvert.SerializeObject(usersListAfter.users.Last()));
            
            // Also get new user by id
            var userResponse = await ApiUtils.SendGetUserByIdRequest(userId);
            Assert.Equal(JsonConvert.SerializeObject(user), JsonConvert.SerializeObject(userResponse.user));
        }
    }
}