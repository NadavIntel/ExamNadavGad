using System.Collections.Generic;
using System.Threading.Tasks;
using AutomatedTests.Models;
using Flurl;
using Flurl.Http;

namespace AutomatedTests.Utils
{
    public static class ApiUtils
    {
        private const string ServerHost = "localhost";
        private const int ServerPort = 8081;
        private static readonly string ServerAddr = "http://" + ServerHost + ":" + ServerPort;

        private const string GetUsersPath = "users";
        private const string CreateUsersPath = "create";

        //Send Get Users Request
        public static Task<UsersList> SendGetUsersRequest()
        {
            return ApiGetRequest<UsersList>(GetUsersPath);
        }

        //Send Get User By Id Request
        public static Task<UserResponse> SendGetUserByIdRequest(string id)
        {
            return ApiGetRequest<UserResponse>(GetUsersPath, id);
        }

        //Send Update User Request
        public static Task<UserResponse> SendUpdateUserRequest(string id, User user)
        {
            return ApiPutRequest<UserResponse>(GetUsersPath + "/" + id, user);
        }

        //Send Create User Request
        public static Task<IFlurlResponse> SendCreateUserRequest(User user)
        {
            return ApiPostRequest(CreateUsersPath, user);
        }

        //Api Get Request
        private static async Task<T> ApiGetRequest<T>(params string[] segments)
        {
            return await ServerAddr
                .AppendPathSegments(segments)
                .GetJsonAsync<T>();
        }

        //Api Put Request
        private static async Task<T> ApiPutRequest<T>(string segment, object data)
        {
            return await ServerAddr
                .AppendPathSegment(segment)
                .PutJsonAsync(data)
                .ReceiveJson<T>();
        }

        //Api Post Request
        private static async Task<IFlurlResponse> ApiPostRequest(string segment, object data)
        {
            return await ServerAddr
                .AppendPathSegment(segment)
                .PostJsonAsync(data);
        }


    }
}