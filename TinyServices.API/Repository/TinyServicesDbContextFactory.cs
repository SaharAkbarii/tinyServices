using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TinyServices.API.Repository;

public class TinyServicesDbContextFactory
        : IDesignTimeDbContextFactory<TinyServicesDbContext>
{
    public TinyServicesDbContext CreateDbContext(string[] args)
    {
        // string cs = Environment.GetEnvironmentVariable("SAMANTHA_CONNECTIONSTRING");
        string cs = "User ID=cmdmvbdm;Password=fKwLLy7aMxpeUXHNxekE5ulvd3jTA0tT;Host=lallah.db.elephantsql.com;Port=5432;Database=cmdmvbdm;"
;


        if (cs == null)
            throw new InvalidOperationException("Provide connection string via SAMANTHA_CONNECTIONSTRING env var");

        DbContextOptions<TinyServicesDbContext> options
            = new DbContextOptionsBuilder<TinyServicesDbContext>()
                .UseNpgsql(cs)
                .Options;

        return new TinyServicesDbContext(options);
    }
}