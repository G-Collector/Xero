using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Xero.Utils
{
	public class ButtonGroup
	{
		public ButtonGroup(Transform parent, string text)
		{
			headerGameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.buttonGroupHeaderBase, parent);
			headerText = headerGameObject.GetComponentInChildren<TextMeshProUGUI>(true);
			headerText.text = text;
			gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.buttonGroupBase, parent);
			gameObject.transform.DestroyChildren();
			parentMenuMask = parent.parent.GetComponent<RectMask2D>();
		}

		public ButtonGroup(MenuPage pge, string text) : this(pge.menuContents, text)
		{
		}

		public void SetText(string newText)
		{
			headerText.text = newText;
		}

		public void Destroy()
		{
			UnityEngine.Object.Destroy(headerText.gameObject);
			UnityEngine.Object.Destroy(gameObject);
		}
		public void SetActive(bool state)
		{
			if (headerGameObject != null)
			{
				headerGameObject.SetActive(state);
			}
			gameObject.SetActive(state);
		}

		private readonly TextMeshProUGUI headerText;
		public readonly GameObject gameObject;
		private readonly GameObject headerGameObject;
		public readonly RectMask2D parentMenuMask;
	}
}
