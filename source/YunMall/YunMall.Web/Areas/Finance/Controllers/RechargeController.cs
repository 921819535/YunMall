﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using YunMall.Entity.db;
using YunMall.Entity.json;
using YunMall.Utility.LoginUtils;
using YunMall.Web.Controllers;
using YunMall.Web.IBLL.finance;
using YunMall.Web.IBLL.user;

namespace YunMall.Web.Areas.Finance.Controllers
{
    public class RechargeController : BaseController
    {
        [Dependency(name: "PaysServiceImpl")]
        public IFinanceService PaysService { get; set; }

        [Dependency]
        public IUserService UserService { get; set; }


        // GET: Finance/Recharge
        public ActionResult Index()
        {
            return View();
        }


        public JsonResult ToRecharge(string username, double amount) {
            User user = UserService.GetUserByName(username);
            bool result = PaysService.Recharge(user.Uid, amount);
            if(result) return Json(new HttpResp("充值成功"));
            return Json(new HttpResp(1, "充值失败"));
        }
    }
}