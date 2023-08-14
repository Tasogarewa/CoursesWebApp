using Duende.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Tasogarewa.IdentityServer.Data;
using Tasogarewa.IdentityServer.Models;

namespace Tasogarewa.IdentityServer
{
    internal static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
              
            }) ;

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            builder.Services
                .AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = true;
                    options.Events.RaiseInformationEvents = true;
                    options.Events.RaiseFailureEvents = true;
                    options.Events.RaiseSuccessEvents = true;
                    options.Authentication.CookieLifetime = TimeSpan.FromMinutes(5);
                  options.LicenseKey = null;
                   
                    options.EmitStaticAudienceClaim = true;
                })
                .AddInMemoryIdentityResources(Config.IdentityResources)
                .AddInMemoryApiScopes(Config.ApiScopes)
                .AddInMemoryClients(Config.Clients)
                .AddAspNetIdentity<ApplicationUser>();

            builder.Services.AddAuthentication()
                .AddMicrosoftAccount(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.ClientId = "737ae946-3a0f-44eb-b5b2-4224b0a77b7d";
                    options.ClientSecret = "e598Q~XscKlz_cTWhqCcRnmIho0EflKGu6.M9aD1";
                   
                    
                })
                .AddFacebook(options=>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.AppId = "670111461669984";
                    options.AppSecret = "5e680c9ca099d8f6e7e195fa43128b1c";
                    options.Fields.Add("picture");
                })
                .AddGoogle(options =>
                {
                    options.SignInScheme = IdentityServerConstants.ExternalCookieAuthenticationScheme;
                    options.ClientId = "732613832106-e4tuudvpgekmud7g6igh58uef9d7pfcb.apps.googleusercontent.com";
                    options.ClientSecret = "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";
                    
                  
                });

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.MapRazorPages()
                .RequireAuthorization();

            return app;
        }
    }
}