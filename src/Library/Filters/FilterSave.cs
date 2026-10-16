//------------------------------------------------------------------------------
// <copyright file="FilterSave.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

namespace Ucu.Poo.PipesAndFilters.Filters
{
    /// <summary>
    /// Un filtro que recibe una imagen, la guarda y la devuelve.
    /// </summary>
    public class FilterSave : IFilter
    {
        private string imagePath;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FilterSave"/>.
        /// </summary>
        /// <param name="imagePath">EL Path donde guardar la imagen.</param>
        public FilterSave(string imagePath)
        {
            this.imagePath = imagePath;
        }

        /// <summary>
        /// Un filtro que retorna la imagen recibida despues de ser guardada.
        /// </summary>
        /// <param name="image">La imagen que se va a guardar.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            PictureProvider pictureProvider = new PictureProvider();
            pictureProvider.SavePicture(image, this.imagePath);
            return image;
        }
    }
}