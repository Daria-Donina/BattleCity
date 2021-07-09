using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
	/// <summary>
	/// Controller that defines how the character moves.
	/// </summary>
	public abstract class MovingController : MonoBehaviour
	{
		/// <summary>
		/// X coordinate of the character.
		/// </summary>
		public abstract float X { get; protected set; }

		/// <summary>
		/// Y coordinate of the character.
		/// </summary>
		public abstract float Y { get; protected set; }
	}
}
