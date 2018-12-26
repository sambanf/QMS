using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QMS.DataModel;
using QMS.ViewModel;

namespace QMS.Repo
{
    public class QHeadRepo
    {
        public static List<QHeadViewModel> All()
        {
            List<QHeadViewModel> result = new List<QHeadViewModel>();
            using (var db = new DataContext())
            {
                result = (from qh in db.QHeaders
                          select new QHeadViewModel
                          {
                              q_id = qh.q_id,
                              q_code = qh.q_code,
                              q_name = qh.q_name,
                              q_type = qh.q_type
                          }).ToList();
            }
            return result;
        }


        public static ResponResultViewModel Update(QHeadViewModel entity)
        {
            //Untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new DataContext())
                {
                    //Create
                    if (entity.q_id == 0)
                    {
                        QHeader head = new QHeader();

                        head.q_code = entity.q_code;
                        head.q_name = entity.q_name;
                        head.q_type = entity.q_type;

                        db.QHeaders.Add(head);
                        db.SaveChanges();
                    }
                    else
                    {
                        QHeader question = db.QHeaders.Where(o => o.q_id == entity.q_id).FirstOrDefault();
                        if (question != null)
                        {
                            question.q_code = entity.q_code;
                            question.q_name = entity.q_name;
                            question.q_type = entity.q_type;
                            foreach (var q in entity.questiondetail)
                            {
                                if (q.q_id == 0)
                                {
                                    QDetail detail = new QDetail();
                                    detail.q_no = q.q_no;
                                    detail.q_qh_id = entity.q_id;
                                    detail.q_question = q.q_question;

                                    db.QDetails.Add(detail);
                                }
                                else
                                {
                                    QDetail detail = db.QDetails.Where(o => o.q_id == q.q_id).FirstOrDefault();
                                    detail.q_no = q.q_no;
                                    detail.q_qh_id = entity.q_id;
                                    detail.q_question = q.q_question;

                                }

                            }

                            db.SaveChanges();
                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Question not Found!";
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }

        public static ResponResultViewModel EditQue(QDetailViewModel entity)
        {
            //Untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new DataContext())
                {
                    if (entity.q_id == 0)
                    {
                        QDetail detail = new QDetail();
                        detail.q_no = entity.q_no;
                        detail.q_question = entity.q_question;

                        db.QDetails.Add(detail);
                        db.SaveChanges();
                    }
                    else
                    {
                        QDetail detail = db.QDetails.Where(o => o.q_id == entity.q_id).FirstOrDefault();
                        detail.q_no = entity.q_no;
                        detail.q_question = entity.q_question;

                        db.SaveChanges();

                    }
                }
            }
            catch (Exception ex)
            {

                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }




        public static QHeadViewModel GetQHeadCode()
        {
            QHeadViewModel result = new QHeadViewModel();

            string newRole = String.Format("Q");
            using (var db = new DataContext())
            {
                var res = (from r in db.QHeaders
                           where r.q_code.Contains(newRole) //contains: check newRev ada atau tidak pada bulan dan tahun itu
                           select new { code = r.q_code }).OrderByDescending(x => x.code).FirstOrDefault();
                if (res != null)
                {
                    string[] lastRef = res.code.Split('Q');
                    newRole += (int.Parse(lastRef[1]) + 1).ToString("D3");
                }
                else
                {
                    newRole += "001";
                }
            }
            result.q_code = newRole;
            return result;
        }

        public static QHeadViewModel GetQuestion(int id)
        {
            QHeadViewModel result = new QHeadViewModel();
            using (var db = new DataContext())
            {
                result = (from c in db.QHeaders
                          where c.q_id == id
                          select new QHeadViewModel
                          {
                              q_id = c.q_id,
                              q_code = c.q_code,
                              q_name = c.q_name,
                              q_type = c.q_type,

                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new QHeadViewModel();
                }
            }
            return result;
        }

        public static QDetailViewModel GetQuestionDetail(int id)
        {
            QDetailViewModel result = new QDetailViewModel();
            using (var db = new DataContext())
            {
                result = (from c in db.QDetails
                          where c.q_id == id
                          select new QDetailViewModel
                          {
                              q_id = c.q_id,
                              q_qh_id =c.q_qh_id,
                              q_no = c.q_no,
                              q_question = c.q_question

                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new QDetailViewModel();
                }
            }
            return result;
        }

        public static List<QDetailViewModel> Detail(int id)
        {
            List<QDetailViewModel> result = new List<QDetailViewModel>();
            using (var db = new DataContext())
            {
                result = (from qd in db.QDetails
                          join qh in db.QHeaders
                          on qd.q_qh_id equals qh.q_id
                          where qd.q_qh_id == id
                          select new QDetailViewModel
                          {
                              q_id = qd.q_id,
                              q_qh_id = qd.q_qh_id,
                              q_no = qd.q_no,
                              q_question = qd.q_question
                          }).ToList();
            }
            return result;
        }
        public static QDetailViewModel DetailItem(QDetailViewModel model)
        {
            QDetailViewModel result = new QDetailViewModel();
            result.q_no = model.q_no;
            result.q_question = model.q_question;
            return result;
        }


    }
}
