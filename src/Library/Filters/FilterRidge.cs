//------------------------------------------------------------------------------
// <copyright file="FilterRidge.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Ucu.Poo.PipesAndFilters.Filters
{
    public class FilterRidge : FilterKernel
    {
        public FilterRidge()
        {
            this.Kernel = new int[3, 3];
            this.Complement = 1;
            this.Divider = 1;
            this.Kernel[0, 0] = 0;
            this.Kernel[0, 1] = -1;
            this.Kernel[0, 2] = 0;
            this.Kernel[1, 0] = -1;
            this.Kernel[1, 1] = 4;
            this.Kernel[1, 2] = -1;
            this.Kernel[2, 0] = 0;
            this.Kernel[2, 1] = -1;
            this.Kernel[2, 2] = 0;
        }
    }
}