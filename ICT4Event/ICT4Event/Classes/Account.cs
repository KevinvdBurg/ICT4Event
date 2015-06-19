// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Account.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   In this object will be all the account data stored.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    using System;

    /// <summary>
    /// The account.
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// Only use if you create a account 
        /// </summary>
        /// <param name="gebruiksersnaam">
        /// The username
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="wachtwoord">
        /// The password
        /// </param>
        /// <param name="type">
        /// The type of the account.
        /// False is User
        /// True is Admin
        /// </param>
        /// <param name="hash">
        /// The activation hash
        /// </param>
        /// <param name="geactiveerd">
        /// True or False if the account is active. Default 0
        /// </param>
        public Account(string gebruiksersnaam, string email, string wachtwoord, bool type, string hash, bool geactiveerd)
        {
            this.Gebruiksersnaam = gebruiksersnaam.ToLower();
            this.Email = email.ToLower();
            this.Wachtwoord = wachtwoord;
            this.Type = type;
            this.Geactiveerd = geactiveerd;
            this.Hash = Convert.ToString(hash);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// Use this if only the username and type is known
        /// </summary>
        /// <param name="gebruiksersnaam">
        /// The username.
        /// </param>
        /// <param name="type">
        /// The type of the account
        /// </param>
        public Account(string gebruiksersnaam, bool type)
        {
            this.Gebruiksersnaam = gebruiksersnaam;
            this.Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// use for the session
        /// </summary>
        /// <param name="gebruikersId">
        /// The User id.
        /// </param>
        /// <param name="gebruiksersnaam">
        /// The Usename.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        public Account(int gebruikersId, string gebruiksersnaam, string email)
        {
            this.GebruikerId = gebruikersId;
            this.Email = email;
            this.Gebruiksersnaam = gebruiksersnaam;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// to create a empty object of account 
        /// </summary>
        public Account()
        {
        }

        /// <summary>
        /// Gets or sets the gebruiker id.
        /// </summary>
        public int GebruikerId { get; set; }

        /// <summary>
        /// Gets or sets the gebruiksersnaam.
        /// </summary>
        public string Gebruiksersnaam { get; set; }

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the wachtwoord.
        /// </summary>
        public string Wachtwoord { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether type.
        /// </summary>
        public bool Type { get; set; }

        /// <summary>
        /// Gets or sets the hash.
        /// </summary>
        public string Hash { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether geactiveerd.
        /// </summary>
        public bool Geactiveerd { get; set; }
    }
}