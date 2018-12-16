using System;
using System.Collections.Generic;
using System.Linq;
using WebCommon;

namespace WebApp.PrintClasses
{
    public class TEST : BasePrint
    {
        protected override void PrintHeader()
        {
            base.creator.Cell("B4").Value = "ExcelCreator 2016";
        }

        protected override void PrintDetail()
        {
            //【2】値の設定
            base.creator.Cell("H4").Value = 10;
            base.creator.Cell("K4").Value = 64000;
            base.creator.Cell("O4").Func("=H4*K4", 640000);
            base.creator.Cell("B5").Value = "VB-Report 8";
            base.creator.Cell("H5").Value = 8;
            base.creator.Cell("K5").Value = 85000;
            base.creator.Cell("O5").Func("=H5*K5", 680000);
            base.creator.Cell("B6").Value = "ExcelWebForm";
            base.creator.Cell("H6").Value = 5;
            base.creator.Cell("K6").Value = 70000;
            base.creator.Cell("O6").Func("=H6*K6", 350000);
            base.creator.Cell("O10").Func("=SUM(O4:R8)", 1670000);
            base.creator.Cell("O11").Func("=O10*0.08", 133600);
            base.creator.Cell("O12").Func("=O10+O11", 1803600);
        }

        protected override void PrintFooter()
        {

        }
    }
}