using Assets.Scripts.Enums;
using Assets.Scripts.EventArgs;
using Assets.Scripts.Pickables;
using UnityEngine;

namespace Assets.Scripts.Models
{
    public class SuitcaseSection : MonoBehaviour
    {
        [field: SerializeField]
        public GameObject Holder { get; private set; }

        [field: SerializeField]
        public PickableType TargetType { get; private set; }

        // Change public to private
        [field: SerializeField]
        public bool IsSet { get; private set; }

        public delegate void ItemInsertedEvent(
            object sender, ItemInsertedEventArgs eventArgs);
        public event ItemInsertedEvent? ItemInserted;

        public delegate void ItemRetrievedEvent(
            object sender, ItemRetrievedEventArgs eventArgs);
        public event ItemRetrievedEvent? ItemRetrieved;

        public void InsertItem(Pickable pickable)
        {
            ItemInserted?.Invoke(this, new(pickable));
        }

        public void RetrieveItem(Pickable pickable)
        {
            ItemRetrieved?.Invoke(this, new(pickable));
        }
    }
}