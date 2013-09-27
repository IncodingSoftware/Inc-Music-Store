namespace IncMusicStore.Domain
{
    #region << Using >>

    using Incoding.CQRS;

    #endregion

    public class AddGenreCommand : CommandBase
    {
        #region Properties

        public string Name { get; set; }

        public string Description { get; set; }

        #endregion

        public override void Execute()
        {
            Repository.Save(new Genre(Name, Description));
        }
    }
}