//------------------------------------------------------------------------------
// <copyright file="IFilterConditional.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;

namespace Ucu.Poo.PipesAndFilters
{
    /// <summary>
    /// Un filtro que recibe, procesa y retorna imágenes. El filtro puede
    /// retornar la misma imagen o una nueva imagen creada por él.
    /// </summary>
    public interface IFilterConditional : IFilter
    {
        /// <summary>
        /// Obtiene el resultado de la condicion.
        /// </summary>
        bool Result { get; }
    }
}