using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Services
{
    public class DiscountService
        (DiscountContext dbContext, ILogger<DiscountService> logger)
        : DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            // TODO: Implement the logic to retrieve the discount based on the request parameters.
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

            if (coupon is null)
                return new CouponModel { ProductName = request.ProductName, Description = "No discount available", Amount = 0 };

            logger.LogInformation("Discount retrieved for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);

            var couponModel = coupon.Adapt<CouponModel>();

            return couponModel;
        }

        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            var coupon = request.Coupon.Adapt<Coupon>();

            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "Invalid request data"));

            dbContext.Coupons.Add(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount created for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }

        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            //var coupon = await dbContext.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.Coupon.ProductName);
            var coupon = request.Coupon.Adapt<Coupon>();

            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount for ProductName: {request.Coupon.ProductName} not found"));

            //coupon.Description = request.Coupon.Description;
            //coupon.Amount = request.Coupon.Amount;
            dbContext.Coupons.Update(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount updated for ProductName: {ProductName}, Amount: {Amount}", coupon.ProductName, coupon.Amount);

            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }

        public override async Task<DeleteDiscountResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            var coupon = await dbContext.Coupons.FirstOrDefaultAsync(c => c.ProductName == request.ProductName);

            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Discount for ProductName: {request.ProductName} not found"));

            dbContext.Coupons.Remove(coupon);
            await dbContext.SaveChangesAsync();

            logger.LogInformation("Discount deleted for ProductName: {ProductName}", coupon.ProductName);

            return new DeleteDiscountResponse { Success = true };
        }
    }
}
