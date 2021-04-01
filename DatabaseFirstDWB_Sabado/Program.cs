using DatabaseFirstDWB_Sabado.Backend;
using DatabaseFirstDWB_Sabado.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DatabaseFirstDWB_Sabado
{
    class Program
    {

        public static EmployeeSC employeeService = new EmployeeSC();
        public static ProductSC productService = new ProductSC();
        public static OrderSC orderService = new OrderSC();


        #region MainExcercises
        public static void Excercise1()
        {
            var employeeQry = employeeService.GetAllEmployees();
            var output = employeeQry.ToList();
        }

      
        public static void Excercise2()
        {
            var employeeQry = employeeService.GetAllEmployees().Select(s => new 
            {
                s.Title,
                s.FirstName,
                s.LastName,
            }).Where(w=> w.Title == "Sales Representative");

            var output = employeeQry.ToList();

            output.ForEach(fe => Console.WriteLine("Nombre: " + fe.FirstName));


        }

        public static void Excercise3()
        {

            var employeeQry = employeeService.GetAllEmployees().Where(w => w.Title != "Sales Representative").Select(s => new
            {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title,
            });

            var output = employeeQry.ToList();

        }

        public static void Excercise4(int id = 1)
        {
            employeeService.UpdateEmployeeFirstNameById(id, "Alejandra");

        }

        public static void Excercise5()
        {
           productService.AddNewProduct("Juzzy de uva Bonafont", 15.50m);
           
        }

   

        public static void Excercise6(int id = 13)
        {
            employeeService.DeleteEmployeeById(id);
        }

      

        public static void Excersice7(int orderID = 10248)
        {
            var qry = orderService.GetOrderByID(orderID)
                .Select(s => new
                {
                    Cliente = s.Customer.CompanyName,
                    Vendedor = s.Employee.FirstName,
                    Productos = s.OrderDetails.Select(se => se.Product.ProductName),
                });

            var result = qry.ToList();
        }


        #endregion

        static void Main(string[] args)
        {
            Excercise1();
            Excercise2();
            Excercise3();
            Excercise4(id: 4);
            Excercise4();
            Excercise5();
            Excercise6();
            Excersice7(); 
            //

            Console.WriteLine("Hello World!");
        }
    }
}
