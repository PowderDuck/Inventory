using Assets.Scripts.Pickables;

namespace Assets.Scripts.EventArgs
{
    public class ItemRetrievedEventArgs : ItemUpdatedEventArgs
    {
        public ItemRetrievedEventArgs(Pickable pickable)
            : base(pickable, false) { }
    }
}