using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace app.timesheet.com.Controllers {
    [Authorize]
    public class ActivityController : Controller {
        private readonly IUnitOfWork repository;

        public ActivityController(IUnitOfWork _repository) {
            repository = _repository;
        }

        public ActionResult Index() {
            try {
                ActivityViewModel Activity = new ActivityViewModel() {
                    ActivityList = repository.Activity.GetActivities().ToList()
                };
                return View(Activity);
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ActivityController", "Index", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        public ActionResult Add() {
            try {
                return PartialView("_Add", new ActivityViewModel() {
                    Mode = "Add",
                    DepartmentList = repository.Departments.GetDropdown().ToList(),
                    CustomerProductMappingList = repository.CustomerProductMapping.GetDropdown().ToList()
                });
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ActivityController", "Add", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        public ActionResult Edit(string ID) {
            try {
                var selectedActivity = repository.Activity.GetActivityByID(Guid.Parse(ID));

                if (selectedActivity == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                ActivityViewModel Activity = new ActivityViewModel() {
                    ID = selectedActivity.ID,
                    ActivityCode = selectedActivity.ActivityCode,
                    ActivityName = selectedActivity.ActivityName,
                    DepartmentList = repository.Departments.GetDropdown().ToList(),
                    CustomerProductMappingList = repository.CustomerProductMapping.GetDropdown().ToList(),
                    DepartmentID = selectedActivity.DepartmentID,
                    CustomerProductMappingID = selectedActivity.CustomerProductMappingID,
                };

                return PartialView("_Add", Activity);
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ActivityController", "Edit", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        public ActionResult List() {
            try {
                return PartialView("_List", repository.Activity.GetActivities().ToList());
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ActivityController", "List", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        [HttpPost]
        public ActionResult Save(ActivityViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    //To do : Add Validation for Activity
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Activity Name and Activity Code is required.", showError = false });
                }

                Activity c = new Activity() {
                    ID = Guid.NewGuid(),
                    ActivityCode = viewModel.ActivityCode,
                    ActivityName = viewModel.ActivityName,
                    DepartmentID = viewModel.DepartmentID,
                    CustomerProductMappingID = viewModel.CustomerProductMappingID,
                    CreatedBy = HttpContext.User.Identity.Name,
                    CreatedDtim = DateTime.Now
                };

                repository.Activity.Add(c);
                repository.Complete();

                return Json(new ResponseClass<bool>() {
                    data = true,
                    isError = false,
                    message = "Data saved successfully.",
                });
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ActivityController", "Save", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }

        [HttpPost]
        public ActionResult Update(ActivityViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    Activity c = new Activity() {
                        ID = viewModel.ID,
                        ActivityCode = viewModel.ActivityCode,
                        ActivityName = viewModel.ActivityName,
                        UpdatedBy = HttpContext.User.Identity.Name,
                        UpdatedDtim = DateTime.Now
                    };
                    repository.Activity.Add(c);
                    repository.Complete();
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Activity Name and Activity Code  is required.", showError = false });
                }
                return Json(new ResponseClass<bool>() {
                    data = true,
                    isError = false,
                    message = "Data Updated successfully.",
                });
            }
            catch (Exception ex) {
                repository.Exception.Log(ex, "ActivityController", "Update", HttpContext.User.Identity.Name);
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = "Something went wrong",
                });
            }
        }
    }
}