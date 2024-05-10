using Hotelv2.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Hotelv2.Data
{
    public class HotelDbContext : DbContext
    {
        // Определение сущностей в базе данных
        public DbSet<Client> Clients { get; set; } // Клиент
        public DbSet<Room> Rooms { get; set; } // Номер
        public DbSet<Staff> Staffs { get; set; } // Сотрудники
        public DbSet<Booking> Bookings { get; set; } // Бронирование
        public DbSet<Role> Roles { get; set; } // Роль

        // Конструктор
        public HotelDbContext()
        {
            Database.EnsureCreated();
            SeedInitialData();
        }

        // Переопределение метода для подключения к БД
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=localhost; Port=5432; User id=postgres; Password=1234; Database=Hotelv2;");
        }

        // Метод для добавления первоначальных данных
        private void SeedInitialData()
        {
            if (!Roles.Any())
            {
                var initialRoles = new List<Role>
                {
                    new Role { Post = "Администратор гостиницы" },
                };

                Roles.AddRange(initialRoles);
                SaveChanges();
            }

            if (!Staffs.Any())
            {
                var initialStaffs = new List<Staff>
                {
                    new Staff { FirstName = "Елизавета", LastName = "Владимирова", Patronymic = "Денисовна", UserName = "admin", Password = "111", RoleId = 1 },
                    new Staff { FirstName = "Дарья", LastName = "Долинина", Patronymic = "Александровна", UserName = "admin2", Password = "222", RoleId = 1 },
                };
                Staffs.AddRange(initialStaffs);
                SaveChanges();
            }
        }
    }
}
