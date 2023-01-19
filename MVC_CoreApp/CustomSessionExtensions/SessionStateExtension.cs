using System.Text.Json;

namespace MVC_CoreApp.CustomSessionExtensions
{
    /// <summary>
    /// Custom Session Extensions
    /// </summary>
    public static class SessionStateExtension
    {
        public static void SetObject<T>(this ISession session, string key, T value)
        {
            session.SetString(key, JsonSerializer.Serialize<T>(value));
        }


        public static T GetObjet<T>(this ISession session, string key)
        {
            T data = JsonSerializer.Deserialize<T>(session.GetString(key));
            if(data == null)
                return default(T); 
            return data;
        }
    }
}
