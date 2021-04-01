using DatabaseFirstDWB_Sabado.DataAccess;
using DatabaseFirstDWB_Sabado.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDWB_Sabado.Backend
{
    public class EmployeeSC : BaseSC
    {

        //GET
        public Employee GetEmployeeById(int id)
        {
            var employee = GetAllEmployees().Where(w => w.EmployeeId == id).FirstOrDefault();

            if (employee == null)
                throw new Exception("El id solicitado para el empleado que quieres obtener, no existe");

            return employee;
        }

        //GET
        public IQueryable<Employee> GetAllEmployees()
        {
            return dataContext.Employees.Select(s => s);
        }

        //DELETE
        public void DeleteEmployeeById(int id)
        {
            var employee = GetEmployeeById(id);
            dataContext.Employees.Remove(employee);
            dataContext.SaveChanges();
        }

        public void UpdateEmployeeFirstNameById(int id, string newName)
        {
            Employee currentEmployee = GetEmployeeById(id);

            if (currentEmployee == null)
                throw new Exception("No se encontró el empleado con el ID proporcionado");

            currentEmployee.FirstName = newName;
            dataContext.SaveChanges();
        }


        public void AddEmployee(EmployeeModel newEmployee)
        {
            // notación parecida a JSON
            var newEmployeeRegister = new Employee()
            {
                FirstName = newEmployee.Name,
                LastName = newEmployee.FamilyName
            };


            dataContext.Employees.Add(newEmployeeRegister);
            dataContext.SaveChanges();


        }

    }
}
