//------------------------------------------------------------------------------
// <copyright file="FilterConditional.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using Ucu.Poo.Cognitive;

namespace Ucu.Poo.PipesAndFilters.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen y la retorna en escala de grises.
    /// </summary>
    public class FilterConditional : IFilterConditional
    {
        private CognitiveFace faceApi;

        /// <summary>
        /// Obtiene el resultado del filtro.
        /// </summary>
        public bool Result { get; private set; }

        public FilterConditional()
        {
            string subscriptionKey = Environment.GetEnvironmentVariable("AZURE_FACE_SUBSCRIPTION_KEY");
            if (string.IsNullOrWhiteSpace(subscriptionKey))
            {
                Console.WriteLine("Falta la variable de entorno AZURE_FACE_SUBSCRIPTION_KEY'.");
            }

            this.faceApi = new CognitiveFace();
        }

        public IPicture Filter(IPicture image)
        {
            string imagePath = @"checkedimage.jpg";
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, imagePath);

            CognitiveFace.RecognitionResult result = this.faceApi.Recognize(@"checkedimage.jpg", true);
            if (result.Success && result.FaceFound) // Recognize procesó la imagen y encontró una cara
            {
                this.Result = true;
                return provider.GetPicture(@"checkedimage_r_.jpg"); // Recognize agrega '_r_' como sufijo al archivo
            }
            else // Recognize no pudo procesar la imagen.
            {
                this.Result = false;
                return image;
            }
        }
    }
}