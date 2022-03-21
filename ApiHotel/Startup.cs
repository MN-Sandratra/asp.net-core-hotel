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

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<BDDContext>(con =>
            con.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPerson, PersonService>();
            services.AddScoped<ICategory, CategoryService>();
            services.AddScoped<IReservation, ReservationService>();
            services.AddScoped<IRoom, RoomService>();
            services.AddScoped<ISupplier, SupplierService>();
            services.AddScoped<IArticle, ArticleService>();
            services.AddScoped<IArticleCategory, ArticleCategoryService>();
            services.AddScoped<IOrder, OrderService>();
            services.AddScoped<IOrderLine, OrderLineService>();
            services.AddScoped<IInput, InputService>();
            services.AddScoped<IOutput, OutputService>();
            services.AddScoped<IReception, ReceptionService>();




        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
