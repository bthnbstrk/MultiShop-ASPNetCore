using Shop.Discount.Dtos;

namespace Shop.Discount.Services;

public interface IDiscountService
{
    Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();

    Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);

    Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);

    Task DeleteDiscountCouponAsync(int id);

    Task<GetByIdCouponDto> GetByIdDiscountCouponAsync(int id);
}