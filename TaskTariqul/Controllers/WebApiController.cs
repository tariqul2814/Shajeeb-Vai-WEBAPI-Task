using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskTariqul.Models;
using TaskTariqul.Models.ViewModel;

namespace TaskTariqul.Controllers
{
    public class WebApiController : ApiController
    {
        ApplicationDBContext context;
        public WebApiController()
        {
            context = new ApplicationDBContext();
        }

        [HttpPost]
        public HttpResponseMessage AddHoliday(Holiday holiday)
        {
            if(!ModelState.IsValid)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            else
            {
                var holidayTracker = context.Holidays.FirstOrDefault(x=>x.UserId==holiday.UserId && x.From_Date==holiday.From_Date && x.To_Date==holiday.To_Date);
                var CheckUser = context.Users.FirstOrDefault(x=> x.UserId==holiday.UserId);
                if(holidayTracker==null && CheckUser!=null)
                {
                    context.Holidays.Add(holiday);
                    context.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, holiday);
                }
                else
                {
                    return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                }
                
            }
        }


        [HttpPost]
        public HttpResponseMessage AddEmployee(EmployeeAddingVModel employeeAddingVModel)
        {
            employeeAddingVModel.Role = employeeAddingVModel.Role.ToString().Trim().ToLower();
            int MaxValue = 0;

            try
            {
                Users users = new Users()
                {
                    Name = employeeAddingVModel.Name,
                    Role = employeeAddingVModel.Role
                };
                context.Users.Add(users);
                context.SaveChanges();

                MaxValue = context.Users.Max(x => x.UserId);

                Salary salary = new Salary()
                {
                    UserId = MaxValue,
                    Salary_Amount = employeeAddingVModel.Salary
                };
                context.Salaries.Add(salary);
                context.SaveChanges();
                employeeAddingVModel.Id = MaxValue;
                return Request.CreateResponse(HttpStatusCode.Created, employeeAddingVModel);
            }
            catch (Exception er)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                throw;
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateEmployee(EmployeeAddingVModel employeeAddingVModel)
        {
            employeeAddingVModel.Role = employeeAddingVModel.Role.ToString().Trim().ToLower();
            try
            {
                Users users = new Users()
                {
                    UserId = employeeAddingVModel.Id,
                    Name = employeeAddingVModel.Name,
                    Role = employeeAddingVModel.Role
                };
                context.Users.AddOrUpdate(users);
                //Salary salary = new Salary()
                //{
                //    UserId = employeeAddingVModel.Id,
                //    Salary_Amount = employeeAddingVModel.Salary
                //};
                Salary salary = new Salary();
                salary = context.Salaries.FirstOrDefault(x => x.UserId == employeeAddingVModel.Id);
                salary.Salary_Amount = employeeAddingVModel.Salary;
                context.Salaries.AddOrUpdate(salary);
                context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.Created, employeeAddingVModel);
            }
            catch (Exception er)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError);
                throw;
            }
        }
    }
}
