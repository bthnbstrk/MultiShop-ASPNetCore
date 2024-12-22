using Shop.Cargo.DataAccessLayer.Abstract;
using Shop.Cargo.DataAccessLayer.Concrete;
using Shop.Cargo.DataAccessLayer.Repositories;
using Shop.Cargo.EntityLayer.Concrete;

namespace Shop.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
{
     
    public EfCargoDetailDal(CargoContext context) : base(context)
    {
        
    }
}