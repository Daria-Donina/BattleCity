using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Controllers.Type
{
	[Serializable]
	public class ShootingEvent : UnityEvent { }

	public class InputHandler : MovingController
	{
		public ShootingEvent ShootButtonPressed = new ShootingEvent();

		private void Update()
		{
			if (Input.GetButtonDown("Shoot"))
			{
				ShootButtonPressed.Invoke();
			}

			X = Input.GetAxisRaw("Horizontal");
			Y = Input.GetAxisRaw("Vertical");
		}
	}
}
