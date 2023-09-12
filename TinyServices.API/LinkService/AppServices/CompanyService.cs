using TinyServices.API.LinkService.Model;
using TinyServices.API.Repository;
using Microsoft.EntityFrameworkCore;

namespace TinyServices.API.LinkService.AppServices;
public class CompanyService
{
    private readonly TinyServicesDbContext dbContext;

    public CompanyService(TinyServicesDbContext dbContext)
    {
        this.dbContext = dbContext;

    }

    public Company Create(string name)
    {
        var company = new Company(name);
        dbContext.Companies.Add(company);
        dbContext.SaveChanges();
        return company;
    }

    public List<ShortLink> Get(Guid id)
    {
        var company = dbContext.Companies
        .Include(x=> x.ShortLinks)
        .FirstOrDefault(x => x.Id == id) ??
        throw new Exception("Company with id: {id} not found.");

        
        var shortLinks = company.ShortLinks?.ToList();
        return shortLinks;
    }
}
