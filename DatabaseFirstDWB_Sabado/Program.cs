using DatabaseFirstDWB_Sabado.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DatabaseFirstDWB_Sabado
{
    class Program
    {

        public static NORTHWNDContext dataContext = new NORTHWNDContext();

        #region MainExcercises
        public static void Excercise1()
        {
            //select *from Employees


            // var employeeQry = dataContext.Employees.AsQueryable();
            var employeeQry = GetAllEmployees();

            //Como obtener order_details de Orders
            //var oderDetail = dataContext.Orders.Where(w=> w.OrderId == 1).SelectMany(sm => sm.OrderDetails);

            //Materializamos el query
            var output = employeeQry.ToList();
        }

      
        public static void Excercise2()
        {
            //SELECT Title, FirstName, LastName FROM Employees WHERE Title = 'Sales Representative';
            var employeeQry = GetAllEmployees().Select(s => new 
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
           

            // A un objeto lambda que se le asigna sobre un ubjeto anonimo o 
            // un objeto no anonimo, se le llama proyección
            var employeeQry = GetAllEmployees().Where(w => w.Title != "Sales Representative").Select(s => new
            {
                Nombre = s.FirstName,
                Apellido = s.LastName,
                Puesto = s.Title,
            });

            var output = employeeQry.ToList();

        }

        public static void Excercise4(int id = 1)
        {
            //UPDATE Employees SET NAME = ‘Alejandra’ WHERE ID = 1;

            UpdateEmployeeFirstNameById(id, "Alejandra");

        }

     

        private static IQueryable<Employee> GetEmployeeByName(string name = "Rolando")
        {
            return dataContext.
                Employees.Where(w => w.FirstName == name).AsQueryable();
        }

        public static void Excercise5()
        {
            //  Insertar nuevo producto en la tabla Products
           AddNewProduct("Jugo del valle 1lt", 15.50m);

           
        }

   

        public static void Excercise6(int id = 13)
        {
            //Borrar un empleado, por el ID

            DeleteEmployeeById(id);

            //Si queremos borrar todos los rolandos
            //var employees = GetEmployeeByName("Rolando").ToList();
            //dataContext.Employees.RemoveRange(employees);
            //dataContext.SaveChanges();

        }

      

        public static void Excersice7(int orderID = 10248)
        {

            var qry = GetOrderByID(orderID)
                .Select(s => new
                {
                    Cliente = s.Customer.CompanyName,
                    Vendedor = s.Employee.FirstName,
                    Productos = s.OrderDetails.Select(se => se.Product.ProductName),
                });

            var result = qry.ToList();
            //Obtener los productos, el cliente y el empleado por Id de Order
        }


        #endregion

        #region HelperMethods
        private static IQueryable<Employee> GetAllEmployees()
        {
            return dataContext.Employees.Select(s => s);
        }

        private static Employee GetEmployeeById(int id)
        {
            return GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();
        }

        private static void AddNewProduct(string productName, decimal unitPrice)
        {
            var newProduct = new Product();
            newProduct.ProductName = productName;
            newProduct.UnitPrice = unitPrice;
            

            dataContext.Products.Add(newProduct);
            dataContext.SaveChanges();
        }

        private static void DeleteEmployeeById(int id)
        {
            var employee = GetEmployeeById(id);
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();
        }

        private static void UpdateEmployeeFirstNameById(int id, string newName)
        {
            Employee currentEmployee = GetEmployeeById(id);

            if (currentEmployee == null)
                throw new Exception("No se encontró el empleado con el ID proporcionado");

            currentEmployee.FirstName = newName;
            dataContext.SaveChanges();
        }

        private static IQueryable<Order> GetOrderByID(int orderID)
        {
            return GetAllOrders().Where(w => w.OrderId == orderID);
        }

        private static IQueryable<Order> GetAllOrders()
        {
            return dataContext.Orders;
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
