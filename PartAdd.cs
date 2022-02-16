using InventoryApp.InvClasses;
using InventoryApp.Model;
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
    public partial class PartAdd : Form
    {
       

        public PartAdd()
        {
            InitializeComponent();
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                label8.Text = "Machine ID";
            }
           
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                label8.Text = "Company Name";
            }
            else
            {
                label8.Text = "";
            }
        }

        private void btnPartSave_Click(object sender, EventArgs e)
        {
            int partId = Inventory.AllParts.Count + 1; ;
            string partname = textBox2.Text;
            int machineID = 0;
            string companyName = "";
            int partinv, partmin, partmax;
            double partprice;


            try
            {

                if (radioButton1.Checked)
                {
                    machineID = int.Parse(newPt.Text);
                }
                if (radioButton2.Checked)
                {
                    companyName = newPt.Text;
                }
               
                partinv = Int32.Parse(textBox3.Text);
                partprice = Double.Parse(textBox4.Text);
                partmin = Int32.Parse(textBox5.Text);
                partmax = Int32.Parse(textBox6.Text);

            }
            catch (Exception)
            {
                MessageBox.Show("Please use only numbers for:\n" +
                    $"Inventory\n" +
                    $"Price\n" +
                    $"Max\n" +
                    $"Min\n" +
                    $"MachineID");
                return;
            }

            if (String.IsNullOrEmpty(partname))
            {
                MessageBox.Show(" Please enter a name for part.");
                return;
            }

            if (partmin > partmax)
            {
                MessageBox.Show("Maximum parts should be greater than minimum parts");
                return;
            }
            if (partinv > partmax || partinv < partmin)
            {
                if (partinv > partmax)
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
           


            if (radioButton1.Checked)
            {
                
                Inhouse part = new Inhouse(partId, partname, partinv, partprice, partmin, partmax, machineID);
                Inventory.AddPart(part);
                MessageBox.Show($"{partname} add successful.");
                this.Hide();
               
            }

            if (radioButton2.Checked)
            {
                Outsource part = new Outsource(partId, partname, partinv, partprice, partmin, partmax, companyName);
                Inventory.AddPart(part);
                MessageBox.Show($"{partname} add successful.");
                this.Hide();
               
            }

        }
       
        private void btnPartAddCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

       
    
}
