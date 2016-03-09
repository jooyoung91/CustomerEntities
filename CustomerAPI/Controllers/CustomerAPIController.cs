using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using CustomerBLL;
using CustomerEntities.Entities;

namespace CustomerAPI.Controllers
{
    public class CustomerAPIController : ApiController
    {
        public CustomerAPIController()
        {

        }

        [AllowAnonymous]
        public Customer[] Get()
        {
            var cusDLL = new CusDLL();
            return cusDLL.GetAll();
        }

        [HttpPost]
        public HttpResponseMessage Post(Customer customer)
        {
            var cusDLL = new CusDLL();
            if (customer.ID == 0)
                cusDLL.Insert(customer);
            else
                cusDLL.Update(customer, customer.ID);

            HttpResponseMessage message = Request.CreateResponse<Customer>(System.Net.HttpStatusCode.Created, customer);
            return message;
        }

        [HttpDelete]
        public virtual HttpResponseMessage Delete(int id)
        {
            var cusDLL = new CusDLL();
            if(id != 0)
            {
                //Customer delUser = cusDLL.GetById(id);
                cusDLL.Delete(id);
            }

            HttpResponseMessage message = Request.CreateResponse<int>(System.Net.HttpStatusCode.Created, id);
            return message;

        }
    }
}
