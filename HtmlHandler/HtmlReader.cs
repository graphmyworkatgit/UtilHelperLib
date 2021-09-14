using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UtilHelper.HtmlHandler
{
    public class HtmlReader
    {
        public void ModifyHtmlTag(string SourceFilePath, string TargetArchivePath)
        {
            HtmlDocument reportDocument = new HtmlDocument();
            reportDocument.Load(SourceFilePath);
            HtmlNode[] htmlHyperlinkNodes = reportDocument.DocumentNode.SelectNodes("//a").ToArray();
            try
            {
                foreach (var link in htmlHyperlinkNodes)
                {
                    var testName = link.ParentNode.PreviousSibling.PreviousSibling.InnerText;
                    link.Attributes["href"].Value = @"";
                }
                reportDocument.Save(SourceFilePath);
            }
            catch(Exception e)
            {

            }


        }
    }
}
