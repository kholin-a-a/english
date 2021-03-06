using English.BusinessLogic;
using English.BusinessLogic.Repositories;
using English.BusinessLogic.Services;
using English.BusinessLogic.Validation;
using English.WebApi.Controllers;
using LiteDB;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.IO;

namespace English.WebApi.Entry
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .PartManager
                .ApplicationParts
                .Add(
                    new AssemblyPart(
                        typeof(ApiControllerBase).Assembly
                    )
                );

            services.AddScoped<ICommandService<StartLessonCommand>, StartLessonService>();
            //services.AddScoped<ICommandService<MarkWordAsCompletedCommand>, MarkWordAsCompletedService>();
            services.AddScoped<MarkWordAsCompletedService, MarkWordAsCompletedService>();

            services.AddScoped<ICommandService<MarkWordAsCompletedCommand>, MarkWordAsCompletedValidator>(sp =>
                new MarkWordAsCompletedValidator(
                    sp.GetRequiredService<MarkWordAsCompletedService>(),
                    sp.GetRequiredService<IUserRepository>(),
                    sp.GetRequiredService<IWordRepository>(),
                    sp.GetRequiredService<IUserContext>()
                    )
                );

            services.AddScoped<ICommandService<MarkWordAsUknownCommand>, MarkWordAsUknownService>();

            services.AddScoped<IQueryService<GetCurrentLessonQuery, Lesson>, GetCurrentLessonService>();
            services.AddScoped<IQueryService<GetUserStatsQuery, UserStats>, GetUserStatsService>();
            services.AddScoped<IQueryService<GetWordDefinitionsQuery, IEnumerable<Definition>>, GetWordDefinitionsService>();
            services.AddScoped<IQueryService<GetNextUserWordQuery, Word>, GetNextUserWordService>();

            services.AddScoped<IUserContext, UserContextStub>();

            var dbStream = new MemoryStream();
            services.AddScoped<ILiteDatabase>(sp => new LiteDatabase(dbStream));
            services.AddScoped(sp => sp.GetRequiredService<ILiteDatabase>().GetCollection<User>());
            services.AddScoped(sp => sp.GetRequiredService<ILiteDatabase>().GetCollection<Word>());

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IWordRepository, WordRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            BsonMapper.Global.Entity<Answer>().DbRef(a => a.Word);

            // Add default user
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var users = scope.ServiceProvider.GetRequiredService<ILiteCollection<User>>();
                users.Insert(new User { Id = 11211 });

                var words = scope.ServiceProvider.GetRequiredService<ILiteCollection<Word>>();
                words.Insert(new Word { Text = "example" });
                words.Insert(new Word { Text = "test" });
            }

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
