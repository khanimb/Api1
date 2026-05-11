using Api1.Data;
using Api1.Profiles;
using Microsoft.EntityFrameworkCore;

namespace Api1
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddHttpContextAccessor();
            services.AddAutoMapper(opt => opt.AddProfile(new MapperProfile(new HttpContextAccessor())));
        }
    }
}
