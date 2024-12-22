using Shop.Cargo.DataAccessLayer.Abstract;
using Shop.Cargo.DataAccessLayer.Concrete;
using Shop.Cargo.DataAccessLayer.Repositories;
using Shop.Cargo.EntityLayer.Concrete;

namespace Shop.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoCustomerDal : GenericRepository<CargoCustomer>, ICargoCustomerDal
{
    
    public EfCargoCustomerDal(CargoContext context) : base(context)
    {
        
    }
}