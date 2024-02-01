using UnityEngine;

namespace Arkanoid
{
	public class CameraMover : MonoBehaviour
	{
		private float speed;
		private ControlMethod controlMethod;

		void Update()
		{
			float xInput = 0f;
			float zInput = 0f;

			switch (controlMethod)
			{
				case ControlMethod.MethodOne:
					#if UNITY_EDITOR
					zInput = Input.GetAxis("Method_One_Horizontal_EDITOR");
					xInput = Input.GetAxis("Method_One_Vertical_EDITOR");
					#elif UNITY_STANDALONE_WIN
					zInput = Input.GetAxis("Method_One_Horizontal_WIN");
					xInput = Input.GetAxis("Method_One_Vertical_WIN");
					#endif
					break;
				case ControlMethod.MethodTwo:
					#if UNITY_EDITOR
					xInput = Input.GetAxis("Method_Two_Horizontal_EDITOR");
					zInput = Input.GetAxis("Method_Two_Vertical_EDITOR");
					#elif UNITY_STANDALONE_WIN
					xInput = Input.GetAxis("Method_Two_Horizontal_WIN");
					zInput = Input.GetAxis("Method_Two_Vertical_WIN");
					#endif
					break;
			}

			Move(xInput, zInput);
		}

		void Move(float x, float z)
		{
			transform.position += new Vector3(x, 0, z) * speed * Time.deltaTime;
		}

		public void SetSpeed(float speed)
		{
			this.speed = speed;
		}

		public void SetControlMethod(ControlMethod method)
		{
			controlMethod = method;
		}
	}

}
