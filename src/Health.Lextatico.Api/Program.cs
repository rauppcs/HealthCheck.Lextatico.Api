using Health.Lextatico.Api.Extensions;
using Health.Lextatico.Api.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseLextaticoSerilog(builder.Environment, builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddLextaticoHealthChecks(builder.Configuration);

var app = builder.Build();

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
    options.AddCustomStylesheet("lextaticoStyle.css");

    options.UIPath = "/";
});

app.MapControllers();

app.Run();