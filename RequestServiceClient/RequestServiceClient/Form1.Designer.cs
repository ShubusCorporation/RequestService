using System.Windows.Forms;
namespace RequestServiceDektopApp
{
    partial class Form1
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginBox = new System.Windows.Forms.TextBox();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.getRequestsButton = new System.Windows.Forms.Button();
            this.seldonRequestGrid = new System.Windows.Forms.DataGridView();
            this.versionColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seldonPriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.garanteColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.justiceRequestGrid = new System.Windows.Forms.DataGridView();
            this.priceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.courtColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loyerColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.debtorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.learningRequestGrid = new System.Windows.Forms.DataGridView();
            this.courseColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coursePriceColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lectorColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.seldonRequestGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.justiceRequestGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRequestGrid)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(31, 25);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(260, 20);
            this.loginBox.TabIndex = 0;
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(325, 25);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.PasswordChar = '*';
            this.passwordBox.Size = new System.Drawing.Size(260, 20);
            this.passwordBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(322, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(31, 616);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Create Request";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createRequestButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(654, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Create new account";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(31, 157);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(766, 46);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set request type : ";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Заявка на Селдон",
            "Заявка на юридическое сопровождение",
            "Заявка на участие в семинаре"});
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(316, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.SelectedValueChanged += new System.EventHandler(this.comboBox1_SelectedValueChanged);
            // 
            // getRequestsButton
            // 
            this.getRequestsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.getRequestsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.getRequestsButton.Location = new System.Drawing.Point(165, 616);
            this.getRequestsButton.Name = "getRequestsButton";
            this.getRequestsButton.Size = new System.Drawing.Size(126, 23);
            this.getRequestsButton.TabIndex = 9;
            this.getRequestsButton.Text = "Show my requests";
            this.getRequestsButton.UseVisualStyleBackColor = true;
            this.getRequestsButton.Click += new System.EventHandler(this.getRequestsButton_Click);
            // 
            // seldonRequestGrid
            // 
            this.seldonRequestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.seldonRequestGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.versionColumn,
            this.seldonPriceColumn,
            this.garanteColumn});
            this.seldonRequestGrid.Location = new System.Drawing.Point(6, 19);
            this.seldonRequestGrid.Name = "seldonRequestGrid";
            this.seldonRequestGrid.Size = new System.Drawing.Size(343, 59);
            this.seldonRequestGrid.TabIndex = 0;
            this.seldonRequestGrid.Visible = false;
            // 
            // versionColumn
            // 
            this.versionColumn.HeaderText = "Version";
            this.versionColumn.Name = "versionColumn";
            // 
            // seldonPriceColumn
            // 
            this.seldonPriceColumn.HeaderText = "Цена";
            this.seldonPriceColumn.Name = "seldonPriceColumn";
            // 
            // garanteColumn
            // 
            this.garanteColumn.HeaderText = "Срок техподдержки";
            this.garanteColumn.Name = "garanteColumn";
            // 
            // justiceRequestGrid
            // 
            this.justiceRequestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.justiceRequestGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.priceColumn,
            this.phoneColumn,
            this.courtColumn,
            this.loyerColumn,
            this.debtorColumn});
            this.justiceRequestGrid.Location = new System.Drawing.Point(6, 19);
            this.justiceRequestGrid.Name = "justiceRequestGrid";
            this.justiceRequestGrid.Size = new System.Drawing.Size(544, 47);
            this.justiceRequestGrid.TabIndex = 10;
            this.justiceRequestGrid.Visible = false;
            // 
            // priceColumn
            // 
            this.priceColumn.HeaderText = "Цена";
            this.priceColumn.Name = "priceColumn";
            // 
            // phoneColumn
            // 
            this.phoneColumn.HeaderText = "Телефон";
            this.phoneColumn.Name = "phoneColumn";
            // 
            // courtColumn
            // 
            this.courtColumn.HeaderText = "Суд";
            this.courtColumn.Name = "courtColumn";
            // 
            // loyerColumn
            // 
            this.loyerColumn.HeaderText = "Адвокат";
            this.loyerColumn.Name = "loyerColumn";
            // 
            // debtorColumn
            // 
            this.debtorColumn.HeaderText = "Должник";
            this.debtorColumn.Name = "debtorColumn";
            // 
            // learningRequestGrid
            // 
            this.learningRequestGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.learningRequestGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.courseColumn,
            this.coursePriceColumn,
            this.lectorColumn,
            this.addressColumn});
            this.learningRequestGrid.Location = new System.Drawing.Point(6, 19);
            this.learningRequestGrid.Name = "learningRequestGrid";
            this.learningRequestGrid.Size = new System.Drawing.Size(445, 47);
            this.learningRequestGrid.TabIndex = 11;
            this.learningRequestGrid.Visible = false;
            // 
            // courseColumn
            // 
            this.courseColumn.HeaderText = "Курс";
            this.courseColumn.Name = "courseColumn";
            // 
            // coursePriceColumn
            // 
            this.coursePriceColumn.HeaderText = "Цена";
            this.coursePriceColumn.Name = "coursePriceColumn";
            // 
            // lectorColumn
            // 
            this.lectorColumn.HeaderText = "Лектор";
            this.lectorColumn.Name = "lectorColumn";
            // 
            // addressColumn
            // 
            this.addressColumn.HeaderText = "Адрес";
            this.addressColumn.Name = "addressColumn";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.justiceRequestGrid);
            this.groupBox3.Controls.Add(this.seldonRequestGrid);
            this.groupBox3.Controls.Add(this.learningRequestGrid);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(31, 54);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(766, 88);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Request : ";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(31, 222);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(766, 370);
            this.webBrowser1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 651);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.getRequestsButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passwordBox);
            this.Controls.Add(this.loginBox);
            this.Name = "Form1";
            this.Text = "Request service client";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.seldonRequestGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.justiceRequestGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.learningRequestGrid)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private ComboBox comboBox1;
        private Button getRequestsButton;
        private DataGridView seldonRequestGrid;
        private DataGridView justiceRequestGrid;
        private DataGridView learningRequestGrid;
        private GroupBox groupBox3;
        private DataGridViewTextBoxColumn versionColumn;
        private DataGridViewTextBoxColumn seldonPriceColumn;
        private DataGridViewTextBoxColumn garanteColumn;
        private DataGridViewTextBoxColumn priceColumn;
        private DataGridViewTextBoxColumn phoneColumn;
        private DataGridViewTextBoxColumn courtColumn;
        private DataGridViewTextBoxColumn loyerColumn;
        private DataGridViewTextBoxColumn debtorColumn;
        private DataGridViewTextBoxColumn courseColumn;
        private DataGridViewTextBoxColumn coursePriceColumn;
        private DataGridViewTextBoxColumn lectorColumn;
        private DataGridViewTextBoxColumn addressColumn;
        private WebBrowser webBrowser1;
    }
}

