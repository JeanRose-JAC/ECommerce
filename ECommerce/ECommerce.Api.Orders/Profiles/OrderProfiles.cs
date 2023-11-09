namespace ECommerce.Api.Orders.Profiles
{
    public class OrderProfiles : AutoMapper.Profile
    {
        public OrderProfiles()
        {
            CreateMap<Db.Order, Models.Order>();
            CreateMap<Db.OrderItem, Models.OrderItem>();
        }
    }
}
