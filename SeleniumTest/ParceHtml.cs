using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SeleniumTest
{
    class ParceHtml
    {
        private static ResultParse resultParse;
       public ParceHtml(IHtmlDocument htmlDocument)
        {
            AllMoneyStaf(htmlDocument.QuerySelectorAll("[class='bet-wrapper ng-star-inserted']"));
            WinMoneyStaf(htmlDocument.QuerySelectorAll("[class='bet roboto-font padding']"));
            resultParse.Cof = Convert.ToDouble(htmlDocument.QuerySelector(".flew-coefficient.ng-star-inserted").TextContent.Replace("x","").Replace(".",","));
            resultParse.CountPeoples = Convert.ToInt32(htmlDocument.QuerySelector("[class='number roboto-font']").TextContent);
            resultParse.LoseMoney = resultParse.AllMoney - resultParse.WinMoney;
            resultParse.PrintResult();
        }
        static void AllMoneyStaf(IHtmlCollection<IElement> elements)
        {
            double Result = 0;
            foreach (var e in elements)
            {
                if(e.TextContent != "FREE BET")
                    Result += Convert.ToDouble(e.TextContent.Replace( ".", ","));
            }
            resultParse.AllMoney = Result;
        }

        static void WinMoneyStaf(IHtmlCollection<IElement> elements)
        {
            if (elements.Count() == 0)
                return;
            double Result = 0;

            foreach (var e in elements)
            {
                if (e.TextContent != "-")
                    Result += Convert.ToDouble(e.TextContent.Replace( ".", ","));
            }
            resultParse.WinMoney = Result;

        }
    }
}
