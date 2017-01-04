using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using CoreBackend.Database;

namespace CoreBackend.Controllers
{
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        [HttpGet]
        public JsonResult Get()
        {
            using (var db = new TaskContext())
            {
                return Json(db.Tasks.ToList());
            }
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            using (var db = new TaskContext())
            {
                return Json(db.Tasks.SingleOrDefault(x => x.Id == id));
            }
        }

        [HttpPost]
        public JsonResult Post([FromBody]Task task)
        {
            try
            {
                using (var db = new TaskContext())
                {
                    db.Tasks.Add(task);
                    db.SaveChanges();

                    return Json("done.");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpPut]
        public JsonResult Put([FromBody]Task task)
        {
            try
            {
                using (var db = new TaskContext())
                {
                    db.Tasks.Update(task);
                    db.SaveChanges();

                    return Json("done.");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            try
            {
                using (var db = new TaskContext())
                {
                    db.Tasks.Remove(db.Tasks.SingleOrDefault(x => x.Id == id));
                    db.SaveChanges();

                    return Json("done.");
                }
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
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
