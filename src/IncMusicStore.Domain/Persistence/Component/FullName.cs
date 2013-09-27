namespace IncMusicStore.Domain
{
    public class FullName
    {
        #region Constructors

        public FullName() { }

        public FullName(string first, string middle, string last)
        {
            First = first;
            Middle = middle;
            Last = last;
        }

        #endregion

        #region Properties

        public virtual string First { get; protected set; }

        public virtual string Last { get; protected set; }

        public virtual string Middle { get; protected set; }

        #endregion
    }
}