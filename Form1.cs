using System;
using System.Collections.Generic;
using System.Windows.Forms;
using InventoryApp.InvClasses;
using InventoryApp.Model;


//Inventory App Created By Latoya Hudley/////////////////////////////////////////////////////////////////////
namespace InventoryApp
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
          
            InitializeComponent();
            Form1_Load();
           
        }

        public  void Form1_Load()
        {
            Inventory.PopulateGrid();
           
            var bindingSourcePart = new BindingSource();
            bindingSourcePart.DataSource = Inventory.AllParts;
            dgvParts.DataSource = bindingSourcePart;

            dgvParts.Columns["PartID"].HeaderText = "ID";
            dgvParts.Columns["PartName"].HeaderText = "Name";
            dgvParts.Columns["PartInv"].HeaderText = "Inventory";
            dgvParts.Columns["PartPrice"].HeaderText = "Price";
            dgvParts.Columns["PartMin"].Visible = true;
            dgvParts.Columns["PartMax"].Visible = true;


            var bindingSourceProduct = new BindingSource();
            bindingSourceProduct.DataSource = Inventory.Products;
            dgvProducts.DataSource = bindingSourceProduct;

            dgvProducts.Columns["PdId"].HeaderText = "Product ID";
            dgvProducts.Columns["_Name"].HeaderText = "Product Name";
            dgvProducts.Columns["_Inv"].HeaderText = "Inventory";
            dgvProducts.Columns["_Price"].HeaderText = "Price";
            dgvProducts.Columns["_Min"].Visible = true;
            dgvProducts.Columns["_Max"].Visible = true;

        }




        private void btnAdd_Click(object sender, EventArgs e)
        {

            new PartAdd().ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvParts.CurrentRow.DataBoundItem.GetType() == typeof(Inhouse))
            {
                Inhouse inhouse = (Inhouse)dgvParts.CurrentRow.DataBoundItem;
                new PartModify(inhouse).ShowDialog();

            }
            else
            {
                Outsource outsourced = (Outsource)dgvParts.CurrentRow.DataBoundItem;
                new PartModify(outsourced).ShowDialog();
            }
            dgvParts.Update();
            dgvParts.Refresh();
        }


        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            new productAdd().ShowDialog();
        }

       
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnPartSearch_Click(object sender, EventArgs e)
        {

            
                if (txtPartSearch.Text != "")
                {
                    for (int i = 0; i < Inventory.AllParts.Count; i++)
                    {
                        if (Inventory.AllParts[i].PartName.ToUpper().Contains(txtPartSearch.Text.ToUpper()))
                        {
                            dgvParts.Rows[i].Selected = true;
                        }
                        else if (Inventory.AllParts[i].PartName.ToUpper().Contains(txtPartSearch.Text.ToUpper()))
                        {

                        }
                        else
                        {
                            dgvParts.Rows[i].Selected = false;

                        }
                    }

                }
 
                else
                {
                    MessageBox.Show("Please enter valid part name");
                 }
                


            


        }
       

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this part?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                foreach (DataGridViewRow row in dgvParts.SelectedRows)
                {
                    dgvParts.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            if (txtProductSearch.Text != "")
            {
                for (int i = 0; i < Inventory.Products.Count; i++)
                {
                    if (Inventory.Products[i]._Name.ToUpper().Contains(txtProductSearch.Text.ToUpper()))
                    {
                        dgvProducts.Rows[i].Selected = true;
                    }
                    else if (Inventory.Products[i]._Name.ToUpper().Contains(txtProductSearch.Text.ToUpper()))
                    {

                    }
                    else
                    {
                        dgvProducts.Rows[i].Selected = false;

                    }
                }

            }

            else
            {
                MessageBox.Show("Please enter valid product name");
            }
        }

        private void btnDeleteProduct_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm ", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                
                Product product = (Product)dgvProducts.CurrentRow.DataBoundItem;
                if (product.associatedParts.Count > 0)
                {
                    MessageBox.Show("Please remove all parts from product before delete");
                    return;
                }
                foreach (DataGridViewRow row in dgvProducts.SelectedRows)
                {
                    dgvProducts.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void btnModifyProduct_Click(object sender, EventArgs e)
        {
            Product ct = (Product)dgvProducts.CurrentRow.DataBoundItem;
            new Product_Modify(ct).ShowDialog();
            dgvProducts.Update();
            dgvProducts.Refresh();

        }
    }
}
