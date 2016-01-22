using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PageWizardPoc.Models;

namespace PageWizardPoc.Controllers
{
    public class MonitorController : Controller
    {
        // GET: Monitor
        public ActionResult Index(int id, MonitorEditViewModel monitorEditViewModel)
        {
            ViewBag.Message = "Monitor page.";

            if (!monitorEditViewModel.EditingTriggerOrAlert)
            {
                monitorEditViewModel = new MonitorEditViewModel
                {
                    MonitorId = 99,
                    MonitorName = "testing 123",
                    Triggers = new List<TriggerViewModel>
                    {
                        new TriggerViewModel {TriggerId = 2, TriggerName = "trigger 2"},
                        new TriggerViewModel {TriggerId = 4, TriggerName = "trigger 4"},
                    }
                };

            }
            else
            {
                monitorEditViewModel.EditingTriggerOrAlert = false;
            }

            return View(monitorEditViewModel);
        }

        // POST: Monitor
        [HttpPost]
        public ActionResult Index(MonitorEditViewModel monitorEditViewModel)
        {
            if (monitorEditViewModel.EditingTriggerOrAlert)
            {
                
                TempData["monitorEditViewModel"] = monitorEditViewModel;
                return RedirectToAction("Trigger" );
                //return Trigger(monitorEditViewModel);
            }

            ViewBag.Message = "Saved Monitor!";

            return View(monitorEditViewModel);
        }

        public ActionResult Trigger(MonitorEditViewModel monitorEditViewModel)
        {
            monitorEditViewModel = TempData["monitorEditViewModel"] as MonitorEditViewModel;
            return View(monitorEditViewModel);

        }
    }
}