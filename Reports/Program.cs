using EmployeeManager.Models;
using Microsoft.EntityFrameworkCore;
using System;
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



            Console.WriteLine("User Management Console App");
            using (EmployeeContext db = new EmployeeContext(optionsBuilder.Options))
            {
                var totalUser = db.Users.Count();
                var lastuserCreate = db.Users.OrderByDescending(x => x.CreateDate).FirstOrDefault();
                var firstUserCreate = db.Users.OrderByDescending(x => x.CreateDate).LastOrDefault();
                var userHeightAge = db.Users.OrderByDescending(x=>x.BirthDay).LastOrDefault();
                var userYoungest = db.Users.OrderByDescending(x => x.BirthDay).FirstOrDefault();
                Console.WriteLine($"Total user: {totalUser}");
                Console.WriteLine($"Last user created: {lastuserCreate.UserName}");
               // Console.WriteLine($"First user created: {firstUserCreate.UserName},Id:{firstUserCreate.Id}");
                Console.WriteLine($"User with highest age: {userHeightAge.UserName} - Date Of Birth: {userHeightAge.BirthDay.ToString("dd-MMM-yyyy")}");
               // Console.WriteLine($"User is youngest: {userYoungest.UserName} - Date Of Birth: {userYoungest.BirthDay.ToString("dd-MMM-yyyy")}");
            }

        }
    }
}
