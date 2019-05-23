using StoreClient.StoreServiceReference;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace StoreClient {
    public partial class StoreClientForm : Form {
        StoreServiceClient proxy;
        List<Book> books = new List<Book>();
        List<Client> clients = new List<Client>();
        List<Order> orders = new List<Order>();
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
            newClientPanel.Parent = newOrderPanel;
            regClientPanel.Parent = newOrderPanel;
            newClientPanel.Location = regClientPanel.Location;
            newClientPanel.Visible = false;
            setVisibility(0);
        }

        public void setVisibility(int index) {
            List<Panel> panels = new List<Panel>() { newOrderPanel, stockPanel, requestsPanel };
            panels.ForEach(panel => panel.Visible = false);
            panels[index].Visible = true;
        }

        private void newOrderButton_Click(object sender, EventArgs e) {
            setVisibility(0);
            regClientPanel.Visible = true;
            newClientPanel.Visible = false;
        }

        private void stockButton_Click(object sender, EventArgs e) {
            setVisibility(1);
        }

        private void requestsButton_Click(object sender, EventArgs e) {
            setVisibility(2);
        }

        private void resClientButton_Click(object sender, EventArgs e) {
            regClientPanel.Visible = true;
            newClientPanel.Visible = false;
        }

        private void newClientButton_Click(object sender, EventArgs e) {
            regClientPanel.Visible = false;
            newClientPanel.Visible = true;
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
            } else {
                totalPrice = Convert.ToInt32(quantityNumericUpDown.Value) * selectedBook.price;
            }
            
            totalPriceLabel.Text = totalPrice.ToString();
        }

        private void StoreClientForm_Shown(object sender, EventArgs e) {
            addBooksToForm();
            addClientsToForm();
            addOrdersToForm();
        }

        public void addBooksToForm() {
            books = new List<Book>(proxy.GetBooks());
            books.ForEach(book => {
                booksComboBox.Items.Add(book.title);
                stockGrid.Rows.Add(book.title, book.stock);
            });
        }

        public void addClientsToForm() {
            clients = new List<Client>(proxy.GetClients());
            clients.ForEach(client => clientsComboBox.Items.Add(client.name));
        }

        public void addOrdersToForm() {
            orders = new List<Order>(proxy.GetOrders());
            orders.ForEach(order => {
                Console.WriteLine(order.state.ToString());
                requestsGrid.Rows.Add(order.guid, order.book.title, order.quantity, stateToString(order.state));
                });
        }

        private string stateToString(Order.State state) {
            switch (state.type) {
                case Order.State.Type.DELIVERED:
                    return "Delivered at " + state.dispatchDate.ToString("MM/dd/yyyy");
                case Order.State.Type.WAITING:
                    return "Waiting Expedition";
                case Order.State.Type.DISPATCHED_AT:
                    return "Dispatched at " + state.dispatchDate.ToString("MM/dd/yyyy");
                case Order.State.Type.DISPATCH_OCCURS_AT:
                    return "Dispatch will occur at" + state.dispatchDate.ToString("MM/dd/yyyy");
                default:
                    return "";
            }
        }
    }
}
