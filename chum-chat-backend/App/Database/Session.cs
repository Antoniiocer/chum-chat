namespace chum_chat_backend.App.Database
{
    public class ChumChatSession(IHttpContextAccessor httpContextAccessor)
    {
        
       
        public void SetSession(string userId, string name, string username, string email, string role)
        {
            if (!IsSessionActive()) return;
            var session = httpContextAccessor.HttpContext.Session;
            session.SetString("UserId", userId);
            session.SetString("Name", name);
            session.SetString("Username", username);
            session.SetString("Email", email);
            session.SetString("Role", role);
        }
        
        public string GetUserId()
        {
            return httpContextAccessor.HttpContext.Session.GetString("UserId");
        }

        public string GetName()
        {
            return httpContextAccessor.HttpContext.Session.GetString("Name");
        }

        public string GetUsername()
        {
            return httpContextAccessor.HttpContext.Session.GetString("Username");
        }

        public string GetEmail()
        {
            return httpContextAccessor.HttpContext.Session.GetString("Email");
        }

        public string GetRole()
        {
            return httpContextAccessor.HttpContext.Session.GetString("Role");
        }

        public void ClearSession()
        {
            var session = httpContextAccessor.HttpContext.Session;
            session.Remove("UserId");
            session.Remove("Name");
            session.Remove("Username");
            session.Remove("Email");
            session.Remove("Role");
        }

        public bool IsSessionActive()
        {
            return !string.IsNullOrEmpty(GetUserId());
        }
    }
}