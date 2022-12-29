using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum SectionTypes
    {
        Straight = 2,
        Vertical = 3,
        LeftCorner = 6,
        RightCorner = 8,
        StartGrid = 4,
        Finish = 5,
    }
    public class Section
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public int Compass { get; set; } = 1;
        public SectionTypes SectionType { get; set; }
        public SectionData SectionData { get; set; }
        public Section(SectionTypes sectionTypes,int x, int y, int compass) {
            SectionType = sectionTypes;
            X = x;
            Y = y;
            Compass = compass;
            SectionData = new SectionData();
        }

    }
}
