using Microsoft.AspNetCore.Builder;
using WebApiAut;

var builder = WebApplication.CreateBuilder(args);

// config startup.

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
//

var app = builder.Build();

startup.Configure(app, app.Environment);


app.Run();
