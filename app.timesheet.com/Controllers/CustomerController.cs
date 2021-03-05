﻿using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace app.timesheet.com.Controllers {
    public class CustomerController : Controller {
        private readonly IUnitOfWork repository;

        public CustomerController(IUnitOfWork _repository) {
            repository = _repository;
        }

        public ActionResult Index() {
            CustomerViewModel customer = new CustomerViewModel() {
                CustomerList = repository.Customers.GetAll().ToList()
            };
            return View(customer);
        }

        public ActionResult Add() => PartialView("_Add", new CustomerViewModel() { Mode = "Add" });
        
        public ActionResult Edit(string ID) {
            try {
                var selectedCustomer = repository.Customers.Get(Guid.Parse(ID));

                if (selectedCustomer == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                CustomerViewModel customer = new CustomerViewModel() {
                    ID  = selectedCustomer.ID,
                    CustomerCode = selectedCustomer.CustomerCode,
                    CustomerName = selectedCustomer.CustomerName
                };

                return PartialView("_Add", customer);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public ActionResult List() => PartialView("_List", repository.Customers.GetAll().ToList());

        [HttpPost]
        public ActionResult Save(CustomerViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    var customer = repository.Customers.GetCustomerByCode(viewModel.CustomerCode);
                    if (customer != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Customer Code Already Exist.", showError = false });
                    }

                    customer = repository.Customers.GetCustomerByName(viewModel.CustomerName);
                    if (customer != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Customer Name Already Exist.", showError = false });
                    }
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Customer Name and Customer Code is required.", showError = false });
                }

                Customer c = new Customer() {
                    ID = Guid.NewGuid(),
                    CustomerCode = viewModel.CustomerCode,
                    CustomerName = viewModel.CustomerName,
                    CreatedBy = "system",
                    CreatedDtim = DateTime.Now
                };

                repository.Customers.Add(c);
                repository.Complete();

                return Json(new ResponseClass<bool>() {
                    data = true,
                    isError = false,
                    message = "Data saved successfully.",
                });
            }
            catch (Exception ex) {
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = String.Format("{0}" , Convert.ToString(ex.Message) + " " + Convert.ToString(ex.InnerException)),
                });
            }
        }

        [HttpPost]
        public ActionResult Update(CustomerViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    Customer c = new Customer() {
                        ID = viewModel.ID,
                        CustomerCode = viewModel.CustomerCode,
                        CustomerName = viewModel.CustomerName,
                        UpdatedBy = "system",
                        UpdatedDtim = DateTime.Now
                    };
                    repository.Customers.Add(c);
                    repository.Complete();
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Customer Name and Customer Code  is required.", showError = false });
                }
                return Json(new ResponseClass<bool>() {
                    data = true,
                    isError = false,
                    message = "Data Uodated successfully.",
                });
            }
            catch (Exception ex) {
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = String.Format("{0}", Convert.ToString(ex.Message) + " " + Convert.ToString(ex.InnerException)),
                });
            }
        }
    }
}