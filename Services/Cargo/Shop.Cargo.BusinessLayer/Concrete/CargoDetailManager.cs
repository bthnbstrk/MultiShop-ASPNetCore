using MultiShop_ASPNetCore.Cargo.Business.Abstract;
using Shop.Cargo.DataAccessLayer.Abstract;
using Shop.Cargo.EntityLayer.Concrete;

namespace MultiShop_ASPNetCore.Cargo.Business.Concrete;

public class CargoDetailManager : ICargoDetailService
{

    private readonly ICargoDetailDal _cargoDetailDal;

    public CargoDetailManager(ICargoDetailDal cargoDetailDal)
    {
        _cargoDetailDal = cargoDetailDal;
    }

    public void TInsert(CargoDetail entity)
    {
         _cargoDetailDal.Insert(entity);
    }

    public void TUpdate(CargoDetail entity)
    {
        _cargoDetailDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoDetailDal.Delete(id);
    }

    public CargoDetail TGetById(int id)
    {
        return _cargoDetailDal.GetById(id);
    }

    public List<CargoDetail> TGetAll()
    {
        return _cargoDetailDal.GetAll();
    }
}