using UnityEngine;

namespace ArrowHero.Core
{
    public static class GameObjectExt
    {
        public static bool IsInLayer(this GameObject go, LayerMask layer)
        {
            return layer == ( layer | 1 << go.layer );
        }
    }
}