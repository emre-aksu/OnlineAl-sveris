using Infrastructure.DataAccess.Interface;
using Model.Entities;

namespace DataAccesLayer.Interface;

public  interface IEmployeeRepository:IRepository<Employee,int>
{
    Task<List<Employee>> GetByCityAndCountry(string city, string country);
    Task<Employee> LogInAsync(string userName, string password);
}
