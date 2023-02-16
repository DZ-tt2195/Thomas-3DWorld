using UnityEngine;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif
using UnityEngine.SceneManagement;

namespace StarterAssets
{
	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool restart;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;

#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
		public void OnMove(InputValue value)
		{
			MoveInput(value.Get<Vector2>());
		}

		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void OnJump(InputValue value)
		{
			if (Challenges.instance.oneJump)
			{
				if (Challenges.instance.jumpsLeft > 0)
				{
					Challenges.instance.jumpsLeft--;
					JumpInput(value.isPressed);
				}
			}
			else
				JumpInput(value.isPressed);
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

		public void OnRestart(InputValue value)
		{
			RestartInput(value.isPressed);
		}

		public void RestartInput(bool newRestartState)
		{
			restart = newRestartState;
		}

		public void OnHardRestart(InputValue value)
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

#endif

		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}

		private void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}
	}

}