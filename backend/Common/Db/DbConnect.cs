using SqlSugar;

namespace Common.Db;

public class DbConnect
{
    public static SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
    {
        
        //数据库连接对象
        ConnectionString = "Server=localhost;Database=newuser;Uid=root;Pwd=lrz19971009;", //连接字符串
        DbType = DbType.MySql, //数据库类型，支持多种类型的数据库，比如MySql,SqlServer,Sqlite,Oracle
        IsAutoCloseConnection = true //连接数据库后自动关闭

    });
}