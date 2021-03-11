using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace app.timesheet.com.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IUnitOfWork repository;

        public ActivityController(IUnitOfWork _repository) {
            repository = _repository;
        }

        public ActionResult Index() {
            ActivityViewModel Activity = new ActivityViewModel() {
                ActivityList = repository.Activity.GetActivities().ToList()
            };
            return View(Activity);
        }

        public ActionResult Add() => PartialView("_Add", new ActivityViewModel() { Mode = "Add",
            DepartmentList = repository.Departments.GetDropdown().ToList(),
            CustomerProductMappingList = repository.CustomerProductMapping.GetDropdown().ToList()
        });

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
                throw ex;
            }
        }

        public ActionResult List() => PartialView("_List", repository.Activity.GetActivities().ToList());

        [HttpPost]
        public ActionResult Save(ActivityViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    //var Activity = repository.Activity.GetActivityByCode(viewModel.ActivityCode);
                    //if (Activity != null) {
                    //    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Activity Code Already Exist.", showError = false });
                    //}

                    //Activity = repository.Activity.GetActivityByName(viewModel.ActivityName);
                    //if (Activity != null) {
                    //    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Activity Name Already Exist.", showError = false });
                    //}
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
                    CreatedBy = "system",
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
                return Json(new ResponseClass<bool>() {
                    isError = true,
                    errorType = ErrorType.RuntimeError,
                    message = String.Format("{0}", Convert.ToString(ex.Message) + " " + Convert.ToString(ex.InnerException)),
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
                        UpdatedBy = "system",
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