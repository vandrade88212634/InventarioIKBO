using Common.Utils.RestServices.Interface;
using Dominio.Servicio.DTO.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using Infraestructura.Core.UnitOfWork.Interface;
using Dominio.Servicio.DTO;
using Infraestructura.Entity.Entities;
using Dominio.Servicio.Servicios.Interfaces;


namespace Dominio.Servicio.Servicios
{
    public class InventarioIKBOServices : IInventarioIKBOServices
    {

        #region Atributos

        public readonly IUnitOfWork unitOfWork;

        #endregion Atributos

        #region Constructor 
        public InventarioIKBOServices(
            IUnitOfWork unitOfWork
            )
        {
            this.unitOfWork = unitOfWork;

        }

        #endregion coonstructor

        #region Metodos

        public ProductoDto Insertproducto(ProductoDto producto)
        { 
            if (producto.Nombre == "")
            {
                producto.IsSucess = false;
                producto.Message = "El nombre no debe ir vacio..";
                return producto;
            }
            ProductoEntity productoDato = new ProductoEntity();
            productoDato.Nombre = producto.Nombre;
            this.unitOfWork.ProductoRepository.Insert( productoDato );
            this.unitOfWork.Save();
            producto.IsSucess = true;
            producto.Message = "Producto creado con Exito";
            return producto;
        }

        

        public List<ExistenciasDto> Existencias(ProductoDto producto)
        {
            List<ExistenciasDto> Lista = new List<ExistenciasDto>();
            /*
            if (producto.Nombre == "")
            {
                ExistenciasDto existencias = new ExistenciasDto();
                existencias.IsSucess = false;
                
                Lista.Add( existencias );
                existencias.Message = "El nombre no debe ir vacio..";
                return Lista;
            }
            */
             Lista = (from pf in this.unitOfWork.ProductoFechaRepository.AsQueryable()
                                          join p in this.unitOfWork.ProductoRepository.AsQueryable() on pf.IdProducto equals p.IdProducto
                                          where p.Nombre.Contains(producto.Nombre.Trim())
                                          select new ExistenciasDto
                                          {
                                           IdProducto = pf.IdProducto,
                                           Nombre = p.Nombre,
                                           FechaVence = pf.FechaVence,
                                           saldo= pf.Saldo


                                          }).ToList();

                    foreach(var iLista in Lista)
                        {
                TimeSpan diferencia = iLista.FechaVence - DateTime.Now;
                if (diferencia.Days <= 0)
                    iLista.NombreEstado = "Vencido";
                if (diferencia.Days > 0 && diferencia.Days <= 60)
                    iLista.NombreEstado = "Por vencer";
                if (diferencia.Days >= 60)
                    iLista.NombreEstado = "Vigente";


            }

           
            return Lista;
        }

        public MvtoDto InsertEntrada(MvtoDto entrada)

        {
            if (entrada.Cantidad < 0)
            {
                entrada.IsSucess = false;
                entrada.Message = "La cantidad no Puede ser negativa";
                return entrada;

            }
            //Primero Miramos si trae idproductofeha
            if (entrada.IdProductoFecha == 0)
            {
                // Insertamos el registro en Producto fecha
                ProductoFechaEntity productoFecha = new ProductoFechaEntity();
                productoFecha.IdProducto = entrada.IdProducto;
                productoFecha.FechaVence = entrada.Fechavence;
                productoFecha.Saldo = entrada.Cantidad;
                this.unitOfWork.ProductoFechaRepository.Insert(productoFecha);
                this.unitOfWork.Save();
                int IdProductoFecha = this.unitOfWork.ProductoFechaRepository.AsQueryable().OrderBy(p=> p.IdProducto).LastOrDefault().IdProductoFecha;
                entrada.IdProductoFecha= IdProductoFecha;


            }
            else
            {
                ProductoFechaEntity productoFecha = this.unitOfWork.ProductoFechaRepository.Find(pf => pf.IdProductoFecha == entrada.IdProductoFecha);
                productoFecha.Saldo = productoFecha.Saldo + entrada.Cantidad;
            }

            MvtoEntity mvtodato= new MvtoEntity();
            mvtodato.Fecha = entrada.Fecha;
            mvtodato.Cantidad = entrada.Cantidad;
            mvtodato.IdProductoFecha = entrada.IdProductoFecha;
            mvtodato.IdTipoMvto = 1;
            
            this.unitOfWork.MvtoRepository.Insert(mvtodato);
            this.unitOfWork.Save();
            entrada.IsSucess = true;
            entrada.Message = "Registro de entrada grabado con Exito";






            return entrada;
            
        }

        public MvtoDto InsertSalida(MvtoDto salida)

        {
            if (salida.Cantidad < 0)
            {
                salida.IsSucess = false;
                salida.Message = "La cantidad no Puede ser negativa";
                return salida;

            }
            //Primero Miramos si trae idproductofeha
          
                ProductoFechaEntity productoFecha = this.unitOfWork.ProductoFechaRepository.Find(pf => pf.IdProductoFecha == salida.IdProductoFecha);
            if (productoFecha.Saldo - productoFecha.Saldo < 0)
            {
                salida.IsSucess = false;
                salida.Message = "El saldo no alcanza , Saldo: " + productoFecha.Saldo.ToString();
                return salida;
            }
                productoFecha.Saldo = productoFecha.Saldo - salida.Cantidad;
           

            MvtoEntity mvtodato = new MvtoEntity();
            mvtodato.Fecha = salida.Fecha;
            mvtodato.Cantidad = salida.Cantidad;
            mvtodato.IdProductoFecha = salida.IdProductoFecha;
            mvtodato.IdTipoMvto = 2;

            this.unitOfWork.MvtoRepository.Insert(mvtodato);
            this.unitOfWork.Save();
            salida.IsSucess = true;
            salida.Message = "Registro de entrada grabado con Exito";






            return salida;

        }

        public List<ProductoDto> GetAllProductos()
        {
            List<ProductoDto> listaProducto = (from p in this.unitOfWork.ProductoRepository.AsQueryable()
                                               select new ProductoDto
                                               { 
                                               IdProducto = p.IdProducto,
                                               Nombre = p.Nombre
                                               
                                               }).ToList();

            return listaProducto;
        }


        public List<ProductoFechaDto> GetAllProductoFechaByIdProducto(int IdProducto)
        {
            List<ProductoFechaDto> listaFechas = (from pf in this.unitOfWork.ProductoFechaRepository.AsQueryable()
                                                  where pf.IdProducto == IdProducto
                                               select new ProductoFechaDto
                                               {
                                                   IdProducto = pf.IdProducto,
                                                   IdProductoFecha = pf.IdProductoFecha,
                                                   FechaVence = pf.FechaVence,
                                                   Saldo = pf.Saldo
                                                   

                                               }).ToList();

            return listaFechas;
        }

        #endregion Metodos


    }
}
