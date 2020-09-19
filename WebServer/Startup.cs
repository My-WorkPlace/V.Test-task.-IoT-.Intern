using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebServer.Helpers;
using WebServer.Services;

namespace WebServer
{
  public class Startup
  {
    private readonly IConfiguration _configuration;

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }
    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      // receive conString from config 
      var connection = _configuration.GetConnectionString("DefaultConnection");
      // add context AppContextDataBase such as service
      services.AddDbContext<DataContext>(options =>
        options.UseSqlServer(connection));
      services.AddControllers().AddNewtonsoftJson(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
      // configure DI for application services
      services.AddScoped<IPersonService, PersonService>();
      services.AddScoped<ICategoryService, CategoryService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseRouting();
      // global cors policy
      app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());


      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}
