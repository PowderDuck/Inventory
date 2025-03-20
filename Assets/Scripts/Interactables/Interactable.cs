using UnityEngine;

namespace Assets.Scripts.Interactables
{
    public class Interactable : MonoBehaviour
    {
        public virtual void Interact(object subject) { }
    }
}