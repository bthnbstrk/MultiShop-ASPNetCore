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
    
    public async Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync()
    {
        string query = "Select * From Coupons";
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryAsync<ResultDiscountCouponDto>(query);
            return values.ToList();
        }
    }

    public async Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto)
    {
        string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isActive,@validDate)";
        var parameters = new DynamicParameters();
        parameters.Add("@code",createDiscountCouponDto.Code);
        parameters.Add("@rate",createDiscountCouponDto.Rate);
        parameters.Add("@isActive",createDiscountCouponDto.IsActive);
        parameters.Add("@validDate",createDiscountCouponDto.ValidDate);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto)
    {
        string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isActive,ValidDate=@validDate where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("@code",updateDiscountCouponDto.Code);
        parameters.Add("@rate",updateDiscountCouponDto.Rate);
        parameters.Add("@isActive",updateDiscountCouponDto.IsActive);
        parameters.Add("@validDate",updateDiscountCouponDto.ValidDate);
        parameters.Add("@couponId",updateDiscountCouponDto.CouponId);
    }

    public async Task DeleteDiscountCouponAsync(int id)
    {
        string query = "Delete From Coupons where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("couponId",id);
        using (var connection = _context.CreateConnection())
        {
            await connection.ExecuteAsync(query, parameters);
        }
    }

    public async Task<GetByIdCouponDto> GetByIdDiscountCouponAsync(int id)
    {
        string query = "Select * From Coupons where CouponId=@couponId";
        var parameters = new DynamicParameters();
        parameters.Add("couponId",id);
        using (var connection = _context.CreateConnection())
        {
            var values = await connection.QueryFirstOrDefaultAsync<GetByIdCouponDto>(query, parameters);
            return values;
        }
    }
}