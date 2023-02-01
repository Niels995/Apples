using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public enum TeamColors
    {
        Red,
        Green,
        Yellow,
        Grey,
        Blue
    }
    public interface IParticipant : IEquipment
    {

        string Name { get; set; }
        int Points { get; set; }
        IEquipment Equipment { get; set; }
        TeamColors Teamcolors { get; set; }
        int Finished { get; set; }
        int CurrentSection { get; set; }
    }
}
