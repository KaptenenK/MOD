using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MOD.Database.Entities
{
    public class Director : IEntity
    {
        public Director()
        {
            Films = new HashSet<Film>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Film> Films { get; set; }
    }
}
