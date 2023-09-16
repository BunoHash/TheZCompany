using Microsoft.AspNetCore.HttpOverrides;
using NLog;
using TheZ.API.Extensions;
using TheZ.API.Middlewares;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntergation();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers()
    .AddApplicationPart(typeof(TheZ.Presentation.AssemblyReference).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment()) app.UseDeveloperExceptionPage();
else app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions { ForwardedHeaders = ForwardedHeaders.All});
app.UseCors();
app.UseAuthorization();



// Some custom Middlewares examples

//app.Use( async (context, next) => {
//    Console.WriteLine("Logic Before execution the next middleware");
//    context.Response.StatusCode = 200; // Status code can be set before you start send/writing response
//    await next.Invoke();
//    Console.WriteLine("Logic After execution the next middleware");
//});


//app.MapWhen(context => context.Request.Query.ContainsKey("sales"), builder =>
//{
//    builder.Use(async (context, next) =>
//    {
//        Console.WriteLine("Map branch logic in the Use method before the next delegate");
//        await next.Invoke();
//        Console.WriteLine("Map branch logic in the Use method after the next delegate");
//    });

//    //builder.Run(async context =>
//    //{
//    //    await context.Response.WriteAsync("test with MapWhen");

//    //});
//});

app.UseLogTestMiddleware();


app.Map("/products", builder => {

    builder.Use(async (context, next) =>
    {
        Console.WriteLine("Map branch logic in the Use method before the next delegate");
        await next.Invoke();
        Console.WriteLine("Map branch logic in the Use method after the next delegate");
    });
    builder.Run(async context =>
    {
        Console.WriteLine($"Map branch response to the client in the Run method");
        await context.Response.WriteAsync("Hello from the products map branch.");
    });
});

app.UseHomePathMiddleware();



app.MapControllers();
app.Run();
