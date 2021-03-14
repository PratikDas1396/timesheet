using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace app.timesheet.com.Controllers {
    public class AccountController : Controller {

        private readonly IUnitOfWork repository;

        public AccountController(IUnitOfWork _repository) {
            repository = _repository;
        }

        public ActionResult Index() {
            return View("Index", new AccountViewModel() {
                UserList = repository.Account.GetAccounts().ToList(),
            });
        }

        public ActionResult Login() => View("Login");

        public ActionResult ForgotPassword() => View("Login");

        public ActionResult List() => PartialView("_List", repository.Account.GetAccounts().ToList());

        public ActionResult Add() => PartialView("_Add", new AccountViewModel() {
            Mode = "Add",
            DepartmentList = repository.Departments.GetDropdown().ToList(),
            DesignationList = repository.Designations.GetDropdown().ToList(),
        });

        public ActionResult Edit(string ID) {
            try {
                var account = repository.Account.Get(Guid.Parse(ID));

                if (account == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                AccountViewModel accountViewModel = new AccountViewModel() {
                    Mode = "Update",
                    ID = account.ID,
                    Email = account.Email,
                    UserName = account.UserName,
                    DepartmentList = repository.Departments.GetDropdown().ToList(),
                    DesignationList = repository.Designations.GetDropdown().ToList(),
                    DepartmentID = account.DepartmentID,
                    DesignationID = account.DesignationID,
                };

                return PartialView("_Add", accountViewModel);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Save(AccountViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    //To do : Add Validation for Account
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Customer Name and Customer Code is required.", showError = false });
                }

                Account c = new Account() {
                    ID = Guid.NewGuid(),
                    DepartmentID = viewModel.DepartmentID,
                    DesignationID = viewModel.DesignationID,
                    UserPin = viewModel.Password,
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    IsActive = true,
                    CreatedBy = "system",
                    CreatedDtim = DateTime.Now
                };

                repository.Account.Add(c);
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
                    message = String.Format("{0}", Convert.ToString(ex.Message) + " " + Convert.ToString(ex.InnerException)),
                });
            }
        }

    }
}