using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class CircleModel : BaseModel
    {
        public float MinSpeed { get; } = 0.3f;
        public float MaxSpeed { get; set; }
        public bool IsMoving { get; set; }
        public Vector2? Target { get; set; }
        public List<Vector2> Targets { get; set; }
        public float Distance { get; internal set; }
        public float TotalDistance { get; internal set; }
        public float ElapsedDistance { get; internal set; }
    }
}

