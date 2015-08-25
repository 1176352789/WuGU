﻿using Framework.Core;
using Framework.Web.Mvc;
using SoftProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SoftPlatform.Controllers
{
    /// <summary>
    /// 控制器：Act_ActivityCostRegulation(活动费用规定)
    /// </summary>
    public class Act_ActivityCostRegulationController : BaseController
    {
        public Act_ActivityCostRegulationController()
        {
        }

        /// <summary>
        /// 活动费用规定--查询
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Index(SoftProjectAreaEntityDomain domain)
        {
            //if (!domain.Querys.QueryDicts.ContainsKey("___equal"))
            //{
            //    if (domain.Item. == null)
            //throw new Exception("主键不能为空");
            //domain.Querys.Add(new Query { QuryType = 0, FieldName = "___equal", Value = domain.Item..ToString() });
            //}

            ModularOrFunCode = "ActivityAreas.Act_ActivityCostRegulation.Index";
            domain.Design_ModularOrFun = Design_ModularOrFun;
            var resp = domain.QueryIndex();

            resp.Items.ForEach(p => p.ActivityCostRegulationContext = p.ActivityCostRegulationContext.Replace("<input ", "<input disabled='disabled'"));
            if (Request.IsAjaxRequest())
                return View(Design_ModularOrFun.PartialView, resp);
            resp.ViewContextName = Design_ModularOrFun.PartialView;
            return View(Design_ModularOrFun.MainView, resp);
        }

        /// <summary>
        /// 活动费用规定--添加查询
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public ActionResult Add(SoftProjectAreaEntityDomain domain)
        {
            var resp = domain.Default();
            ModularOrFunCode = "ActivityAreas.Act_ActivityCostRegulation.Add";
            resp.FunNameEn = "Add";
            resp.ViewContextName = Design_ModularOrFun.PartialView;
            return View(Design_ModularOrFun.MainView, resp);
        }

        /// <summary>
        /// 活动费用规定--添加保存
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        [HttpPost]
        public HJsonResult AddSave(SoftProjectAreaEntityDomain domain)
        {
            domain.Item.ActivityCostRegulationContext = Server.UrlDecode(domain.Item.ActivityCostRegulationContext);

            ModularOrFunCode = "ActivityAreas.Act_ActivityCostRegulation.Add";
            domain.Design_ModularOrFun = Design_ModularOrFun;
            var resp = domain.AddSave();
            return new HJsonResult(new { Data = resp });
        }

        /// <summary>
        /// 活动费用规定--编辑查询
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public ActionResult Edit(SoftProjectAreaEntityDomain domain)
        {
            ModularOrFunCode = "ActivityAreas.Act_ActivityCostRegulation.Edit";
            domain.Design_ModularOrFun = Design_ModularOrFun;
            var resp = domain.ByID();

            ModularOrFunCode = "ActivityAreas.Act_ActivityCostRegulation.Edit";
            resp.FunNameEn = "Edit";
            resp.ViewContextName = Design_ModularOrFun.PartialView;
            return View(Design_ModularOrFun.MainView, resp);
        }

        /// <summary>
        /// 活动费用规定--编辑保存
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        [HttpPost]
        public HJsonResult EditSave(SoftProjectAreaEntityDomain domain)
        {
            domain.Item.ActivityCostRegulationContext = Server.UrlDecode(domain.Item.ActivityCostRegulationContext);

            ModularOrFunCode = "ActivityAreas.Act_ActivityCostRegulation.Edit";
            domain.Design_ModularOrFun = Design_ModularOrFun;

            var resp = domain.EditSave();
            return new HJsonResult(new { Data = resp });
        }

        /// <summary>
        /// 活动费用规定--查看
        /// </summary>
        /// <param name="domain"></param>
        /// <returns></returns>
        public ActionResult Detail(SoftProjectAreaEntityDomain domain)
        {
            ModularOrFunCode = "ActivityAreas.Act_ActivityCostRegulation.Detail";
            domain.Design_ModularOrFun = Design_ModularOrFun;
            var resp = domain.ByID();

            resp.FunNameEn = "Detail";
            resp.ViewContextName = Design_ModularOrFun.PartialView;
            return View(Design_ModularOrFun.MainView, resp);
        }

    }
}
