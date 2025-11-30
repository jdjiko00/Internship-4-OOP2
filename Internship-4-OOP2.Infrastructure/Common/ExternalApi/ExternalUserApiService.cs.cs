using Internship_4_OOP2.Doimain.Entities;
using Internship_4_OOP2.Doimain.Persistence.Users;
using System.Net.Http.Json;

namespace Internship_4_OOP2.Infrastructure.Common.ExternalApi
{
    public class ExternalUserApiService : IExternalUserApiService
    {
        private const string CacheKey = "ExternalUsersCache";
        private readonly HttpClient _httpClient;
        private readonly IMemoryCacheService _cache;
        private readonly IUserUnitOfWork _unitOfWork;

        public ExternalUserApiService(HttpClient httpClient,
                                      IMemoryCacheService cache,
                                      IUserUnitOfWork unitOfWork)
        {
            _httpClient = httpClient;
            _cache = cache;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<User>> GetExternalUsersAsync()
        {
            if (_cache.TryGetValue<IEnumerable<User>>(CacheKey, out var cachedUsers))
            {
                return cachedUsers;
            }

            var response = await _httpClient.GetAsync("https://jsonplaceholder.typicode.com/users");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Vanjski API nije dostupan.", null, response.StatusCode);
            }

            var externalUsers = await response.Content.ReadFromJsonAsync<List<ExternalUserDto>>();

            if (externalUsers == null)
                return new List<User>();

            var usersToSave = new List<User>();

            foreach (var external in externalUsers)
            {
                var user = new User(
                    external.Name,
                    external.Username,
                    external.Email,
                    external.Address.Street,
                    external.Address.City,
                    external.Address.Geo.Lat,
                    external.Address.Geo.Lng,
                    external.Website
                );

                usersToSave.Add(user);

                await _unitOfWork.UserRepository.InsertAsync(user);
            }

            await _unitOfWork.SaveAsync();

            var now = DateTime.UtcNow;
            var endOfDay = DateTime.UtcNow.Date.AddDays(1).AddTicks(-1);
            var cacheDuration = endOfDay - now;

            _cache.Set(CacheKey, usersToSave, cacheDuration);

            return usersToSave;
        }

        private class ExternalUserDto
        {
            public string Name { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public ExternalAddress Address { get; set; }
            public string Website { get; set; }
        }

        private class ExternalAddress
        {
            public string Street { get; set; }
            public string City { get; set; }
            public ExternalGeo Geo { get; set; }
        }

        private class ExternalGeo
        {
            public decimal Lat { get; set; }
            public decimal Lng { get; set; }
        }
    }
}
