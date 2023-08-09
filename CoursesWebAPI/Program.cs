
using CoursesWebAPI.Middleware;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using Tasogarewa.Application;
using Tasogarewa.Application.Common.Behaviors;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Persistance;

var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddAuthentication("Bearer")
           .AddJwtBearer("Bearer", options =>
           {
               options.Authority = "https://localhost:5001";

               options.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateAudience = false
               };
           });
    
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerDocument();
        builder.Services.AddControllers();
        builder.Services.AddAutoMapper(opt =>
        {
            opt.AddProfile(new AssemblyMappingProfile(typeof(ITasogarewaDbContext).Assembly));
            opt.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
        });
        var DbScope = builder.Services.BuildServiceProvider().CreateScope();
        var ServiceProvider = DbScope.ServiceProvider;
        try
        {
            var context = ServiceProvider.GetRequiredService<TasogarewaDbContext>();
    await context.Database.EnsureCreatedAsync();
        }
        catch (Exception ex)
        {
        }
builder.Services.AddApplication();
builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddCors(opt =>
opt.AddPolicy("AllowAll", policy =>
{
policy.AllowAnyHeader();
policy.AllowAnyMethod();
policy.AllowAnyOrigin();
}));

        var app = builder.Build();
        if (app.Environment.IsDevelopment())
        {
              app.UseOpenApi();   
             app.UseSwagger();
            app.UseSwaggerUi3();
        }
        app.UseCors("AllowAll");
        app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
endpoints.MapControllers());


app.UseCustomExceptionHandler();


        app.MapControllers();
        app.Run();


