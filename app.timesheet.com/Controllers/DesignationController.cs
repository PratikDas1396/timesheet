using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;


namespace app.timesheet.com.Controllers
{
    [Authorize]

    public class DesignationController : Controller
    {
        private readonly IUnitOfWork repository;

        public DesignationController(IUnitOfWork _repository) {
            repository = _repository;
        }

        public ActionResult Index() {
            DesignationViewModel Designation = new DesignationViewModel() {
                DesignationList = repository.Designations.GetAll().ToList()
            };
            return View(Designation);
        }

        public ActionResult Add() => PartialView("_Add", new DesignationViewModel() { Mode = "Add" });

        public ActionResult Edit(string ID) {
            try {
                var selectedDesignation = repository.Designations.Get(Guid.Parse(ID));

                if (selectedDesignation == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                DesignationViewModel Designation = new DesignationViewModel() {
                    ID = selectedDesignation.ID,
                    DesignationCode = selectedDesignation.DesignationCode,
                    DesignationName = selectedDesignation.DesignationName
                };

                return PartialView("_Add", Designation);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public ActionResult List() => PartialView("_List", repository.Designations.GetAll().ToList());

        [HttpPost]
        public ActionResult Save(DesignationViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    var Designation = repository.Designations.GetDesignationByCode(viewModel.DesignationCode);
                    if (Designation != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Designation Code Already Exist.", showError = false });
                    }

                    Designation = repository.Designations.GetDesignationByName(viewModel.DesignationName);
                    if (Designation != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Designation Name Already Exist.", showError = false });
                    }
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Designation Name and Designation Code is required.", showError = false });
                }

                Designation c = new Designation() {
                    ID = Guid.NewGuid(),
                    DesignationCode = viewModel.DesignationCode,
                    DesignationName = viewModel.DesignationName,
                    CreatedBy = "system",
                    CreatedDtim = DateTime.Now
                };

                repository.Designations.Add(c);
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
        public ActionResult Update(DesignationViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    Designation c = new Designation() {
                        ID = viewModel.ID,
                        DesignationCode = viewModel.DesignationCode,
                        DesignationName = viewModel.DesignationName,
                        UpdatedBy = "system",
                        UpdatedDtim = DateTime.Now
                    };
                    repository.Designations.Add(c);
                    repository.Complete();
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Designation Name and Designation Code  is required.", showError = false });
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