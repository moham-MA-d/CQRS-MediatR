using CQRS_MediatR.DataStore;
using CQRS_MediatR.Extensions;
using CQRS_MediatR.Helpers;
using CQRS_MediatR.PipelineBehaviors;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// It will automatically scan for the handlers and register them in DI
builder.Services.AddMediatR(typeof(Program));

// We want to return to product class and register ProductDataStore as a service
builder.Services.AddSingleton<ProductDataStore>();

builder.Services.AddControllers()
    // Register fluent valudaotr in DI
    .AddFluentValidation(options =>
    {
       // Validate child properties and root collection elements
       options.ImplicitlyValidateChildProperties = true;
       options.ImplicitlyValidateRootCollectionElements = true;
       // Automatic registration of validators in assembly
       options.RegisterValidatorsFromAssembly(typeof(Program).Assembly);
    });

builder.Services.AddAutoMapper(typeof(MapperService).Assembly);
// <,> means for any TRequest and TResponse
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));


var app = builder.Build();

app.UseFluentValidationExceptionHandler();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
