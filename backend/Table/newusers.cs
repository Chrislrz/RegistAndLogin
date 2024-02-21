using SqlSugar;

namespace Table;

public class newusers
{
    [SugarColumn (IsPrimaryKey = true, IsIdentity = true)]
    
    public int Id { get; set; }
    
    public string password { get; set; }
    
    public string username { get; set; }

    public DateTime modifydate { get; set; }
}