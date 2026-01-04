using HelloApi.Daos;
using HelloApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// dependency injection :
builder.Services.AddScoped<IHelloDao, HelloDao>();
builder.Services.AddScoped<IHelloService, HelloService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


// app.UseHttpsRedirection();


app.MapControllers();

app.Run();

// needed for WebApplicationFactory<Program> integration tests
public partial class Program { }
