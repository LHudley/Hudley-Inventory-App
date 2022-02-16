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
    public partial class PartModify : Form
    {
        Form1 fm = (Form1)Application.OpenForms["Form1"];
        public PartModify(Inhouse ihPart)
        {
            InitializeComponent();

            RbPartModifyOS.Checked = false;
            RbPartModifyIH.Checked = true;

            label9.Text = ihPart.PartId.ToString();
            textBox2.Text = ihPart.PartName.ToString();
            textBox3.Text = ihPart.PartInv.ToString();
            textBox4.Text = ihPart.PartPrice.ToString();
            textBox5.Text = ihPart.PartMin.ToString();
            textBox6.Text = ihPart.PartMax.ToString();
            label11.Text = "Machine ID";
            textBox1.Text = ihPart.MachineId.ToString();


           
        }

        public PartModify(Outsource osPart)
        {
            InitializeComponent();
            RbPartModifyOS.Checked = true;
            RbPartModifyIH.Checked = false;
            label9.Text = osPart.PartId.ToString();
            textBox2.Text = osPart.PartName.ToString();
            textBox3.Text = osPart.PartInv.ToString();
            textBox4.Text = osPart.PartPrice.ToString();
            textBox5.Text = osPart.PartMin.ToString();
            textBox6.Text = osPart.PartMax.ToString();
            label11.Text = "Company Name";
            textBox1.Text = osPart.CompanyName.ToString();
            
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            int partId, partinv, partmin, partmax;
            string partname;
            double partprice;
            Inhouse updt;
            Outsource upos;
            try {

                partmin = int.Parse(textBox5.Text);
                partmax = int.Parse(textBox6.Text);
                partId = int.Parse(label9.Text);
                partname = textBox2.Text;
                partinv = int.Parse(textBox3.Text);
                partprice = double.Parse(textBox4.Text);
                

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


            if (RbPartModifyIH.Checked)
            {
                
                int machineID;
                try {
                    machineID = int.Parse(textBox1.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Machine ID only contain numbers", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                machineID = int.Parse(textBox1.Text);
                updt = new Inhouse(partId, partname, partinv, partprice, partmin, partmax, machineID);
                Inventory.UpdatePart(partId, updt);
                MessageBox.Show($"{partname} updated successful.");
                RbPartModifyIH.Checked = true;
                
            }else 
            {
                string companyName = textBox1.Text;
                upos = new Outsource(partId, partname, partinv, partprice, partmin, partmax, companyName);
                Inventory.UpdatePart(partId,upos);
                MessageBox.Show($"{partname} updated successful.");
                RbPartModifyOS.Checked = true;
            }
            this.Close();

            
            fm.dgvParts.Update();
            fm.dgvParts.Refresh();
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
       
        private void RbPartModifyIH_CheckedChanged_1(object sender, EventArgs e)
        {
           
            label11.Text = "Machine Id: ";

        }

        private void RbPartModifyOS_CheckedChanged_1(object sender, EventArgs e)
        {
            label11.Text = "Company Name: ";
           

        }
    }
}
    



