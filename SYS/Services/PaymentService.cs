using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SYS.Models;
using SYS.Repositories;

namespace SYS.Services
{
    public class PaymentService : BaseService
    {
        public PaymentService(IRepositoryWrapper repositoryWrapper)
            : base(repositoryWrapper)
        {
        }

        public List<Payment> GetPayment()
        {
            return repositoryWrapper.PaymentRepository.FindAll().ToList();
        }

        public List<Payment> GetPaymentByCondition(Expression<Func<Payment, bool>> expression)
        {
            return repositoryWrapper.PaymentRepository.FindByCondition(expression).ToList();
        }

        public void AddPayment(Payment payment)
        {
            repositoryWrapper.PaymentRepository.Create(payment);
        }

        public void UpdatePayment(Payment payment)
        {
            repositoryWrapper.PaymentRepository.Update(payment);
        }

        public void DeletePayment(Payment payment)
        {
            repositoryWrapper.PaymentRepository.Delete(payment);
        }
    }
}

