using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Azure.Documents.Client;
using Microsoft.Azure.Documents;

namespace poolranking_matches_api
{
    public class Startup
    {
        
        private DocumentClient client;


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            this.client = new DocumentClient(new Uri(Constants.EndpointUri), Constants.PrimaryKey);

            this.client.CreateDatabaseIfNotExistsAsync(new Database { Id = Constants.databaseName }).Wait();

            this.client.CreateDocumentCollectionIfNotExistsAsync(UriFactory.CreateDatabaseUri(Constants.databaseName), new DocumentCollection { Id = Constants.collectionName }).Wait();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
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
