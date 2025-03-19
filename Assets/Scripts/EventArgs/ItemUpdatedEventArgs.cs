using Assets.Scripts.Pickables;

namespace Assets.Scripts.EventArgs
{
    public class ItemUpdatedEventArgs : System.EventArgs
    {
        public Pickable Pickable { get; }

        public bool IsSet { get; }

        public ItemUpdatedEventArgs(Pickable pickable, bool isSet)
        {
            Pickable = pickable;
            IsSet = isSet;
        }
    }
}