using ExifMetadata.Exif;
using ProgramAnalysis.Models;
using ProgramAnalysis.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProgramAnalysis.Controllers
{
    public class InfoImageController : Controller
    {
        //
        // GET: /InfoImage/

        [HttpGet]
        public ActionResult Index()
        {
            InfoImageMV model = new InfoImageMV();
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(InfoImageMV model)
        {
            var infoImage = new ExifTagCollection(model.ImagePath);
            foreach (ExifTag elm in infoImage)
            {
                model.ResultImage.Add(elm);
            }
            MatLabConfig mark = new MatLabConfig();
            mark.MatlabObj.Execute("clc; clear");
            mark.MatlabObj.Execute("cd " + mark.matlabFuncPath);
            ImageInfoMark item = new ImageInfoMark();
            //model.ImagePath = mark.matlabDataPath + "\\THMILKImages\\10000315_SM000736_C000117994_1456718517808.jpg";
            item = mark.ImageReal(model.ImagePath);
            model.ListItem.Add(item);
            item = mark.ItemExistImage(model.ImagePath);
            model.ListItem.Add(item);
            mark.MatlabObj.Quit();
            //List<ObjParamSP> listParam = new List<ObjParamSP>();
            //listParam.Add(new ObjParamSP() { Key = "CommandType", Value = results.CommandType });
            //listParam.Add(new ObjParamSP() { Key = "CommandId", Value = results.CommandId });
            //listParam.Add(new ObjParamSP() { Key = "CommandAction", Value = results.CommandAction });
            //listParam.Add(new ObjParamSP() { Key = "ResultData", Value = deserializer.Serialize(results.Data) });
            //listParam.Add(new ObjParamSP() { Key = "MessStatus", Value = results.Status });
            //listParam.Add(new ObjParamSP() { Key = "Topic", Value = e.Topic });
            //listParam.Add(new ObjParamSP() { Key = "CreateTime", Value = DateTime.Now });
            //var sdsdsd = Utility.Helper.QueryStoredProcedure("LogMessages", listParam);
            return View(model);
        }

    }
}
