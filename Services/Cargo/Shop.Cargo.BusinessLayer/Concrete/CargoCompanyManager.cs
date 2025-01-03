using MultiShop_ASPNetCore.Cargo.Business.Abstract;
using Shop.Cargo.DataAccessLayer.Abstract;
using Shop.Cargo.EntityLayer.Concrete;

namespace MultiShop_ASPNetCore.Cargo.Business.Concrete;

public class CargoCompanyManager : ICargoCompanyService
{
    
    private readonly ICargoCompanyDal _cargoCompanyDal;

    public CargoCompanyManager(ICargoCompanyDal cargoCompanyDal)
    {
        _cargoCompanyDal = cargoCompanyDal;
    }

    public void TInsert(CargoCompany entity)
    {
        _cargoCompanyDal.Insert(entity);
    }

    public void TUpdate(CargoCompany entity)
    {
        _cargoCompanyDal.Update(entity);
    }

    public void TDelete(int id)
    {
        _cargoCompanyDal.Delete(id);
    }

    public CargoCompany TGetById(int id)
    {
        return _cargoCompanyDal.GetById(id);
    }

    public List<CargoCompany> TGetAll()
    {
        return _cargoCompanyDal.GetAll();
    }
}