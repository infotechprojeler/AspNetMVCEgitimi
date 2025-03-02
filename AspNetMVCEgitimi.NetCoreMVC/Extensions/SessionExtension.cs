using System.Text.Json;

namespace AspNetMVCEgitimi.NetCoreMVC.Extensions
{
    public static class SessionExtension
    {
        public static void SetJson(this ISession session, string key, object value) // this ISession session kodu uygulamadaki session yapısını kullanacağımızı belirtir.
        {
            session.SetString(key, JsonSerializer.Serialize(value)); // session ın SetString metoduna gelen key değerine göre obje türünde her türlü veriyi kabul edip Json veri türüne dönüştürerek saklama işlemini yaptık
        }
        public static T? GetJson<T>(this ISession session, string key) where T : class // bu metot da yukarıda json a çevrilerek session da saklanan veriyi tekrar nesneye dönüştürmeyi sağlar.
        {
            var data = session.GetString(key);
            return data == null ?
                default : JsonSerializer.Deserialize<T>(data);
        }
    }
}
