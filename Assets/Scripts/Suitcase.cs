using System.Collections.Generic;
using Assets.Scripts.Interactables;
using Assets.Scripts.Models;
using UnityEngine;

namespace Assets.Scripts
{
    public class Suitcase : Interactable
    {
        [SerializeField] private List<SuitcaseSection> _sections = new();

        public IReadOnlyList<SuitcaseSection> Sections => _sections;
    }
}