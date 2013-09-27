namespace IncMusicStore.Domain
{
    public static class IncMusicStoreExtensions
    {
         public static string ToMoney(this decimal value)
         {
             return value.ToString("C");
         }
    }
}