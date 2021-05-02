using BugTracker.infrastructure.contracts.responses;

namespace BugTracker
{
    public class LoginResponse : ResponseBase
    {
        public string Token { get; set; }
    }
}