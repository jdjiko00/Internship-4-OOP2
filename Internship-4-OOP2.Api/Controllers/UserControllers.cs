using Internship_4_OOP2.Application.Common.Interfaces;
using Internship_4_OOP2.Doimain.Persistence.Users;
using Microsoft.AspNetCore.Mvc;

namespace Internship_4_OOP2.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IExternalUserApiService _externalUserApiService;

        public UsersController(IUserUnitOfWork userUnitOfWork, IExternalUserApiService externalUserApiService)
        {
            _userUnitOfWork = userUnitOfWork;
            _externalUserApiService = externalUserApiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var usersFromDb = await _userUnitOfWork.UserRepository.Get();

            if (usersFromDb.Values == null || !usersFromDb.Values.Any())
            {
                var externalUsers = await _externalUserApiService.GetExternalUsersAsync();

                foreach (var user in externalUsers)
                {
                    await _userUnitOfWork.UserRepository.InsertAsync(user);
                }

                await _userUnitOfWork.SaveAsync();

                usersFromDb = await _userUnitOfWork.UserRepository.Get();
            }

            return Ok(usersFromDb.Values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userUnitOfWork.UserRepository.GetById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}
