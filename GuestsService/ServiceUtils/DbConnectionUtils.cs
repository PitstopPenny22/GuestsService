using Bouncer;
using System.Data.Entity.Core.EntityClient;

namespace GuestsService.ServiceUtils
{
    public static class DbConnectionUtils
    {
        public static EntityConnection GetEntityConnection()
        {
            string providerName = "System.Data.SqlClient";
            string providerString = new BouncerService().GetEFPass();
            var entityBuilder = new EntityConnectionStringBuilder
            {
                Provider = providerName,
                ProviderConnectionString = providerString,
                Metadata = @"res://*/GuestsDbContext.csdl|res://*/GuestsDbContext.ssdl|res://*/GuestsDbContext.msl"
            };
            return new EntityConnection(entityBuilder.ToString());
        }
    }
}