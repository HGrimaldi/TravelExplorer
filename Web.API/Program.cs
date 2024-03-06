using Application;
using Infrastructure;
using Web.API;
using Web.API.Extensions;
using Web.API.Middlewares;
<<<<<<< HEAD
using Microsoft.Extensions.DependencyInjection;

=======
>>>>>>> 445520db14f862bd97211cc643700f05f88eeb5b

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPresentation()
                .AddInfrastructure(builder.Configuration)
                .AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

<<<<<<< HEAD
app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
=======
app.UseMiddleware<GloblalExceptionHandlingMiddleware>();
>>>>>>> 445520db14f862bd97211cc643700f05f88eeb5b

app.MapControllers();

app.Run();

