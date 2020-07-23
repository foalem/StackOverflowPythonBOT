// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.9.1

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.AI.QnA;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackOverflowPythonBOT.Bots;

//using StackOverflowPythonBOT.Bots;
//using StackOverflowPythonBOT.Dialogs;

namespace StackOverflowPythonBOT
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<ChatBOTContext>(options =>
            //options.UseSqlServer(Configuration.GetConnectionString("ChatBOTDatabaseConnection")));

            // Add the HttpClientFactory to be used for the QnAMaker calls.
            services.AddHttpClient();

            services.AddControllers().AddNewtonsoftJson();

            // Create the storage we'll be using for User and Conversation state. (Memory is great for testing purposes.)
            services.AddSingleton<IStorage, MemoryStorage>();

            // Create the User state.
            services.AddSingleton<UserState>();

            // Create the Bot Framework Adapter with error handling enabled.
            services.AddSingleton<IBotFrameworkHttpAdapter, AdapterWithErrorHandler>();

            // Create the Conversation state. (Used by the Dialog system itself.)
           // services.AddSingleton<ConversationState>();

            // The Dialog that will be run by the bot.
            //services.AddSingleton<MainDialog>();
            //services.AddSingleton<MyQnAMaker>();
            //services.AddSingleton(new QnAMakerEndpoint
            //{
            //    KnowledgeBaseId = Configuration.GetValue<string>($"QnAKnowledgebaseId"),
            //    EndpointKey = Configuration.GetValue<string>($"QnAAuthKey"),
            //    Host = Configuration.GetValue<string>($"QnAEndpointHostName")
            //});

            // The Dialog that will be run by the bot.
            //services.AddSingleton<DialogBot>();

            // Create the bot as a transient. In this case the ASP Controller is expecting an IBot.
            services.AddTransient<IBot, DialogAndWelcomeBot>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles()
                .UseStaticFiles()
                .UseWebSockets()
                .UseRouting()
                .UseAuthorization()
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });

            // app.UseHttpsRedirection();
        }
    }
}
