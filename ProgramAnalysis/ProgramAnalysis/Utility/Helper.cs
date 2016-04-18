using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProgramAnalysis.Utility
{
    public static class Helper
    {
        public static string pathMatlab = String.Empty;
        //public static void ThreadProcessing(EvaluationMatlabClass matlab, List<EvaluationImageClass> imagelist, ref EvalAutoMarkMV results)
        //{
        //    try
        //    {
        //        CustomLog.LogError("Start thread ");
        //        int ProcessType = 0;
        //        object output;
        //        object[] result;
        //        foreach (EvaluationImageClass elm in imagelist)
        //        {
        //            //elm.CheckImageValidOrNot();
        //            if (true)
        //            {
        //                try
        //                {
        //                    ProcessType = 1; //Run check Image Real or Fake
        //                    output = null;
        //                    //CustomLog.LogError(" \n imageID: " + elm.CustomerImageID + "----image: " + elm.InputImagePath + "-------img2: " + elm.ComparedImagePath + "----path: " + matlab.BagPath);
        //                    matlab.MatlabObj.Feval(matlab.FunctionName, 10, out output, elm.InputImagePath, elm.ComparedImagePath, "None", matlab.RealFakeThreshold, matlab.StandardOrNotThreshold, matlab.PassOrNotThreshold, ProcessType, matlab.BagPath, matlab.MeanMhistRGBPath, matlab.VLFeat_LibPath);
        //                    result = output as object[];

        //                    elm.RealOrFakeResult = Convert.ToInt16(result[0]);
        //                    elm.PercentFake = Convert.ToDouble(result[3]);
        //                    elm.RealOrFakeTime = Convert.ToDouble(result[6]);
        //                    elm.RealOrFakeResult = (elm.PercentFake >= matlab.RealFakeThreshold) ? 0 : 1;
        //                    elm.ErrorStatus = elm.ErrorStatus + Convert.ToString(result[9]);
        //                    //CustomLog.LogError(" \n Real or Fake Ouput: " + elm.RealOrFakeResult.ToString() + ";" + elm.PercentFake.ToString() + ";" + elm.ErrorStatus);

        //                    ProcessType = 2;// Run check Image correlated with the outlet image
        //                    output = null;
        //                    matlab.MatlabObj.Feval(matlab.FunctionName, 10, out output, elm.InputImagePath, elm.ComparedImagePath, "None", matlab.RealFakeThreshold, matlab.StandardOrNotThreshold, matlab.PassOrNotThreshold, ProcessType, matlab.BagPath, matlab.MeanMhistRGBPath, matlab.VLFeat_LibPath);
        //                    result = output as object[];
        //                    elm.StandardOrNotResult = Convert.ToInt16(result[1]);
        //                    elm.NumCorrelation = Convert.ToDouble(result[4]);
        //                    elm.StandardOrNotTime = Convert.ToDouble(result[7]);
        //                    elm.StandardOrNotResult = (elm.NumCorrelation >= matlab.StandardOrNotThreshold) ? 1 : 0;
        //                    elm.ErrorStatus = elm.ErrorStatus + Convert.ToString(result[9]);
        //                    //CustomLog.LogError(" \n StandardOrNotResult: " + elm.RealOrFakeResult.ToString() + ";" + elm.PercentFake.ToString() + ";" + elm.ErrorStatus);

        //                    ProcessType = 3; //Run check Item exists or not
        //                    List<string> numberExist = new List<string>();
        //                    if (matlab.isNumberic)
        //                    {
        //                        //CustomLog.LogError("So: " + matlab.numNumericItem);
        //                        for (int k = 0; k < matlab.numNumericItem; k++)
        //                        {
        //                            output = null;
        //                            matlab.MatlabObj.Feval(matlab.FunctionName, 10, out output, elm.InputImagePath, elm.ComparedImagePath, matlab.arrItemImagePath[k], matlab.RealFakeThreshold, matlab.StandardOrNotThreshold, matlab.PassOrNotThreshold, ProcessType, matlab.BagPath, matlab.MeanMhistRGBPath, matlab.VLFeat_LibPath);
        //                            result = output as object[];
        //                            matlab.arrNumFeature[k] = Convert.ToDouble(result[5]);
        //                            matlab.arrPassOrNotTime[k] = Convert.ToDouble(result[8]);
        //                            matlab.arrPassOrNotResult[k] = (matlab.arrNumFeature[k] >= matlab.PassOrNotThreshold) ? 1 : 0;
        //                            elm.ErrorStatus = elm.ErrorStatus + Convert.ToString(result[9]);
        //                            if (matlab.arrPassOrNotResult[k] == 1)
        //                            {
        //                                numberExist.Add(matlab.arrItemNumbericID[k]);
        //                            }
        //                            //CustomLog.LogError("Numberic: " + matlab.arrPassOrNotResult[k].ToString() + ";" + elm.ErrorStatus);
        //                        }
        //                        elm.PassOrNotResult = matlab.arrPassOrNotResult.Aggregate(1, (a, b) => a * b);
        //                        elm.PassOrNotNumberic = matlab.arrPassOrNotResult.Aggregate(1, (a, b) => a * b);
        //                        elm.PassOrNotTime = matlab.arrPassOrNotTime.Aggregate(0.0, (a, b) => a + b) / matlab.numNumericItem;
        //                        elm.NumFeature = matlab.arrNumFeature.Aggregate(0.0, (a, b) => a + b);
        //                    }

        //                    elm.StandardOrNotResult = elm.StandardOrNotResult * elm.RealOrFakeResult;
        //                    elm.PassOrNotResult = elm.PassOrNotResult * elm.RealOrFakeResult * elm.StandardOrNotResult;
        //                    elm.ErrorStatus = (elm.ErrorStatus == "") ? "No Error" : elm.ErrorStatus;

        //                    using (NGVisibilityDataContext context = new NGVisibilityDataContext())
        //                    {
        //                        context.usp_UpdateAutoEvalOutletImageByID(
        //                            elm.EvaluationID,
        //                            elm.CustomerID,
        //                            elm.CustomerImageID,
        //                            elm.RealOrFakeResult,
        //                            elm.StandardOrNotResult,
        //                            elm.PassOrNotResult,
        //                            string.Join(";", numberExist.ToArray())
        //                            );
        //                    }
        //                    if (elm.RealOrFakeResult == 1)
        //                    {
        //                        results.ImgThat++;
        //                    }
        //                    else
        //                    {
        //                        results.ImgFakes++;
        //                    }
        //                    if (elm.StandardOrNotResult == 1)
        //                    {
        //                        results.ImgChuan++;
        //                    }
        //                    else
        //                    {
        //                        results.ImgNotStandard++;
        //                    }
        //                    if (elm.PassOrNotResult == 1)
        //                    {
        //                        results.ImgPass++;
        //                    }
        //                    else
        //                    {
        //                        results.ImgNotPass++;
        //                    }
        //                    if (numberExist.Count > 0)
        //                    {
        //                        results.ImgNumberic++;
        //                    }
        //                    else
        //                    {
        //                        results.ImgNotPassNumberic++;
        //                    }
        //                    results.TimeMarking = results.TimeMarking + elm.RealOrFakeTime + elm.StandardOrNotTime + elm.PassOrNotTime;
        //                    results.ImageMarking++;
        //                }
        //                catch (Exception ex)
        //                {
        //                    CustomLog.LogError(ex);
        //                    results.ImgErrorMarking++;
        //                }
        //            }
        //            else
        //            {
        //                results.ImgNotExist++;
        //            }
        //            results.ImagesProgress++;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        CustomLog.LogError(ex);
        //    }
        //}
    }

    public class ImageInfoMark
    {
        public bool IsImgReal {get; set;}
        public int Result {get; set;}
        public double Rate{get;set;}
        public double RunningTime {get; set;}
        public string ErrorDesc{ get; set;}

        public ImageInfoMark()
        {
            this.IsImgReal = false;
            this.ErrorDesc = string.Empty;
        }

    }
    public class MatLabConfig
    {
        public MLApp.MLApp MatlabObj = new MLApp.MLApp();
        public string matlabFuncPath {get; set;}
        public string matlabDataPath {get; set;}
        private string BagPath {get; set;}
        private string MeanMhistRGBPath {get; set;}
        private string RealSamplePath {get; set;}
        private string VLFeatLibPath {get; set;}
        private string ProductImagePath {get; set;}

        public MatLabConfig()
        {
            this.matlabFuncPath = Helper.pathMatlab + "AutoEvaluationFunction";
            this.matlabDataPath = Helper.pathMatlab + "AutoEvaluationData";
            this.BagPath = matlabDataPath + "\\Bag.mat";
            this.MeanMhistRGBPath = matlabDataPath + "\\MeanMhistRGB.mat";
            this.RealSamplePath = matlabDataPath + "\\RealImage_Sample.jpg";
            this.VLFeatLibPath = matlabDataPath + "\\VLFeat_Lib\\toolbox\\vl_setup.m";
            this.ProductImagePath = matlabDataPath + "\\SuaHop_Sample.jpg";
            //this.ProductImagePath = matlabDataPath + "\\sanpham1.jpg";

            this.MatlabObj.Execute("clc; clear");
            this.MatlabObj.Execute("cd " + matlabFuncPath);

        }

        public ImageInfoMark ImageReal(string ImagePath)
        {
            ImageInfoMark info = new ImageInfoMark();
            object output;
            object[] result;
            MatlabObj.Feval("CheckRealImage", 4, out output, ImagePath, BagPath, MeanMhistRGBPath, RealSamplePath);
            result = output as object[];

            info.Result = Convert.ToInt16(result[0]);
            if (info.Result == 1)
            {
                info.IsImgReal = true;
            }
            info.Rate = Convert.ToDouble(result[1]);
            info.RunningTime = Convert.ToDouble(result[2]);
            info.ErrorDesc = Convert.ToString(result[3]);
            //Console.WriteLine("CheckRealImage: \n\t Ket Qua That Gia : " + Result + "\n\t Thoi Gian Chay :" + RunningTime + "\n\t Trang Thai Loi : " + ErrorDesc);
            return info;
        }
        public ImageInfoMark ItemExistImage(string ImagePath, string ItemInImage = "")
        {
            ImageInfoMark info = new ImageInfoMark();
            object output;
            object[] result;
            MatlabObj.Feval("CheckProductImage", 4, out output, ImagePath, ProductImagePath);
            result = output as object[];

            info.Result = Convert.ToInt16(result[0]);
            if (info.Result == 1)
            {
                info.IsImgReal = true;
            }
            info.Rate = Convert.ToDouble(result[1]);
            info.RunningTime = Convert.ToDouble(result[2]);
            info.ErrorDesc = Convert.ToString(result[3]);
            //Console.WriteLine("CheckRealImage: \n\t Ket Qua That Gia : " + Result + "\n\t Thoi Gian Chay :" + RunningTime + "\n\t Trang Thai Loi : " + ErrorDesc);
            return info;
        }
    }
}