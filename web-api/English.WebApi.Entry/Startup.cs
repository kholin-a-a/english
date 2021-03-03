using English.BusinessLogic;
using English.BusinessLogic.Providers;
using English.BusinessLogic.Repositories;
using English.BusinessLogic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace English.WebApi.Entry
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddScoped<ICommandService<StartLessonCommand>, StartLessonService>();
            services.AddScoped<ICommandService<MarkWordAsCompleted>, MarkWordAsCompletedService>();
            services.AddScoped<ICommandService<MarkWordAsUknown>, MarkWordAsUknownService>();

            services.AddScoped<IQueryService<GetCurrentLessonQuery, Lesson>, GetCurrentLessonService>();
            services.AddScoped<IQueryService<GetUserStatsQuery, UserStats>, GetUserStatsService>();
            services.AddScoped<IQueryService<GetWordDefinitions, IEnumerable<WordDefinition>>, GetWordDefinitionsService>();
            services.AddScoped<IQueryService<GetNextUserWord, Word>, GetNextUserWordService>();

            services.AddScoped<ILessonRepository, LessonRepository>();
            services.AddScoped<IWordRepository, WordRepository>();
            services.AddScoped<IWordDefinitionRepository, WordDefinitionRepository>();
            services.AddScoped<IUnknownWordRepository, UnknownWordRepository>();
            services.AddScoped<ICompletedWordRepository, CompletedWordRepository>();

            services.AddScoped<INextLessonNumberProvider, NextLessonNumberProvider>();

            services.AddScoped<IUserContext, UserContextStub>();
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
