using Health.Lextatico.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddLextaticoHealthChecks(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (!app.Environment.IsProduction())
{
    app.UseDeveloperExceptionPage();
}

if (app.Environment.IsProduction())
{
    app.UseHttpsRedirection();

    app.UseHsts();
}

app.UseAuthorization();

app.MapHealthChecksUI(options =>
{
    // options.AddCustomStylesheet("lextaticoStyle.css");
});

app.MapControllers();

app.Run();
