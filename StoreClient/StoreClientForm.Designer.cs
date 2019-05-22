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
            this.booksComboBox = new System.Windows.Forms.ComboBox();
            this.clientsComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // booksComboBox
            // 
            this.booksComboBox.FormattingEnabled = true;
            this.booksComboBox.Location = new System.Drawing.Point(29, 55);
            this.booksComboBox.Name = "booksComboBox";
            this.booksComboBox.Size = new System.Drawing.Size(165, 24);
            this.booksComboBox.TabIndex = 0;
            // 
            // clientsComboBox
            // 
            this.clientsComboBox.FormattingEnabled = true;
            this.clientsComboBox.Location = new System.Drawing.Point(269, 55);
            this.clientsComboBox.Name = "clientsComboBox";
            this.clientsComboBox.Size = new System.Drawing.Size(121, 24);
            this.clientsComboBox.TabIndex = 1;
            // 
            // StoreClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.clientsComboBox);
            this.Controls.Add(this.booksComboBox);
            this.Name = "StoreClientForm";
            this.Text = "Store Terminal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox booksComboBox;
        private System.Windows.Forms.ComboBox clientsComboBox;
    }
}

