using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data.Entity.SqlServer;
using System.Linq;

namespace Reports
{
    class Program
    {
        static string connectionString = "workstation id=netcoredatabase.mssql.somee.com;packet size=4096;user id=nhatle_SQLLogin_1;pwd=w3leq3urg6;data source=netcoredatabase.mssql.somee.com;persist security info=False;initial catalog=netcoredatabase";
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeContext>();

            optionsBuilder
                .UseSqlServer(connectionString);



            Console.WriteLine("User manager console app");
            using (EmployeeContext db = new EmployeeContext(optionsBuilder.Options))
            {
                var totalUser = db.Users.Count();
                var lastuserCreate = db.Users.OrderByDescending(x => x.CreateDate).FirstOrDefault();
                var userHeightAge = db.Users.OrderByDescending(x=>x.BirthDay).FirstOrDefault();
                Console.WriteLine($"Total User: {totalUser}");
                Console.WriteLine($"Last User created: {lastuserCreate.UserName}");
                Console.WriteLine($"User with hight age: {userHeightAge.UserName} - Date Of Birth: {userHeightAge.BirthDay.ToString("dd-MMM-yyyy")}");
            }

        }
    }
}
