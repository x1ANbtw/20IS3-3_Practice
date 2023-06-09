using BusinessLogic.Services;
using Domain.Interfaces;
using Domain.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Tests
{
    public class UserServiceTest
    {
        private readonly UserService service;
        private readonly Mock<IUserRepository> userRepositoryMoq;

        public UserServiceTest()
        {
            var repositoryWrapperMoq = new Mock<IRepositoryWrapper>();
            userRepositoryMoq = new Mock<IUserRepository>();

            repositoryWrapperMoq.Setup(x => x.User).Returns(userRepositoryMoq.Object);
            service = new UserService(repositoryWrapperMoq.Object); 
        }

        public static IEnumerable<object[]> GetIncorrectUsers()
        {
            return new List<object[]>
            {
                new object[] {new User() { Username = "Test", Password = "Test", FirstName = "Test", LastName = "Test", PhoneNumber = 999999999, Email = "Test", Addres = "Test", RoleId = 1, IsDeleted = false } },
                new object[] {new User() { Username = "", Password = "", FirstName = "", LastName = "", PhoneNumber = 999999999, Email = "Test", Addres = "", RoleId = 1, IsDeleted = false } },
                new object[] {new User() { Username = "Test", Password = "", FirstName = "", LastName = "", PhoneNumber = 999999999, Email = "Test", Addres = "", RoleId = 1, IsDeleted = false } },
            };
        }

        [Fact]
        public async Task CreateAsync_NullUser_ShouldThrowNullArgumentException()
        {
            //act 
            var ex = await Assert.ThrowsAnyAsync<ArgumentNullException>(() => service.Create(null));

            //assert
            Assert.IsType<ArgumentNullException>(ex);
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never());
        }

        [Theory]
        [MemberData(nameof(GetIncorrectUsers))]
        public async Task CreateAsyncNewUserShouldNotCreateNewUser(User user)
        {
            // arrange
            var newUser = user;


            // act
            var ex = await Assert.ThrowsAnyAsync<ArgumentException>(() => service.Create(newUser));

            // assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Never);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public async Task CreateAsyncNewUserShouldCreateNewUser()
        {
            // arrange
            var newUser = new User()
            {
                Username = "Test",
                Password = "TestPassword",
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = 999999999,
                Email = "Test",
                Addres = "Test",
                RoleId = 1,
                IsDeleted = false
            };


            // act
            await service.Create(newUser);

            // assert
            userRepositoryMoq.Verify(x => x.Create(It.IsAny<User>()), Times.Once);
        }
    }
}
