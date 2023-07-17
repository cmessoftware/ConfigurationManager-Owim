using ConfigurationManager.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Web.Compilation;

namespace ConfigurationManager.Data
{
    internal class DataInitializer : CreateDatabaseIfNotExists<CMDbContext>
    {
         protected override void Seed(CMDbContext context)
         {
    //        var customers = new List<Customer>
    //{
    //    new Customer {FirstName = "Dave", LastName = "Brenner"},
    //    new Customer {FirstName = "Matt", LastName = "Walton"},
    //    new Customer {FirstName = "Steve", LastName = "Hagen"},
    //    new Customer {FirstName = "Pat", LastName = "Walton"},
    //    new Customer {FirstName = "Bad", LastName = "Customer"},
    //};
    //        customers.ForEach(x => context.Customers.AddOrUpdate(
    //            c => new { c.FirstName, c.LastName }, x));
    //        var cars = new List<Inventory>
    //{
    //    new Inventory {Make = "VW", Color = "Black", PetName = "Zippy"},
    //    new Inventory {Make = "Ford", Color = "Rust", PetName = "Rusty"},
    //    new Inventory {Make = "Saab", Color = "Black", PetName = "Mel"},
    //    new Inventory {Make = "Yugo", Color = "Yellow", PetName = "Clunker"},
    //    new Inventory {Make = "BMW", Color = "Black", PetName = "Bimmer"},
    //    new Inventory {Make = "BMW", Color = "Green", PetName = "Hank"},
    //    new Inventory {Make = "BMW", Color = "Pink", PetName = "Pinky"},
    //    new Inventory {Make = "Pinto", Color = "Black", PetName = "Pete"},
    //    new Inventory {Make = "Yugo", Color = "Brown", PetName = "Brownie"},
    //};
    //        context.Cars.AddOrUpdate(x => new { x.Make, x.Color }, cars.ToArray());
    //        var orders = new List<Order>
    //{
    //    new Order {Car = cars[0], Customer = customers[0]},
    //    new Order {Car = cars[1], Customer = customers[1]},
    //    new Order {Car = cars[2], Customer = customers[2]},
    //    new Order {Car = cars[3], Customer = customers[3]},
    //};
    //        orders.ForEach(x => context.Orders.AddOrUpdate(c => new { c.CarId, c.CustomerId }, x));

    //        context.CreditRisks.AddOrUpdate(x => new { x.FirstName, x.LastName },
    //            new CreditRisk
    //            {
    //                Id = customers[4].Id,
    //                FirstName = customers[4].FirstName,
    //                LastName = customers[4].LastName,
    //            });
    //    }

            List<AppRole> roles = new List<AppRole>
            {
                    new AppRole() { RoleName = "Admin",RoleId=EnumRoleId.ADMIN },
                    new AppRole() { RoleName = "Reader",RoleId=EnumRoleId.READER },
                    new AppRole() { RoleName = "Writer",RoleId=EnumRoleId.WRITER }
            };

            roles.ForEach(role => context.AppRole.AddOrUpdate(
                          r => new { r.RoleName, r.RoleId }, role ));

            List<AppRole> roles2 = new List<AppRole>
            {
                    new AppRole() { RoleName = "Reader",RoleId=EnumRoleId.READER },
            };

            context.AppRole.AddOrUpdate(x => new { x.RoleName, x.RoleId }, 
                                        roles2.ToArray());

            List<AppRole> roles3 = new List<AppRole>
            {
                    new AppRole() { RoleName = "Reader",RoleId=EnumRoleId.READER },
            };

            context.AppRole.AddOrUpdate(x => new { x.RoleName, x.RoleId }, 
                                        roles3.ToArray());

            List<AppUser> users = new List<AppUser>
            {
                new AppUser() { Name = "User 1", UserId = "userId1",AppRoles = roles },
                new AppUser() { Name = "User 2", UserId = "userId2",AppRoles = roles2  },
                new AppUser() { Name = "User 3", UserId = "userId3",AppRoles = roles3  }
            };

            users.ForEach(u => context.AppUser.AddOrUpdate(
                          user => new { user.Name, user.UserId, u.RoleId }, 
                          users.ToArray()));


            List<Application> applications = new List<Application>
            {
                    new Application() { Name = "APP1"},
                    new Application() { Name = "APP2"},
                    new Application() { Name = "APP3"},
            };

            applications.ForEach(app => context.Application.AddOrUpdate(
                                 apps => new { apps.Name, apps.UserId, apps.EnvironmentId},
                                 applications.ToArray()));


            base.Seed(context);
        }
    }
}
