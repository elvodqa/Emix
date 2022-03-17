using System.Collections.Generic;

namespace Emix.Graphics
{
    public class ParticalSystem : List<Drawable>
    {
        public ParticalSystem()
        {
            Particals = new List<Drawable>();
        }

        public List<Drawable> Particals { get; set; }
    }
}