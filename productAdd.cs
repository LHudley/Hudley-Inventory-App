using InventoryApp.InvClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp
{
    public partial class productAdd : Form
    {
        public static BindingList<Part> AdPt = new BindingList<Part>();

        public productAdd()
        {
            InitializeComponent();
            ProductAdd_Load();
            dgvPdAddPt.DataSource = Inventory.AllParts;
            dgvPtPd.DataSource = AdPt;
        }


        private void ProductAdd_Load()
        {

            var bindingSourcePart = new BindingSource();
            bindingSourcePart.DataSource = Inventory.AllParts;
            dgvPdAddPt.DataSource = bindingSourcePart;

            dgvPdAddPt.Columns["PartID"].HeaderText = "ID";
            dgvPdAddPt.Columns["PartName"].HeaderText = "Name";
            dgvPdAddPt.Columns["PartInv"].HeaderText = "Inventory";
            dgvPdAddPt.Columns["PartPrice"].HeaderText = "Price";
            dgvPdAddPt.Columns["PartMax"].Visible = false;
            dgvPdAddPt.Columns["PartMin"].Visible = false;

            var bindingSourceProduct = new BindingSource();
            bindingSourceProduct.DataSource = AdPt;
            dgvPtPd.DataSource = bindingSourceProduct;

            dgvPtPd.Columns["PartID"].HeaderText = "ID";
            dgvPtPd.Columns["PartName"].HeaderText = "Name";
            dgvPtPd.Columns["PartInv"].HeaderText = "Inventory";
            dgvPtPd.Columns["PartPrice"].HeaderText = "Price";
            dgvPtPd.Columns["PartMax"].Visible = false;
            dgvPtPd.Columns["PartMin"].Visible = false;



        }
        private void button2_Click(object sender, EventArgs e)
        {
            Part AdPts = (Part)dgvPdAddPt.CurrentRow.DataBoundItem;
            AdPt.Add(AdPts);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].PartName.ToUpper().Contains(textBox1.Text.ToUpper()))
                    {
                        dgvPdAddPt.Rows[i].Selected = true;
                    }
                    //else if (Inventory.AllParts[i].PartName.ToUpper().Contains(textBox1.Text.ToUpper()))
                    //{

                    //}
                    else
                    {
                        dgvPdAddPt.Rows[i].Selected = false;

                    }
                }

            }

            else
            {
                MessageBox.Show("Please enter valid part name");
            }

        }

        private void btnPdSv_Click(object sender, EventArgs e)
        {
            int productId = Inventory.AllParts.Count + 1; ;
            string pdname = textBox3.Text;
            int pdinv = Int32.Parse(textBox4.Text);
            double pdprice = Double.Parse(textBox5.Text);
            int pdmax = Int32.Parse(textBox6.Text);
            int pdmin = Int32.Parse(textBox7.Text);



            if (pdmin > pdmax)
            {
                MessageBox.Show("Maximum parts should be greater than minimum parts");
                return;
            }
            if (pdinv > pdmax || pdinv < pdmin)
            {
                if (pdinv > pdmax)
                {
                    MessageBox.Show("Part inventory should not be greater than maximum inventory");
                    return;
                }
                else
                {
                    MessageBox.Show("Part inventory should not be less than minimum inventory");
                    return;
                }
            }
            Product pdLt = new Product(productId, pdname, pdinv, pdprice, pdmax, pdmin);
            Inventory.AddProduct(pdLt);

            foreach (Part part in AdPt)
            {
                pdLt.AddAssociatedPart(part);
            }

            this.Close();
            


        }


        private void btnPdDl_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this part?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                foreach (DataGridViewRow row in dgvPtPd.SelectedRows)
                {
                    dgvPtPd.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void btnPdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



