using System;
using System.Data;
using System.Windows.Forms;
namespace _1_lab_Finance_converter_Surovtsev
{
    public partial class ExchangeRate : Form
    {
        static string dollarPurchaseMinfinComUa, dollarSaleMinfinComUa,
        euroPurchaseMinfinComUa, euroSaleMinfinComUa, rublePurchaseMinfinComUa,
        rubleSaleMinfinComUa;
        static string dollarPurchaseKursComUa, dollarSaleKursComUa, euroPurchaseKursComUa,
        euroSaleKursComUa, rublePurchaseKursComUa, rubleSaleKursComUa;
        static string dollarPurchaseFinanceUa, dollarSaleFinanceUa, euroPurchaseFinanceUa,
        euroSaleFinanceUa, rublePurchaseFinanceUa, rubleSaleFinanceUa;
        static string dollarPurchasePrivat = "N/A", dollarSalePrivat = "N/A";
        static string euroPurchasePrivat = "N/A", euroSalePrivat = "N/A";

        private DataGridView dataCurrencyTable;
        public Button LoadData;

        public ExchangeRate()
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }
        private void LoadData_Click(object sender, EventArgs e)
        {
            LoadMinfinComUaData();
            LoadKursComUaData();
            LoadFinanceUaData();
            dataCurrencyTable.DataSource = SetData();
        }
        public static void LoadMinfinComUaData()
        {
            try
            {
                MinfinComUa minfinComUa = new MinfinComUa();
                var dollarMinfinComUa = minfinComUa.GetDollar();
                if (dollarMinfinComUa != null)
                {
                    dollarPurchaseMinfinComUa = dollarMinfinComUa[0];
                    dollarSaleMinfinComUa = dollarMinfinComUa[1];
                }
                var euroMinfinComUa = minfinComUa.GetEuro();
                if (euroMinfinComUa != null)
                {
                    euroPurchaseMinfinComUa = euroMinfinComUa[0];
                    euroSaleMinfinComUa = euroMinfinComUa[1];
                }
                var rubleMinfinComUa = minfinComUa.GetRuble();
                if (rubleMinfinComUa != null)
                {
                    rublePurchaseMinfinComUa = rubleMinfinComUa[0];
                    rubleSaleMinfinComUa = rubleMinfinComUa[1];
                }
            }
            catch
            {
                MessageBox.Show(ExchangeRate.WarningMessage, ExchangeRate.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void LoadPrivatUaData()
        {
            try
            {
                PrivatBankAPI privatBankApi = new PrivatBankAPI();

                var dollarPrivatBank = privatBankApi.GetDollar();
                if (dollarPrivatBank != null)
                {
                    dollarPurchasePrivat = dollarPrivatBank[0];
                    dollarSalePrivat = dollarPrivatBank[1];
                }

                var euroPrivatBank = privatBankApi.GetEuro();
                if (euroPrivatBank != null)
                {
                    euroPurchasePrivat = euroPrivatBank[0];
                    euroSalePrivat = euroPrivatBank[1];
                }

                
            }
            catch
            {
                MessageBox.Show(ExchangeRate.WarningMessage, ExchangeRate.WarningTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public static void LoadKursComUaData()
        {
            try
            {
                KursComUa kursComUa = new KursComUa();
                var dollarKursKomUa = kursComUa.GetDollar();
                if (dollarKursKomUa != null)
                {
                    dollarPurchaseKursComUa = dollarKursKomUa[0];
                    dollarSaleKursComUa = dollarKursKomUa[1];
                }
                var euroKursKomUa = kursComUa.GetEuro();
                if (euroKursKomUa != null)
                {
                    euroPurchaseKursComUa = euroKursKomUa[0];
                    euroSaleKursComUa = euroKursKomUa[1];
                }
                var rubleKursKomUa = kursComUa.GetRuble();
                if (rubleKursKomUa != null)
                {
                    rublePurchaseKursComUa = rubleKursKomUa[0];
                    rubleSaleKursComUa = rubleKursKomUa[1];
                }
            }
            catch
            {
                MessageBox.Show(ExchangeRate.WarningMessage, ExchangeRate.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public static void LoadFinanceUaData()
        {
            try
            {
                FinanceUa financeUa = new FinanceUa();
                var dollarFinanceUa = financeUa.GetDollar();
                if (dollarFinanceUa != null)
                {
                    dollarPurchaseFinanceUa = dollarFinanceUa[0];
                    dollarSaleFinanceUa = dollarFinanceUa[1];
                }
                var euroFinanceUa = financeUa.GetEuro();
                if (euroFinanceUa != null)
                {
                    euroPurchaseFinanceUa = euroFinanceUa[0];
                    euroSaleFinanceUa = euroFinanceUa[1];
                }
                var rubleFinanceUa = financeUa.GetRuble();
                if (rubleFinanceUa != null)
                {
                    rublePurchaseFinanceUa = rubleFinanceUa[0];
                    rubleSaleFinanceUa = rubleFinanceUa[1];
                }
            }
            catch
            {
                MessageBox.Show(ExchangeRate.WarningMessage, ExchangeRate.WarningTitle,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void InitializeComponent()
        {
            dataCurrencyTable = new DataGridView();
            LoadData = new Button();
            ((System.ComponentModel.ISupportInitialize)dataCurrencyTable).BeginInit();
            SuspendLayout();
            // 
            // dataCurrencyTable
            // 
            dataCurrencyTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCurrencyTable.Location = new Point(27, 82);
            dataCurrencyTable.Name = "dataCurrencyTable";
            dataCurrencyTable.RowTemplate.Height = 25;
            dataCurrencyTable.Size = new Size(679, 254);
            dataCurrencyTable.TabIndex = 0;
            // 
            // LoadData
            // 
            LoadData.Location = new Point(335, 35);
            LoadData.Name = "LoadData";
            LoadData.Size = new Size(75, 23);
            LoadData.TabIndex = 1;
            LoadData.Text = "Load Data";
            LoadData.UseVisualStyleBackColor = true;
            LoadData.Click += LoadData_Click;
            // 
            // ExchangeRate
            // 
            ClientSize = new Size(745, 360);
            Controls.Add(LoadData);
            Controls.Add(dataCurrencyTable);
            Name = "ExchangeRate";
            ((System.ComponentModel.ISupportInitialize)dataCurrencyTable).EndInit();
            ResumeLayout(false);
        }

        public static DataTable SetData()
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add(ExchangeRate.ResourceColumnTitle, typeof(string));
            dataTable.Columns.Add(ExchangeRate.CurrencyColumnTitle, typeof(string));
            dataTable.Columns.Add(ExchangeRate.PurchaseColumnTitle, typeof(string));
            dataTable.Columns.Add(ExchangeRate.SaleColumnTitle, typeof(string));
            dataTable.Rows.Add(ExchangeRate.MinfinComUaTitle, ExchangeRate.Dollar,
            dollarPurchaseMinfinComUa, dollarSaleMinfinComUa);
            dataTable.Rows.Add(ExchangeRate.MinfinComUaTitle, ExchangeRate.Euro,
            euroPurchaseMinfinComUa, euroSaleMinfinComUa);
            dataTable.Rows.Add(ExchangeRate.MinfinComUaTitle, ExchangeRate.Ruble,
            rublePurchaseMinfinComUa, rubleSaleMinfinComUa);
            dataTable.Rows.Add(ExchangeRate.KursComUaTitle, ExchangeRate.Dollar,
            dollarPurchaseKursComUa, dollarSaleKursComUa);
            dataTable.Rows.Add(ExchangeRate.KursComUaTitle, ExchangeRate.Euro,
            euroPurchaseKursComUa, euroSaleKursComUa);
            dataTable.Rows.Add(ExchangeRate.KursComUaTitle, ExchangeRate.Ruble,
            rublePurchaseKursComUa, rubleSaleKursComUa);
            dataTable.Rows.Add(ExchangeRate.FinanceUaTitle, ExchangeRate.Dollar,
            dollarPurchaseFinanceUa, dollarSaleFinanceUa);
            dataTable.Rows.Add(ExchangeRate.FinanceUaTitle, ExchangeRate.Euro,
            euroPurchaseFinanceUa, euroSaleFinanceUa);
            dataTable.Rows.Add(ExchangeRate.FinanceUaTitle, ExchangeRate.Ruble,
            rublePurchaseFinanceUa, rubleSaleFinanceUa);
            dataTable.Rows.Add(ExchangeRate.PrivatUaTitle, ExchangeRate.Dollar, dollarPurchasePrivat, dollarSalePrivat);
            dataTable.Rows.Add(ExchangeRate.PrivatUaTitle, ExchangeRate.Euro, euroPurchasePrivat, euroSalePrivat);
            return dataTable;
        }
    }
}