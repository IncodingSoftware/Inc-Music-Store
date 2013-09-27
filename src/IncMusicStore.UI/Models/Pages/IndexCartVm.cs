namespace IncMusicStore.UI.Models
{
    #region << Using >>

    using System.Collections.Generic;
    using System.Linq;

    #endregion

    public class IndexCartVm
    {
        #region Properties

        public List<CartItemVm> Items { get; set; }

        public decimal Total
        {
            get { return Items.Sum(r => r.Cost); }
        }

        #endregion
    }
}