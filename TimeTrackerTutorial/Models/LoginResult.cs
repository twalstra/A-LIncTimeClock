using System;
namespace TimeTrackerTutorial.Models
{
    public class LoginResult
    {
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }

        public static LoginResult FromError(string message) => new LoginResult
        {
            IsSuccess = false,
            ErrorMessage = message
        };

        public static LoginResult FromSuccess() => new LoginResult { IsSuccess = true };
    }
}
