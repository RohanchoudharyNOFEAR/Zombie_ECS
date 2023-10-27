using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Zombie
{
    public class GraveyardMono : MonoBehaviour
    {
        public float2 FieldDimenions;
        public int NumberTombstonesToSpawn;
        public GameObject TombstonePrefab;
    }

    public class GraveyardBaker : Baker<GraveyardMono>
    {
        public override void Bake(GraveyardMono authoring)
        {
            AddComponent(new GraveyardProperties
            {
                FieldDimenions = authoring.FieldDimenions,
                NumberTombstonesToSpawn = authoring.NumberTombstonesToSpawn,
                TombstonePrefab= GetEntity(authoring.TombstonePrefab)
            });
        }
    }
}