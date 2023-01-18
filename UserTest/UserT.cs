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

        [Fact(DisplayName = "Criar usuário deve retornar o usuário")]
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

        [Fact(DisplayName = "Criar usuário deve retornar erro")]
        public void CreateUser_ReturnError()
        {
            userTest = null;

            _userRepositoryMock.Setup(x => x.CreateUser(userTest)).Throws(new ArgumentNullException("model"));

            Assert.Throws<ArgumentNullException>(() => _userRepository.CreateUser(userTest));
        }

        [Fact(DisplayName = "Deletar usuário deve retornar true")]
        public void DeleteUser_ReturnTrue()
        {
            _userRepositoryMock.Setup(x => x.DeleteUser(userTest.Id)).Returns(true);

            bool result = _userRepository.DeleteUser(userTest.Id);

            Assert.True(result);
        }

        [Fact(DisplayName = "Deletar usuário deve retornar erro")]
        public void DeleteUser_ReturnErro()
        {
            _userRepositoryMock.Setup(x => x.DeleteUser(2)).Throws(new Exception());

            Assert.Throws<Exception>(() => _userRepository.DeleteUser(2));
        }

        [Fact(DisplayName = "Atualizar usuário deve retornar o usuário atualizado")]
        public void UpdateUser_ReturnUser()
        {
            userTest.Name = "Testando123";

            _userRepositoryMock.Setup(x => x.UpdateUser(userTest.Id, userTest)).Returns(userTest);

            User result = _userRepository.UpdateUser(userTest.Id, userTest);

            Assert.Equal(userTest, result);
        }

        [Fact(DisplayName = "Pegar usuário deve retornar o usuário")]
        public void GetUser_ReturnUser()
        {
            _userRepositoryMock.Setup(x => x.GetUser(userTest.Id)).Returns(userTest);

            var result = _userRepository.GetUser(userTest.Id);

            Assert.Equal(userTest, result);
        }

        [Fact(DisplayName = "Pegar usuário deve retornar erro")]
        public void GetUser_ReturnError()
        {
            _userRepositoryMock.Setup(x => x.GetUser(2)).Throws(new Exception());

            Assert.Throws<Exception>(() => _userRepository.GetUser(2));
        }
    }
}