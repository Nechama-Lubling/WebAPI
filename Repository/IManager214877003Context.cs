using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public interface IManager214877003Context
    {
        DbSet<Category> Categories { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Rating> Ratings { get; set; }
        DbSet<User> Users { get; set; }
    }
}