using Domain.Models;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendApi.Contracts.User;
using Mapster;

namespace BackendApi.Controllers
{
    [Route(template:"api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Получение данных по всем пользователям
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userService.GetAll());
        }
        /// <summary>
        /// Получение данных по пользователю через id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// Get /Todo
        /// {
        /// "userId" : "1",
        /// }
        ///
        /// </remarks>
        [HttpGet(template: "{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = new GetUserResponse();
            var responseResult = response.Adapt<User>();
            return Ok(responseResult);
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// POST /Todo
        /// {
        /// "login" : "user1",
        /// "password" : "!Pa$$word123@",
        /// "firstname" : "Иван",
        /// "lastname" : "Иванов",
        /// "phonenumber" : "89999999999"
        /// "email" : "who@gmail.com"
        /// "address" : "г.Москва, Тверская улица, дом 13"
        /// "RoleID" : "1"
        /// "IsDeleted" : "0"
        /// }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>
        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Create(userDto);
            return Ok();
        }
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     PUT /Todo
        ///     {
        ///         "login" : "user1",
        ///         "password" : "!Pa$$word123@",
        ///         "firstname" : "Иван",
        ///         "lastname" : "Иванов",
        ///         "phonenumber" : "89999999990"
        ///         "email" : "who1@gmail.com"
        ///         "address" : "г.Москва, Тверская улица, дом 14"
        ///         "RoleID" : "1"
        ///         "IsDeleted" : "0"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // PUT api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(CreateUserRequest request)
        {
            var userDto = request.Adapt<User>();
            await _userService.Update(userDto);
            return Ok();
        }
        /// <summary>
        /// Удаление записи по id
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        /// Delete /Todo
        /// {
        /// "userId" : "1",
        /// }
        ///
        /// </remarks>
        // DELETE api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
