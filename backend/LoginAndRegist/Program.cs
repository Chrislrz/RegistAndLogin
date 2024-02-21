using Service;
using Service.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 绑定，接口和实例的关系
builder.Services.AddTransient<IUserService, UserService>();

// AutoMapper映射,我这里没有安装automapper包到本地class中，仍然可以读取到，可能因为是新版本
builder.Services.AddAutoMapper(typeof(AutoMapperConfig));

// 配置 CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        policy => policy.WithOrigins("http://localhost:8085")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin"); // 使用 CORS 策略

app.UseAuthorization();

app.MapControllers();

app.Run();