//------------------------------------------------------------------------------
// <copyright file="Program.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System.IO.Pipelines;
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
            // Filter Ridge:
            PipeNull pipeNull = new PipeNull();
            PipeSerial pipeSerial1 = new PipeSerial(new FilterRidge(), pipeNull);

            // Filter Sharpen
            // PipeNull pipeNull = new PipeNull();
            // PipeSerial pipeSerial1 = new PipeSerial(new FilterSharpen(), pipeNull);

            // PipeNull pipeNull = new PipeNull();
            // PipeSerial pipeSerial3 = new PipeSerial(new FilterNegative(), pipeNull);
            // PipeSerial pipeSerial2 = new PipeSerial(new FilterPublishDiscord(), pipeNull);
            // PipeConditionalFork pipeConditionalFork = new PipeConditionalFork(new FilterConditional(), pipeSerial2, pipeSerial3);
            // PipeSerial pipeSerial1 = new PipeSerial(new FilterGrayscale(), pipeConditionalFork);


            // PipeNull pipeNull = new PipeNull();
            // PipeSerial pipeSerial4 = new PipeSerial(new FilterPublishDiscord(), pipeNull);
            // PipeSerial pipeSerial3 = new PipeSerial(new FilterNegative(), pipeSerial4);
            // PipeSerial pipeSerial2 = new PipeSerial(new FilterSave(@"filteredimage1.jpg"), pipeSerial3);
            // PipeSerial pipeSerial1 = new PipeSerial(new FilterGrayscale(), pipeSerial2);

            PictureProvider provider = new PictureProvider();
            IPicture picture1 = provider.GetPicture(@"beer.jpg");
            IPicture picture2 = provider.GetPicture(@"luke.jpg");

            IPicture result1 = pipeSerial1.Send(picture1);
            provider.SavePicture(result1, @"beerfiltered.jpg");

            IPicture result2 = pipeSerial1.Send(picture2);
            provider.SavePicture(result2, @"lukefiltered.jpg");
        }
    }
}
