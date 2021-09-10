using System;
using System.Collections.Generic;

#nullable disable

namespace RomEndprojectAwApi.Models
{
    public partial class Emotion
    {
        public int Id { get; set; }
        public DateTime? Time { get; set; }
        public double? Happiness { get; set; }
        public double? Sadness { get; set; }
        public double? Anger { get; set; }
        public double? Neutral { get; set; }
        public double? Surprise { get; set; }
        public double? Disgut { get; set; }
        public string DeviceId { get; set; }

        public virtual Device Device { get; set; }
    }
}
