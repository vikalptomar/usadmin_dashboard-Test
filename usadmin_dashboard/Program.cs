using usadmin_dashboard.MyDatabase;
using Microsoft.EntityFrameworkCore;
using usadmin_dashboard.Services;


IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var builder = WebApplication.CreateBuilder(args);


string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContextPool<AppDbContext>(options => options.UseMySQL(mySqlConnectionStr));
// Add services to the container.

builder.Services.AddScoped<IUsGrantsService, UsGrantsService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddAuthentication(IISDefaults.AuthenticationScheme);
var app = builder.Build();
app.UseCors("AllowSpecificOrigin");
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();