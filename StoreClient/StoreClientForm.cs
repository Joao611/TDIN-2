using StoreClient.StoreServiceReference;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StoreClient {
    public partial class StoreClientForm : Form {
        StoreServiceClient proxy;
        List<Book> books = new List<Book>();
        List<Client> clients = new List<Client>();
        Book selectedBook = null;
        double totalPrice = 0;
        public StoreClientForm(StoreServiceClient proxy) {
            InitializeComponent();
            this.proxy = proxy;
            newOrderPanel.Parent = this;
            stockPanel.Parent = this;
            stockPanel.Location = newOrderPanel.Location;
            requestsPanel.Parent = this;
            requestsPanel.Location = newOrderPanel.Location;
            newMemberPanel.Parent = newOrderPanel;
            regMemberPanel.Parent = newOrderPanel;
            newMemberPanel.Location = regMemberPanel.Location;
            newMemberPanel.Visible = false;
            setVisibility(0);
        }

        public async void addBooksToFormAsync() {
            Book[] books2 = proxy.GetBooks();
            //books = new List<Book>(await proxy.GetBooksAsync());
            books.ForEach(book => booksComboBox.Items.Add(book.title));
        }

        public void setVisibility(int index) {
            List<Panel> panels = new List<Panel>() { newOrderPanel, stockPanel, requestsPanel };
            panels.ForEach(panel => panel.Visible = false);
            panels[index].Visible = true;
        }

        private void newOrderButton_Click(object sender, EventArgs e) {
            setVisibility(0);
            regMemberPanel.Visible = true;
            newMemberPanel.Visible = false;
        }

        private void stockButton_Click(object sender, EventArgs e) {
            setVisibility(1);
        }

        private void requestsButton_Click(object sender, EventArgs e) {
            setVisibility(2);
        }

        private void resMemberButton_Click(object sender, EventArgs e) {
            regMemberPanel.Visible = true;
            newMemberPanel.Visible = false;
        }

        private void newMemberButton_Click(object sender, EventArgs e) {
            regMemberPanel.Visible = false;
            newMemberPanel.Visible = true;
        }

        private void booksComboBox_SelectedIndexChanged(object sender, EventArgs e) {
            selectedBook = books.Find(book => book.title == booksComboBox.Text);
            updateTotalPrice();
        }

        private void quantityNumericUpDown_ValueChanged(object sender, EventArgs e) {
            updateTotalPrice();
        }

        public void updateTotalPrice() {
            if (selectedBook == null) {
                totalPrice = 0;
            }
            totalPrice = Convert.ToInt32(quantityNumericUpDown.Value) * selectedBook.price;
            totalPriceLabel.Text = totalPrice.ToString();
        }

        private async void StoreClientForm_Shown(object sender, EventArgs e) {

            addBooksToFormAsync();
            Console.WriteLine(books);
        }
    }
}
