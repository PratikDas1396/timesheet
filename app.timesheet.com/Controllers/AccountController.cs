using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

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

        public ActionResult Login() {
            if(HttpContext.User.Identity.Name != null) {
                if(HttpContext.User.Identity.Name.ToString() != "") {
                    return RedirectToAction("Index", "Home");
                }
                else {
                    FormsAuthentication.SignOut();
                    return PartialView("Login");
                }
            }
            FormsAuthentication.SignOut();
            return PartialView("Login");
        }


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
                    UserID = account.UserID,
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
                    if (repository.Account.CheckUserEmail(viewModel.Email)) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Email Already Exits.", showError = false });
                    }
                    if (repository.Account.CheckUserCode(viewModel.UserID)) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "User Code Already Exits.", showError = false });
                    }
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "All fields are required.", showError = false });
                }
                var key = ConfigurationManager.AppSettings["EncKey"].ToString();
                var EncryptedPassword = Cryptography.Encryption(viewModel.Password, key);
                Account c = new Account() {
                    ID = Guid.NewGuid(),
                    DepartmentID = viewModel.DepartmentID,
                    DesignationID = viewModel.DesignationID,
                    UserPin = EncryptedPassword,
                    UserName = viewModel.UserName,
                    UserID = viewModel.UserID,
                    Email = viewModel.Email,
                    IsActive = true,
                    CreatedBy = HttpContext.User.Identity.Name,
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

        [HttpPost]
        public ActionResult Authenticate(LoginViewModel loginView) {
            if (ModelState.IsValid) {
                var key = ConfigurationManager.AppSettings["EncKey"].ToString();
                var EncryptedPassword = Cryptography.Encryption(loginView.UserPin, key);
                if (repository.Account.Authenticate(loginView.UserID, EncryptedPassword)) {
                    FormsAuthentication.SetAuthCookie(loginView.UserID, loginView.RememberMe);
                    var accountDetails = repository.Account.GetAccountByUserID(loginView.UserID);
                    Session["UserName"] = accountDetails.UserName;
                    return Json(new ResponseClass<bool>() { isError = false, message = "Authentication Successful.", showError = false });
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Invalid User Email and Password", showError = false });
                }
            }
            else {
                return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Invalid User Email and Password", showError = false });
            }
        }

        public ActionResult SignOut() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}