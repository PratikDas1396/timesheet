using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace app.timesheet.com.Controllers {
    [Authorize]
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork repository;

        public DepartmentController(IUnitOfWork _repository) {
            repository = _repository;
        }

        public ActionResult Index() {
            DepartmentViewModel Department = new DepartmentViewModel() {
                DepartmentList = repository.Departments.GetAll().ToList()
            };
            return View(Department);
        }

        public ActionResult Add() => PartialView("_Add", new DepartmentViewModel() { Mode = "Add" });

        public ActionResult Edit(string ID) {
            try {
                var selectedDepartment = repository.Departments.Get(Guid.Parse(ID));

                if (selectedDepartment == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                DepartmentViewModel Department = new DepartmentViewModel() {
                    ID = selectedDepartment.ID,
                    DepartmentCode = selectedDepartment.DepartmentCode,
                    DepartmentName = selectedDepartment.DepartmentName
                };

                return PartialView("_Add", Department);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public ActionResult List() => PartialView("_List", repository.Departments.GetAll().ToList());

        [HttpPost]
        public ActionResult Save(DepartmentViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    var Department = repository.Departments.GetDepartmentByCode(viewModel.DepartmentCode);
                    if (Department != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Department Code Already Exist.", showError = false });
                    }

                    Department = repository.Departments.GetDepartmentByName(viewModel.DepartmentName);
                    if (Department != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Department Name Already Exist.", showError = false });
                    }
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Department Name and Department Code is required.", showError = false });
                }

                Department c = new Department() {
                    ID = Guid.NewGuid(),
                    DepartmentCode = viewModel.DepartmentCode,
                    DepartmentName = viewModel.DepartmentName,
                    CreatedBy = "system",
                    CreatedDtim = DateTime.Now
                };

                repository.Departments.Add(c);
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
        public ActionResult Update(DepartmentViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    Department c = new Department() {
                        ID = viewModel.ID,
                        DepartmentCode = viewModel.DepartmentCode,
                        DepartmentName = viewModel.DepartmentName,
                        UpdatedBy = "system",
                        UpdatedDtim = DateTime.Now
                    };
                    repository.Departments.Add(c);
                    repository.Complete();
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Department Name and Department Code  is required.", showError = false });
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