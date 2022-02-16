using InventoryApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventoryApp.InvClasses
{
   public class Inventory
    {
        public static BindingList<Part> AllParts = new BindingList<Part>();
        public static BindingList<Product> Products = new BindingList<Product>();


        public static void PopulateGrid()
        {
            Part pt1 = new Inhouse(10, "Wheel", 36, 19.03, 80, 5, 5436);
            Part pt2 = new Outsource(11, "Seat", 70, 45.67, 100, 5, "Zippy");
            Part pt3 = new Outsource(12, "Pedals", 112, 10.12, 170, 5, "Escape Plan");

            Inventory.AllParts.Add(pt1);
            Inventory.AllParts.Add(pt2);
            Inventory.AllParts.Add(pt3);


            Product product1 = new Product(01, "BMX", 15, 260.00, 40, 5);
            product1.AddAssociatedPart(pt1);
            product1.AddAssociatedPart(pt2);
            product1.AddAssociatedPart(pt3);

            Product product2 = new Product(02, "Huffy", 23, 120.99, 57, 5);
            product2.AddAssociatedPart(pt1);
            product2.AddAssociatedPart(pt3);

            Product product3 = new Product(03, "Redline", 12, 300.98, 65, 5);
            product3.AddAssociatedPart(pt2);
            product3.AddAssociatedPart(pt3);

            Inventory.Products.Add(product1);
            Inventory.Products.Add(product2);
            Inventory.Products.Add(product3);


        }


        /// <summary>
        /// //////////////////////////////////Product/////////////////////////////////
        /// </summary>
        /// <param name="product"></param>
        public static void AddProduct(Product product)
        {
            Products.Add(product);

        }
        public static bool RemoveProduct(int pdId)
        {
            bool productRemoved = false;

            foreach (Product products in Products)
            {
                if (products.PdId == pdId)
                {
                    Products.Remove(products);
                    return productRemoved = true;
                }
                else
                {
                    productRemoved = false;
                }
            }

            return productRemoved;

        }
        public static Product LookupProduct(int pdId)
        {
            Product prodlook = null;
            foreach (var product in Products)
            {
                if (product.PdId == pdId)
                {
                    prodlook = product;
                }
            }
            return prodlook;

        }
        public static void UpdateProduct(int pdId, Product updatePd)
        {
            foreach (var product in Products)
            {
                if (product.PdId == pdId)
                {
                    product.associatedParts = updatePd.associatedParts;
                    product._Name = updatePd._Name;
                    product._Price = updatePd._Price;
                    product._Inv = updatePd._Inv;
                    product._Min = updatePd._Min;
                    product._Max = updatePd._Max;
                    return;
                }
            }

        }


        /// <summary>
        /// ////////////////////////////////Part////////////////////////////////////
        /// </summary>
        /// <param name="product"></param>
        public static void AddPart(Part part)
        {

            AllParts.Add(part);
        }
        public static bool DeletePart(Part partRemoved)
        {
            DialogResult result = MessageBox.Show("Do you want to save changes?", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (result == DialogResult.Yes)
            {
                foreach (var part in AllParts)
                {
                    if (part.PartId == partRemoved.PartId)
                    {
                        AllParts.Remove(part);
                        return true;
                    }
                }

            }

            return false;
        }


        public static Part LookupPart(int LUPartId)
        {
            Part RPart = null;
            foreach (var part in AllParts)
            {
                if (part.PartId == LUPartId)
                {
                    RPart = part;
                }
            }
            return RPart;

        }
        public static void UpdatePart(int partId, Part nwPt )
        {
            Part OdPt = LookupPart(partId);
            AllParts.Remove(OdPt);
            AllParts.Add(nwPt);
            
        }

    }
}  

    

