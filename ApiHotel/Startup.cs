using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RepositoryLayer;
using ServiceLayer.Implementation;
using ServiceLayer.Interfaces;

namespace ApiHotel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.WithOrigins("http://localhost:58379",
                                        "http://localhost:4200"
                                        )
                                        .AllowAnyHeader()
                                        .AllowAnyMethod();
                });
            });
            services.AddMvc();
            services.AddDbContext<BDDContext>(con =>
            con.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPerson, PersonService>();
            services.AddScoped<ICategory, CategoryService>();
            services.AddScoped<IReservation, ReservationService>();
            services.AddScoped<IRoom, RoomService>();

            services.AddScoped<ICompte, CompteService>();
            services.AddScoped<ITypeCompte, TypeCompteService>();
            services.AddScoped<IClasseCompte, ClasseCompteService>();
            services.AddScoped<IEcriture, EcritureService>();
            services.AddScoped<IMouvement, MouvementService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors(MyAllowSpecificOrigins);
            app.UseMvc();
        }
    }
}
