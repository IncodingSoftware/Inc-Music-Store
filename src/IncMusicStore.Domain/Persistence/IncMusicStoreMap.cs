namespace IncMusicStore.Domain
{
    #region << Using >>

    using System.Diagnostics.CodeAnalysis;
    using Incoding.Data;
    using JetBrains.Annotations;

    #endregion

    [UsedImplicitly, ExcludeFromCodeCoverage]
    public class IncMusicStoreMap<TEntity> : NHibernateEntityMap<TEntity> where TEntity : IncEntityBase
    {
        ////ncrunch: no coverage start
        #region Constructors

        public IncMusicStoreMap()
        {
            IdGenerateByGuid(r => r.Id);
        }

        #endregion

        ////ncrunch: no coverage end
    }
}