﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.EF;
using Model.Dao;
using ShopThoiTrang.Common;
using PagedList.Mvc;
using PagedList;

namespace ShopThoiTrang.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
       
        //
        // GET: /Admin/User/
        [HasCredential(RoleID = "VIEW_USER")]
        public ActionResult Index(string searchString, int page = 1,int pageSize = 10)
        {
            var dao = new UserDao();
            var model = dao.ListAllPaging(searchString,page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }
        [HttpGet]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [HasCredential(RoleID = "ADD_USER")]
        public ActionResult Create(User user)
        {
            if(ModelState.IsValid)
            {

                var dao = new UserDao();
                var encryptedMd5Pas = Encryptor.MD5Hash(user.PassWord);
                user.PassWord = encryptedMd5Pas;

                long id = dao.Insert(user);
                if (id > 0)
                {
                    SetAlert("Thêm User Thành Công.","success");
                    return RedirectToAction("Index", "User");

                   
                }
                else
                {
                    ModelState.AddModelError("", "Thêm User Không Thành Công");
                }
            }
            return View("Index");
         
        }
        [HttpGet]
        [HasCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(int id)
        {
            var user = new UserDao().ViewDetail(id);
            return View(user);
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
                 
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {

                var dao = new UserDao();
                if(!string.IsNullOrEmpty(user.PassWord))
                {
                    var encryptedMd5Pas = Encryptor.MD5Hash(user.PassWord);
                    user.PassWord = encryptedMd5Pas;
                }
                

                var result = dao.Update(user);
                if (result)
                {
                    SetAlert("Sửa User Thành Công.", "success");

                    return RedirectToAction("Index", "User");
                }
                else
                {
                    ModelState.AddModelError("", "Cập Nhật User Không Thành Công");
                }
            }
            return View("Edit");

        }
        [HttpDelete]
        [HasCredential(RoleID = "DELETE_USER")]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [HasCredential(RoleID = "EDIT_USER")]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                 status = result
            });
        }
	}
}