using Api;
using Api2.ActionFilters;
using Api2.ContextFactory;
using Api2.Extensions;
using Microsoft.AspNetCore.Mvc;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));


// Add services to the container.
builder.Services.ConfigureCors(new string[] { "https://localhost:7006" });
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CqrsApplication.AssemblyReference).Assembly));

builder.Services.ConfigureSqliteContext(RepositoryContextFactory.GetConnectionString());
builder.Services.ConfigureOutputCaching();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.AddHealthChecks();

builder.Services.AddControllers(config =>
{
    config.ReturnHttpNotAcceptable = true;
    config.RespectBrowserAcceptHeader = true;
    config.CacheProfiles.Add("60SecondsDuration", new CacheProfile { Duration = 60 });
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapHealthChecks("/health");
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseExceptionHandler(opt => { });
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = Microsoft.AspNetCore.HttpOverrides.ForwardedHeaders.All
});
app.UseCors("CorsPolicy");
app.UseOutputCache();

app.MapControllers();

app.Run();
