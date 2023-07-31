using AspNetCoreRateLimit;
using Core.Interfaces;
using Infrastructure.Repository;
using Infrastructure.UnitOfWork;

namespace API.Extensions;

    public static class ApllicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options => 
            {
                options.AddPolicy("CorsPolicy",builder=>
                    builder.AllowAnyOrigin()        //WithOrigins("http://domini.com")
                    .AllowAnyMethod()               //WithMethods(*GET", "POST")
                    .AllowAnyHeader());             //WithHeaders(*accept*, "content-type")
            });


        public static void AddAplicacionServices(this IServiceCollection services){
            services.AddScoped<IUnitOfWork,UnitOfWork>();
        }

        public static void ConfigureRateLimiting(this IServiceCollection services){
            services.AddMemoryCache();
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddInMemoryRateLimiting();
            services.Configure<IpRateLimitOptions>(options =>
            {
                options.EnableEndpointRateLimiting = true;
                options.StackBlockedRequests = false;
                options.HttpStatusCode = 429;
                options.RealIpHeader = "X-Real-Ip";
                options.GeneralRules = new List<RateLimitRule>{
                    new RateLimitRule 
                    { 
                        Endpoint = "*", 
                        Period = "10s", 
                        Limit = 2 
                    }
                };

            });
        }


    //     public static void ConfigureApiVersioning(this IServiceCollection services){
    //         services.AddApiVersioning(options => {
    //             options.DefaultApiVersion = new ApiVersion(1, 0);
    //             options.AssumeDefaultVersionWhenUnspecified = true;
    //             //option.ApiVersionReader = new QueryStringApiVersionReader("v);
    //             //option.ApiVersionReader = new HeaderApiVersionReader("X-Version");
    //             options.ApiVersionReader = ApiVersionReader.Combine{
    //                 new QueryStringApiVersionReader("v");
    //                 new HeaderApiVersionReader("X-Version");
    //             } 
    //             options.ReportApiVersions = true;
    //         });
    //     }


 }

    

    
