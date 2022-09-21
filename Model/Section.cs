﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum SectionTypes
    {
        Straight,
        LeftCorner,
        RightCorner,
        StartGrid,
        Finish,
    }
    public class Section
    {
        public SectionTypes SectionType { get; set; }
        public Section(SectionTypes sectionTypes) {
            SectionType = sectionTypes;
        }

    }
}
