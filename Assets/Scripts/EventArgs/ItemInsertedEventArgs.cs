using Assets.Scripts.Pickables;

namespace Assets.Scripts.EventArgs
{
    public class ItemInsertedEventArgs : ItemUpdatedEventArgs
    {
        public ItemInsertedEventArgs(Pickable pickable)
            : base(pickable, true) { }
    }
}