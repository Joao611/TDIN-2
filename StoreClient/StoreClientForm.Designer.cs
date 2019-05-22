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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.booksComboBox = new System.Windows.Forms.ComboBox();
            this.clientsComboBox = new System.Windows.Forms.ComboBox();
            this.newOrderPanel = new System.Windows.Forms.Panel();
            this.newMemberPanel = new System.Windows.Forms.Panel();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.addressLabel = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.payButton = new System.Windows.Forms.Button();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.priceLabel = new System.Windows.Forms.Label();
            this.regMemberPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.newMemberButton = new System.Windows.Forms.Button();
            this.resMemberButton = new System.Windows.Forms.Button();
            this.quantityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.quantityLabel = new System.Windows.Forms.Label();
            this.bookLabel = new System.Windows.Forms.Label();
            this.requestsPanel = new System.Windows.Forms.Panel();
            this.requestsGrid = new System.Windows.Forms.DataGridView();
            this.orderIdColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockPanel = new System.Windows.Forms.Panel();
            this.stockGrid = new System.Windows.Forms.DataGridView();
            this.bookNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bookStockColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newOrderButton = new System.Windows.Forms.Button();
            this.stockButton = new System.Windows.Forms.Button();
            this.requestsButton = new System.Windows.Forms.Button();
            this.newOrderPanel.SuspendLayout();
            this.newMemberPanel.SuspendLayout();
            this.regMemberPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).BeginInit();
            this.requestsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.requestsGrid)).BeginInit();
            this.stockPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // booksComboBox
            // 
            this.booksComboBox.FormattingEnabled = true;
            this.booksComboBox.Location = new System.Drawing.Point(116, 39);
            this.booksComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.booksComboBox.Name = "booksComboBox";
            this.booksComboBox.Size = new System.Drawing.Size(263, 24);
            this.booksComboBox.TabIndex = 0;
            this.booksComboBox.SelectedIndexChanged += new System.EventHandler(this.booksComboBox_SelectedIndexChanged);
            // 
            // clientsComboBox
            // 
            this.clientsComboBox.FormattingEnabled = true;
            this.clientsComboBox.Location = new System.Drawing.Point(93, 10);
            this.clientsComboBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.clientsComboBox.Name = "clientsComboBox";
            this.clientsComboBox.Size = new System.Drawing.Size(240, 24);
            this.clientsComboBox.TabIndex = 1;
            // 
            // newOrderPanel
            // 
            this.newOrderPanel.Controls.Add(this.newMemberPanel);
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
            this.newOrderPanel.Controls.Add(this.requestsPanel);
            this.newOrderPanel.Controls.Add(this.stockPanel);
            this.newOrderPanel.Location = new System.Drawing.Point(12, 84);
            this.newOrderPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newOrderPanel.Name = "newOrderPanel";
            this.newOrderPanel.Size = new System.Drawing.Size(776, 354);
            this.newOrderPanel.TabIndex = 2;
            // 
            // newMemberPanel
            // 
            this.newMemberPanel.Controls.Add(this.emailTextBox);
            this.newMemberPanel.Controls.Add(this.emailLabel);
            this.newMemberPanel.Controls.Add(this.addressTextBox);
            this.newMemberPanel.Controls.Add(this.addressLabel);
            this.newMemberPanel.Controls.Add(this.nameTextBox);
            this.newMemberPanel.Controls.Add(this.label2);
            this.newMemberPanel.Location = new System.Drawing.Point(44, 199);
            this.newMemberPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newMemberPanel.Name = "newMemberPanel";
            this.newMemberPanel.Size = new System.Drawing.Size(476, 140);
            this.newMemberPanel.TabIndex = 10;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(89, 103);
            this.emailTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(245, 22);
            this.emailTextBox.TabIndex = 14;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.emailLabel.Location = new System.Drawing.Point(11, 103);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(67, 27);
            this.emailLabel.TabIndex = 13;
            this.emailLabel.Text = "Email";
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(113, 58);
            this.addressTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(221, 22);
            this.addressTextBox.TabIndex = 12;
            // 
            // addressLabel
            // 
            this.addressLabel.AutoSize = true;
            this.addressLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addressLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.addressLabel.Location = new System.Drawing.Point(11, 58);
            this.addressLabel.Name = "addressLabel";
            this.addressLabel.Size = new System.Drawing.Size(93, 27);
            this.addressLabel.TabIndex = 11;
            this.addressLabel.Text = "Address";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(93, 10);
            this.nameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(241, 22);
            this.nameTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(11, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 27);
            this.label2.TabIndex = 9;
            this.label2.Text = "Name";
            // 
            // payButton
            // 
            this.payButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.payButton.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.payButton.ForeColor = System.Drawing.Color.White;
            this.payButton.Location = new System.Drawing.Point(696, 297);
            this.payButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.payButton.Name = "payButton";
            this.payButton.Size = new System.Drawing.Size(77, 43);
            this.payButton.TabIndex = 11;
            this.payButton.Text = "Pay";
            this.payButton.UseVisualStyleBackColor = false;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Location = new System.Drawing.Point(656, 265);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(16, 17);
            this.totalPriceLabel.TabIndex = 10;
            this.totalPriceLabel.Text = "0";
            // 
            // priceLabel
            // 
            this.priceLabel.AutoSize = true;
            this.priceLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.priceLabel.Location = new System.Drawing.Point(525, 257);
            this.priceLabel.Name = "priceLabel";
            this.priceLabel.Size = new System.Drawing.Size(118, 27);
            this.priceLabel.TabIndex = 9;
            this.priceLabel.Text = "Total Price";
            // 
            // regMemberPanel
            // 
            this.regMemberPanel.Controls.Add(this.label1);
            this.regMemberPanel.Controls.Add(this.clientsComboBox);
            this.regMemberPanel.Location = new System.Drawing.Point(44, 199);
            this.regMemberPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.regMemberPanel.Name = "regMemberPanel";
            this.regMemberPanel.Size = new System.Drawing.Size(476, 140);
            this.regMemberPanel.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 27);
            this.label1.TabIndex = 9;
            this.label1.Text = "Name";
            // 
            // newMemberButton
            // 
            this.newMemberButton.BackColor = System.Drawing.Color.White;
            this.newMemberButton.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newMemberButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.newMemberButton.Location = new System.Drawing.Point(253, 151);
            this.newMemberButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newMemberButton.Name = "newMemberButton";
            this.newMemberButton.Size = new System.Drawing.Size(155, 43);
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
            this.resMemberButton.Location = new System.Drawing.Point(44, 151);
            this.resMemberButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resMemberButton.Name = "resMemberButton";
            this.resMemberButton.Size = new System.Drawing.Size(204, 43);
            this.resMemberButton.TabIndex = 6;
            this.resMemberButton.Text = "Registered Member";
            this.resMemberButton.UseVisualStyleBackColor = false;
            this.resMemberButton.Click += new System.EventHandler(this.resMemberButton_Click);
            // 
            // quantityNumericUpDown
            // 
            this.quantityNumericUpDown.Location = new System.Drawing.Point(163, 92);
            this.quantityNumericUpDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quantityNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityNumericUpDown.Name = "quantityNumericUpDown";
            this.quantityNumericUpDown.Size = new System.Drawing.Size(217, 22);
            this.quantityNumericUpDown.TabIndex = 5;
            this.quantityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.quantityNumericUpDown.ValueChanged += new System.EventHandler(this.quantityNumericUpDown_ValueChanged);
            // 
            // quantityLabel
            // 
            this.quantityLabel.AutoSize = true;
            this.quantityLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantityLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.quantityLabel.Location = new System.Drawing.Point(39, 92);
            this.quantityLabel.Name = "quantityLabel";
            this.quantityLabel.Size = new System.Drawing.Size(101, 27);
            this.quantityLabel.TabIndex = 4;
            this.quantityLabel.Text = "Quantity";
            // 
            // bookLabel
            // 
            this.bookLabel.AutoSize = true;
            this.bookLabel.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bookLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.bookLabel.Location = new System.Drawing.Point(39, 39);
            this.bookLabel.Name = "bookLabel";
            this.bookLabel.Size = new System.Drawing.Size(61, 27);
            this.bookLabel.TabIndex = 3;
            this.bookLabel.Text = "Book";
            // 
            // requestsPanel
            // 
            this.requestsPanel.Controls.Add(this.requestsGrid);
            this.requestsPanel.Location = new System.Drawing.Point(3, 0);
            this.requestsPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.requestsPanel.Name = "requestsPanel";
            this.requestsPanel.Size = new System.Drawing.Size(776, 354);
            this.requestsPanel.TabIndex = 13;
            // 
            // requestsGrid
            // 
            this.requestsGrid.AllowUserToAddRows = false;
            this.requestsGrid.AllowUserToDeleteRows = false;
            this.requestsGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.requestsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.requestsGrid.BackgroundColor = System.Drawing.Color.White;
            this.requestsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.requestsGrid.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requestsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.requestsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.requestsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.orderIdColumn,
            this.bookColumn,
            this.quantityColumn,
            this.stateColumn});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.requestsGrid.DefaultCellStyle = dataGridViewCellStyle7;
            this.requestsGrid.GridColor = System.Drawing.Color.White;
            this.requestsGrid.Location = new System.Drawing.Point(44, 39);
            this.requestsGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.requestsGrid.Name = "requestsGrid";
            this.requestsGrid.ReadOnly = true;
            this.requestsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.requestsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.Black;
            this.requestsGrid.RowsDefaultCellStyle = dataGridViewCellStyle9;
            this.requestsGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.requestsGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestsGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.requestsGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.requestsGrid.RowTemplate.Height = 24;
            this.requestsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.requestsGrid.Size = new System.Drawing.Size(729, 290);
            this.requestsGrid.TabIndex = 12;
            // 
            // orderIdColumn
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.orderIdColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.orderIdColumn.HeaderText = "Order ID";
            this.orderIdColumn.Name = "orderIdColumn";
            this.orderIdColumn.ReadOnly = true;
            this.orderIdColumn.Width = 127;
            // 
            // bookColumn
            // 
            this.bookColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.bookColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.bookColumn.HeaderText = "Book Name";
            this.bookColumn.Name = "bookColumn";
            this.bookColumn.ReadOnly = true;
            // 
            // quantityColumn
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.quantityColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.quantityColumn.HeaderText = "Quantity";
            this.quantityColumn.Name = "quantityColumn";
            this.quantityColumn.ReadOnly = true;
            this.quantityColumn.Width = 130;
            // 
            // stateColumn
            // 
            this.stateColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.stateColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.stateColumn.HeaderText = "State";
            this.stateColumn.Name = "stateColumn";
            this.stateColumn.ReadOnly = true;
            // 
            // stockPanel
            // 
            this.stockPanel.Controls.Add(this.stockGrid);
            this.stockPanel.Location = new System.Drawing.Point(3, 0);
            this.stockPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockPanel.Name = "stockPanel";
            this.stockPanel.Size = new System.Drawing.Size(776, 354);
            this.stockPanel.TabIndex = 12;
            // 
            // stockGrid
            // 
            this.stockGrid.AllowUserToAddRows = false;
            this.stockGrid.AllowUserToDeleteRows = false;
            this.stockGrid.AllowUserToResizeRows = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
            this.stockGrid.BackgroundColor = System.Drawing.Color.White;
            this.stockGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stockGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.stockGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.stockGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bookNameColumn,
            this.bookStockColumn});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.stockGrid.DefaultCellStyle = dataGridViewCellStyle13;
            this.stockGrid.GridColor = System.Drawing.Color.White;
            this.stockGrid.Location = new System.Drawing.Point(44, 39);
            this.stockGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockGrid.Name = "stockGrid";
            this.stockGrid.ReadOnly = true;
            this.stockGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.stockGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle14;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.Color.Black;
            this.stockGrid.RowsDefaultCellStyle = dataGridViewCellStyle15;
            this.stockGrid.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.stockGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockGrid.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.stockGrid.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.stockGrid.RowTemplate.Height = 24;
            this.stockGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.stockGrid.Size = new System.Drawing.Size(729, 290);
            this.stockGrid.TabIndex = 12;
            // 
            // bookNameColumn
            // 
            this.bookNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Open Sans", 12F, System.Drawing.FontStyle.Bold);
            this.bookNameColumn.DefaultCellStyle = dataGridViewCellStyle12;
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
            // newOrderButton
            // 
            this.newOrderButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.newOrderButton.Font = new System.Drawing.Font("Open Sans", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newOrderButton.ForeColor = System.Drawing.Color.White;
            this.newOrderButton.Location = new System.Drawing.Point(357, 34);
            this.newOrderButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.newOrderButton.Name = "newOrderButton";
            this.newOrderButton.Size = new System.Drawing.Size(125, 43);
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
            this.stockButton.Location = new System.Drawing.Point(488, 34);
            this.stockButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stockButton.Name = "stockButton";
            this.stockButton.Size = new System.Drawing.Size(76, 43);
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
            this.requestsButton.Location = new System.Drawing.Point(569, 34);
            this.requestsButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.requestsButton.Name = "requestsButton";
            this.requestsButton.Size = new System.Drawing.Size(219, 43);
            this.requestsButton.TabIndex = 14;
            this.requestsButton.Text = "Warehouse Requests";
            this.requestsButton.UseVisualStyleBackColor = false;
            this.requestsButton.Click += new System.EventHandler(this.requestsButton_Click);
            // 
            // StoreClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(851, 450);
            this.Controls.Add(this.requestsButton);
            this.Controls.Add(this.stockButton);
            this.Controls.Add(this.newOrderButton);
            this.Controls.Add(this.newOrderPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StoreClientForm";
            this.Text = "Store Terminal";
            this.Shown += new System.EventHandler(this.StoreClientForm_Shown);
            this.newOrderPanel.ResumeLayout(false);
            this.newOrderPanel.PerformLayout();
            this.newMemberPanel.ResumeLayout(false);
            this.newMemberPanel.PerformLayout();
            this.regMemberPanel.ResumeLayout(false);
            this.regMemberPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.quantityNumericUpDown)).EndInit();
            this.requestsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.requestsGrid)).EndInit();
            this.stockPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.stockGrid)).EndInit();
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

