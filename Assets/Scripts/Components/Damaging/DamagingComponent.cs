using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Components.Damaging
{
	public abstract class DamagingComponent : MonoBehaviour
	{
		public abstract void OnAttack();
	}
}
