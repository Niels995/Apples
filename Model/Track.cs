using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Track
    {
        public String Name { get; set; }
        public LinkedList<Section> Sections { get; set; } = new LinkedList<Section> ();
        public Track(string name)
        {
            Name = name;
        }
        public Track(string name, SectionTypes[] sections) : this(name)
        {
            foreach (SectionTypes s in sections)
            {
                Sections.AddLast(new Section(s, 0,0,1));
               // SectionList(s,0,0,1);
            }
        }


        public LinkedList<Section> SectionList(SectionTypes sections,int x, int y, int compass)
        {   
            //foreach (SectionTypes section in sections) {
                Sections.AddLast(new Section(sections, x, y, compass));
            //}
            return Sections;
        }
        //public string setXY(int x, int y) {
        //    X = x;
        //    Y = y;
        //    return $"{x}+{y}";
        //}
    }
}
