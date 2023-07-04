using Countries.Objects;
using System.Text.Json;

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

app.MapGet("/api/countries", async (HttpContext context) =>
{
    // Make the request to the REST Countries API
    string apiUrl = "https://restcountries.com/v3.1/all";
    using (var httpClient = new HttpClient())
    {
        var response = await httpClient.GetAsync(apiUrl);
        var content = await response.Content.ReadAsStringAsync();

        // Parse the JSON response into a variable/object
        var countries = JsonSerializer.Deserialize<List<CountryItem>>(content);

        // Perform any additional processing with the retrieved data

        // Return the response as JSON
        context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonSerializer.Serialize(countries));
    }
});

app.MapGet("/api/countries/filter", async (HttpContext context) =>
{
        // Retrieve the filter string from the query string
        string filter = context.Request.Query["filter"].ToString();

        // Make the request to the REST Countries API
        string apiUrl = "https://restcountries.com/v3.1/all";
    using (var httpClient = new HttpClient())
    {
        var response = await httpClient.GetAsync(apiUrl);
        var content = await response.Content.ReadAsStringAsync();

            // Parse the JSON response into a list of country objects
            var countries = JsonSerializer.Deserialize<List<CountryItem>>(content);

            // Filter the countries based on the provided string
            var filteredCountries = countries.Where(c => c.name.common.Contains(filter, StringComparison.OrdinalIgnoreCase)).ToList();

            // Return the filtered countries as JSON
            context.Response.ContentType = "application/json";
        await context.Response.WriteAsync(JsonSerializer.Serialize(filteredCountries));
    }
});

app.Run();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
