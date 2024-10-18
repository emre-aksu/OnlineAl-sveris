using Model.Dtos;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEmployeeManager
    {
        Task<Employee> LogIn(LogInDto dto);
    }
}
