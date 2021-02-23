using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wanda.Games.TicTacToe.BLL;
using Wanda.Games.TicTacToe.DAL;
using Wanda.Games.TicTacToe.Interface.Game;
using Wanda.Games.TicTacToe.Interface.Repository;
using Wanda.Games.TicTacToe.Repository.Helpers;
using Wanda.Games.TicTacToe.Utility;

namespace Wanda.Games.TicTacToe.API
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
            services.AddCors();
            services.AddRouting(options => options.LowercaseUrls = true);
            services.AddDbContext<GameDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GameDatabase")));
            services.AddControllers();
            services.AddTransient<IRepositoryProvider, RepositoryProvider>();
            services.AddTransient<RepositoryFactory, RepositoryFactory>();
            services.AddTransient<IDBContextProvider, DBContextProvider>();
            services.AddTransient<IGameManager, GameManager>();
            services.AddTransient<IPlayerManager, PlayerManager>();


            services.AddAutoMapper(typeof(MapperProfile));

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Dilated Technologies Recruitment",
                    Version = "v2",
                    Description = "Dilated Technologies Recruitment",
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v2/swagger.json", "Recruitment Services");

            }
            );
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
