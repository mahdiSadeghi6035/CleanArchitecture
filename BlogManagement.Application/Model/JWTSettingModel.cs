namespace BlogManagement.Application.Model;

public class JWTSettingModel
{
    public string SecretKey { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public int DurationDay { get; set; }
}
