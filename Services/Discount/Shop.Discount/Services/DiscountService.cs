using Dapper;
using Shop.Discount.Context;
using Shop.Discount.Dtos;

namespace Shop.Discount.Services;

public class DiscountService : IDiscountService
{
    private readonly DapperContext _context;

    public DiscountService(DapperContext context)
    {
        _context = context;
    }
    
    public  Task<List<ResultCouponDto>> GetAllCouponAsync()
    {
        throw new NotImplementedException();
    }

    public async Task CreateCouponAsync(CreateCouponDto createCouponDto)
    {
        string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code",createCouponDto.Code);
        parameters.Add("@rate",createCouponDto.Rate);
        parameters.Add("@isActive",createCouponDto.IsActive);
        parameters.Add("@validDate",createCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public Task UpdateCouponAsync(UpdateCouponDto updateCouponDto)
    {
        throw new NotImplementedException();
    }

    public Task DeleteCouponAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<GetByIdCouponDto> GetByIdCouponAsync(int id)
    {
        throw new NotImplementedException();
    }
}