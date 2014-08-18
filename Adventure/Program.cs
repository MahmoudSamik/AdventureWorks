using ServiceStack.DataAnnotations;
using ServiceStack.OrmLite;
using ServiceStack.OrmLite.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new OrmLiteConnectionFactory("Data Source=MAHMOUD\\MAHMOUD;Initial Catalog=AdventureWorks2012;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False", new SqlServerOrmLiteDialectProvider()).OpenDbConnection())
            {


                //var ColorANdSaftey = db.Select<products>().Where(x => x.Color == "black" && x.SafetyStockLevel<1000);
                //foreach (var item in ColorANdSaftey)
                //{
                //    Console.WriteLine("the item name is ", item.Name);
                //}


                //var NumberOfEmployee = db.Scalar<int>(db.From<Employee>().Select(Sql.Count("*")));
                //Console.WriteLine(NumberOfEmployee);





                //var Departments = db.Select<EmployeeDepartmentHistory>().OrderBy(x => x.DepartmentID);
                //foreach (var department in Departments)
                //{
                //    Console.WriteLine(department.DepartmentID);
                //}


                //Console.WriteLine("\n");
                //Console.WriteLine("");
                //var product = db.Select<product>();

                //var max = product.GroupBy(w => w.ProductID, w => w.StandardCost, (groupkey, invtotal) => new
                //     {
                //         key = groupkey,
                //         standarcost = invtotal.Max()


                //     });

                // foreach (var item in max)
                //{
                //    Console.WriteLine("{0} , {1}", item.key, item.standarcost);
                //}


                var productinventory = db.Select<ProductInventory>();
                var query = productinventory.GroupBy(x => new
                {

                    prouductid = x.ProductID,
                    locationid = x.LocationID
                }, x => x.Quantity, (groupkey, Maximum) => new
                {
                    key = groupkey,
                    Quantity = Maximum.Max()


                });

                foreach (var item in query)
                {
                    Console.WriteLine("{0} , {1}, {2}", item.key.prouductid, item.key.locationid , item.Quantity);
                }


                
               



                //var NightShift = db.Select<Person>(db.From<Person>().Join<EmployeeDepartmentHistory>().Join<Shift, EmployeeDepartmentHistory>().Where<Shift>(o => o.Name == "Night").OrderBy(x => x.FirstName));

                //foreach (var shift in NightShift)
                //{
                //    Console.WriteLine(shift.FirstName);
                //}









	

                Console.ReadLine();
            }
        }


    }
}