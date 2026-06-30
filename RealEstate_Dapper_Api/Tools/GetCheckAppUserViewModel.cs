namespace RealEstate_Dapper_Api.Tools;

public class GetCheckAppUserViewModel
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string UserRole { get; set; }
    public bool IsExist { get; set; }
}
