using SFQG.Models;

var builder = WebApplication.CreateBuilder(args);
const string PolicyName = "CorsPolicy";
// Add services to the container.

builder.Services.AddCors(options => options.AddPolicy(PolicyName,
    builder =>
    {
        builder.WithOrigins("http://localhost:3000");
    }));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

List<Person> users = new List<Person>(){
    new (){ Id = 1, Name = "Evgen", Age = 20},
    new (){ Id = 2, Name = "Ruslan", Age = 21},
    new (){ Id = 3, Name = "Nikita", Age = 19},
    };

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapGet("/apl/getUser", () => users);
app.MapGet("/apl/getUser/{id}", (int id) =>
{
    try
    {
        Person temp = users[id];
        return Results.Json(temp);

    }
    catch (Exception)
    {
        return Results.Json(new { message = "Пользователь не найден" });
    }
}
);

app.UseHttpsRedirection();

app.UseCors(PolicyName);

app.UseAuthorization();

app.MapControllers();

app.Run();
