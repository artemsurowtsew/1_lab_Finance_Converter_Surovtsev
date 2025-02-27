﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
namespace _1_lab_Finance_converter_Surovtsev
{
    public class MinfinComUa : CurrencyAPI
    {
        private static List<HtmlNode> currencyDocumentListHtml;
        public override string[] GetDollar()
        {
            Task task = Task.Factory.StartNew(() => SendRequest());
            task.Wait();
            System.Threading.Thread.Sleep(00);
            if (currencyDocumentListHtml != null)
            {
                var dollarPurchaseString = currencyDocumentListHtml[0].InnerHtml.ToString();
                string[] dollarPurchaseStringArray = dollarPurchaseString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                string dollarPurchaseMinfinComUa = dollarPurchaseStringArray[0].Trim();
                var dollarSaleString = currencyDocumentListHtml[1].InnerHtml.ToString();
                string[] dollarSaleStringArrayHtml = dollarSaleString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                string dollarSaleHtml = dollarSaleStringArrayHtml[6].Trim();
                var dollarSaleStringArray = dollarSaleHtml.Split(new[] { '>' },
                StringSplitOptions.RemoveEmptyEntries);
                string dollarSaleMinfinComUa = dollarSaleStringArray[1].Trim();
                return new string[] { dollarPurchaseMinfinComUa, dollarSaleMinfinComUa };
            }
            else
            {
                return null;
            }
        }
        public override string[] GetEuro()
        {
            if (currencyDocumentListHtml != null)
            {
                var euroPurchaseString = currencyDocumentListHtml[2].InnerHtml.ToString();
                string[] euroPurchaseStringArray = euroPurchaseString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                string euroPurchaseMinfinComUa = euroPurchaseStringArray[0].Trim();
                var euroSaleString = currencyDocumentListHtml[3].InnerHtml.ToString();
                string[] euroSaleStringArrayHtml = euroSaleString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                string euroSaleHtml = euroSaleStringArrayHtml[6].Trim();
                var euroSaleStringArray = euroSaleHtml.Split(new[] { '>' },
                StringSplitOptions.RemoveEmptyEntries);
                string euroSaleMinfinComUa = euroSaleStringArray[1].Trim();
                return new string[] { euroPurchaseMinfinComUa, euroSaleMinfinComUa };
            }
            else
            {
                return null;
            }
        }
        public override string[] GetZloty()
        {
            if (currencyDocumentListHtml != null)
            {
                var PLNPurchaseString = "currencyDocumentListHtml[4].InnerHtml.ToString()";
                string[] PLNPurchaseStringArray = PLNPurchaseString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var PLNPurchaseMinfinComUa = PLNPurchaseStringArray[0].Trim();
                var PLNSaleString = currencyDocumentListHtml[5].InnerHtml.ToString();
                string[] PLNSaleStringArrayHtml = PLNSaleString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                string PLNSaleHtml = PLNSaleStringArrayHtml[6].Trim();
                var PLNSaleStringArray = PLNSaleHtml.Split(new[] { '>' },
                StringSplitOptions.RemoveEmptyEntries);
                var PLNSaleMinfinComUa = PLNSaleStringArray[1].Trim();
                return new string[] { PLNPurchaseMinfinComUa, PLNSaleMinfinComUa };
            }
            else
            {
                return null;
            }
        }
        private static async void SendRequest()
        {
            try
            {
                var httpClient = new HttpClient();
                var html = await httpClient.GetStringAsync(Constants.MinfinComUaUrl);
                var htmlDocument = new HtmlDocument();
                htmlDocument.LoadHtml(html);
                currencyDocumentListHtml = htmlDocument.DocumentNode.Descendants("td")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("mfm-text-nowrap")).ToList();
            }
            catch
            {
                MessageBox.Show(ExchangeRate.WarningMessage, ExchangeRate.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}