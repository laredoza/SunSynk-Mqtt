using System.Net.Http.Headers;
using System.Text;
using Api.Authentication;
using Api.Authentication.Configuration;
using Api.Configuration;
using Api.Services;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "SunSynk", Version = "v1" });
			});
// builder.Services.AddSwaggerGen(c =>
// {
// 	c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
// 	c.IgnoreObsoleteActions();
// 	c.IgnoreObsoleteProperties();
// 	c.CustomSchemaIds(type => type.FullName);
// });
// builder.Services.AddSwaggerGen(options =>
// 	{

// 		options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
// 	});

builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();
builder.Services.Configure<SunSynk>(builder.Configuration.GetSection("SunSynkApi"));

// var tokenKey = builder.Configuration.GetValue<string>("TokenKey");
// var key = Encoding.ASCII.GetBytes(tokenKey);

ConfigureAuthentication();
var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SunSynk v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

void ConfigureAuthentication()
{
	var config = builder.Configuration.GetSection("SunSynk");
	builder.Services.Configure<AuthenticationServiceOptions<SunSynkServiceOptions>>(config);
	builder.Services.AddTransient<AuthenticationHandler<SunSynkServiceOptions>>();


	builder.Services.AddHttpClient<ISunSynkService, SunSynkService>()
		    .ConfigureHttpClient((serviceProvider, client) =>
		    {
			    var options = serviceProvider.GetRequiredService<IOptionsMonitor<AuthenticationServiceOptions<SunSynkServiceOptions>>>().CurrentValue;
			    client.BaseAddress = new Uri(options.Url);
			    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
		    })
		    .AddHttpMessageHandler<AuthenticationHandler<SunSynkServiceOptions>>();

	builder.Services.AddHttpClient<IAuthenticationService<SunSynkServiceOptions>, AuthenticationService<SunSynkServiceOptions>>()
	    .ConfigureHttpClient((serviceProvider, client) =>
	    {
		    var options = serviceProvider.GetRequiredService<IOptionsMonitor<AuthenticationServiceOptions<SunSynkServiceOptions>>>().CurrentValue;
		    client.BaseAddress = new Uri(options.Url);
		    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
	    });
}