using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QMS.Repo;
using QMS.ViewModel;

namespace QMS.Presentation.Controllers
{
    public class QMSController : Controller
    {
        // GET: QMS
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView("_List", QHeadRepo.All());
        }

        public ActionResult Create()
        {
            return PartialView("_Create", QHeadRepo.GetQHeadCode());
        }
        [HttpPost]
        public ActionResult Create(QHeadViewModel model)
        {
            ResponResultViewModel result = QHeadRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(int id)
        {
            return PartialView("_Edit", QHeadRepo.GetQuestion(id));
        }
        [HttpPost]
        public ActionResult Edit(QHeadViewModel model)
        {
            ResponResultViewModel respon = QHeadRepo.Update(model);

            return Json(new
            {
                success = respon.Success,
                message = respon.Message,
                entity = respon.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditQue(int id)
        {
            return PartialView("_QuestionEdit", QHeadRepo.GetQuestionDetail(id));
        }

        [HttpPost]
        public ActionResult EditQue(QDetailViewModel model)
        {
            ResponResultViewModel respon = QHeadRepo.EditQue(model);
            return Json(new
            {
                success = respon.Success,
                message = respon.Message,
                entity = respon.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(int id)
        {
            return PartialView("_Detail", QHeadRepo.Detail(id));
        }

        public ActionResult Detailitem(QDetailViewModel model)
        {
            return PartialView("_Detailitem", QHeadRepo.DetailItem(model));
        }

        public ActionResult Question()
        {
            return PartialView("_Question");
        }


    }
}