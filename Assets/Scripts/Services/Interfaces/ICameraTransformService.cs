

using System;
using UnityEngine;

namespace Services.Interfaces
{
    public interface ICameraTransformService
    {
        public Vector3 StartPosition { get; set; }
        public bool CurrentPostionStart { get; set; }
        public Vector3 EndPosition { get; set; }
        public bool CurrentPostionEnd { get; set; }
        public float TimeToPlay { get; set; }
        public event Action OnEnd;

        public void Play();
    }
}
