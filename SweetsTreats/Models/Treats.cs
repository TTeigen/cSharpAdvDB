using System.Collections.Generic;

namespace SweetsTreats.Models
{
    public class Treat
    {
        public Treat()
        {
            this.Flavors = new HashSet<FlavorTreat>();
        }

        public int TreatId { get; set; }
        public string Title { get; set; }

        public ICollection<FlavorTreat> Flavors { get; }
    }
}