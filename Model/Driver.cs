﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class Driver : IParticipant
    {
        public Driver(String name, int points, IEquipment equipment, TeamColors teamColors)
        {
            Name = name;
            Points = points;
            Equipment = equipment;
            Teamcolors = teamColors;
        }

        public string Name { get; set; }
        public int Points { get; set; }
        public IEquipment Equipment { get; set; }
        public TeamColors Teamcolors { get; set; }
    }
}