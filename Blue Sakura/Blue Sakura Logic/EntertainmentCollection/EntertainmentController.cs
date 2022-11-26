using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blue_Sakura_Logic.EntertainmentCollection
{
    public class EntertainmentController
    {
        private List<Entertainment> entertainments;

        public EntertainmentController()
        {
            entertainments = new List<Entertainment>();
        }

        public bool AddEntertainment(Entertainment entertainment)
        {
            bool check = true;
            foreach(Entertainment e in entertainments)
            {
                if(e.Title == entertainment.Title)
                { check = false; }
            }
            if(check)
            { entertainments.Add(entertainment); }
            return check;
        }

        public List<Entertainment> GetAllEntertainments
        { get { return entertainments; } }

        public Entertainment GetEntertainment(int id)
        {
            Entertainment entertainment = null;
            foreach(Entertainment e in entertainments)
            {
                if(e.Id == id)
                {
                    entertainment = e;
                }
            }
            return entertainment;
        }

        public Entertainment GetEntertainment(string title)
        {
            Entertainment entertainment = null;
            foreach (Entertainment e in entertainments)
            {
                if (e.Title == title)
                {
                    entertainment = e;
                }
            }
            return entertainment;
        }
    }
}
