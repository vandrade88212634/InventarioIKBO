using Xunit;
using Moq;
using System.Collections.Generic;
using Dominio.Servicio.Servicios;
using Infraestructura.Core.UnitOfWork.Interface;
using Common.Utils.Utils.Interface;
using Infraestructura.Entity.Entities;
using Dominio.Servicio.DTO;
using System.Linq;
using Common.Utils.Resources;
using System.Xml;

public class UsuariosServicesTests
{
    private readonly Mock<IUnitOfWork> _mockUnitOfWork;
    private readonly Mock<IUtils> _mockUtils;
    private readonly UsuariosServices _usuariosService;

    public UsuariosServicesTests()
    {
        _mockUnitOfWork = new Mock<IUnitOfWork>();
        _mockUtils = new Mock<IUtils>();
        _usuariosService = new UsuariosServices(_mockUnitOfWork.Object, _mockUtils.Object);
    }

    [Fact]
    public void GetAllUser_ShouldReturnListOfUsers()
    {
        // Arrange
        var users = new List<UsuariosEntity>
        {
            new UsuariosEntity { Idusuario = 1, Cedula = 123, Nombre = "Test User 1", Usuario = "testuser1", IdRol = 1 },
            new UsuariosEntity { Idusuario = 2, Cedula = 456, Nombre = "Test User 2", Usuario = "testuser2", IdRol = 2 }
        };

        var roles = new List<RolesEntity>
        {
            new RolesEntity { IdRol = 1, Descripcion = "Admin" },
            new RolesEntity { IdRol = 2, Descripcion = "User" }
        };

        _mockUnitOfWork.Setup(u => u.UsuariosRepository.AsQueryable()).Returns(users.AsQueryable());
        _mockUnitOfWork.Setup(u => u.RolRepository.AsQueryable()).Returns(roles.AsQueryable());

        // Act
        var result = _usuariosService.GetAllUser();

        // Xunit.Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.Equal(2, result.Count);
        Xunit.Assert.Equal("Admin", result[0].DescRol);
        Xunit.Assert.Equal("User", result[1].DescRol);
    }

    [Fact]
    public void GetUserById_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var user = new UsuariosEntity { Idusuario = 1, Cedula = 123, Nombre = "Test User", Usuario = "testuser", IdRol = 1 };
        var role = new RolesEntity { IdRol = 1, Descripcion = "Admin" };

        _mockUnitOfWork.Setup(u => u.UsuariosRepository.Find(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns(user);
        _mockUnitOfWork.Setup(u => u.RolRepository.AsQueryable()).Returns(new List<RolesEntity> { role }.AsQueryable());

        // Act
        var result = _usuariosService.GetUserById(1);

        // Xunit.Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.True(result.IsSuccess);
        Xunit.Assert.Equal("Test User", result.Nombre);
        Xunit.Assert.Equal("Admin", result.DescRol);
    }

    [Fact]
    public void GetUserById_ShouldReturnUserNotFound_WhenUserDoesNotExist()
    {
        // Arrange
        _mockUnitOfWork.Setup(u => u.UsuariosRepository.Find(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns((UsuariosEntity)null);

        // Act
        var result = _usuariosService.GetUserById(1);

        // Xunit.Assert
        Xunit.Assert.NotNull(result);
        Xunit.Assert.False(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.UserNotFound, result.Messages);
    }

    [Fact]
    public void Insertusuario_ShouldInsertUser_WhenUserDoesNotExist()
    {
        // Arrange
        var newUser = new UsuariosDto { Cedula = 789, Nombre = "New User", Usuario = "newuser", IdRol = 1 };

        _mockUnitOfWork.Setup(u => u.UsuariosRepository.Find(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns((UsuariosEntity)null);
        _mockUtils.Setup(u => u.Encrypt(It.IsAny<string>())).Returns("encrypted_password");

        // Act
        var result = _usuariosService.Insertusuario(newUser);

        // Xunit.Assert
        Xunit.Assert.True(result.IsSuccess);
        Xunit.Assert.Equal("encrypted_password", result.Contraseña);
    }

    [Fact]
    public void Insertusuario_ShouldReturnError_WhenUserAlreadyExists()
    {
        // Arrange
        var existingUser = new UsuariosEntity { Cedula = 123, Nombre = "Existing User" };

        _mockUnitOfWork.Setup(u => u.UsuariosRepository.Find(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns(existingUser);

        var newUser = new UsuariosDto { Cedula = 123, Nombre = "New User", Usuario = "newuser" };

        // Act
        var result = _usuariosService.Insertusuario(newUser);

        // Xunit.Assert
        Xunit.Assert.False(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.ReadyUser, result.Messages);
    }

    [Fact]
    public void Editusuario_ShouldUpdateUser_WhenUserExists()
    {
        // Arrange
        var existingUser = new UsuariosEntity { Idusuario = 1, Cedula = 123, Nombre = "Test User", Usuario = "testuser" };

        _mockUnitOfWork.Setup(u => u.UsuariosRepository.Find(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns(existingUser);

        var updatedUser = new UsuariosDto { Idusuario = 1, Cedula = 123, Nombre = "Updated User", Usuario = "updateduser" };

        // Act
        var result = _usuariosService.Editusuario(updatedUser);

        // Xunit.Assert
        Xunit.Assert.True(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, result.Messages);
    }

    [Fact]
    public void DeleteUser_ShouldDeleteUser_WhenUserExists()
    {
        // Arrange
        var existingUser = new UsuariosEntity { Idusuario = 1, Cedula = 123, Nombre = "Test User", Usuario = "testuser" };

        _mockUnitOfWork.Setup(u => u.UsuariosRepository.Find(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns(existingUser);

        // Act
        var result = _usuariosService.DeleteUser(1);

        // Xunit.Assert
        Xunit.Assert.True(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, result.Messages);
    }

    [Fact]
    public void DeleteUser_ShouldReturnError_WhenUserDoesNotExist()
    {
        // Arrange
        _mockUnitOfWork.Setup(u => u.UsuariosRepository.Find(It.IsAny<System.Linq.Expressions.Expression<System.Func<UsuariosEntity, bool>>>())).Returns((UsuariosEntity)null);

        // Act
        var result = _usuariosService.DeleteUser(1);

        // Xunit.Assert
        Xunit.Assert.False(result.IsSuccess);
        Xunit.Assert.Equal(GeneralMessages.UserNotFound, result.Messages);
    }
}

