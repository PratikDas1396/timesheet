using db.timesheet.com;
using repository.timesheet.com;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace app.timesheet.com.Controllers
{
    [Authorize]

    public class TaskController : Controller
    {
        private readonly IUnitOfWork repository;

        public TaskController(IUnitOfWork _repository) {
            repository = _repository;
        }

        public ActionResult Index() {
            TaskViewModel Task = new TaskViewModel() {
                TaskList = repository.Tasks.GetAll().ToList()
            };
            return View(Task);
        }

        public ActionResult Add() => PartialView("_Add", new TaskViewModel() { Mode = "Add" });

        public ActionResult Edit(string ID) {
            try {
                var selectedTask = repository.Tasks.Get(Guid.Parse(ID));

                if (selectedTask == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

                TaskViewModel Task = new TaskViewModel() {
                    ID = selectedTask.ID,
                    TaskCode = selectedTask.TaskCode,
                    TaskDescription = selectedTask.TaskDescription
                };

                return PartialView("_Add", Task);
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public ActionResult List() => PartialView("_List", repository.Tasks.GetAll().ToList());

        [HttpPost]
        public ActionResult Save(TaskViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    var Task = repository.Tasks.GetTaskByCode(viewModel.TaskCode);
                    if (Task != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Task Code Already Exist.", showError = false });
                    }

                    Task = repository.Tasks.GetTaskByDescription(viewModel.TaskDescription);
                    if (Task != null) {
                        return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Task Description Already Exist.", showError = false });
                    }
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Task Description and Task Code is required.", showError = false });
                }

                Task c = new Task() {
                    ID = Guid.NewGuid(),
                    TaskCode = viewModel.TaskCode,
                    TaskDescription = viewModel.TaskDescription,
                    CreatedBy = HttpContext.User.Identity.Name,
                    CreatedDtim = DateTime.Now
                };

                repository.Tasks.Add(c);
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
        public ActionResult Update(TaskViewModel viewModel) {
            try {
                if (ModelState.IsValid) {
                    Task c = new Task() {
                        ID = viewModel.ID,
                        TaskCode = viewModel.TaskCode,
                        TaskDescription = viewModel.TaskDescription,
                        UpdatedBy = HttpContext.User.Identity.Name,
                        UpdatedDtim = DateTime.Now
                    };
                    repository.Tasks.Add(c);
                    repository.Complete();
                }
                else {
                    return Json(new ResponseClass<bool>() { isError = true, errorType = ErrorType.Validation, message = "Task Description and Task Code  is required.", showError = false });
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