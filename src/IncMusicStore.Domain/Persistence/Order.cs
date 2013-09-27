namespace IncMusicStore.Domain
{
    #region << Using >>

    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.CodeAnalysis;
    using Incoding.Data;
    using Incoding.Quality;
    using JetBrains.Annotations;

    #endregion

    public class Order : IncEntityBase
    {
        #region Fields

        readonly IList<OrderItem> items = new List<OrderItem>();

        #endregion

        #region Constructors

        [UsedImplicitly, Obsolete(ObsoleteMessage.SerializeConstructor, true), ExcludeFromCodeCoverage]
        public Order() { }

        public Order(string promoCode, PaymentInfo paymentInfo)
        {
            CreateDt = DateTime.Now;
            PromoCode = promoCode;
            PaymentInfo = paymentInfo;            
            
        }

        #endregion

        #region Properties

        public virtual DateTime CreateDt { get; protected set; }

        public virtual User User { get; protected internal set; }

        public virtual PaymentInfo PaymentInfo { get; protected set; }

        public virtual string PromoCode { get; protected set; }

        public virtual IReadOnlyCollection<OrderItem> Items
        {
            get { return new ReadOnlyCollection<OrderItem>(this.items); }
        }

        #endregion

        #region Api Methods

        public virtual void AddItem(OrderItem item)
        {
            item.Order = this;
            this.items.Add(item);
        }

        #endregion

        #region Nested classes

        [UsedImplicitly, Obsolete(ObsoleteMessage.ClassNotForDirectUsage, true), ExcludeFromCodeCoverage]
        public class Map : IncMusicStoreMap<Order>
        {
            ////ncrunch: no coverage start
            #region Constructors

            public Map()
            {
                Map(r => r.CreateDt);
                Map(r => r.PromoCode);
                Component(r => r.PaymentInfo, part =>
                                                  {
                                                      part.Map(r => r.Address);
                                                      part.Map(r => r.City);
                                                      part.Map(r => r.State);
                                                      part.Map(r => r.PostalCode);
                                                      part.Map(r => r.Country);
                                                      part.Map(r => r.Phone);
                                                  });
                References(r => r.User).Cascade.SaveUpdate();
                HasMany(r => r.Items).Access.CamelCaseField().Cascade.AllDeleteOrphan();
            }

            #endregion

            ////ncrunch: no coverage end
        }

        #endregion
    }
}