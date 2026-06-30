namespace FixerCurrencyApp
{
    partial class MainForm
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
            txtApiKey = new TextBox();
            lblApiHint = new Label();
            btnLoadData = new Button();
            txtAmount = new TextBox();
            cmbTargetCurrency = new ComboBox();
            btnConvert = new Button();
            lblResult = new Label();
            lblBase = new Label();
            dtpHistoryDate = new DateTimePicker();
            btnGetHistory = new Button();
            lstHistoryResult = new ListBox();
            SuspendLayout();
            // 
            // txtApiKey
            // 
            txtApiKey.Location = new Point(65, 27);
            txtApiKey.Name = "txtApiKey";
            txtApiKey.Size = new Size(240, 23);
            txtApiKey.TabIndex = 0;
            // 
            // lblApiHint
            // 
            lblApiHint.AutoSize = true;
            lblApiHint.Location = new Point(12, 30);
            lblApiHint.Name = "lblApiHint";
            lblApiHint.Size = new Size(47, 15);
            lblApiHint.TabIndex = 1;
            lblApiHint.Text = "API Key";
            // 
            // btnLoadData
            // 
            btnLoadData.BackColor = Color.Cyan;
            btnLoadData.Location = new Point(322, 27);
            btnLoadData.Name = "btnLoadData";
            btnLoadData.Size = new Size(75, 23);
            btnLoadData.TabIndex = 2;
            btnLoadData.Text = "Загрузить данные";
            btnLoadData.UseVisualStyleBackColor = false;
            btnLoadData.Click += btnLoadData_Click;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(12, 121);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(100, 23);
            txtAmount.TabIndex = 3;
            txtAmount.Text = "1";
            // 
            // cmbTargetCurrency
            // 
            cmbTargetCurrency.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTargetCurrency.FormattingEnabled = true;
            cmbTargetCurrency.Location = new Point(132, 121);
            cmbTargetCurrency.Name = "cmbTargetCurrency";
            cmbTargetCurrency.Size = new Size(121, 23);
            cmbTargetCurrency.TabIndex = 4;
            // 
            // btnConvert
            // 
            btnConvert.BackColor = Color.Cyan;
            btnConvert.Location = new Point(65, 167);
            btnConvert.Name = "btnConvert";
            btnConvert.Size = new Size(111, 23);
            btnConvert.TabIndex = 5;
            btnConvert.Text = "Конвертировать";
            btnConvert.UseVisualStyleBackColor = false;
            btnConvert.Click += btnConvert_Click;
            // 
            // lblResult
            // 
            lblResult.AutoSize = true;
            lblResult.Location = new Point(77, 204);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(87, 15);
            lblResult.TabIndex = 6;
            lblResult.Text = "Результат: 0.00";
            // 
            // lblBase
            // 
            lblBase.AutoSize = true;
            lblBase.Location = new Point(12, 88);
            lblBase.Name = "lblBase";
            lblBase.Size = new Size(120, 15);
            lblBase.TabIndex = 7;
            lblBase.Text = "Базовая валюта: EUR";
            // 
            // dtpHistoryDate
            // 
            dtpHistoryDate.Location = new Point(452, 30);
            dtpHistoryDate.Name = "dtpHistoryDate";
            dtpHistoryDate.Size = new Size(200, 23);
            dtpHistoryDate.TabIndex = 8;
            // 
            // btnGetHistory
            // 
            btnGetHistory.Location = new Point(452, 59);
            btnGetHistory.Name = "btnGetHistory";
            btnGetHistory.Size = new Size(200, 23);
            btnGetHistory.TabIndex = 9;
            btnGetHistory.Text = "Курс на дату";
            btnGetHistory.UseVisualStyleBackColor = true;
            // 
            // lstHistoryResult
            // 
            lstHistoryResult.FormattingEnabled = true;
            lstHistoryResult.ItemHeight = 15;
            lstHistoryResult.Location = new Point(452, 96);
            lstHistoryResult.Name = "lstHistoryResult";
            lstHistoryResult.Size = new Size(200, 124);
            lstHistoryResult.TabIndex = 10;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstHistoryResult);
            Controls.Add(btnGetHistory);
            Controls.Add(dtpHistoryDate);
            Controls.Add(lblBase);
            Controls.Add(lblResult);
            Controls.Add(btnConvert);
            Controls.Add(cmbTargetCurrency);
            Controls.Add(txtAmount);
            Controls.Add(btnLoadData);
            Controls.Add(lblApiHint);
            Controls.Add(txtApiKey);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtApiKey;
        private Label lblApiHint;
        private Button btnLoadData;
        private TextBox txtAmount;
        private ComboBox cmbTargetCurrency;
        private Button btnConvert;
        private Label lblResult;
        private Label lblBase;
        private DateTimePicker dtpHistoryDate;
        private Button btnGetHistory;
        private ListBox lstHistoryResult;
    }
}
