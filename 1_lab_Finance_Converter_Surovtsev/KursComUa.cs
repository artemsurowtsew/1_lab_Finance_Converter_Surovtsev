using HtmlAgilityPack;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
namespace _1_lab_Finance_converter_Surovtsev
{
    public class KursComUa : CurrencyAPI
    {
        private static List<HtmlNode> currencyDocumentListHtml;

        public override string[] GetDollar()
        {
            Task task = Task.Factory.StartNew(() => SendRequest());
            task.Wait();
            System.Threading.Thread.Sleep(1500);
            if (currencyDocumentListHtml != null)
            {
                var dollarPurchaseString = currencyDocumentListHtml[0].InnerHtml.ToString();
                string[] dollarPurchaseStringArray = dollarPurchaseString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var dollarPurchaseKursComUa = dollarPurchaseStringArray[0];
                var dollarSaleString = currencyDocumentListHtml[1].InnerHtml.ToString();
                string[] dollarSaleStringArray = dollarSaleString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var dollarSaleKursComUa = dollarSaleStringArray[0];
                return new string[] { dollarPurchaseKursComUa, dollarSaleKursComUa };
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
                var euroPurchaseString = currencyDocumentListHtml[4].InnerHtml.ToString();
                string[] euroPurchaseStringArray = euroPurchaseString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var euroPurchaseKursComUa = euroPurchaseStringArray[0];
                var euroSaleString = currencyDocumentListHtml[5].InnerHtml.ToString();
                string[] euroSaleStringArray = euroSaleString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var euroSaleKursComUa = euroSaleStringArray[0];
                return new string[] { euroPurchaseKursComUa, euroSaleKursComUa };
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
                var PLNPurchaseString = currencyDocumentListHtml[8].InnerHtml.ToString();
                string[] PLNPurchaseStringArray = PLNPurchaseString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var PLNPurchaseKursComUa = PLNPurchaseStringArray[0];
                var PLNSaleString = currencyDocumentListHtml[9].InnerHtml.ToString();
                string[] PLNSaleStringArray = PLNSaleString.Split(new[] { '<' },
                StringSplitOptions.RemoveEmptyEntries);
                var PLNSaleKursComUa = PLNSaleStringArray[0];
                return new string[] { PLNPurchaseKursComUa, PLNSaleKursComUa };
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
                var html = await httpClient.GetStringAsync(Constants.KursComUaUrl);
                var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(html);
                currencyDocumentListHtml = htmlDocument.DocumentNode.Descendants("div")
                .Where(node => node.GetAttributeValue("class", "")
                .Equals("course")).ToList();
            }
            catch
            {
                MessageBox.Show(ExchangeRate.WarningMessage, ExchangeRate.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}