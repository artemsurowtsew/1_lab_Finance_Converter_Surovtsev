namespace _1_lab_Finance_converter_Surovtsev
{
    partial class ExchangeRate
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            dataCurrencyTable = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataCurrencyTable).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(190, 307);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "Load Data";
            button1.UseVisualStyleBackColor = true;
            // 
            // dataCurrencyTable
            // 
            dataCurrencyTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCurrencyTable.Location = new Point(113, 117);
            dataCurrencyTable.Name = "dataCurrencyTable";
            dataCurrencyTable.RowTemplate.Height = 25;
            dataCurrencyTable.Size = new Size(240, 150);
            dataCurrencyTable.TabIndex = 1;
            // 
            // ExchangeRate
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataCurrencyTable);
            Controls.Add(button1);
            Name = "ExchangeRate";
            Text = "Exchange Rate";
            ((System.ComponentModel.ISupportInitialize)dataCurrencyTable).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        public DataGridView dataCurrencyTable;
    }
}
