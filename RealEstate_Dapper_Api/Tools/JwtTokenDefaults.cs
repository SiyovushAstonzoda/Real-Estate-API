namespace RealEstate_Dapper_Api.Tools;

public class JwtTokenDefaults
{
    public const string ValidAudience = "https://localhost";
    public const string ValidIssuer = "https://localhost";
    public const string Key = "RealEstateDapperApiSuperSecretKeyForJwtAuthenticationVx_1234567890";
    public const int Expire = 5;
}
