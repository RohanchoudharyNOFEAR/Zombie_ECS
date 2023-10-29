using Unity.Entities;

namespace Zombie
{
    [InternalBufferCapacity(8)]
    public struct BrainDamageBufferElement : IBufferElementData
    {
        public float Value;
    }
}