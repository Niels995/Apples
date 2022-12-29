﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Competition
    {
        public List<IParticipant> Participants { get; set; }
        public static Queue<Track> Tracks { get; set; }
        public Track NextTrack() {
            if (Tracks.Count() != 0)
            {
                return Tracks.Dequeue();
            }
            return null;
        }
        public Competition(List<IParticipant> participants, Queue<Track> tracks) { 
            Participants = participants;
            Tracks = tracks;
        }
    }
}
