using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon;

namespace WebApp.PrintClasses
{
    public class TEST : BasePrint
    {
        protected PrintData data;

        public TEST(string uketukeID, string templateFileName, string downloadFileName)
            : base(uketukeID, templateFileName, downloadFileName){}

        protected override void GetPrintData()
        {
            using (var comodb = new ComDB())
            {
                data = new PrintData
                {
                    CorpInfo = new EntCorpInfo
                    {
                        COMPANY_NM = "",
                        TELNO = "",
                        FAXNO = ""
                    },

                    OrderM = new EntOrderM(),

                    OrderMB = new List<EntOrderMB>()

                };
            }
        }

        protected override void PrintHeader()
        {
            creator.Cell("B4").Value = "ExcelCreator 2016";
            creator.Cell("A1").Value = data.CorpInfo.COMPANY_NM;
        }

        protected override void PrintDetail()
        {
            //【2】値の設定
            creator.Cell("H4").Value = 10;
            creator.Cell("K4").Value = 64000;
            creator.Cell("O4").Func("=H4*K4", 640000);
            creator.Cell("B5").Value = "VB-Report 8";
            creator.Cell("H5").Value = 8;
            creator.Cell("K5").Value = 85000;
            creator.Cell("O5").Func("=H5*K5", 680000);
            creator.Cell("B6").Value = "ExcelWebForm";
            creator.Cell("H6").Value = 5;
            creator.Cell("K6").Value = 70000;
            creator.Cell("O6").Func("=H6*K6", 350000);
            creator.Cell("O10").Func("=SUM(O4:R8)", 1670000);
            creator.Cell("O11").Func("=O10*0.08", 133600);
            creator.Cell("O12").Func("=O10+O11", 1803600);
        }

        protected override void PrintFooter()
        {

        }
    }
}