namespace IncMusicStore.Domain
{
    #region << Using >>

    using Incoding.CQRS;

    #endregion

    public class AddAlbumCommand : CommandBase
    {
        #region Properties

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string ArtUrl { get; set; }

        public string ArtistId { get; set; }

        public string GenreId { get; set; }

        #endregion

        public override void Execute()
        {
            var artist = Repository.GetById<Artist>(ArtistId);
            var genre = Repository.GetById<Genre>(GenreId);

            Repository.Save(new Album(Title, artist, genre, Price, ArtUrl));
        }
    }
}