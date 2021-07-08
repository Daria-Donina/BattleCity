using Assets.Scripts.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Enemy
{
	public class EnemyController : MovingController
	{
		public override float X { get; protected set; }
		public override float Y { get; protected set; }

		
	}
}
