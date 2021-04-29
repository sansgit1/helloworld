
namespace helloworld.Infrastructure
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading;
    using System.Threading.Tasks;
    using helloworld.Models;
    using helloworld.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    
    /// <summary>
    /// database migrator hosted service
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class MigratorHostedService : IHostedService
    {
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="serviceProvider">Instance of IServiceProvider</param>
        public MigratorHostedService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Start method of the hosted service.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task</returns>
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var score = this.serviceProvider.CreateScope())
            {
                var dutchCtx = score.ServiceProvider.GetRequiredService<DutchContext>();
                await dutchCtx.Database.MigrateAsync(cancellationToken);

                // todo: seed later

                //var myDatabaseContext = score.ServiceProvider.GetRequiredService<MyDatabaseContext>();
                //await myDatabaseContext.Database.MigrateAsync(cancellationToken);
            }
        }

        /// <summary>
        /// Cancellation method.
        /// </summary>
        /// <param name="cancellationToken">Cancellation token.</param>
        /// <returns>Task</returns>
        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
    }
}
