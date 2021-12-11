using UnityEngine;
using UnityEngine.XR;

namespace nakashun
{
    public class InputHandler : MonoBehaviour
    {
        public delegate void OnTapLeftDelegate();
        public event OnTapLeftDelegate OnTapLeftHandler;

        public delegate void OnTapRightDelegate();
        public event OnTapRightDelegate OnTapRightHandler;

        public delegate void OnTapMenuDelegate();
        public event OnTapMenuDelegate OnTapMenuHandler;

        public delegate void OnSwipeRightDelegate();
        public event OnSwipeRightDelegate OnSwipeRightHandler;

        public delegate void OnSwipeLeftDelegate();
        public event OnSwipeLeftDelegate OnSwipeLeftHandler;

        public delegate void OnSwipeUpDelegate();
        public event OnSwipeUpDelegate OnSwipeUpHandler;

        public delegate void OnSwipeDownDelegate();
        public event OnSwipeDownDelegate OnSwipeDownHandler;


        void Update()
        {
            InputDevice inputDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

            if (inputDevice.isValid)
            {
                bool isPrimary2DAxisClicked;
                if (inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxisClick, out isPrimary2DAxisClicked) && isPrimary2DAxisClicked)
                {
                    OnTapLeftHandler?.Invoke();
                }

                bool isTrigger;
                if (inputDevice.TryGetFeatureValue(CommonUsages.triggerButton, out isTrigger) && isTrigger)
                {
                    OnTapRightHandler?.Invoke();
                }

                bool isMenu;
                if (inputDevice.TryGetFeatureValue(CommonUsages.menuButton, out isMenu) && isMenu)
                {
                    OnTapMenuHandler?.Invoke();
                }

                if (inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
                {
                    if (position.x > 1.2f)
                    {
                        position = Vector2.zero;
                        OnSwipeRightHandler?.Invoke();
                    }
                    if (position.x < -1.2f)
                    {
                        position = Vector2.zero;
                        OnSwipeLeftHandler?.Invoke();
                    }
                    if (position.y > 1.2f)
                    {
                        position = Vector2.zero;
                        OnSwipeUpHandler?.Invoke();
                    }
                    if (position.y < -1.2f)
                    {
                        position = Vector2.zero;
                        OnSwipeDownHandler?.Invoke();
                    }
                }
            }
        }
    }
}
