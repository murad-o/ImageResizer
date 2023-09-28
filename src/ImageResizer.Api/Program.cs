using FluentValidation;
using ImageResizer.Abstractions.Services;
using ImageResizer.Api.Middlewares;
using ImageResizer.Application.Handlers.Commands.ResizeImage;
using ImageResizer.Application.Services;
using ImageResizer.Core.Behaviors;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ExceptionHandlingMiddleware>();

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddMediatR(c => c.RegisterServicesFromAssembly(typeof(ResizeImageCommand).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(ResizeImageCommand).Assembly);
builder.Services.AddScoped<IImageResizerService, ImageResizerService>();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
