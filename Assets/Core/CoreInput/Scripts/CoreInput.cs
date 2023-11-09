using UnityEngine;

namespace ArrowHero.Core
{
    public class CoreInput : MonoBehaviour
    {
        public Joystick Joystick => _joyStick;
        [SerializeField]
        private Joystick _joyStick;
    }
}