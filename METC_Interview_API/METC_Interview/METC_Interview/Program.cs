var builder = WebApplication.CreateBuilder(args);

// ���U�A��
builder.Services.AddControllers();

// ���U Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// ���T�[�� IConfiguration
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var app = builder.Build();

// �t�m HTTP �ШD�޹D
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
