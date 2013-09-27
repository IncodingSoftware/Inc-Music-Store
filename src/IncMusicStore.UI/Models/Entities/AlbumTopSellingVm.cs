namespace IncMusicStore.UI.Models
{
    #region << Using >>

    using IncMusicStore.Domain;

    #endregion

    public class AlbumTopSellingVm
    {
        #region Constructors

        public AlbumTopSellingVm(Album album)
        {
            this.Id = album.Id.ToString();            
            this.Title = album.Title;
            this.ArtUrl = album.ArtUrl;
        }

        #endregion

        #region Properties

        public string Id { get; private set; }

        public string ArtUrl { get; private set; }

        public string Title { get; private set; }

        #endregion
    }
}