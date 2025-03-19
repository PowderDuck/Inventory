using UnityEngine;

namespace Assets.Scripts.Interactables
{
    public class Interactable : MonoBehaviour
    {
        public virtual void Press() { }

        public virtual void LongPress() { }
    }
}