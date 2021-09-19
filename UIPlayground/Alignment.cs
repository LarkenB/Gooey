using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIPlayground
{
    class Alignment
    {
        public VerticalAlignment Vertical = VerticalAlignment.Center;
        public HorizontalAlignment Horizontal = HorizontalAlignment.Center;
    }

    enum VerticalAlignment
    {
        Top,
        Center,
        Bottom
    }

    enum HorizontalAlignment
    {
        Left,
        Center,
        Right
    }
}
