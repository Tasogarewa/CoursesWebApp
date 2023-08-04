
using CoursesWebAPI.Middleware;

using System.Reflection;
using Tasogarewa.Application;
using Tasogarewa.Application.Common.Mapping;
using Tasogarewa.Application.Interfaces;
using Tasogarewa.Persistance;




        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

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
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        app.UseCors("AllowAll");
        app.UseHttpsRedirection();
app.UseEndpoints(endpoints =>
endpoints.MapControllers());

app.UseCustomExceptionHandler();

        app.UseAuthorization();
        app.MapControllers();
        app.Run();


