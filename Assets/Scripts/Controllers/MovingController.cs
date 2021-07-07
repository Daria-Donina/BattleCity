using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Controllers
{
	public abstract class MovingController : MonoBehaviour
	{
		public float X { get; protected set; }
		public float Y { get; protected set; }
	}
}
