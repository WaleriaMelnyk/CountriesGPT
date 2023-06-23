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


// Middleware for handling endpoints
app.MapGet("Countries", async (IHttpClientFactory clientFactory, HttpContext httpContext) =>
{
    // Read the query parameters (optional)
    var param1 = httpContext.Request.Query["param1"].ToString();
    var param2 = httpContext.Request.Query["param2"].ToString();
    var param3 = httpContext.Request.Query["param3"].ToString();

    // Make a request to the REST Countries API
    var client = clientFactory.CreateClient();
    var response = await client.GetAsync("https://restcountries.com/v3.1/all");

    if (response.IsSuccessStatusCode)
    {
        var content = await response.Content.ReadAsStringAsync();

        // Response in JSON format
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response.WriteAsync(content);
    }
    else
    {
        httpContext.Response.StatusCode = 500;
        await httpContext.Response.WriteAsync("Error retrieving countries data");
    }
});

app.Run();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
