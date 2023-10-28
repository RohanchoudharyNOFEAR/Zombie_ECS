using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Random = Unity.Mathematics.Random;

namespace Zombie
{
    public class GraveyardMono : MonoBehaviour
    {
        public float2 FieldDimenions;
        public int NumberTombstonesToSpawn;
        public GameObject TombstonePrefab;
        public uint RandomSeed;
        public GameObject ZombiePrefab;
        public float ZombieSpawnRate;
    }

    public class GraveyardBaker : Baker<GraveyardMono>
    {
        public override void Bake(GraveyardMono authoring)
        {
            var graveyardEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent(graveyardEntity, new GraveyardProperties
            {
                FieldDimensions = authoring.FieldDimenions,
                NumberTombstonesToSpawn = authoring.NumberTombstonesToSpawn,
                TombstonePrefab = GetEntity(authoring.TombstonePrefab, TransformUsageFlags.Dynamic),
                 ZombiePrefab = GetEntity(authoring.ZombiePrefab, TransformUsageFlags.Dynamic),
                ZombieSpawnRate = authoring.ZombieSpawnRate
            });

            AddComponent(graveyardEntity, new GraveyardRandom
            {
                Value = Random.CreateFromIndex(authoring.RandomSeed)
            });
            AddComponent<ZombieSpawnPoints>(graveyardEntity);
            AddComponent<ZombieSpawnTimer>(graveyardEntity);
        }
    }
}