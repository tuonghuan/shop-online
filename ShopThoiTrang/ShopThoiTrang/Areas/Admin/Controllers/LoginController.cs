using Model.Dao;
using ShopThoiTrang.Areas.Admin.Models;
using ShopThoiTrang.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Admin/Login/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord), true);
                if (result == 1)
                {
                    var user = dao.GetById(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.GroupID = user.GroupID;
                    var listCredentials = dao.GetListCredential(model.UserName);

                    Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");

                }
                else
                    if (result == 0)
                    {
                        ModelState.AddModelError("", "Tài Khoản Không Tồn Tại.");
                    }
                    else
                        if (result == -1)
                        {
                            ModelState.AddModelError("", "Tài Khoản Đang Bị Khóa.");
                        }
                        else
                            if (result == -2)
                            {
                                ModelState.AddModelError("", "Sai Mật Khẩu.");
                            }
                            else
                                if (result == -3)
                                {
                                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập.");
                                }

                            else
                            {
                                ModelState.AddModelError("", "Đăng Nhập Không Thành Công.");
                            }

            }
            return View("Index");
        }


    }
}