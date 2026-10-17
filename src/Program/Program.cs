//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using Ucu.Poo.PipesAndFilters.Filters;
using Ucu.Poo.PipesAndFilters.Pipes;

namespace Ucu.Poo.PipesAndFilters
{
    /// <summary>
    /// Programa principal.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Punto de entrada al programa principal.
        /// </summary>
        public static void Main()
        {
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerial4 = new PipeSerial(new FilterPublishDiscord(), pipeNull);
            PipeSerial pipeSerial3 = new PipeSerial(new FilterNegative(), pipeSerial4);
            PipeSerial pipeSerial2 = new PipeSerial(new FilterSave(@"filteredimage1.jpg"), pipeSerial3);
            PipeSerial pipeSerial1 = new PipeSerial(new FilterGrayscale(), pipeSerial2);

            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"luke.jpg");

            IPicture result = pipeSerial1.Send(picture);
            provider.SavePicture(result, @"lukefiltered.jpg");
        }
    }
}
