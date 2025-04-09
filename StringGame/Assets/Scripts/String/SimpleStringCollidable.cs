using UnityEngine;
using UnityEngine.Events;

namespace String
{
    public class SimpleStringCollidable : MonoBehaviour, IStringCollidable
    {
        [SerializeField]
        private UnityEvent<StringHitData> onStringHit;

        public void OnStringHit(StringHitData data)
        {
            // Handle the string hit event
            onStringHit?.Invoke(data);
        }
    }
}