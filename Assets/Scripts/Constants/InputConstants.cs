using UnityEngine;

namespace Assets.Scripts.Constants
{
    public static class InputConstants
    {
        public static bool SelectPressed => Input.GetMouseButtonDown(0);
        public static bool SelectReleased => Input.GetMouseButtonUp(0);

        public const float LongPress = 0.35f;
    }
}