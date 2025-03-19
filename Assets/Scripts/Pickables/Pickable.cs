using Assets.Scripts.Enums;
using Assets.Scripts.Interactables;
using UnityEngine;

namespace Assets.Scripts.Pickables
{
    [RequireComponent(typeof(Rigidbody))]
    public abstract class Pickable : Interactable
    {
        [field: SerializeField]
        public long Id { get; private set; } = default!;

        [field: SerializeField]
        public float Weight { get; private set; } = default!;

        [field: SerializeField]
        public string Name { get; private set; } = default!;

        public abstract PickableType Type { get; }

        protected Rigidbody Rigidbody { get; private set; } = default!;

        protected virtual void Start()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }
    }
}