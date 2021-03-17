using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace app.timesheet.com.Controllers {

    [Authorize]
    public class ProductController : Controller {
        private readonly IUnitOfWork repository;

        public ProductController(IUnitOfWork _repository) {
            repository = _repository;
        }

        public ActionResult Index() {
            try {
                ProductViewModel Product = new ProductViewModel() {
                    ProductList = repository.Products.GetAll().ToList()
                };
                return View(Product);
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ProductController", "Index", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        public ActionResult Add() {
            try {
                return PartialView("_Add", new ProductViewModel() { Mode = "Add" });
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ProductController", "Add", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        public ActionResult Edit(string ID) {
            try {
                var selectedProduct = repository.Products.Get(Guid.Parse(ID));

                if (selectedProduct == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                ProductViewModel Product = new ProductViewModel() {
                    ID = selectedProduct.ID,
                    ProductCode = selectedProduct.ProductCode,
                    ProductName = selectedProduct.ProductName
                };

                return PartialView("_Add", Product);
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ProductController", "Edit", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        public ActionResult List() {
            try {
                return PartialView("_List", repository.Products.GetAll().ToList());
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ProductController", "List", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        [HttpPost]
        public ActionResult Save(ProductViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    var Product = repository.Products.GetProductByCode(viewModel.ProductCode);
                    if (Product != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Product Code Already Exist.", showError = false });
                    }

                    Product = repository.Products.GetProductByName(viewModel.ProductName);
                    if (Product != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Product Name Already Exist.", showError = false });
                    }
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Product Name and Product Code is required.", showError = false });
                }

                Product c = new Product() {
                    ID = Guid.NewGuid(),
                    ProductCode = viewModel.ProductCode,
                    ProductName = viewModel.ProductName,
                    CreatedBy = HttpContext.User.Identity.Name,
                    CreatedDtim = DateTime.Now
                };

                repository.Products.Add(c);
                repository.Complete();

                return Json(new ResponseClass<bool>() {
                    data = true,
                    isError = false,
                    message = "Data saved successfully.",
                });
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ProductController", "Save", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        [HttpPost]
        public ActionResult Update(ProductViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    Product c = new Product() {
                        ID = viewModel.ID,
                        ProductCode = viewModel.ProductCode,
                        ProductName = viewModel.ProductName,
                        UpdatedBy = HttpContext.User.Identity.Name,
                        UpdatedDtim = DateTime.Now
                    };
                    repository.Products.Add(c);
                    repository.Complete();
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Product Name and Product Code  is required.", showError = false });
                }
                return Json(new ResponseClass<bool>() {
                    data = true,
                    isError = false,
                    message = "Data Updated successfully.",
                });
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ProductController", "Update", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }
    }
}