using EJProject.Server.Repository;
using EJProject.Shared.Domain;

namespace EJProject.Server.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        Task Save(HttpContext httpContext);
        IGenericRepository<Buyer> Buyers { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<Seller> Sellers { get; }
        IGenericRepository<Staff> Staffs { get; }
        IGenericRepository<Trade> Trades { get; }
        IGenericRepository<Profile> Profiles { get; }


    }
}