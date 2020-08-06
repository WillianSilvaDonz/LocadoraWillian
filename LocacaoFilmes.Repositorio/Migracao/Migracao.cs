using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace LocacaoFilmes.Repositorio.Migracao
{
    //Classe de Migracao automatica quando inicia o projeto.
    public static class Migracao
    {
        public static void MigracaoLocadora<TContext>(this IApplicationBuilder app, string databaseName = "wmsdev")
            where TContext : IdentityDbContext
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<TContext>();

                context.Database.OpenConnection();

                try
                {
                    context.Database.GetDbConnection().ChangeDatabase(databaseName);

                    var pendingMigrations = context.Database.GetPendingMigrations();

                    if (pendingMigrations.ToList().Any())
                        context.Database.Migrate();
                }
                catch (Exception ex)
                {
#if (DEBUG)
                    throw new Exception(ex.Message);
#endif
                }

                context.Database.CloseConnection();
            }
        }

    }
}
