using DatabaseFirstDWB_Sabado.DataAccess;
using System;
using System.Linq;

namespace DatabaseFirstDWB_Sabado
{
    class Program
    {

        public static void Excercise1()
        {
            //select *from Employees
            NORTHWNDContext dataContext = new NORTHWNDContext();

            // var employeeQry = dataContext.Employees.AsQueryable();
            var employeeQry = dataContext.Employees.Select(s => s);

            //Como obtener order_details de Orders
            //var oderDetail = dataContext.Orders.Where(w=> w.OrderId == 1).SelectMany(sm => sm.OrderDetails);

            //Materializamos el query
            var output = employeeQry.ToList();
        }

        public static void Excercise2()
        {
            //SELECT Title, FirstName, LastName FROM Employees WHERE Title = 'Sales Representative';

            var dbContext = new NORTHWNDContext();

            var employeeQry = dbContext.Employees.Select(s => new
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

            //Ejemplo de clase NO anonima
            //var employee = new EmployeeModel() { Name  = "Rolando", Age = 21};

            //Objecto o clase anonima
            //var employee = new { Name = "Rolando", Age = 21 };
            //SELECT FirstName as Nombre, LastName as Apellido, Title as Puesto  FROM Employees WHERE Title<> 'Sales Representative'
            var dbContext = new NORTHWNDContext();

            // A un objeto lambda que se le asigna sobre un ubjeto anonimo o 
            // un objeto no anonimo, se le llama proyección
            var employeeQry = dbContext.Employees.Where(w => w.Title != "Sales Representative").Select(s => new
            {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title,
            });

            var output = employeeQry.ToList();

        }
        static void Main(string[] args)
        {
            //Excercise1();
            //Excercise2();
            Excercise3();
            Console.WriteLine("Hello World!");
        }
    }
}
