using InventoryApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApp.InvClasses

{

    public class Product 
    {
        public BindingList<Part> associatedParts = new BindingList<Part>();

        public int PdId { get; set; }
        public string _Name { get; set; }
        public int _Inv { get; set; }
        public double _Price { get; set; }
        public int _Max { get; set; }
        public int _Min { get; set; }

        public Product() { }
        public Product(int pdId, string _name, int _inv, double _price, int _max, int _min)
        {
            PdId = pdId;
            _Name = _name;
            _Inv = _inv;
            _Price = _price;
            _Max = _max;
            _Min = _min;

        }
       
       


        public void AddAssociatedPart(Part part)
        {
            associatedParts.Add(part);
        }

        public bool RemoveAssociatedPart(int ptId)
        {
            bool prtRemoved = false;

            foreach (Part part in associatedParts)
            {
                if (part.PartId == ptId)
                {
                    associatedParts.Remove(part);
                    return prtRemoved = true;
                }
                else
                {
                    prtRemoved = false;
                }
            }

            return prtRemoved;

            
        }

        public Part LookupAssociatedPart( int partId)
        {
            Part lookUpParts = null;

            foreach (var part in associatedParts)
            {
                if (part.PartId == partId)
                {
                    lookUpParts = part;
                    return lookUpParts;
                }
            }

            return lookUpParts;
        }
      

    }
}
