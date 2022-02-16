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
    public partial class Product_Modify : Form
    {
        BindingList<Part> AdPt = new BindingList<Part>();


        

        public Product_Modify(Product ct)
        {
            InitializeComponent();

            dgvPd2.DataSource = Inventory.AllParts;
            dgvPt2.DataSource = AdPt; 
            label10.Enabled = false;
            label10.Text = ct.PdId.ToString();
            textBox2.Text = ct._Name.ToString();
            textBox3.Text = ct._Inv.ToString();
            textBox4.Text = ct._Price.ToString();
            textBox5.Text = ct._Max.ToString();
            textBox6.Text = ct._Min.ToString();

           
            foreach (Part part in ct.associatedParts)
            {
                AdPt.Add(part);
            }


            dgvPd2.Update();
            dgvPt2.Refresh();
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Part AdPts = (Part)dgvPd2.CurrentRow.DataBoundItem;
            AdPt.Add(AdPts);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int productId, pdinv, pdmax, pdmin;
            string pdname = textBox2.Text;
            double pdprice;
            
            try
            {

                pdmin = int.Parse(textBox6.Text);
                pdmax = int.Parse(textBox5.Text);
                productId = int.Parse(label10.Text);
                pdname = textBox2.Text;
                pdinv = int.Parse(textBox3.Text);
                pdprice = double.Parse(textBox4.Text);


            }
            catch (Exception)
            {
                MessageBox.Show($"Please use only numbers for:\n" +
                    $"Inventory\n" +
                    $"Price\n" +
                    $"Max\n" +
                    $"Min\n" +
                    $"MachineID");
                return;
            }
            if (String.IsNullOrEmpty(pdname))
            {
                MessageBox.Show(" Please enter a name for part.");
                return;
            }


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

            Product ct = new Product(productId, pdname, pdinv, pdprice, pdmax, pdmin);
            foreach (var part in AdPt)
            {
                ct.AddAssociatedPart(part);
            }
            Inventory.UpdateProduct(productId, ct);

            MessageBox.Show($"{pdname} modified successful.");
            Close();

            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this part?", "Confirm", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {

                foreach (DataGridViewRow row in dgvPt2.SelectedRows)
                {
                    dgvPt2.Rows.RemoveAt(row.Index);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                for (int i = 0; i < Inventory.AllParts.Count; i++)
                {
                    if (Inventory.AllParts[i].PartName.ToUpper().Contains(textBox7.Text.ToUpper()))
                    {
                        dgvPd2.Rows[i].Selected = true;
                    }
                    else if (Inventory.AllParts[i].PartName.ToUpper().Contains(textBox7.Text.ToUpper()))
                    {

                    }
                    else
                    {
                        dgvPd2.Rows[i].Selected = false;

                    }
                }

            }

            else
            {
                MessageBox.Show("Please enter valid part name");
            }


        }
    }
}
