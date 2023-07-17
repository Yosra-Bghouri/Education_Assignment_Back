namespace Education_Assignments_App.Dtos
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string AccessToken { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    public string UserId { get; set; }
        public string Message { get; set; }
    }
}
