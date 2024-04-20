using SimpleEcommerce.Api;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureService().ConfigurePipeline();

//await app.ResetDatabaseAsync();
app.Run();
