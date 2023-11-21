using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {

        static List<Employee> employees = new List<Employee>()
        {
               new Employee() {Id = 1 , Name = "PersonA"},
               new Employee() {Id = 2 , Name = "PersonB"},
               new Employee() {Id = 3 , Name = "PersonC"}
        };

        [Route("")]
        public IEnumerable<Employee> Get()
        {
            return employees.ToList();
        }
        [Route("{id:int}", Name = "GetById")]
        public Employee Get(int id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }

        [Route("{name:alpha:lastletter}")]
        public Employee Get(string name)
        {
            return employees.FirstOrDefault(x => x.Name.ToLower().Replace(" ", "") == name.ToLower().Replace(" ", ""));
        }

        [Route("{id}/tasks")]
        public List<string> GetEmployeeTasks(int id)
        {
            switch (id)
            {
                case 1:
                    return new List<String> { "Task 1-1", "Task 1-2", "Task 1-3" };
                case 2:
                    return new List<String> { "Task 2-1", "Task 2-2", "Task 2-3" };
                case 3:
                    return new List<String> { "Task 3-1", "Task 3-2", "Task 3-3" };
                default:
                    return default;

            }
        }


        [Route("~/api/tasks")]
        public IEnumerable<String> GetTasks()
        {
            return new List<String> { "Task 1-1", "Task 1-2", "Task 1-3", "Task 2-1", "Task 2-2", "Task 2-3", "Task 3-1", "Task 3-2", "Task 3-3" };
        }

        [Route("add")]
        [HttpPost]
        public HttpResponseMessage Post(Employee employee)
        {
            employee.Id = employees.Max(x => x.Id) + 1;
            employees.Add(employee);

            HttpResponseMessage responseMessage = Request.CreateResponse(HttpStatusCode.Created);
            //responseMessage.Headers.Location = new Uri(Request.RequestUri + "/" + employee.Id.ToString());
            responseMessage.Headers.Location = new Uri(Url.Link("GetById", new { id = employee.Id }));

            return responseMessage;
        }

    }
}
