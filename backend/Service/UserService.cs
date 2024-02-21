using AutoMapper;
using Common.Db;
using Service.Dto;
using Table;

namespace Service;

public class UserService:IUserService
{
    private readonly IMapper _mapper;
    //构造函数注入对象
    public UserService(IMapper mapper)
    {
        _mapper = mapper;
    } 
    //我想要添加一个注册登录功能
    
    //1.注册功能
    public newusers AddUser (RegistDto input){
        //创建一个新的users表格对象user 等于 转换对象
        //他在定义方法的时候对数据进行了初步的筛选，从这里添加逻辑控制语句，而不是在controller中
        newusers newuser = TransRegistDto (input) ;
        if (!DbConnect.db.Queryable<newusers>().Any(m => m.password.Equals(input.password) || m.username.Equals(input.username)))
        {   
            // 使用 SqlSugar 保存 user 到数据库
            DbConnect.db.Insertable(newuser).ExecuteCommand();
            return _mapper.Map<newusers>(newuser);
        }
        else throw new Exception("QQ 或者 手机号已存在");
    }
    
    private newusers TransRegistDto (RegistDto input){
        var newuser = _mapper. Map<newusers> (input) ;
        var date = DateTime. Now;
        newuser. modifydate = date;
        return newuser;
    }
    
    //2.登录功能
    //我要使用到异步方法来写登录功能，为了避免堵塞当前线程
    
    // async Task<Users> 异步方法且规定返回数据类型，方法名字为login，传入对象为logindto表单下的login一个对象
     // public async Task<newusers> Login(LoginDto login)
     // {
     //     //只要不是void声明的方法都要有return值
     //     //返回的是db连接数据对象
     //     return await DbConnect.db.Queryable<newusers>().
     //         FirstAsync(m => m.password.Equals(login.password) && 
     //                         m.username.Equals(login.username));
     // }
     public async Task<newusers> Login(LoginDto loginDto)
     {
         var user = await DbConnect.db.Queryable<newusers>()
             .Where(u => u.username == loginDto.username && u.password == loginDto.password)
             .FirstAsync();

         if (user == null)
         {
             throw new Exception("Invalid username or password.");
         }

         return user;
     }
}