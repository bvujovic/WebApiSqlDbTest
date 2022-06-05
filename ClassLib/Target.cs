using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLib
{
    /// <summary>
    /// Target tj. resurs koji se pamti i pretražuje: link/fajl/folder/dokument.
    /// </summary>
    public class Target
    {
        public int TargetId { get; set; }

        /// <summary>Naslov dokumenta ili naslov/kratak opis linka/fajla/foldera.</summary>
        public string Title { get; set; } = default!;

        /// <summary>Adresa linka/fajla/foldera ili tekst dokumenta.</summary>
        public string Text { get; set; } = default!;

        private string tags = default!;
        [Required]
        //[MaxLength(100)]
        /// <summary>Tagovi za pretragu ovog target-a.</summary>
        /// <example>raf, tagged-world, projekat, c#, web-api</example>
        public string Tags
        {
            get => tags;
            set => tags = value; //TODO validacija datog stringa (tagova)
        }

        public DateTime CreatedDate { get; set; }

        public User Owner { get; set; } = default!;

        [Timestamp]
        public byte[] TStamp { get; set; } = default!;

        /// <summary>Inicijalni target koji se automatski dodaje kao primer za svakog korisnika.</summary>
        public static Target InitTarget(User owner)
            => new()
            {
                Title = "Tagged World GitHub page",
                Text = "https://github.com/bvujovic/TaggedWorld",
                Tags = "raf, tagged-world, project, c#, web-api",
                CreatedDate = new DateTime(2022, 06, 01),
                Owner = owner
            };
    }
}