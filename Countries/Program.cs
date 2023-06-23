var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

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


// ...rest of the code

if (response.IsSuccessStatusCode)
{
    var content = await response.Content.ReadAsStringAsync();

    // Deserialize the JSON string into a List of Country objects
    var countries = System.Text.Json.JsonSerializer.Deserialize<List<Country>>(content);

    // Now you can work with the data as C# objects
    // For example, let's send the names of the countries as the response
    var countryNames = countries.Select(c => c.Name.Common);

    // Send the country names as the response
    httpContext.Response.ContentType = "application/json";
    await httpContext.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(countryNames));
}
    // ...rest of the code
});

Regenerate response


app.Run();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
