// "Wave SDK 
// © 2020 HTC Corporation. All Rights Reserved.
//
// Unless otherwise required by copyright law and practice,
// upon the execution of HTC SDK license agreement,
// HTC grants you access to and use of the Wave SDK(s).
// You shall fully comply with all of HTC’s SDK license agreement terms and
// conditions signed by you and all SDK and API requirements,
// specifications, and documentation provided by HTC to You."

using UnityEngine;
using UnityEngine.UI;
using Wave.Native;
using Wave.Essence.Events;
using Wave.Essence.Hand;

namespace Wave.Essence.InputModule.Demo
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Button))]
	sealed class ButtonHandGesture : MonoBehaviour
	{
		private Button m_Button = null;
		private Text m_ButtonText = null;

		void Start()
		{
			m_Button = gameObject.GetComponent<Button>();
			m_ButtonText = gameObject.GetComponentInChildren<Text>();
		}

		HandManager.GestureStatus hand_gesture_status = HandManager.GestureStatus.NotStart;
		void Update()
		{
			hand_gesture_status = HandManager.Instance.GetHandGestureStatus();
			if (m_ButtonText != null && m_Button != null)
			{
				if (hand_gesture_status == HandManager.GestureStatus.Available)
				{
					m_Button.interactable = true;
					m_ButtonText.text = "Disable Hand Gesture";
				}
				else if (
				  hand_gesture_status == HandManager.GestureStatus.NotStart ||
				  hand_gesture_status == HandManager.GestureStatus.StartFailure)
				{
					m_Button.interactable = true;
					m_ButtonText.text = "Enable Hand Gesture";
				}
				else if (hand_gesture_status == HandManager.GestureStatus.NoSupport)
				{
					m_Button.interactable = false;
					m_ButtonText.text = "Not Support Gesture";
				}
				else
				{
					m_Button.interactable = false;
					m_ButtonText.text = "Processing Gesture";
				}
			}
		}

		void OnEnable()
		{
			GeneralEvent.Listen(HandManager.HAND_GESTURE_STATUS, OnGestureStatus);
		}

		void OnDisable()
		{
			GeneralEvent.Remove(HandManager.HAND_GESTURE_STATUS, OnGestureStatus);
		}

		private void OnGestureStatus(params object[] args)
		{
			HandManager.GestureStatus status = (HandManager.GestureStatus)args[0];
			Log.d("ButtonHandGesture", "Hand gesture status: " + status, true);
		}

		public void EnableHandGesture()
		{
			if (hand_gesture_status == HandManager.GestureStatus.Available)
				HandManager.Instance.GestureOptions.Enable = false;
			else
				HandManager.Instance.GestureOptions.Enable = true;
		}
	}
}
