using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CoreBackend.Database;

namespace CoreBackend.Controllers
{
    public class TaskController : Controller
    {
        [HttpGet]
        [Route("api/[controller]/GetTasks")]
        public JsonResult GetTasks()
        {
            using (var db = new TaskContext())
            {
                return Json(db.Tasks.ToList());
            }
        }

        [HttpGet]
        [Route("api/[controller]/GetTask/{id}")]
        public JsonResult GetTask(int id)
        {
            return Json("");
        }

        [HttpPost]
        [Route("api/[controller]/CreateTask")]
        public JsonResult CreateTask()
        {
            return Json("");
        }

        [HttpPut]
        [Route("api/[controller]/UpdateTask")]
        public JsonResult UpdateTask()
        {
            return Json(""); 
        }

        [HttpDelete]
        [Route("api/[controller]/DeleteTask")]
        public JsonResult DeleteTask()
        {
            return Json("");
        }

        #region "Testing methods"
        [HttpGet]
        [Route("api/[controller]/CreateTestTask")]
        public string CreateTestTask()
        {
            using (var db = new TaskContext())
            {
                int taskCount = db.Tasks.Count();

                db.Tasks.Add(new Task() { Description = String.Format("Test task #{0}", (taskCount += 1).ToString()) });

                db.SaveChanges();
            }

            return "done.";
        }
        #endregion
    }
}
