//------------------------------------------------------------------------------
// <copyright file="FilterBlurConvolution.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.Drawing;

namespace Ucu.Poo.PipesAndFilters.Filters
{
    /// <summary>
    /// Un filtro de convolución que retorna la imagen recibida con los bordes suavizados. Basado en
    /// https://en.wikipedia.org/wiki/Box_blur utilizando el kernel
    /// https://wikimedia.org/api/rest_v1/media/math/render/svg/91256bfeece3344f8602e288d445e6422c8b8a1c.
    /// </summary>
    public class FilterBlurConvolution : FilterKernel
    {
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see
        /// cref="FilterBlurConvolution"/> asignando el kernel, complemento, y
        /// divisor según
        /// https://wikimedia.org/api/rest_v1/media/math/render/svg/91256bfeece3344f8602e288d445e6422c8b8a1c.
        /// </summary>
        public FilterBlurConvolution()
        {
            this.Kernel = new int[3, 3];
            this.Complement = 0;
            this.Divider = 9;
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    this.Kernel[x, y] = 1;
                }
            }
        }
    }
}