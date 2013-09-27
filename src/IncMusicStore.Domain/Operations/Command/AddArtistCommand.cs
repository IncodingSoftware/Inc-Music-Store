namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using Incoding.CQRS;

    #endregion

    public class AddArtistCommand : CommandBase
    {
        #region Properties

        public string Name { get; set; }

        #endregion

        public override void Execute()
        {
            Repository.Save(new Artist(Name));
        }
    }
}