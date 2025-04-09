using UnityEngine;

namespace String
{
    /// <summary>
    ///     Data about the string collision
    /// </summary>
    public struct StringHitData
    {
        public Vector2 hitDirection;
    }

    /// <summary>
    ///     Interface for object that can be hit by the string
    /// </summary>
    public interface IStringCollidable
    {
        public void OnStringHit(StringHitData data);
    }
}