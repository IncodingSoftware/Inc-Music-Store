namespace IncMusicStore.Domain
{
    #region << Using >>

    using Incoding.CQRS;
    using Incoding.Data;

    #endregion

    ////ncrunch: no coverage start
    public class DataBaseSetUp : ISetUp
    {
        #region Fields

        readonly IManagerDataBase managerDataBase;

        #endregion

        #region Constructors

        public DataBaseSetUp(IManagerDataBase managerDataBase)
        {
            this.managerDataBase = managerDataBase;
        }

        #endregion

        #region ISetUp Members

        public int GetOrder()
        {
            return 1;
        }

        public void Execute()
        {
            if (!this.managerDataBase.IsExist())
                this.managerDataBase.Create();
        }

        #endregion

        #region Disposable

        public void Dispose() { }

        #endregion
    }

    ////ncrunch: no coverage end
}