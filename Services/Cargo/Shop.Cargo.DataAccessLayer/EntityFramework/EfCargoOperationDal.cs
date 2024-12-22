using Shop.Cargo.DataAccessLayer.Abstract;
using Shop.Cargo.DataAccessLayer.Concrete;
using Shop.Cargo.DataAccessLayer.Repositories;
using Shop.Cargo.EntityLayer.Concrete;

namespace Shop.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoOperationDal : GenericRepository<CargoOperation> , ICargoOperationDal
{
    
    public EfCargoOperationDal(CargoContext context) : base(context)
    {
        
    }
}