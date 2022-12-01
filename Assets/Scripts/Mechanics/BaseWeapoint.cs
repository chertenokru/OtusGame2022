using System;
using UnityEngine;

namespace Mechanics
{
    [Serializable]
    public abstract class BaseWeapoint : MonoBehaviour
    {
        public abstract void Attack();
        public abstract string GetName();
    }
}