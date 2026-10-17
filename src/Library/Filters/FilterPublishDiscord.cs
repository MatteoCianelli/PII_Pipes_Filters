//------------------------------------------------------------------------------
// <copyright file="FilterPublishDiscord.cs" company="Universidad Católica del Uruguay">
//     Copyright (c) Programación II. Derechos reservados.
// </copyright>
//------------------------------------------------------------------------------

using System;
using Ucu.Poo.Discord;

namespace Ucu.Poo.PipesAndFilters.Filters
{

    /// <summary>
    /// Un filtro que recibe una imagen y la publica en Discord.
    /// </summary>
    public class FilterPublishDiscord : IFilter
    {
        private DiscordClient discord;
        private ulong channelId;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FilterPublishDiscord"/>.
        /// </summary>
        public FilterPublishDiscord()
        {
            string botToken = Environment.GetEnvironmentVariable("DISCORD_BOT_TOKEN");
            string channelText = Environment.GetEnvironmentVariable("CHANNEL_ID");
            if (!string.IsNullOrWhiteSpace(botToken) && !string.IsNullOrWhiteSpace(channelText))
            {
                this.channelId = ulong.Parse(channelText);
                this.discord = new DiscordClient();

                this.discord.Login(botToken);
            }
            else
            {
                Console.WriteLine("Faltan las variables de entorno 'DISCORD_BOT_TOKEN' y 'CHANNEL_ID'.");
            }
        }

        /// <summary>
        /// Un filtro que retorna la imagen recibida despues de ser publicada en Discord.
        /// </summary>
        /// <param name="image">La imagen que se va a publicar.</param>
        /// <returns>La imagen recibida.</returns>
        public IPicture Filter(IPicture image)
        {
            string imagePath = @"sentimage.jpg";
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, imagePath);

            this.discord.SendImage(this.channelId, imagePath, "Imagen Filtrada.");

            return image;
        }
    }
}