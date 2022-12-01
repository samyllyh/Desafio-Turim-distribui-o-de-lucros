using Microsoft.EntityFrameworkCore;

namespace Desafio_Turim.Context
{
    public class ServiceDbContext
    {
        public static void ConfigureService(IServiceCollection services)
        {
            services.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("FuncionariosBD"));
        }

    }
}