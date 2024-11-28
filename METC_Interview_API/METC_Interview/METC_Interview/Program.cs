var builder = WebApplication.CreateBuilder(args);

// 註冊服務
builder.Services.AddControllers();

// 註冊 Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 正確加載 IConfiguration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// 配置 HTTP 請求管道
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
