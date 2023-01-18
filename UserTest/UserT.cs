using Moq;
using UserApi.Data;
using UserApi.Models;
using UserApi.Repository;
using UserApi.Repository.Contracts;

namespace UserTest
{
    public class UserT
    {
        IUserRepository _userRepository;
        Mock<IUserRepository> _userRepositoryMock;
        User userTest;

        public UserT() 
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _userRepository = _userRepositoryMock.Object;

            userTest = new User
            {
                Id = 1,
                Name = "Teste",
                Email = "teste@dev.com",
                Password = "password"
            };
        }

        [Fact(DisplayName= "Criar usu�rio deve retornar o usu�rio")]
        public void CreateUser_ReturnUser()
        {
            // Arrange
            var expected = userTest;
            _userRepositoryMock.Setup(x => x.CreateUser(userTest)).Returns(userTest);

            // Act
            var userCreated = _userRepository.CreateUser(expected);
            
            // Assert
            Assert.Equal(expected, userCreated);
        }
    }
}