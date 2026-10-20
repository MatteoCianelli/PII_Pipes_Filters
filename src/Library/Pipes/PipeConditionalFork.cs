//------------------------------------------------------------------------------
// <copyright file="PipeConditionalFork.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ucu.Poo.PipesAndFilters;
using Ucu.Poo.PipesAndFilters.Filters;

namespace Ucu.Poo.PipesAndFilters.Pipes
{
    /// <summary>
    /// Un pipe que recibe una imagen, le aplica un filtro y la envía a la siguiente pipe
    /// segun el resultado del filtro.
    /// </summary>
    public class PipeConditionalFork : IPipe
    {
        private IPipe truePipe;

        private IPipe falsePipe;

        private IFilterConditional filterConditional;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="PipeConditionalFork"/>.
        /// </summary>
        /// <param name="filterConditional">El filtro condicional que se debe aplicar sobre la imagen.</param>
        /// <param name="truePipe">La siguiente pipe si el resultado es verdadero.</param>
        /// <param name="falsePipe">La siguiente pipe si el resultado es falso.</param>
        public PipeConditionalFork(IFilterConditional filterConditional, IPipe truePipe, IPipe falsePipe)
        {
            this.filterConditional = filterConditional;
            this.truePipe = truePipe;
            this.falsePipe = falsePipe;
        }

        /// <summary>
        /// Recibe una imagen, le aplica un filtro y la envía al siguiente pipe segun el resultado.
        /// </summary>
        /// <param name="picture">Imagen a la cual se debe aplicar el filtro.</param>
        /// <returns>La imagen retornada por el siguiente pipe.</returns>
        public IPicture Send(IPicture picture)
        {
            IPicture checkedPicture = this.filterConditional.Filter(picture);

            if (this.filterConditional.Result)
            {
                return this.truePipe.Send(checkedPicture);
            }
            else
            {
                return this.falsePipe.Send(checkedPicture);
            }
        }
    }
}
