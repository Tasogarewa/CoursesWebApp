namespace Tasogarea.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAuthentication(options =>
             {
            options.DefaultScheme = "Cookies";
            options.DefaultChallengeScheme = "oidc";
               
            })
            .AddCookie("Cookies")
           .AddOpenIdConnect("oidc", options =>
           {
               options.Authority = "https://localhost:5001";

               options.ClientId = "35682e2c71354c7c5e7168282a334f742b7d7c3e545c564b6e3b636649";
               options.ClientSecret = "4e4e2f4954536a7a79257945232f5f50";
               options.ResponseType = "code";
               
               options.SaveTokens = true;

               options.Scope.Add("Tasogarewa.Api");

           });
            // Add services to the container.
            builder.Services.AddControllersWithViews();
       
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute()
                    .RequireAuthorization();
            });

            app.Run();
        }
    }
}