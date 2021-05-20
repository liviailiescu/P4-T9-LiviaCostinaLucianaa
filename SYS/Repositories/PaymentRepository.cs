using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SYS.Models;

namespace SYS.Repositories
{
    public class PaymentRepository : RepositoryBase<Payment>, IPaymentRepository
    {
        public PaymentRepository(contextclass contextClass)
            : base(contextClass)
        {
        }
    
    }
}
