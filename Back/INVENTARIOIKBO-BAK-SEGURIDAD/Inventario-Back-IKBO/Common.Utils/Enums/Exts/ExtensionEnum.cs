// ***********************************************************************
// Assembly         : Common.Utils
// Author           : Luis Carlos Uribe Lozano
// Created          : 07-21-2020
//
// Last Modified By : Luis Carlos Uribe Lozano
// Last Modified On : 07-21-2020
// ***********************************************************************
// <copyright file="ExtensionEnum.cs" company="Common.Utils">
//     Copyright (c) Ingeneo SAS. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Common.Utils.Enums.Exts
{
    #region Métodos Públicos

    /// <summary>
    /// Clase que se encarga de recuperar el decorado StrigValue de los enumeradores
    /// </summary>
    /// <seealso cref="System.Attribute" />
    /// <remarks>Elkin Vasquez Isenia</remarks>
    [ExcludeFromCodeCoverage]
    public class StringValueAttribute : Attribute
    {
        /// <summary>
        /// Inicializa una nueva instancia de la <see cref="StringValueAttribute" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public StringValueAttribute(string value) { Value = value; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <value>The value.</value>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public string Value { get; }
    }

    /// <summary>
    /// Clase para agregar los métodos de extensión de los enumeradores
    /// </summary>
    /// <remarks>Elkin Vasquez Isenia</remarks>
    [ExcludeFromCodeCoverage]
    public static class ExtencionParaEnum
    {
        /// <summary>
        /// Método que recupera la cadena asignada en el decorado del enumerador
        /// </summary>
        /// <param name="value">Enumerador al cual se recuperará el avalor</param>
        /// <returns>System.String.</returns>
        /// <remarks>Elkin Vasquez Isenia</remarks>
        public static string ToStringAttribute(this Enum value)
        {
            var stringValues = new Hashtable();

            string output = null;
            var type = value.GetType();

            //Comprueba si ya existe la búsqueda en caché
            if (stringValues.ContainsKey(value))
            {
                var stringValueAttribute = (StringValueAttribute)stringValues[value];
                if (stringValueAttribute != null)
                    output = stringValueAttribute.Value;
            }
            else
            {
                //Buscar el ToStringAttribute en los atributos personalizados
                System.Reflection.FieldInfo fi = type.GetField(value.ToString());
                var attrs = (StringValueAttribute[])fi.GetCustomAttributes(typeof(StringValueAttribute), false);
                if (attrs.Length <= 0) return null;

                stringValues.Add(value, attrs[0]);
                output = attrs[0].Value;
            }
            return output;
        }
    }

    #endregion Métodos Públicos
}
