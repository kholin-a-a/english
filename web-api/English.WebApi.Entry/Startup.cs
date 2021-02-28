using English.BusinessLogic;
using English.BusinessLogic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace English.WebApi
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ICommandService<StartLesson>, StartLessonService>();
            services.AddScoped<ICommandService<StopLesson>, StopLessonService>();
            services.AddScoped<ICommandService<MarkWordAsCompleted>, MarkWordAsCompletedService>();
            services.AddScoped<ICommandService<MarkWordAsUknown>, MarkWordAsUknownService>();

            services.AddScoped<IQueryService<GetCurrentLesson, Lesson>, GetCurrentLessonService>();
            services.AddScoped<IQueryService<GetUserStats, UserStats>, GetUserStatsService>();
            services.AddScoped<IQueryService<GetWordDefinitions, IEnumerable<WordDefinition>>, GetWordDefinitionsService>();
            services.AddScoped<IQueryService<GetNextUserWord, Word>, GetNextUserWordService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()
                    .WithMethods("GET", "POST", "PUT", "DELETE")
                    .AllowCredentials();
            });

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
