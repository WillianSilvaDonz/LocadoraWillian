using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LocacaoFilmes.Repositorio.Data
{
    //Classe para geração do Migrations
    public class EntityDataContextFactory : IDesignTimeDbContextFactory<EntityDataContext>
    {
        public EntityDataContext CreateDbContext(string[] args)
        {
            var rootPath = Directory.GetParent(Environment.CurrentDirectory).FullName;
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(rootPath, "LocacaoFilmes.App"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<EntityDataContext>();

            var connectionString = configuration.GetConnectionString("FilmeLocadoraSql");

            optionsBuilder.UseSqlServer(connectionString);

            //optionsBuilder.ConfigureWarnings(w => w.Throw(RelationalEventId.QueryClientEvaluationWarning));

            return new EntityDataContext(optionsBuilder.Options);
        }
    }
}
