using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace Zombie
{
    [BurstCompile]
    [UpdateInGroup(typeof(InitializationSystemGroup))]
    public partial struct SpawnTombstoneSystem : ISystem
    {
        [BurstCompile]
        public void OnCreate(ref SystemState state)
        {
            //used like required component for unning onupdate
            state.RequireForUpdate<GraveyardProperties>();
        }
        [BurstCompile]
        public void OnDestroy(ref SystemState state)
        {

        }
        [BurstCompile]
        public void OnUpdate(ref SystemState state)
        {
            state.Enabled = false;
            var graveyardEntity = SystemAPI.GetSingletonEntity<GraveyardProperties>();
            var graveyard = SystemAPI.GetAspect<GraveyardAspect>(graveyardEntity);

            //it is used to store command to a queue to be executed later 
            //allocater is uded to define if it is temperory(for 1-4 frames) or persitent
            var ecb = new EntityCommandBuffer(Allocator.Temp);

            var tombstoneOffset = new float3(0f, -2f, 1f);

            var builder = new BlobBuilder(Allocator.Temp);
            ref var spawnPoints = ref builder.ConstructRoot<ZombieSpawnPointsBlob>();
            var arrayBuilder = builder.Allocate(ref spawnPoints.Value, graveyard.NumberTombstonesToSpawn);

            for (var i = 0; i < graveyard.NumberTombstonesToSpawn; i++)
            {
                var newTombstone = ecb.Instantiate(graveyard.TombstonePrefab);
                var newTombstoneTransform = graveyard.GetRandomTombstoneTransform();
                //setting new transform to our tombstoneinstancedentity
                ecb.SetComponent(newTombstone, newTombstoneTransform);

                var newZombieSpawnPoint = newTombstoneTransform.Position + tombstoneOffset;
                arrayBuilder[i] = newZombieSpawnPoint;
            }
            var blobAsset = builder.CreateBlobAssetReference<ZombieSpawnPointsBlob>(Allocator.Persistent);
            ecb.SetComponent(graveyardEntity, new ZombieSpawnPoints { Value = blobAsset });
            builder.Dispose();

            ecb.Playback(state.EntityManager);

        }


    }


}

