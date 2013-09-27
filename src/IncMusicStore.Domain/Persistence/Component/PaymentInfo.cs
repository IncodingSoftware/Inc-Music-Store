namespace IncMusicStore.Domain
{
    public class PaymentInfo
    {
        #region Properties

        public virtual string Address { get; set; }

        public virtual string City { get; set; }

        public virtual string State { get; set; }

        public virtual string PostalCode { get; set; }

        public virtual string Country { get; set; }

        public virtual string Phone { get; set; }

        #endregion
    }
}