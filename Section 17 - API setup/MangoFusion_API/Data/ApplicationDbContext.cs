using MangoFusion_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MangoFusion_API.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<MenuItem> MenuItems { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<MenuItem>().HasData(
				new MenuItem
				{
					Id = 1,
					Name = "Samosa",
					Description = "A crispy and savory Indian snack filled with spiced potatoes and peas.",
					Category = "Appetizer",
					SpecialTag = "Vegetarian",
					Price = 1.99,
				},
				new MenuItem
				{
					Id = 2,
					Name = "Paneer Tikka",
					Description = "Chunks of paneer marinated in spices and grilled to perfection.",
					Category = "Appetizer",
					SpecialTag = "Vegetarian",
					Price = 3.99,
				},
				new MenuItem
				{
					Id = 3,
					Name = "Chicken Curry",
					Description = "A flavorful curry made with tender chicken pieces simmered in a rich tomato-based sauce.",
					Category = "Main Course",
					SpecialTag = "",
					Price = 7.99,
				},
				new MenuItem
				{
					Id = 4,
					Name = "Garlic Naan",
					Description = "Soft and fluffy Indian bread topped with garlic and butter.",
					Category = "Bread",
					SpecialTag = "Vegetarian",
					Price = 1.49,
				},
				new MenuItem
				{
					Id = 5,
					Name = "Mango Lassi",
					Description = "A refreshing yogurt-based drink blended with ripe mangoes and a hint of cardamom.",
					Category = "Beverage",
					SpecialTag = "Vegetarian",
					Price = 2.99,
				}
			);
		}
	}
}