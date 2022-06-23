using CQRS_MediatR.DataStore;
using CQRS_MediatR.Extensions;
using CQRS_MediatR.Helpers;
using CQRS_MediatR.PipelineBehaviors;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// It will automatically scan for the handlers and register them in DI
builder.Services.AddMediatR(typeof(Program));

// We want to return to product class and register FakeDataStore as a service
builder.Services.AddSingleton<ProductDataStore>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MapperService).Assembly);
builder.Services.AddSingleton(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseFluentValidationExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
