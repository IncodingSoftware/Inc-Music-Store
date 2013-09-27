namespace IncMusicStore.UI.Models
{
    #region << Using >>

    using IncMusicStore.Domain;

    #endregion

    public class CartItemVm
    {
        #region Constructors

        public CartItemVm(CartItem cartItem)
        {
            Id = cartItem.Id.ToString();
            Album = cartItem.Album.Title;
            Cost = cartItem.Album.Price * cartItem.Quantity;
            Price = cartItem.Album.Price.ToMoney();
            Quantity = cartItem.Quantity.ToString();
        }

        #endregion

        #region Properties

        public string Album { get; set; }

        public decimal Cost { get; set; }

        public string Price { get; set; }

        public string Quantity { get; set; }

        public string Id { get; set; }

        #endregion
    }
}