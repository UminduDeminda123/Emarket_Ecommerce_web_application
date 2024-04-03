using eMarket.Models;
using eMarket.Models.Data.Static;
using eTickets.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eTickets.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();


                //Dealers
                if (!context.Dealers.Any())
                {
                    context.Dealers.AddRange(new List<Dealer>()
                    {
                        new Dealer()
                        {
                            FullName = "Chinthaka Athapaththu",
                            Area="Colombo",
                            PhoneNumber="0117220132",
                            Bio = "Retail, Service Provider",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Dealer()
                        {
                            FullName = "Jon Snow",
                            Area="Colombo",
                            PhoneNumber="0117220136",
                            Bio = "Retail, Service Provider",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Dealer()
                        {
                            FullName = "Brien Stark",
                            Area="Kandy",
                            PhoneNumber="0117220139",
                            Bio = "Retail, Service Provider",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Dealer()
                        {
                            FullName = "Channa Perera",
                            Area="Colombo",
                            PhoneNumber="0117220138",
                            Bio = "Retail, Service Provider",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Dealer()
                        {
                            FullName = "Saman Perera",
                            Area="Colombo",
                            PhoneNumber="0117220137",
                            Bio = "Retail, Service Provider",
                            ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                //Movies
                if (!context.Products.Any())
                {
                    context.Products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                            Model="Fashion- FBS 907",
                            BrandName="Fashion Holdings",
                            Capacity="30KG",
                            Description = "Industrial Weighing Scales",
                            Price = 135000,
                            ImageURL = "https://fashionholdings.lk/wp-content/uploads/2021/04/scale-pic-red-02.png",

                        },
                        new Product()
                        {

                            Model="AQUA – BP 30",
                            BrandName="AQUA",
                            Capacity="30KG",
                            Description = "30kg Electronic Cash Register Scale",
                            Price = 25000,
                            ImageURL = "https://www.ruhunuscale.lk/wp-content/uploads/2022/12/lable_print_scale.jpg",
                        },
                        new Product()
                        {

                            Model="Alpha RP30",
                            BrandName="Alpha",
                            Capacity="30KG",
                            Description = "30KG Scale",
                            Price = 25000,
                            ImageURL = "https://www.ruhunuscale.lk/wp-content/uploads/2022/12/bill_printing_04-600x720.jpg",

                        },
                        new Product()
                        {

                            Model="Budry – SHAB-80",
                            BrandName="Budry Eloctronic",
                            Capacity="15KG",
                            Description = "15kg Electronic Cash Register Scale.",
                            Price = 145000,
                            ImageURL = "https://www.ruhunuscale.lk/wp-content/uploads/2022/12/SHAB-80-600x720.jpg",

                        },
                        new Product()
                        {

                            Model="BUDRY – SHAB 79",
                            BrandName="Budry Eloctronic",
                            Capacity="15KG",
                            Description = "15kg Electronic Cash Register Scale.",
                            Price = 151000,
                            ImageURL = "https://www.ruhunuscale.lk/wp-content/uploads/2022/12/bill_printing_fullset.jpg",

                        },
                        new Product()
                        {

                            Model="BUDRY – MFD 51",
                            BrandName="Budry Eloctronic",
                            Capacity="15KG",
                            Description = "15kg Electronic Cash Register Scale.",
                            Price = 139000,
                            ImageURL = "https://www.ruhunuscale.lk/wp-content/uploads/2022/12/MFD-51-Budry.jpg",

                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Dealers_Products.Any())
                {
                    context.Dealers_Products.AddRange(new List<Dealer_Product>()
                    {
                        new Dealer_Product()
                        {
                            DealerId = 1,
                            ProductId = 1
                        },
                        new Dealer_Product()
                        {
                            DealerId = 3,
                            ProductId = 1
                        },

                         new Dealer_Product()
                        {
                            DealerId = 1,
                            ProductId = 2
                        },
                         new Dealer_Product()
                        {
                            DealerId = 4,
                            ProductId = 2
                        },

                        new Dealer_Product()
                        {
                            DealerId = 1,
                            ProductId = 3
                        },
                        new Dealer_Product()
                        {
                            DealerId = 2,
                            ProductId = 3
                        },
                        new Dealer_Product()
                        {
                            DealerId = 5,
                            ProductId = 3
                        },


                        new Dealer_Product()
                        {
                            DealerId = 2,
                            ProductId = 4
                        },
                        new Dealer_Product()
                        {
                            DealerId = 3,
                            ProductId = 4
                        },
                        new Dealer_Product()
                        {
                            DealerId = 4,
                            ProductId = 4
                        },


                        new Dealer_Product()
                        {
                            DealerId = 2,
                            ProductId = 5
                        },
                        new Dealer_Product()
                        {
                            DealerId = 3,
                            ProductId = 5
                        },
                        new Dealer_Product()
                        {
                            DealerId = 4,
                            ProductId = 5
                        },
                        new Dealer_Product()
                        {
                            DealerId = 5,
                            ProductId = 5
                        },


                        new Dealer_Product()
                        {
                            DealerId = 3,
                            ProductId = 6
                        },
                        new Dealer_Product()
                        {
                            DealerId = 4,
                            ProductId = 6
                        },
                        new Dealer_Product()
                        {
                            DealerId = 5,
                            ProductId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }
        }
       public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
            {
                using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
                {

                    //Roles
                    var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                    if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                    if (!await roleManager.RoleExistsAsync(UserRoles.User))
                        await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                    //Users
                    var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    string adminUserEmail = "admin@emarket.com";

                    var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                    if (adminUser == null)
                    {
                        var newAdminUser = new ApplicationUser()
                        {
                            FullName = "Admin User",
                            UserName = "admin-user",
                            Email = adminUserEmail,
                            EmailConfirmed = true
                        };
                        await userManager.CreateAsync(newAdminUser, "Coding@1234?");
                        await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                    }


                    string appUserEmail = "user@etickets.com";

                    var appUser = await userManager.FindByEmailAsync(appUserEmail);
                    if (appUser == null)
                    {
                        var newAppUser = new ApplicationUser()
                        {
                            FullName = "Application User",
                            UserName = "app-user",
                            Email = appUserEmail,
                            EmailConfirmed = true
                        };
                        await userManager.CreateAsync(newAppUser, "Coding@1234?");
                        await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                    }
                }
            }
        }
    }
