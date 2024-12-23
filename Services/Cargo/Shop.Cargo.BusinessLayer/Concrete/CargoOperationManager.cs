using MultiShop_ASPNetCore.Cargo.Business.Abstract;
using Shop.Cargo.DataAccessLayer.Abstract;
using Shop.Cargo.EntityLayer.Concrete;

namespace MultiShop_ASPNetCore.Cargo.Business.Concrete;

public class CargoOperationManager : ICargoOperationService
{
    private readonly ICargoOperationDal _cargoOperationDal;

    public CargoOperationManager(ICargoOperationDal cargoOperationDal)
    {
        _cargoOperationDal = cargoOperationDal;
    }
    
    public void TInsert(CargoOperation entity)
    {
        _cargoOperationDal.Insert(entity);
    }

    public void TUpdate(CargoOperation entity)
    {
        _cargoOperationDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoOperationDal.Delete(id);
    }

    public CargoOperation TGetById(int id)
    {
        return _cargoOperationDal.GetById(id);
    }

    public List<CargoOperation> TGetAll()
    {
        return _cargoOperationDal.GetAll();
    }
}