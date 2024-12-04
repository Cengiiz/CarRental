using CarRentalService.DTOs;

namespace CarRentalMVC
{
    public static class SessionManager
    {
        private static IHttpContextAccessor _httpContextAccessor;

        public static void Initialize(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public static void SetUserSession(UserDto user)
        {
            _httpContextAccessor.HttpContext.Session.SetString("User", Newtonsoft.Json.JsonConvert.SerializeObject(user));
        }

        public static UserDto GetUserSession()
        {
            var userJson = _httpContextAccessor.HttpContext.Session.GetString("User");
            return userJson == null ? null : Newtonsoft.Json.JsonConvert.DeserializeObject<UserDto>(userJson);
        }

        public static void ClearUserSession()
        {
            _httpContextAccessor.HttpContext.Session.Remove("User");
        }
    }
}
