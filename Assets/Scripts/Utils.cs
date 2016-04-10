using UnityEngine;

namespace Utilities
{
    public static class Utils
    {
        public static Vector3 getRandomRotation (int limit)
        {
            int x = UnityEngine.Random.Range(0, limit);
            int y = UnityEngine.Random.Range(0, limit);
            //int z = UnityEngine.Random.Range(0, 0);
            return new Vector3(x,y, 0);
        }
    }
}

