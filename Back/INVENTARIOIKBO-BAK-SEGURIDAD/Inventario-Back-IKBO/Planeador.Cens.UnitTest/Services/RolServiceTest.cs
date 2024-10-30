using Dominio.Servicio.DTO;
using Dominio.Servicio.Servicios;
using Infraestructura.Core.UnitOfWork.Interface;
using Infraestructura.Entity.Entities;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RolServiceTests
{
    public class RolServicesTests
    {
        private readonly RolServices _rolServices;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public RolServicesTests()
        {
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _rolServices = new RolServices(_unitOfWorkMock.Object);
        }

        [Fact]
        public void GetallRoles_Returns_ListOfRoles()
        {
            // Arrange
            var roles = new List<RolesEntity>
            {
                new RolesEntity { IdRol = 1, Descripcion = "Admin" },
                new RolesEntity { IdRol = 2, Descripcion = "User" }
            };
            _unitOfWorkMock.Setup(u => u.RolRepository.AsQueryable()).Returns(roles.AsQueryable());

            // Act
            var result = _rolServices.GetallRoles();

            // Xunit.Assert
            Xunit.Assert.Equal(2, result.Count);
            Xunit.Assert.Equal("Admin", result[0].Descripcion);
            Xunit.Assert.Equal("User", result[1].Descripcion);
        }

        [Fact]
        public void GetRolById_RolExists_Returns_RolDto()
        {
            // Arrange
            var roles = new RolesEntity { IdRol = 1, Descripcion = "Admin" };
            _unitOfWorkMock.Setup(u => u.RolRepository.Find(r => r.IdRol == 1)).Returns(roles);

            // Act
            var result = _rolServices.GetRolById(1);

            // Xunit.Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(1, result.IdRol);
            Xunit.Assert.Equal("Admin", result.Descripcion);
        }

        [Fact]
        public void GetRolById_RolDoesNotExist_Returns_Null()
        {
            // Arrange
            _unitOfWorkMock.Setup(u => u.RolRepository.Find(r => r.IdRol == 1)).Returns((RolesEntity)null);

            // Act
            var result = _rolServices.GetRolById(1);

            // Xunit.Assert
            Xunit.Assert.False(result.IsSuccess);
            Xunit.Assert.Equal("User not found", result.Messages);
        }

        [Fact]
        public void DeleteRolById_RolExists_Deletes_Rol()
        {
            // Arrange
            var rol = new RolesEntity { IdRol = 1, Descripcion = "Admin" };
            _unitOfWorkMock.Setup(u => u.RolRepository.Find(r => r.IdRol == 1)).Returns(rol);
            _unitOfWorkMock.Setup(u => u.UsuariosRepository.Find(u => u.Idusuario == 0)).Returns(new UsuariosEntity());

            // Act
            var result = _rolServices.DeleteRolById(1, "testUser");

            // Xunit.Assert
            _unitOfWorkMock.Verify(u => u.RolRepository.Delete(rol), Times.Once);
            _unitOfWorkMock.Verify(u => u.Save(), Times.Once);
            Xunit.Assert.True(result.IsSuccess);
            Xunit.Assert.Equal("Process completed successfully", result.Messages);
        }

        [Fact]
        public void DeleteRolById_RolAssigned_Returns_ErrorMessage()
        {
            // Arrange
            var rol = new RolesEntity { IdRol = 1, Descripcion = "Admin" };
            _unitOfWorkMock.Setup(u => u.RolRepository.Find(r => r.IdRol == 1)).Returns(rol);
            _unitOfWorkMock.Setup(u => u.UsuariosRepository.Find(u => u.Idusuario == 1)).Returns(new UsuariosEntity());

            // Act
            var result = _rolServices.DeleteRolById(1, "testUser");

            // Xunit.Assert
            Xunit.Assert.False(result.IsSuccess);
            Xunit.Assert.Equal("Role is assigned", result.Messages);
        }

        [Fact]
        public void InsertRol_NewRol_Inserts_Rol()
        {
            // Arrange
            var newRol = new RolDto { Descripcion = "New Role" };
            _unitOfWorkMock.Setup(u => u.RolRepository.Find(r => r.Descripcion == newRol.Descripcion)).Returns((RolesEntity)null);

            // Act
            var result = _rolServices.InsertRol(newRol, "testUser");

            // Xunit.Assert
            _unitOfWorkMock.Verify(u => u.RolRepository.Insert(It.IsAny<RolesEntity>()), Times.Once);
            _unitOfWorkMock.Verify(u => u.Save(), Times.Once);
            Xunit.Assert.True(result.IsSuccess);
        }

        // More tests can be added for EditRol, InsertRolesSeguridad, etc.
    }
}

