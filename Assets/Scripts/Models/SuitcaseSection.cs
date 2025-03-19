using System;
using Assets.Scripts.Enums;
using UnityEngine;

namespace Assets.Scripts.Models
{
    [Serializable]
    public class SuitcaseSection
    {
        [field: SerializeField]
        public GameObject Holder { get; private set; }

        [field: SerializeField]
        public PickableType TargetType { get; private set; }

        [field: SerializeField]
        public bool IsSet { get; private set; }
    }
}