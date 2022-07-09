﻿using RestaurantAPI.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;
        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if(_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Roles.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Roles.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                }
            };
            return roles;
        }
        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {


                new Restaurant
                {
                        Name = "KFC",
                        Category = "Fast Food",
                        Description = "KFC (Kentucky Fried Chicken) is an American fast food restaurant chain headquartered in Louisville, Kentucky, that specializes in fried chicken.",
                        HasDelivery = true,
                        ContactEmail = "contact@kfc.com",
                        ContactNumber = "555444333",
                        Dishes = new List<Dish>
                        {
                            new Dish { Name = "Twister", Price = 10.30M},
                            new Dish { Name = "Zinger", Price = 9.30M}
                        },
                        Address = new Address { City = "Kraków", Street = "Długa 5", PostalCode = "30-001"}

                 },
                new Restaurant
                {
                        Name = "McDonald's",
                        Category = "Fast Food",
                        Description = "McDonald's Corporation is an American-based multinational fast food chain, founded in 1940 as a restaurant operated by Richard and Maurice McDonald, in San Bernardino, California, United States.",
                        HasDelivery = true,
                        ContactEmail= "mcdonald@mcd.com",
                        ContactNumber= "111222333",
                        Dishes = new List<Dish>
                        {
                            new Dish { Name = "Cheeseburger", Price = 3.30M},
                            new Dish { Name = "McFlurry", Price = 7.30M}
                        },
                        Address = new Address { City = "Kraków", Street = "Długa 10", PostalCode = "30-001"}

                 }
            };
            return restaurants;

        }
    }
}
