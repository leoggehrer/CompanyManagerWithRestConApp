﻿using CompanyManager.RestConApp.Models;
using System.Text;
using System.Text.Json;

namespace CompanyManager.RestConApp
{
    internal class Program
    {
        private static string API_BASE_URL = "https://localhost:7074/api/";
        private static Common.Modules.Configuration.AppSettings _appSettings = Common.Modules.Configuration.AppSettings.Instance;

        static Program()
        {
            API_BASE_URL = _appSettings["Server:BASE_URL"] ?? API_BASE_URL;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(/*string[] args*/)
        {
            string input = string.Empty;

            while (!input.Equals("x", StringComparison.CurrentCultureIgnoreCase))
            {
                int index = 1;
                Console.Clear();
                Console.WriteLine("CompanyManager REST-API");
                Console.WriteLine("==========================================");

                Console.WriteLine($"{nameof(InitDatabase),-25}....{index++}");

                Console.WriteLine($"{nameof(PrintCompanyies),-25}....{index++}");
                Console.WriteLine($"{nameof(QueryCompanies),-25}....{index++}");
                Console.WriteLine($"{nameof(AddCompany),-25}....{index++}");
                Console.WriteLine($"{nameof(DeleteCompany),-25}....{index++}");

                //Console.WriteLine($"{nameof(PrintCustomers),-25}....{index++}");
                //Console.WriteLine($"{nameof(QueryCustomers),-25}....{index++}");
                //Console.WriteLine($"{nameof(AddCustomer),-25}....{index++}");
                //Console.WriteLine($"{nameof(DeleteCustomer),-25}....{index++}");

                //Console.WriteLine($"{nameof(PrintEmployees),-25}....{index++}");
                //Console.WriteLine($"{nameof(QueryEmployees),-25}....{index++}");
                //Console.WriteLine($"{nameof(AddEmployee),-25}....{index++}");
                //Console.WriteLine($"{nameof(DeleteEmployee),-25}....{index++}");

                Console.WriteLine();
                Console.WriteLine($"Exit...............x");
                Console.WriteLine();
                Console.Write("Your choice: ");

                input = Console.ReadLine()!;
                if (Int32.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            InitDatabase();
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;

                        case 2:
                            PrintCompanyies();
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        case 3:
                            QueryCompanies();
                            Console.WriteLine();
                            Console.Write("Continue with Enter...");
                            Console.ReadLine();
                            break;
                        case 4:
                            AddCompany();
                            break;
                        case 5:
                            DeleteCompany();
                            break;

                        //case 6:
                        //    PrintCustomers(context);
                        //    Console.WriteLine();
                        //    Console.Write("Continue with Enter...");
                        //    Console.ReadLine();
                        //    break;
                        //case 7:
                        //    QueryCustomers(context);
                        //    Console.WriteLine();
                        //    Console.Write("Continue with Enter...");
                        //    Console.ReadLine();
                        //    break;
                        //case 8:
                        //    AddCustomer(context);
                        //    break;
                        //case 9:
                        //    DeleteCustomer(context);
                        //    break;

                        //case 10:
                        //    PrintEmployees(context);
                        //    Console.WriteLine();
                        //    Console.Write("Continue with Enter...");
                        //    Console.ReadLine();
                        //    break;
                        //case 11:
                        //    QueryEmployees(context);
                        //    Console.WriteLine();
                        //    Console.Write("Continue with Enter...");
                        //    Console.ReadLine();
                        //    break;
                        //case 12:
                        //    AddEmployee(context);
                        //    break;
                        //case 13:
                        //    DeleteEmployee(context);
                        //    break;
                        default:
                            break;
                    }
                }
            }
        }

        public static void InitDatabase()
        {
#if DEBUG
            UserData userData = new UserData() { UserName = "Admin", Password = "passme1234!" };
            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(API_BASE_URL);
            client.PostAsync("System", new StringContent(JsonSerializer.Serialize(userData), Encoding.UTF8, "application/json")).Wait();
#endif
        }

        /// <summary>
        /// Prints all companies in the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void PrintCompanyies()
        {
            Console.WriteLine();
            Console.WriteLine("Companies:");
            Console.WriteLine("----------");

            HttpClient client = new HttpClient();

            client.BaseAddress = new Uri(API_BASE_URL);

            var response = client.GetAsync("Companies").Result;

            if (response.IsSuccessStatusCode)
            {
                // Annahme: Die Antwort ist im JSON-Format
                var json = response.Content.ReadAsStringAsync().Result;
                var companies = JsonSerializer.Deserialize<Company[]>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? [];

                foreach (var company in companies)
                {
                    Console.WriteLine($"{company}");
                    foreach (var customer in company.Customers)
                    {
                        Console.WriteLine($"\t{customer}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Fehler beim Abrufen der Companies. Status: {response.StatusCode}");
            }
        }

        /// <summary>
        /// Queries companies based on a user-provided condition.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void QueryCompanies()
        {
            Console.WriteLine();
            Console.WriteLine("Query-Companies:");
            Console.WriteLine("----------------");

            Console.Write("Query: ");
            var query = Console.ReadLine()!;

            try
            {
                //foreach (var company in context.CompanySet.AsQueryable().Where(query).Include(e => e.Customers))
                //{
                //    Console.WriteLine($"{company}");
                //    foreach (var customer in company.Customers)
                //    {
                //        Console.WriteLine($"{customer}");
                //    }
                //}
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Adds a new company to the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void AddCompany()
        {
            Console.WriteLine();
            Console.WriteLine("Add company:");
            Console.WriteLine("------------");

            //var company = new Logic.Entities.Company();

            //Console.Write("Name [256]:          ");
            //company.Name = Console.ReadLine()!;
            //Console.Write("Adresse [1024]:      ");
            //company.Address = Console.ReadLine()!;
            //Console.Write("Beschreibung [1024]: ");
            //company.Description = Console.ReadLine()!;

            //context.CompanySet.Add(company);
            //context.SaveChanges();
        }

        /// <summary>
        /// Deletes a company from the context.
        /// </summary>
        /// <param name="context">The database context.</param>
        private static void DeleteCompany()
        {
            Console.WriteLine();
            Console.WriteLine("Delete company:");
            Console.WriteLine("---------------");

            Console.WriteLine();
            Console.Write("Name: ");
            var name = Console.ReadLine()!;
            //var entity = context.CompanySet.FirstOrDefault(e => e.Name == name);

            //if (entity != null)
            //{
            //    try
            //    {
            //        context.CompanySet.Remove(entity);
            //        context.SaveChanges();
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        Console.Write("Continue with enter...");
            //        Console.ReadLine();
            //    }
            //}
        }
    }
}
