using Moq;
using Xunit;
using planeador.seguridad.webapi.Controllers;
using planeador.seguridad.webapi.Models;
using Dominio.Servicio.DTO;
using Domain.Service.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Common.Utils.Utils.Interface;
using Common.Utils.Resources;
using Dominio.Servicio.Servicios.Interfaces;

namespace planeador.seguridad.webapi.Tests
{
    public class LoginControllerTests
    {
        private readonly LoginController _loginController;
        private readonly Mock<ILoginService> _loginServiceMock;

        public LoginControllerTests()
        {
            // Inicializamos los mocks
            _loginServiceMock = new Mock<ILoginService>();

            // Creamos una instancia del LoginController con el mock
            _loginController = new LoginController(_loginServiceMock.Object);
        }

        [Fact]
        public async Task Autentication_ReturnsOk_WhenUserIsAuthenticated()
        {
            // Arrange
            var authDto = new AutenticaDto { user = "test", password = "password" };
            var expectedResult = new AutenticationDto { IsSuccess = true, Messages = GeneralMessages.SussefullyProcess };

            _loginServiceMock.Setup(service => service.autentication(It.IsAny<AutenticaDto>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _loginController.Autentication(authDto);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<AutenticationDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, response.Messages);
        }

        [Fact]
        public async Task Autentication_ReturnsOk_WhenUserAuthenticationFails()
        {
            // Arrange
            var authDto = new AutenticaDto { user = "test", password = "wrongpassword" };
            var expectedResult = new AutenticationDto { IsSuccess = false, Messages = "Clave Erronea" };

            _loginServiceMock.Setup(service => service.autentication(It.IsAny<AutenticaDto>()))
                .ReturnsAsync(expectedResult);

            // Act
            var result = await _loginController.Autentication(authDto);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<AutenticationDto>>(okResult.Value);
            Xunit.Assert.False(response.IsSuccess);
            Xunit.Assert.Equal("Clave Erronea", response.Messages);
        }

        [Fact]
        public async Task Remenber_ReturnsOk_WhenUserIsFound()
        {
            // Arrange
            var emailDto = new ObjTextDto { texto = "test@example.com" };
            var expectedResult = new UsuariosDto { IsSuccess = true, Messages = GeneralMessages.SussefullyProcess };

            _loginServiceMock.Setup(service => service.remenber(It.IsAny<ObjTextDto>()))
                .Returns(expectedResult);

            // Act
            var result = await _loginController.remenber(emailDto);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<UsuariosDto>>(okResult.Value);
            Xunit.Assert.True(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, response.Messages);
        }

        [Fact]
        public async Task Remenber_ReturnsOk_WhenUserIsNotFound()
        {
            // Arrange
            var emailDto = new ObjTextDto { texto = "notfound@example.com" };
            var expectedResult = new UsuariosDto { IsSuccess = false, Messages = GeneralMessages.UserNotFound };

            _loginServiceMock.Setup(service => service.remenber(It.IsAny<ObjTextDto>()))
                .Returns(expectedResult);

            // Act
            var result = await _loginController.remenber(emailDto);

            // Xunit.Assert
            var okResult = Xunit.Assert.IsType<OkObjectResult>(result);
            var response = Xunit.Assert.IsType<ResponseModel<UsuariosDto>>(okResult.Value);
            Xunit.Assert.False(response.IsSuccess);
            Xunit.Assert.Equal(GeneralMessages.UserNotFound, response.Messages);
        }
    }
}

