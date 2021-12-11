using UnityEngine;
using UnityEngine.UI;

namespace nakashun
{
    public class DebugLogController : MonoBehaviour
    {
        [SerializeField]
        private Text _rightTapText = null;

        [SerializeField]
        private Text _leftTapText = null;

        [SerializeField]
        private Text _rightSwipeText = null;

        [SerializeField]
        private Text _leftSwipeText = null;

        [SerializeField]
        private Text _upSwipeText = null;

        [SerializeField]
        private Text _downSwipeText = null;

        [SerializeField]
        private InputHandler _inputHandler;
        private void Start()
        {
            _inputHandler.OnTapLeftHandler += OnTapLeft;
            _inputHandler.OnTapRightHandler += OnTapRight;
            _inputHandler.OnTapMenuHandler += OnTapMenu;
            _inputHandler.OnSwipeRightHandler += OnSwipeRight;
            _inputHandler.OnSwipeLeftHandler += OnSwipeLeft;
            _inputHandler.OnSwipeUpHandler += OnSwipeUp;
            _inputHandler.OnSwipeDownHandler += OnSwipeDown;
        }

        private void Update()
        {
        }

        private void OnTapMenu()
        {
        }

        private void OnTapRight()
        {
            _rightTapText.text = "right tap input";
            Invoke("ResetText", 1);
        }

        private void OnTapLeft()
        {
            _leftTapText.text = "left tap input";
            Invoke("ResetText", 1);
        }
        private void OnSwipeRight()
        {
            _rightSwipeText.text = "swipe right input";
            Invoke("ResetText", 1);
        }
        private void OnSwipeLeft()
        {
            _leftSwipeText.text = "swipe left input";
            Invoke("ResetText", 1);
        }
        private void OnSwipeUp()
        {
            _upSwipeText.text = "swipe up input";
            Invoke("ResetText", 1);
        }
        private void OnSwipeDown()
        {
            _downSwipeText.text = "swipe down input";
            Invoke("ResetText", 1);
        }

        private void ResetText()
        {
            _rightTapText.text = "no input";
            _leftTapText.text = "no input";
            _rightSwipeText.text = "no input";
            _leftSwipeText.text = "no input";
            _upSwipeText.text = "no input";
            _downSwipeText.text = "no input";
        }

    }

}
