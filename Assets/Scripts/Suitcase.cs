using System.Collections.Generic;
using Assets.Scripts.Enums;
using Assets.Scripts.EventArgs;
using Assets.Scripts.Interactables;
using Assets.Scripts.Managers;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class Suitcase : Interactable
    {
        [SerializeField] private List<SuitcaseSection> _sections = new();

        public IReadOnlyList<SuitcaseSection> Sections => _sections;

        private void Start()
        {
            _sections
                .ForEach(section =>
                {
                    section.ItemInserted += OnItemInserted;
                    section.ItemRetrieved += OnItemRetrieved;
                });
        }

        private void OnItemInserted(object sender, ItemInsertedEventArgs eventArgs)
        {
            SendInventoryUpdateRequest(eventArgs.Pickable.Type, true);
        }

        private void OnItemRetrieved(object sender, ItemRetrievedEventArgs eventArgs)
        {
            SendInventoryUpdateRequest(eventArgs.Pickable.Type, false);
        }

        private void SendInventoryUpdateRequest(
            PickableType type, bool isSet)
        {
            StartCoroutine(
                NetworkManager.UpdateInventoryStatus(
                    new()
                    {
                        Type = type,
                        IsSet = isSet
                    }));
        }
    }
}