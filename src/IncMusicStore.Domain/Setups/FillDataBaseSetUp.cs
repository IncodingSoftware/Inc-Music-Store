namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Linq;
    using Incoding.CQRS;

    #endregion

    ////ncrunch: no coverage start
    public class FillDataBaseSetUp : ISetUp
    {
        #region Fields

        readonly IDispatcher dispatcher;

        #endregion

        #region Constructors

        public FillDataBaseSetUp(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        #endregion

        #region ISetUp Members

        public int GetOrder()
        {
            return 2;
        }

        public void Execute()
        {
            if (this.dispatcher.Query(new GetEntitiesQuery<Album>()).Any())
                return;

            this.dispatcher.Push(new AddGenreCommand
                                     {
                                             Name = "Rock", 
                                             Description = "Rock music is a genre of music started in America. It has its roots in 1940s and 1950s rock and roll and rockabilly, which evolved from blues, country music and other influences."
                                     });
            this.dispatcher.Push(new AddArtistCommand { Name = "The Beatles" });

            string genreId = this.dispatcher.Query(new GetEntitiesQuery<Genre>()).First().Id.ToString();
            string artistId = this.dispatcher.Query(new GetEntitiesQuery<Artist>()).First().Id.ToString();

            this.dispatcher.Push(new AddAlbumCommand
                                     {
                                             Title = "Abbey Road", 
                                             Price = (decimal)7.25, 
                                             ArtUrl = "http://userserve-ak.last.fm/serve/500/77611986/Abbey+Road.png", 
                                             ArtistId = artistId, 
                                             GenreId = genreId
                                     });
            this.dispatcher.Push(new AddAlbumCommand
                                     {
                                             Title = "Revolver", 
                                             Price = (decimal)6.25, 
                                             ArtUrl = "http://userserve-ak.last.fm/serve/500/83208567/Revolver.png", 
                                             ArtistId = artistId, 
                                             GenreId = genreId
                                     });
            this.dispatcher.Push(new AddAlbumCommand
                                     {
                                             Title = "Rubber Soul", 
                                             Price = (decimal)6.25, 
                                             ArtUrl = "http://userserve-ak.last.fm/serve/500/88059863/Rubber+Soul.png", 
                                             ArtistId = artistId, 
                                             GenreId = genreId
                                     });
            this.dispatcher.Push(new AddAlbumCommand
                                     {
                                             Title = "Magical Mystery Tour ", 
                                             Price = (decimal)12.25, 
                                             ArtUrl = "http://userserve-ak.last.fm/serve/500/88059887/Magical+Mystery+Tour.png", 
                                             ArtistId = artistId, 
                                             GenreId = genreId
                                     });
        }

        #endregion

        #region Disposable

        public void Dispose() { }

        #endregion
    }

    ////ncrunch: no coverage end
}