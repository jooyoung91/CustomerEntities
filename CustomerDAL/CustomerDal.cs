using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomerEntities.Entities;

namespace CustomerDAL
{
    public class CustomerDal
    {
        CustomerServiceEntities ctx = new CustomerServiceEntities();
        public Customer[] GetAll()
        {
            return ctx.Customers.ToArray();
        }

        public Customer GetByID(int id)
        {
            return ctx.Customers.FirstOrDefault(c => c.ID == id);
        }

        public bool Insert(Customer cus)
        {
            try
            {
                ctx.Customers.Add(cus);
                ctx.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Update(int id, Customer cus)
        {
            try
            {
                var _ob = ctx.Customers.SingleOrDefault(c => c.ID == id);
                if(_ob != null)
                {
                    _ob.Email = cus.Email;
                    _ob.Name = cus.Name;
                    _ob.Phone = cus.Phone;
                    _ob.Address = cus.Address;
                    ctx.SaveChanges();

                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var _ob = ctx.Customers.SingleOrDefault(c => c.ID == id);
                if (_ob != null)
                {
                    ctx.Customers.Remove(_ob);
                    ctx.SaveChanges();
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}
