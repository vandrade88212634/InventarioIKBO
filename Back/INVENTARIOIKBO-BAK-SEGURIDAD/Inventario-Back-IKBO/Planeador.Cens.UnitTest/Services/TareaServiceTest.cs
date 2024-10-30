using Xunit;
using Moq;
using Dominio.Servicio.Servicios;
using Infraestructura.Core.UnitOfWork.Interface;
using Infraestructura.Entity.Entities;
using Dominio.Servicio.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using Common.Utils.Resources;
using System.Linq.Expressions;

namespace Dominio.Servicio.Tests
{
    public class TareaServicesTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly TareaServices _tareaServices;

        public TareaServicesTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _tareaServices = new TareaServices(_mockUnitOfWork.Object);
        }

        [Fact]
        public void GetallTarea_ShouldReturnAllTareas()
        {
            // Arrange
            var tareaEntities = new List<TareaEntity>
            {
                new TareaEntity { IdTarea = 1, Estado = "Pendiente", FechaEntrega = DateTime.Now, descripcion = "Test 1", Idusuario = 1 },
                new TareaEntity { IdTarea = 2, Estado = "Completada", FechaEntrega = DateTime.Now, descripcion = "Test 2", Idusuario = 2 }
            };

            _mockUnitOfWork.Setup(uow => uow.TareaRepository.AsQueryable())
                .Returns(tareaEntities.AsQueryable());

            _mockUnitOfWork.Setup(uow => uow.UsuariosRepository.Find(It.IsAny<Expression<Func<UsuariosEntity, bool>>>()))
     .Returns(new UsuariosEntity { Nombre = "Usuario Test" });

            // Act
            var result = _tareaServices.GetallTarea();

            // Xunit.Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(2, result.Count);
            Xunit.Assert.Equal("Pendiente", result[0].Estado);
        }

        [Fact]
        public void GetTareaById_ShouldReturnCorrectTarea_WhenTareaExists()
        {
            // Arrange
            var tareaEntity = new TareaEntity { IdTarea = 1, Estado = "Pendiente", FechaEntrega = DateTime.Now, descripcion = "Test 1", Idusuario = 1 };
            _mockUnitOfWork.Setup(uow => uow.TareaRepository.AsQueryable())
                .Returns(new List<TareaEntity> { tareaEntity }.AsQueryable());

            _mockUnitOfWork.Setup(uow => uow.UsuariosRepository.Find(It.IsAny<Expression<Func<UsuariosEntity, bool>>>()))
    .Returns(new UsuariosEntity { Nombre = "Usuario Test" });

            // Act
            var result = _tareaServices.GetTareaById(1);

            // Xunit.Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(1, result.IdTarea);
            Xunit.Assert.Equal("Pendiente", result.Estado);
        }

        [Fact]
        public void GetTareaById_ShouldReturnNull_WhenTareaDoesNotExist()
        {
            // Arrange
            _mockUnitOfWork.Setup(uow => uow.TareaRepository.AsQueryable())
                .Returns(new List<TareaEntity>().AsQueryable());

            // Act
            var result = _tareaServices.GetTareaById(999);

            // Xunit.Assert
            Xunit.Assert.False(result.IsSucess);
            Xunit.Assert.Equal("Registro No existe", result.Message);
        }

        [Fact]
        public void InsertTarea_ShouldInsertTareaAndReturnSuccess()
        {
            // Arrange
            var tareaDto = new TareaDto { Estado = "Pendiente", FechaEntrega = DateTime.Now, FechaRegistro = DateTime.Now, descripcion = "Test Insert", Idusuario = 1 };

            // Act
            var result = _tareaServices.InsertTarea(tareaDto);

            // Xunit.Assert
            Xunit.Assert.True(result.IsSucess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, result.Message);
            _mockUnitOfWork.Verify(uow => uow.TareaRepository.Insert(It.IsAny<TareaEntity>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void EditTarea_ShouldUpdateTareaAndReturnSuccess()
        {
            // Arrange
            var tareaEntity = new TareaEntity { IdTarea = 1, Estado = "Pendiente", descripcion = "Test Edit", Idusuario = 1 };
            _mockUnitOfWork.Setup(uow => uow.UsuariosRepository.Find(It.IsAny<Expression<Func<UsuariosEntity, bool>>>()))
     .Returns(new UsuariosEntity { Nombre = "Usuario Test" });

            var tareaDto = new TareaDto { IdTarea = 1, Estado = "Completada", descripcion = "Updated", Idusuario = 1 };

            // Act
            var result = _tareaServices.EditTarea(tareaDto);

            // Xunit.Assert
            Xunit.Assert.True(result.IsSucess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, result.Message);
            _mockUnitOfWork.Verify(uow => uow.TareaRepository.Update(It.IsAny<TareaEntity>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void DeleteTarea_ShouldDeleteTareaAndReturnSuccess()
        {
            // Arrange
            var tareaEntity = new TareaEntity { IdTarea = 1 };
            _mockUnitOfWork.Setup(uow => uow.UsuariosRepository.Find(It.IsAny<Expression<Func<UsuariosEntity, bool>>>()))
     .Returns(new UsuariosEntity { Nombre = "Usuario Test" });

            var tareaDto = new TareaDto { IdTarea = 1 };

            // Act
            var result = _tareaServices.DeleteTarea(tareaDto);

            // Xunit.Assert
            Xunit.Assert.True(result.IsSucess);
            Xunit.Assert.Equal(GeneralMessages.SussefullyProcess, result.Message);
            _mockUnitOfWork.Verify(uow => uow.TareaRepository.Delete(It.IsAny<TareaEntity>()), Times.Once);
            _mockUnitOfWork.Verify(uow => uow.Save(), Times.Once);
        }

        [Fact]
        public void GetallTareaByUsuario_ShouldReturnTareasForSpecificUser()
        {
            // Arrange
            var tareaEntities = new List<TareaEntity>
            {
                new TareaEntity { IdTarea = 1, Estado = "Pendiente", descripcion = "Test 1", Idusuario = 1 },
                new TareaEntity { IdTarea = 2, Estado = "Completada", descripcion = "Test 2", Idusuario = 1 }
            };

            _mockUnitOfWork.Setup(uow => uow.TareaRepository.AsQueryable())
                .Returns(tareaEntities.AsQueryable());

            _mockUnitOfWork.Setup(uow => uow.UsuariosRepository.AsQueryable())
                .Returns(new List<UsuariosEntity> { new UsuariosEntity { Idusuario = 1, Nombre = "Usuario Test" } }.AsQueryable());

            // Act
            var result = _tareaServices.GetallTareaByUsuario(1);

            // Xunit.Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(2, result.Count);
            Xunit.Assert.Equal("Usuario Test", result[0].NombreUsuario);
        }
    }
}
