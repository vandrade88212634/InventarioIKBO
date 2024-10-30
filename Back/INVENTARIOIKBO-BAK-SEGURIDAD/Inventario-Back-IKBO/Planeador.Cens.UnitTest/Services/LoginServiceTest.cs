using Moq;
using Common.Utils.Utils.Interface;
using Common.Utils.Resources;
using Dominio.Servicio.DTO;
using Dominio.Servicio.Servicios;
using Dominio.Servicio.Servicios.Interfaces;
using Infraestructura.Core.UnitOfWork.Interface;
using Infraestructura.Entity.Entities;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;

public class LoginServiceTests
{
    private readonly LoginService _loginService;
    private readonly Mock<IUnitOfWork> _unitOfWorkMock;
    private readonly Mock<IUtils> _utilsMock;
    private readonly Mock<ITokenService> _tokenServiceMock;

    public LoginServiceTests()
    {
        _unitOfWorkMock = new Mock<IUnitOfWork>();
        _utilsMock = new Mock<IUtils>();
        _tokenServiceMock = new Mock<ITokenService>();

        _loginService = new LoginService(_unitOfWorkMock.Object, _utilsMock.Object, _tokenServiceMock.Object);
    }

    [Fact]
    public async Task Autentication_UserNotFound_ReturnsFailedResult()
    {
        // Arrange
        var autenticaDto = new AutenticaDto { user = "nonexistentUser", password = "password123" };
        _unitOfWorkMock.Setup(u => u.UsuariosRepository.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns((UsuariosEntity)null);

        // Act
        var result = await _loginService.autentication(autenticaDto);

        // Xunit.Assert
        Xunit.Assert.False(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.UserNotFound, result.Messages);
    }

    [Fact]
    public async Task Autentication_UserInactive_ReturnsFailedResult()
    {
        // Arrange
        var autenticaDto = new AutenticaDto { user = "testUser", password = "password123" };
        var userEntity = new UsuariosEntity { Usuario = "testUser", Contraseña = "qOwMMxqbltLU5qIgMbedqg==", Cedula = 12345 };

        _unitOfWorkMock.Setup(u => u.UsuariosRepository.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns(userEntity);

        // Act
        var result = await _loginService.autentication(autenticaDto);

        // Xunit.Assert
        Xunit.Assert.False(result.IsSuccess);
        Xunit.Assert.Equal("El usuario no esta activo", result.Messages);
    }

    [Fact]
    public async Task Autentication_IncorrectPassword_ReturnsFailedResult()
    {
        // Arrange
        var autenticaDto = new AutenticaDto { user = "testUser", password = "wrongPassword" };
        var userEntity = new UsuariosEntity { Usuario = "testUser", Contraseña = "correctPassword", Cedula = 12345 };

        _unitOfWorkMock.Setup(u => u.UsuariosRepository.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns(userEntity);

        // Act
        var result = await _loginService.autentication(autenticaDto);

        // Xunit.Assert
        Xunit.Assert.False(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.IncorrectPassword, result.Messages);
    }

    [Fact]
    public async Task Autentication_Successful_ReturnsSuccessResult()
    {
        // Arrange
        var autenticaDto = new AutenticaDto { user = "testUser", password = "correctPassword" };
        var userEntity = new UsuariosEntity { Usuario = "testUser", Contraseña = "correctPassword", Cedula = 12345, Idusuario = 1, IdRol = 1, Nombre = "Test User" };

        _unitOfWorkMock.Setup(u => u.UsuariosRepository.FirstOrDefault(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns(userEntity);
        _tokenServiceMock.Setup(t => t.GetToken(It.IsAny<AutenticationDto>())).Returns("fake-jwt-token");

        // Act
        var result = await _loginService.autentication(autenticaDto);

        // Xunit.Assert
        Xunit.Assert.True(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, result.Messages);
        Xunit.Assert.Equal("fake-jwt-token", result.Token);
    }

    [Fact]
    public void Remenber_UserNotFound_ReturnsFailedResult()
    {
        // Arrange
        var emailDto = new ObjTextDto { texto = "nonexistentUser" };

        _unitOfWorkMock.Setup(u => u.UsuariosRepository.Find(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns((UsuariosEntity)null);

        // Act
        var result = _loginService.remenber(emailDto);

        // Xunit.Assert
        Xunit.Assert.False(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.UserNotFound, result.Messages);
    }

    [Fact]
    public void Remenber_Successful_ReturnsSuccessResult()
    {
        // Arrange
        var emailDto = new ObjTextDto { texto = "existingUser" };
        var userEntity = new UsuariosEntity { Usuario = "existingUser", Cedula = 1234, Nombre = "Test User" };

        _unitOfWorkMock.Setup(u => u.UsuariosRepository.Find(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns(userEntity);
        _utilsMock.Setup(u => u.GetRandomPassword(It.IsAny<int>())).Returns("newRandomPassword");
        _utilsMock.Setup(u => u.Encrypt(It.IsAny<string>())).Returns("encryptedPassword");

        // Act
        var result = _loginService.remenber(emailDto);

        // Xunit.Assert
        Xunit.Assert.True(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, result.Messages);
        Xunit.Assert.Equal("encryptedPassword", result.Contraseña);
    }
}
