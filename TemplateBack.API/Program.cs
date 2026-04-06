using Scalar.AspNetCore;
using TemplateBack.TemplateBack.API.Middlewares;
using TemplateBack.TemplateBack.API.Modules;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

/* Dependency Injection */
builder.Services.AddInfraModule(builder.Configuration);
builder.Services.AddAppModule();
builder.Services.AddControllers();

/* Generates the OpenAPI JSON used by Scalar */
builder.Services.AddOpenApi();

WebApplication app = builder.Build();

/* Middleware pipeline */

/* Global exception handler */
app.UseMiddleware<ExceptionMiddleware>();

/* OpenAPI JSON endpoint + Scalar UI */
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        /* Scalar UI config */
        options.Title = "TemplateBack API";
        options.Theme = ScalarTheme.DeepSpace;
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => Results.Redirect("/scalar/v1"));

app.Run();