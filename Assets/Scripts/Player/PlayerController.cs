using Assets.Scripts.Components.Shooting;
using Assets.Scripts.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts.Player
{
	/// <summary>
	/// Class implementing Player moving and shooting logic.
	/// </summary>
	public class PlayerController : MovingController
	{
		/// <summary>
		/// Event invoking when shooting button is pressed.
		/// </summary>
		public ShootingEvent ShootButtonPressed = new ShootingEvent();

		public override float X { get; protected set; }
		public override float Y { get; protected set; }

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
