using Internship_4_OOP2.Application.Common.Interfaces;
using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Infrastructure.Common.Caching;
using System.Net.Http.Json;

namespace Internship_4_OOP2.Infrastructure.Common.ExternalApi
{
    public class ExternalUserApiService : IExternalUserApiService
    {
        private const string CacheKey = "ExternalUsersCache";
        private readonly HttpClient _httpClient;
        private readonly IMemoryCacheService _cacheService;

        public ExternalUserApiService(HttpClient httpClient, IMemoryCacheService cacheService)
        {
            _httpClient = httpClient;
            _cacheService = cacheService;
        }

        public async Task<List<User>> GetExternalUsersAsync()
        {
            var cached = await _cacheService.GetAsync<List<User>>(CacheKey);
            if (cached != null)
                return cached;

            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (!response.IsSuccessStatusCode)
                throw new HttpRequestException("Vanjski API nije dostupan", null, response.StatusCode);

            var externalUsers = await response.Content.ReadFromJsonAsync<List<ExternalUserDto>>();

            var mappedUsers = new List<User>();
            foreach (var eu in externalUsers)
            {
                mappedUsers.Add(new User(
                    name: eu.Name,
                    username: eu.Username,
                    email: eu.Email,
                    addressStreet: eu.Address?.Street,
                    addressCity: eu.Address?.City,
                    geoLat: decimal.Parse(eu.Address?.Geo?.Lat ?? "0"),
                    geoLng: decimal.Parse(eu.Address?.Geo?.Lng ?? "0"),
                    website: eu.Website
                ));
            }

            var endOfDay = DateTime.Now.Date.AddDays(1);
            var duration = endOfDay - DateTime.Now;

            await _cacheService.SetAsync(CacheKey, mappedUsers, duration);

            return mappedUsers;
        }

        private class ExternalUserDto
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public ExternalAddressDto Address { get; set; }
            public string Website { get; set; }
        }

        private class ExternalAddressDto
        {
            public string Street { get; set; }
            public string City { get; set; }
            public ExternalGeoDto Geo { get; set; }
        }

        private class ExternalGeoDto
        {
            public string Lat { get; set; }
            public string Lng { get; set; }
        }
    }
}
