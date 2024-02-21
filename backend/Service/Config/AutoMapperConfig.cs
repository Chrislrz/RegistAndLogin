using Service.Dto;
using Table;
using AutoMapper;

namespace Service.Config;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {   //用于实现这几个dto之间的映射
        CreateMap<newusers,RegistDto>();
        //如果需要互相转换的，则互相映射就可以
        CreateMap<RegistDto,newusers>();
    }
}
//在您的项目中使用 AutoMapper 的原因是为了简化对象之间的映射和转换过程。
//在很多情况下，您需要在不同层（如数据访问层、业务逻辑层和表示层）之间传递数据，这些层可能使用不同的数据模型。例如：
// 
// 数据访问层可能使用与数据库表直接对应的实体类（如 newusers）。
// 表示层可能使用数据传输对象（DTOs，如 RegistDto），这些对象是根据客户端的需求定制的，
// 可能只包含实体类的子集或者以不同的方式组织数据。

// 在这些层之间传递数据时，您通常需要将一个对象的属性复制到另一个对象中。
// 手动编写这种转换代码是乏味且容易出错的，特别是当模型复杂或频繁更改时。
// 
// 使用 AutoMapper，您可以通过定义映射配置来自动化这个过程。例如，CreateMap<RegistDto, newusers>();
// 告诉 AutoMapper 如何将 RegistDto 对象转换为 newusers 对象。
// 一旦定义了映射，您就可以在整个应用程序中重用它，从而减少重复的转换代码并提高代码的可维护性和可读性。