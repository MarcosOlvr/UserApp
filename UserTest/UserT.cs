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

        [Fact(DisplayName = "Criar usu�rio deve retornar o usu�rio")]
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

        [Fact(DisplayName = "Criar usu�rio deve retornar erro")]
        public void CreateUser_ReturnError()
        {
            userTest = null;

            _userRepositoryMock.Setup(x => x.CreateUser(userTest)).Throws(new ArgumentNullException("model"));

            Assert.Throws<ArgumentNullException>(() => _userRepository.CreateUser(userTest));
        }

        [Fact(DisplayName = "Deletar usu�rio deve retornar true")]
        public void DeleteUser_ReturnTrue()
        {
            _userRepositoryMock.Setup(x => x.DeleteUser(userTest.Id)).Returns(true);

            bool result = _userRepository.DeleteUser(userTest.Id);

            Assert.True(result);
        }

        [Fact(DisplayName = "Deletar usu�rio deve retornar erro")]
        public void DeleteUser_ReturnErro()
        {
            _userRepositoryMock.Setup(x => x.DeleteUser(2)).Throws(new Exception());

            Assert.Throws<Exception>(() => _userRepository.DeleteUser(2));
        }

        [Fact(DisplayName = "Atualizar usu�rio deve retornar o usu�rio atualizado")]
        public void UpdateUser_ReturnUser()
        {
            userTest.Name = "Testando123";

            _userRepositoryMock.Setup(x => x.UpdateUser(userTest.Id, userTest)).Returns(userTest);

            User result = _userRepository.UpdateUser(userTest.Id, userTest);

            Assert.Equal(userTest, result);
        }

        [Fact(DisplayName = "Pegar usu�rio deve retornar o usu�rio")]
        public void GetUser_ReturnUser()
        {
            _userRepositoryMock.Setup(x => x.GetUser(userTest.Id)).Returns(userTest);

            var result = _userRepository.GetUser(userTest.Id);

            Assert.Equal(userTest, result);
        }

        [Fact(DisplayName = "Pegar usu�rio deve retornar erro")]
        public void GetUser_ReturnError()
        {
            _userRepositoryMock.Setup(x => x.GetUser(2)).Throws(new Exception());

            Assert.Throws<Exception>(() => _userRepository.GetUser(2));
        }
    }
}