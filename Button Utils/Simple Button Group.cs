using System;
using UnityEngine;
using UnityEngine.UI;

namespace Xero.Utils
{

	public class SimpleButtonGroup
	{

		public SimpleButtonGroup(Transform parent, string text)
		{
			this.gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.buttonGroupBase, parent);
			this.gameObject.transform.DestroyChildren();
			this.parentMenuMask = parent.parent.GetComponent<RectMask2D>();
		}


		public SimpleButtonGroup(MenuPage pge, string text) : this(pge.menuContents, text)
		{
		}

		
		public void Destroy()
		{
			UnityEngine.Object.Destroy(this.gameObject);
		}

		public void SetActive(bool state)
		{
			this.gameObject.SetActive(state);
		}

		public readonly GameObject gameObject;

	
		public readonly RectMask2D parentMenuMask;
	}
}
