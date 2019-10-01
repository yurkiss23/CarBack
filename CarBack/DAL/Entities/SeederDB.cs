using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarBack.DAL.Entities
{
    public class SeederDB
    {
        public static void SeedCars(EFDbContext context)
        {
            string makerName = "BMW";
            if (context.Makers.SingleOrDefault(m => m.Name == makerName) == null)
            {
                DbMaker maker = new DbMaker
                {
                    Name = makerName,
                    Image = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/08/BMW_logo.svg/500px-BMW_logo.svg.png",
                    IsShow = true
                };
                context.Makers.Add(maker);
                context.SaveChanges();
            }
            makerName = "MERSEDES";
            if (context.Makers.SingleOrDefault(m => m.Name == makerName) == null)
            {
                DbMaker maker = new DbMaker
                {
                    Name = makerName,
                    Image = "https://images-na.ssl-images-amazon.com/images/I/61VaoHj7IbL._SY355_.jpg",
                    IsShow = true
                };
                context.Makers.Add(maker);
                context.SaveChanges();
            }

            string name = "беха";
            if (context.Cars.SingleOrDefault(c => c.Name == name) == null)
            {
                DbCar car = new DbCar
                {
                    Name = name,
                    Image = "https://w-dog.ru/wallpapers/1/3/451975307663692.jpg",
                    MakerId = context.Makers.SingleOrDefault(m => m.Name == "BMW").Id
                };
                context.Cars.Add(car);
                context.SaveChanges();
            }

            name = "мерин";
            if (context.Cars.SingleOrDefault(c => c.Name == name) == null)
            {
                DbCar car = new DbCar
                {
                    Name = name,
                    Image = "https://getbg.net/upload/full/www.GetBg.net_Auto_Mercedes-Benz_Red_Gelding_017716_.jpg",
                    MakerId = context.Makers.SingleOrDefault(m => m.Name == "MERSEDES").Id
                };
                context.Cars.Add(car);
                context.SaveChanges();
            }
        }
        public static void SeedData(IServiceProvider services,IHostingEnvironment env,IConfiguration config)
        {
            using(var scope = services.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<EFDbContext>();

                SeedCars(context);
            }
        }
    }
}
