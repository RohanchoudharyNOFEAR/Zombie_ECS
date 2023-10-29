using Unity.Entities;

namespace Zombie
{
    public struct BrainHealth : IComponentData
    {
        public float Value;
        public float Max;
    }
}