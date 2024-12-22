using Shop.Cargo.DataAccessLayer.Abstract;
using Shop.Cargo.DataAccessLayer.Concrete;
using Shop.Cargo.DataAccessLayer.Repositories;
using Shop.Cargo.EntityLayer.Concrete;

namespace Shop.Cargo.DataAccessLayer.EntityFramework;

public class EfCargoCompanyDal : GenericRepository<CargoCompany> ,ICargoCompanyDal
{

    public EfCargoCompanyDal(CargoContext context) : base(context)
    {
        
    }
}