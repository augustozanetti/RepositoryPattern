using RepositoryPattern.domain.Entities;
using RepositoryPattern.domain.Repositories;
using RepositoryPattern.Infra.Repositories;
using RepositoryPattern.Infra.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoryPattern.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        private IUnitOfWork _uow;


        public CustomerController(ICustomerRepository customerRepository,
            IUnitOfWork uow)
        {
            _customerRepository = customerRepository;
            _uow = uow;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View(_customerRepository.GetByRange());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            try
            {
                _customerRepository.Save(customer);
                _uow.Commit();
                return RedirectToAction("Index");
            }
            catch 
            {
                ModelState.AddModelError("DefaultErrorMessage", "Falha ao incluir o cliente.");
                return View(customer);
                
            }
        }


        protected override void Dispose(bool disposing)
        {
            _customerRepository.Dispose();
        }
    }
}