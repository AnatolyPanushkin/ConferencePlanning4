using System.Net;
using ConferencePlanning.Data;
using ConferencePlanning.Data.Entities;
using ConferencePlanning.Hubs;
using ConferencePlanning.IdentityServices;
using ConferencePlanning.Services.AccountService;
using ConferencePlanning.Services.ConferenceServices;
using ConferencePlanning.Services.PhotosServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(/*opt =>
{
    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
    opt.Filters.Add(new AuthorizeFilter(policy));
}*/);



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ConferencePlanningContext>(options=>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConferencePlanningContext")));

/*builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy",policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("https://localhost:3000");
    });
});*/

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(bdr =>
    {
        bdr
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});
builder.Services.AddRouting();
builder.Services.AddSignalR();
builder.Services.AddScoped<IConferenceService, ConferenceService>();
builder.Services.AddScoped<IPhotosService, PhotosService>();
builder.Services.AddScoped<IRegistrationService, RegistrationService>();

builder.Services.AddIdentityService(builder.Configuration);

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = false;
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});

var app = builder.Build();

//add new users into db
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
await Seed.SeedData(userManager,services);
//------------------------------//


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider("C:\\Users\\User\\Downloads\\ConferencePlanning3-master\\ConferencePlanning3-master\\ConferencePlanning\\ImgFiles\\ConferencesImg"),
    RequestPath = "/ConfImg"
});

//app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

/*app.UseCors(options =>
{
    options.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .Build();
});*/

app.MapControllers();

app.UseRouting();

//app.UseCors();

/*app.UseEndpoints(endpoint => { 
    endpoint.MapHub<ConferenceHub>("/hub");
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});*/

app.MapHub<ConferenceHub>("/hub");

app.Run();