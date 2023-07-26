using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewDataDesigner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'inventoryDataSet1.Inventory' . Możesz go przenieść lub usunąć.
            this.inventoryTableAdapter.Fill(this.inventoryDataSet1.Inventory);
            // TODO: Ten wiersz kodu wczytuje dane do tabeli 'inventoryDataSet.Inventory' . Możesz go przenieść lub usunąć.
            this.inventoryTableAdapter.Fill(this.inventoryDataSet.Inventory);

        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            try
            {
                this.inventoryTableAdapter.Update(this.inventoryDataSet1.Inventory);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.inventoryTableAdapter.Fill(this.inventoryDataSet1.Inventory);
        }

        private void inventoryDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
