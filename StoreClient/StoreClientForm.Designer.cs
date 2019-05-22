namespace StoreClient {
    partial class StoreClientForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle46 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle47 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle58 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle59 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle60 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle57 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle48 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle49 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            this.booksComboBox = new System.Windows.Forms.ComboBox();
            this.clientsComboBox = new System.Windows.Forms.ComboBox();
            this.newOrderPanel = new System.Windows.Forms.Panel();
            this.payButton = new System.Windows.Forms.Button();
            this.stockPanel = new System.Windows.Forms.Panel();
            this.requestsPanel = new System.Windows.Forms.Panel();
            this.requestsGrid = new System.Windows.Forms.DataGridView();
            this.stockGrid = new System.Windows.Forms.DataGridView();
            this.bookNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookStockColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.regMemberPanel = new System.Windows.Forms.Panel();
            this.newMemberPanel = new System.Windows.Forms.Panel();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.newMemberButton = new System.Windows.Forms.Button();
            this.resMemberButton = new System.Windows.Forms.Button();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.bookLabel = new System.Windows.Forms.Label();
            this.newOrderButton = new System.Windows.Forms.Button();
            this.stockButton = new System.Windows.Forms.Button();
            this.requestsButton = new System.Windows.Forms.Button();
            this.orderIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newOrderPanel.SuspendLayout();
            this.stockPanel.SuspendLayout();
            this.requestsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).BeginInit();
            this.regMemberPanel.SuspendLayout();
            this.newMemberPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // booksComboBox
            // 
            this.booksComboBox.FormattingEnabled = true;
            this.booksComboBox.Location = new System.Drawing.Point(87, 32);
            this.booksComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.booksComboBox.Name = "booksComboBox";
            this.booksComboBox.Size = new System.Drawing.Size(198, 21);
            this.booksComboBox.TabIndex = 0;
            // 
            // clientsComboBox
            // 
            this.clientsComboBox.FormattingEnabled = true;
            this.clientsComboBox.Location = new System.Drawing.Point(70, 8);
            this.clientsComboBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clientsComboBox.Name = "clientsComboBox";
            this.clientsComboBox.Size = new System.Drawing.Size(181, 21);
            this.clientsComboBox.TabIndex = 1;
            // 
            // newOrderPanel
            // 
            this.newOrderPanel.Controls.Add(this.requestsPanel);
            this.newOrderPanel.Controls.Add(this.newMemberPanel);
            this.newOrderPanel.Controls.Add(this.stockPanel);
            this.newOrderPanel.Controls.Add(this.payButton);
            this.newOrderPanel.Controls.Add(this.totalPriceLabel);
            this.newOrderPanel.Controls.Add(this.priceLabel);
            this.newOrderPanel.Controls.Add(this.regMemberPanel);
            this.newOrderPanel.Controls.Add(this.newMemberButton);
            this.newOrderPanel.Controls.Add(this.resMemberButton);
            this.newOrderPanel.Controls.Add(this.quantityNumericUpDown);
            this.newOrderPanel.Controls.Add(this.quantityLabel);
            this.newOrderPanel.Controls.Add(this.bookLabel);
            this.newOrderPanel.Controls.Add(this.booksComboBox);
            this.newOrderPanel.Location = new System.Drawing.Point(9, 68);
            this.newOrderPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newOrderPanel.Name = "newOrderPanel";
            this.newOrderPanel.Size = new System.Drawing.Size(582, 288);
            this.newOrderPanel.TabIndex = 2;
            // 
            // payButton
            // 
            this.payButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.payButton.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payButton.ForeColor = System.Drawing.Color.White;
            this.payButton.Location = new System.Drawing.Point(522, 241);
            this.payButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.payButton.Name = "payButton";
            this.payButton.Size = new System.Drawing.Size(58, 35);
            this.payButton.TabIndex = 11;
            this.payButton.Text = "Pay";
            this.payButton.UseVisualStyleBackColor = false;
            // 
            // stockPanel
            // 
            this.stockPanel.Controls.Add(this.stockGrid);
            this.stockPanel.Location = new System.Drawing.Point(2, 0);
            this.stockPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stockPanel.Name = "stockPanel";
            this.stockPanel.Size = new System.Drawing.Size(582, 288);
            this.stockPanel.TabIndex = 12;
            // 
            // requestsPanel
            // 
            this.requestsPanel.Controls.Add(this.requestsGrid);
            this.requestsPanel.Location = new System.Drawing.Point(2, 0);
            this.requestsPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.requestsPanel.Name = "requestsPanel";
            this.requestsPanel.Size = new System.Drawing.Size(582, 288);
            this.requestsPanel.TabIndex = 13;
            // 
            // requestsGrid
            // 
            this.requestsGrid.AllowUserToAddRows = false;
            this.requestsGrid.AllowUserToDeleteRows = false;
            this.requestsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle46.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle46.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle46;
            this.requestsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.requestsGrid.BackgroundColor = System.Drawing.Color.White;
            this.requestsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.requestsGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle47.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle47.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle47.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle47.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle47.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle47.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle47.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requestsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle47;
            this.requestsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdColumn,
            this.bookColumn,
            this.quantityColumn,
            this.stateColumn});
            dataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle52.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle52.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle52.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle52.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle52.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle52.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.requestsGrid.DefaultCellStyle = dataGridViewCellStyle52;
            this.requestsGrid.GridColor = System.Drawing.Color.White;
            this.requestsGrid.Location = new System.Drawing.Point(33, 32);
            this.requestsGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.requestsGrid.Name = "requestsGrid";
            this.requestsGrid.ReadOnly = true;
            this.requestsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle53.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle53.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle53.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle53.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requestsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle53;
            dataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle54.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.Color.Black;
            this.requestsGrid.RowsDefaultCellStyle = dataGridViewCellStyle54;
            this.requestsGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.requestsGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.requestsGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.requestsGrid.RowTemplate.Height = 24;
            this.requestsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.requestsGrid.Size = new System.Drawing.Size(547, 236);
            this.requestsGrid.TabIndex = 12;
            // 
            // stockGrid
            // 
            this.stockGrid.AllowUserToAddRows = false;
            this.stockGrid.AllowUserToDeleteRows = false;
            this.stockGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle55;
            this.stockGrid.BackgroundColor = System.Drawing.Color.White;
            this.stockGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle56.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle56.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle56.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle56.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stockGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle56;
            this.stockGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookNameColumn,
            this.bookStockColumn});
            dataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle58.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle58.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle58.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle58.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle58.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle58.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.stockGrid.DefaultCellStyle = dataGridViewCellStyle58;
            this.stockGrid.GridColor = System.Drawing.Color.White;
            this.stockGrid.Location = new System.Drawing.Point(33, 32);
            this.stockGrid.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stockGrid.Name = "stockGrid";
            this.stockGrid.ReadOnly = true;
            this.stockGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle59.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle59.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle59.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle59.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle59.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle59.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stockGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle59;
            dataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle60.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle60.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle60.SelectionForeColor = System.Drawing.Color.Black;
            this.stockGrid.RowsDefaultCellStyle = dataGridViewCellStyle60;
            this.stockGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.stockGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.stockGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.stockGrid.RowTemplate.Height = 24;
            this.stockGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stockGrid.Size = new System.Drawing.Size(547, 236);
            this.stockGrid.TabIndex = 12;
            // 
            // bookNameColumn
            // 
            this.bookNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle57.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold);
            this.bookNameColumn.DefaultCellStyle = dataGridViewCellStyle57;
            this.bookNameColumn.HeaderText = "Book Name";
            this.bookNameColumn.Name = "bookNameColumn";
            this.bookNameColumn.ReadOnly = true;
            // 
            // bookStockColumn
            // 
            this.bookStockColumn.HeaderText = "Stock";
            this.bookStockColumn.Name = "bookStockColumn";
            this.bookStockColumn.ReadOnly = true;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Location = new System.Drawing.Point(492, 215);
            this.totalPriceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(13, 13);
            this.totalPriceLabel.TabIndex = 10;
            this.totalPriceLabel.Text = "0";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.priceLabel.Location = new System.Drawing.Point(394, 209);
            this.priceLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(94, 22);
            this.priceLabel.TabIndex = 9;
            this.priceLabel.Text = "Total Price";
            // 
            // regMemberPanel
            // 
            this.regMemberPanel.Controls.Add(this.label1);
            this.regMemberPanel.Controls.Add(this.clientsComboBox);
            this.regMemberPanel.Location = new System.Drawing.Point(33, 162);
            this.regMemberPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.regMemberPanel.Name = "regMemberPanel";
            this.regMemberPanel.Size = new System.Drawing.Size(357, 114);
            this.regMemberPanel.TabIndex = 8;
            // 
            // newMemberPanel
            // 
            this.newMemberPanel.Controls.Add(this.emailTextBox);
            this.newMemberPanel.Controls.Add(this.emailLabel);
            this.newMemberPanel.Controls.Add(this.addressTextBox);
            this.newMemberPanel.Controls.Add(this.addressLabel);
            this.newMemberPanel.Controls.Add(this.nameTextBox);
            this.newMemberPanel.Controls.Add(this.label2);
            this.newMemberPanel.Location = new System.Drawing.Point(33, 162);
            this.newMemberPanel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newMemberPanel.Name = "newMemberPanel";
            this.newMemberPanel.Size = new System.Drawing.Size(357, 114);
            this.newMemberPanel.TabIndex = 10;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(67, 84);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(185, 20);
            this.emailTextBox.TabIndex = 14;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.emailLabel.Location = new System.Drawing.Point(8, 84);
            this.emailLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(55, 22);
            this.emailLabel.TabIndex = 13;
            this.emailLabel.Text = "Email";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(85, 47);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(167, 20);
            this.addressTextBox.TabIndex = 12;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.addressLabel.Location = new System.Drawing.Point(8, 47);
            this.addressLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(73, 22);
            this.addressLabel.TabIndex = 11;
            this.addressLabel.Text = "Address";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(70, 8);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(182, 20);
            this.nameTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 22);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            // 
            // newMemberButton
            // 
            this.newMemberButton.BackColor = System.Drawing.Color.White;
            this.newMemberButton.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMemberButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.newMemberButton.Location = new System.Drawing.Point(190, 123);
            this.newMemberButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newMemberButton.Name = "newMemberButton";
            this.newMemberButton.Size = new System.Drawing.Size(116, 35);
            this.newMemberButton.TabIndex = 7;
            this.newMemberButton.Text = "New Member";
            this.newMemberButton.UseVisualStyleBackColor = false;
            this.newMemberButton.Click += new System.EventHandler(this.newMemberButton_Click);
            // 
            // resMemberButton
            // 
            this.resMemberButton.BackColor = System.Drawing.Color.White;
            this.resMemberButton.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resMemberButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.resMemberButton.Location = new System.Drawing.Point(33, 123);
            this.resMemberButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.resMemberButton.Name = "resMemberButton";
            this.resMemberButton.Size = new System.Drawing.Size(153, 35);
            this.resMemberButton.TabIndex = 6;
            this.resMemberButton.Text = "Registered Member";
            this.resMemberButton.UseVisualStyleBackColor = false;
            this.resMemberButton.Click += new System.EventHandler(this.resMemberButton_Click);
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(122, 75);
            this.quantityNumericUpDown.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.quantityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(163, 20);
            this.quantityNumericUpDown.TabIndex = 5;
            this.quantityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.quantityLabel.Location = new System.Drawing.Point(29, 75);
            this.quantityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(83, 22);
            this.quantityLabel.TabIndex = 4;
            this.quantityLabel.Text = "Quantity";
            // 
            // bookLabel
            // 
            this.bookLabel.AutoSize = true;
            this.bookLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bookLabel.Location = new System.Drawing.Point(29, 32);
            this.bookLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.bookLabel.Name = "bookLabel";
            this.bookLabel.Size = new System.Drawing.Size(51, 22);
            this.bookLabel.TabIndex = 3;
            this.bookLabel.Text = "Book";
            // 
            // newOrderButton
            // 
            this.newOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.newOrderButton.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newOrderButton.ForeColor = System.Drawing.Color.White;
            this.newOrderButton.Location = new System.Drawing.Point(268, 28);
            this.newOrderButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.newOrderButton.Name = "newOrderButton";
            this.newOrderButton.Size = new System.Drawing.Size(94, 35);
            this.newOrderButton.TabIndex = 12;
            this.newOrderButton.Text = "New Order";
            this.newOrderButton.UseVisualStyleBackColor = false;
            this.newOrderButton.Click += new System.EventHandler(this.newOrderButton_Click);
            // 
            // stockButton
            // 
            this.stockButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.stockButton.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockButton.ForeColor = System.Drawing.Color.White;
            this.stockButton.Location = new System.Drawing.Point(366, 28);
            this.stockButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.stockButton.Name = "stockButton";
            this.stockButton.Size = new System.Drawing.Size(57, 35);
            this.stockButton.TabIndex = 13;
            this.stockButton.Text = "Stock";
            this.stockButton.UseVisualStyleBackColor = false;
            this.stockButton.Click += new System.EventHandler(this.stockButton_Click);
            // 
            // requestsButton
            // 
            this.requestsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.requestsButton.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsButton.ForeColor = System.Drawing.Color.White;
            this.requestsButton.Location = new System.Drawing.Point(427, 28);
            this.requestsButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.requestsButton.Name = "requestsButton";
            this.requestsButton.Size = new System.Drawing.Size(164, 35);
            this.requestsButton.TabIndex = 14;
            this.requestsButton.Text = "Warehouse Requests";
            this.requestsButton.UseVisualStyleBackColor = false;
            this.requestsButton.Click += new System.EventHandler(this.requestsButton_Click);
            // 
            // orderIdColumn
            // 
            dataGridViewCellStyle48.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle48.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle48.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle48.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle48.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle48.SelectionForeColor = System.Drawing.Color.Black;
            this.orderIdColumn.DefaultCellStyle = dataGridViewCellStyle48;
            this.orderIdColumn.HeaderText = "Order ID";
            this.orderIdColumn.Name = "orderIdColumn";
            this.orderIdColumn.ReadOnly = true;
            this.orderIdColumn.Width = 102;
            // 
            // bookColumn
            // 
            this.bookColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle49.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle49.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle49.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle49.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle49.SelectionForeColor = System.Drawing.Color.Black;
            this.bookColumn.DefaultCellStyle = dataGridViewCellStyle49;
            this.bookColumn.HeaderText = "Book Name";
            this.bookColumn.Name = "bookColumn";
            this.bookColumn.ReadOnly = true;
            // 
            // quantityColumn
            // 
            dataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle50.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle50.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle50.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle50.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle50.SelectionForeColor = System.Drawing.Color.Black;
            this.quantityColumn.DefaultCellStyle = dataGridViewCellStyle50;
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.Width = 108;
            // 
            // stateColumn
            // 
            this.stateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle51.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle51.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle51.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.Color.Black;
            this.stateColumn.DefaultCellStyle = dataGridViewCellStyle51;
            this.stateColumn.HeaderText = "State";
            this.stateColumn.Name = "stateColumn";
            this.stateColumn.ReadOnly = true;
            // 
            // StoreClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(638, 366);
            this.Controls.Add(this.requestsButton);
            this.Controls.Add(this.stockButton);
            this.Controls.Add(this.newOrderButton);
            this.Controls.Add(this.newOrderPanel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "StoreClientForm";
            this.Text = "Store Terminal";
            this.newOrderPanel.ResumeLayout(false);
            this.newOrderPanel.PerformLayout();
            this.stockPanel.ResumeLayout(false);
            this.requestsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requestsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).EndInit();
            this.regMemberPanel.ResumeLayout(false);
            this.regMemberPanel.PerformLayout();
            this.newMemberPanel.ResumeLayout(false);
            this.newMemberPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox booksComboBox;
        private System.Windows.Forms.ComboBox clientsComboBox;
        private System.Windows.Forms.Panel newOrderPanel;
        private System.Windows.Forms.Button payButton;
        private System.Windows.Forms.Panel stockPanel;
        private System.Windows.Forms.DataGridView stockGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookStockColumn;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label priceLabel;
        private System.Windows.Forms.Panel regMemberPanel;
        private System.Windows.Forms.Panel newMemberPanel;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.Label addressLabel;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newMemberButton;
        private System.Windows.Forms.Button resMemberButton;
        private System.Windows.Forms.NumericUpDown quantityNumericUpDown;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label bookLabel;
        private System.Windows.Forms.Button newOrderButton;
        private System.Windows.Forms.Button stockButton;
        private System.Windows.Forms.Button requestsButton;
        private System.Windows.Forms.Panel requestsPanel;
        private System.Windows.Forms.DataGridView requestsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderIdColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateColumn;
    }
}

