using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

namespace Zombie
{
    //creating seprate variable for random because graveyardproperties are readonly
    public struct GraveyardRandom : IComponentData
    {
        public Random Value;
    }
}
