﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebReader.Models;
using WebReader.Service;

namespace WebReader.Controllers
{
    public class UserController : Controller
    {
        // 登录
        public ActionResult Login()
        {
            return View();
        }

        //注册
        public ActionResult Register()
        {
            return View();
        }

        //验证登录
        public ActionResult CheckLogin([Bind(Prefix = "uid")]String uid, [Bind(Prefix = "passwd")]String passwd)
        {
            UserService us = new UserService();
            User user = us.CheckLogin(uid, passwd);
            if (null == user)
                return Content("false");
            else
            {
                Session["user"] = user;
                return Content("true");
            }
        }

        //处理注册
        public ActionResult DealRegister([Bind(Prefix = "uid")]string uid, [Bind(Prefix = "passwd")]string passwd, [Bind(Prefix = "uname")]string uname)
        {
            UserService us = new UserService();
            String result = us.DealRegister(uid, uname, passwd);
            if (null == result)
                return Content("true");
            else
                return Content(result);
        }
    }
}