namespace IncMusicStore.UI.Models
{
    using IncMusicStore.Domain;

    public class GenreVm
    {
        #region Constructors

        public GenreVm(Genre genre)
        {
            this.Id = genre.Id.ToString();
            this.Name = genre.Name;
        }

        #endregion

        #region Properties

        public string Name { get; set; }

        public string Id { get; set; }

        #endregion
    }
}