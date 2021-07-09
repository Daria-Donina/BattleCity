using Assets.Scripts.Enemy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
	/// <summary>
	/// Class implementing events that change counters texts.
	/// </summary>
	[Serializable]
	public class CounterTextEvent : UnityEvent<int> { }

	/// <summary>
	/// Class implementing counter text changing logic.
	/// </summary>
	[RequireComponent(typeof(Text))]
	public class CounterText : MonoBehaviour
	{
		private Text _text;
		private string _defaultText;

		private void Awake()
		{
			_text = GetComponent<Text>();
			_defaultText = _text.text;
		}

		public void ChangeText(int count)
		{
			_text.text = _defaultText + count.ToString();
		}
	}
}
