// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Item.cs" company="">
//   
// </copyright>
// <summary>
//   The item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    /// <summary>
    /// The item.
    /// </summary>
    public class Item
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        /// <param name="exemplaarId">
        /// The exemplaar id.
        /// </param>
        /// <param name="merk">
        /// The merk.
        /// </param>
        /// <param name="serie">
        /// The serie.
        /// </param>
        /// <param name="typeNummer">
        /// The type nummer.
        /// </param>
        /// <param name="prijs">
        /// The prijs.
        /// </param>
        public Item(int exemplaarId, string merk, string serie, int typeNummer, int prijs)
        {
            this.ExemplaarID = exemplaarId;
            this.Merk = merk;
            this.Serie = serie;
            this.TypeNummer = typeNummer;
            this.Prijs = prijs;
        }

        /// <summary>
        /// Gets or sets the exemplaar id.
        /// </summary>
        public int ExemplaarID { get; set; }

        /// <summary>
        /// Gets or sets the merk.
        /// </summary>
        public string Merk { get; set; }

        /// <summary>
        /// Gets or sets the serie.
        /// </summary>
        public string Serie { get; set; }

        /// <summary>
        /// Gets or sets the type nummer.
        /// </summary>
        public int TypeNummer { get; set; }

        /// <summary>
        /// Gets or sets the prijs.
        /// </summary>
        public int Prijs { get; set; }

        /// <summary>
        /// The to string.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string ToString()
        {
            string output;
            output = "Exemplaar_ID: " + this.ExemplaarID + ". Merk: " + this.Merk + ". Serie: " + this.Serie
                                 + ". TypeNummer: " + this.TypeNummer + ". prijs: " + this.Prijs + ".";
            return output;
        }
    }
}