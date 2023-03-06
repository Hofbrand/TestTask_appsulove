using System.Collections.Generic;
using UnityEngine;

namespace Models
{
    public class CircleModel : BaseModel
    {
        public bool IsMoving { get; set; }
        public Vector2? Target { get; set; }
        public List<Vector2> Targets { get; set; }
        public float Distance { get; internal set; }
    }
}

