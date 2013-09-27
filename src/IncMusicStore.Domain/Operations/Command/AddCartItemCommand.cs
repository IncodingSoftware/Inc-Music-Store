namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Linq;
    using Incoding.CQRS;

    #endregion

    public class AddCartItemCommand : CommandBase
    {
        #region Properties

        public string AlbumId { get; set; }

        public int Quantity { get; set; }

        #endregion

        public override void Execute()
        {
            var user = Repository.GetById<User>(IncMusicStoreApplication.UserId);                    
            var album = Repository.GetById<Album>(AlbumId);

            user.Cart.AddItem(new CartItem(album, Quantity));
        }
    }
}