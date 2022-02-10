﻿using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace SQLServerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCrud sql = new SqlCrud(GetConnectionString());
            
            ReadAllUsers(sql);

            //Console.WriteLine(GetConnectionString());
            Console.WriteLine("Done Processing");
            Console.ReadLine();
        }

        private static void ReadAllUsers(SqlCrud sql)
        {
            var rows = sql.GetAllUsers();

            foreach (var row in rows)
            {
               Console.WriteLine($"{ row.Id }: { row.FirstName } { row.LastName}");
            }

        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }

    }

}
