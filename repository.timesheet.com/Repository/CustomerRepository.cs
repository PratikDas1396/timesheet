﻿using db.timesheet.com;
using System.Linq;

namespace repository.timesheet.com {
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository {
        
        public CustomerRepository(TimeSheetDBContext _context) : base(_context) {
        }

        public Customer GetCustomerByCode(string CustomerCode) {
            return context.Customer.FirstOrDefault(x => x.CustomerCode == CustomerCode);
        }

        public Customer GetCustomerByName(string CustomerName) {
            return context.Customer.FirstOrDefault(x => x.CustomerName == CustomerName);
        }

        public override bool Equals(object obj) {
            return base.Equals(obj);
        }

        public override int GetHashCode() {
            return base.GetHashCode();
        }

        public override string ToString() {
            return base.ToString();
        }

        public TimeSheetDBContext dBContext { get { return context as TimeSheetDBContext; } }
    }
}