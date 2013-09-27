namespace IncMusicStore.UI.Models
{
    #region << Using >>

    using IncMusicStore.Domain;

    #endregion

    public class AlbumDetailsVm
    {
        #region Constructors

        public AlbumDetailsVm(Album album)
        {
            this.Id = album.Id.ToString();
            this.Title = album.Title;
            this.Price = album.Price.ToMoney();
            this.Genre = album.Genre.Name;
            this.Artist = album.Artist.Name;
            this.ArtUrl = album.ArtUrl;
        }

        #endregion

        #region Properties

        public string Artist { get; set; }

        public string Genre { get; set; }

        public string Price { get; set; }

        public string Title { get; set; }

        public string Id { get; set; }

        public string ArtUrl { get; set; }

        #endregion
    }
}