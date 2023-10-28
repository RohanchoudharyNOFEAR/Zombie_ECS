using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

namespace Zombie
{
    public struct ZombieRiseRate : IComponentData
    {
        public float Value;
    }
}