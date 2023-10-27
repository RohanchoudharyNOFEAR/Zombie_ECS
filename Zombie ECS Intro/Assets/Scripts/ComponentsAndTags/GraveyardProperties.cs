using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Zombie
{
    public struct GraveyardProperties : IComponentData
    {
        public float2 FieldDimenions;
        public int NumberTombstonesToSpawn;
        public Entity TombstonePrefab;
    }
}
