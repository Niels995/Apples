using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Car : IEquipment
    {
        public static IEquipment Equipment { get; set; }
        public int Quality { get ; set ;}
        public int Performance { get; set; }
        public int Speed { get; set; }

        public static IEquipment Equipments(int quality, int performance, int speed)
        {
            Equipment.Quality = quality;
            Equipment.Performance = performance;
            Equipment.Speed = speed;
            return Equipment;
        }
    }
}
