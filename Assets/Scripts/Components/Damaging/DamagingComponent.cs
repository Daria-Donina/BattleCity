using UnityEngine;

namespace Assets.Scripts.Components.Damaging
{
	/// <summary>
	/// Component that makes character vulnerable.
	/// </summary>
	public abstract class DamagingComponent : MonoBehaviour
	{
		/// <summary>
		/// An action to perform when character attacked.
		/// </summary>
		public abstract void OnAttack();
	}
}
