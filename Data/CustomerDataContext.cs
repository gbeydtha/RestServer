using RestServer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestServer.Data
{
    public class CustomerDataContext
    {
        public List<Customer> Customers; 

        public CustomerDataContext()
        {
            if(Customers == null)
            {
                Customers = new List<Customer>();
                LoadCustomers();
            }

        }
        public void LoadCustomers()
        {
            var customerAa = new Customer() { Id = 3, FirstName = "Aaaa", LastName = "Aaaa", Age = 20 };
            Customers.Add(customerAa);

            var customerAB = new Customer() { Id = 2, FirstName = "Bbbb", LastName = "Aaaa", Age = 56 };
            Customers.Add(customerAB);

            var customerCA = new Customer() { Id = 5, FirstName = "Aaaa", LastName = "Cccc", Age = 32 };
            Customers.Add(customerCA);

            var customerCB = new Customer() { Id = 1, FirstName = "Bbbb", LastName = "Cccc", Age = 50 };
            Customers.Add(customerCB);

            var customerDA = new Customer() { Id = 4, FirstName = "Aaaa", LastName = "Dddd", Age = 70 };
            Customers.Add(customerDA);
        }

        public List<Customer> GetCustomers()
        {
            return Customers.ToList<Customer>()
                .OrderBy(l => l.LastName)
                .ThenBy(f => f.FirstName)
                .ToList();
        }

        public List<Customer> AddCustomer(List<Customer> customers)
        {
            foreach (var customer in customers)
            {
                var uniqueId = Customers.Where(x => x.Id == customer.Id).FirstOrDefault(); 
                if(uniqueId != null)
                {
                    throw new ArgumentException($"CustomerId : {customer.Id} of '{customer.FirstName} {customer.LastName}' is already existed"); 
                }
                Customers.Add(customer);
            }

            return GetCustomers();
        }
    }
}
