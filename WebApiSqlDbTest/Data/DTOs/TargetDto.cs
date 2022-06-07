namespace WebApiSqlDbTest.Data.DTOs
{
    public class TargetDto
    {
        //public int TargetId { get; set; }

        /// <summary>Naslov dokumenta ili naslov/kratak opis linka/fajla/foldera.</summary>
        public string Title { get; set; } = default!;

        /// <summary>Adresa linka/fajla/foldera ili tekst dokumenta.</summary>
        public string Text { get; set; } = default!;

        /// <summary>Tagovi za pretragu ovog target-a.</summary>
        /// <example>raf, tagged-world, projekat, c#, web-api</example>
        public string Tags { get; set; } = default!;

        public DateTime CreatedDate { get; set; }

        //public User Owner { get; set; } = default!;
        public int OwnerId { get; set; }

    }
}
