using KD12MVCDataAnnotation.Contexts;
using KD12MVCDataAnnotation.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace KD12MVCDataAnnotation.Models.SeedData
{
    public static class SeedData
    {
        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<HastaneDbContext>();
            context.Database.Migrate();

            if(context.Calisans.Count() == 0)
            {
                context.Calisans.Add(new Calisan()
                {

                    Ad = "Admin",
                    Soyad = "Admin",
                    DogumTarihi = new DateTime(1999, 10, 2),
                    Role = Roles.Admin,
                    EmailAdress = "admin@admin.com",
                    Sifre = "12345",
                });
                context.Calisans.Add(new Calisan()
                {

                    Ad = "Sahin",
                    Soyad = "Uzun",
                    DogumTarihi = new DateTime(1999, 10, 2),
                    Role = Roles.Calisan,
                    EmailAdress = "sahinuzun03@gmail.com",
                    Sifre = "1234",
                });
            }

            context.SaveChanges();
        }
    }
}
