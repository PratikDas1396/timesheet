using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace app.timesheet.com.Controllers {
    [Authorize]
    public class CustomerProductMappingController : Controller {
        private readonly IUnitOfWork repository;

        public CustomerProductMappingController(IUnitOfWork _repository) {
            repository = _repository;
        }

        public ActionResult Index() {
            try {
                CustomerProductMappingViewModel CustomerProductMapping = new CustomerProductMappingViewModel() {
                    CustomerProductMappingList = repository.CustomerProductMapping.GetCustomerProductMapping().ToList()
                };
                return View(CustomerProductMapping);
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "CustomerProductMappingController", "Index", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        public ActionResult Add() {
            try {
                return PartialView("_Add", new CustomerProductMappingViewModel() {
                    Mode = "Add",
                    CustomerList = repository.Customers.GetAll().ToList(),
                    ProductList = repository.Products.GetAll().ToList()
                });
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "CustomerProductMappingController", "Add", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        public ActionResult Edit(string ID) {
            try {
                var selectedCustomer = repository.CustomerProductMapping.GetCustomerProductMappingByID(Guid.Parse(ID));

                if (selectedCustomer == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                return PartialView("_Add", new CustomerProductMappingViewModel() {
                    Mode = "Update",
                    ID = Guid.Parse(ID),
                    CustomerID = selectedCustomer.Customer.ID,
                    ProductID = selectedCustomer.Product.ID,
                    CustomerList = repository.Customers.GetAll().ToList(),
                    ProductList = repository.Products.GetAll().ToList()
                });
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "CustomerProductMappingController", "Edit", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        public ActionResult List() {
            try {
                return PartialView("_List", repository.CustomerProductMapping.GetCustomerProductMapping().ToList());
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "CustomerProductMappingController", "List", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        [HttpPost]
        public ActionResult Save(CustomerProductMappingViewModel viewModel) {
            try {

                if (ModelState.IsValid) {
                    var isAvail = repository.CustomerProductMapping.CheckCustomerMappingExists(viewModel.CustomerID, viewModel.CustomerID);
                    if (!isAvail) {
                        var customer = repository.Customers.Get(viewModel.CustomerID);
                        var product = repository.Products.Get(viewModel.ProductID);

                        repository.CustomerProductMapping.Add(new CustomerProductMapping() {
                            ID = Guid.NewGuid(),
                            Product = product,
                            Customer = customer,
                            CreatedBy = HttpContext.User.Identity.Name,
                            CreatedDtim = DateTime.Now
                        });

                        repository.Complete();

                        return Json(new ResponseClass<bool>() {
                            data = true,
                            isError = false,
                            message = "Data saved successfully.",
                        });
                    }
                    else {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "This Mapping Already exits", showError = false });
                    }
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Please select all required fields.", showError = false });
                }
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "CustomerProductMappingController", "Save", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        [HttpPost]
        public ActionResult Update(CustomerProductMappingViewModel viewModel) {
            try {
                return Json(new ResponseClass<bool>() {
                    data = true,
                    isError = false,
                    message = "Data Updated successfully.",
                });
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "CustomerProductMappingController", "Update", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }
    }
}