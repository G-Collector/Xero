using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements.Tooltips;

namespace Xero.Utils
{

	public class SimpleSingleButton
	{
		public SimpleSingleButton(Transform parent, string text, Action click, string tooltip)
		{
			this.gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.singleButtonBase, parent);
			this.buttonText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
			this.buttonText.text = text;
			this.buttonText.fontSize = 28f;
			this.buttonText.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(0f, -25f, 0f);
			this.buttonButton = this.gameObject.GetComponentInChildren<Button>(true);
			this.buttonButton.onClick = new Button.ButtonClickedEvent();
			this.buttonButton.onClick.AddListener(click);
			this.buttonTooltip = this.gameObject.GetComponentInChildren<UiTooltip>(true);
			this.buttonTooltip.field_Public_String_0 = tooltip;
			UnityEngine.Object.Destroy(this.gameObject.transform.Find("Icon").gameObject);
			UnityEngine.Object.Destroy(this.gameObject.transform.Find("Icon_Secondary").gameObject);
			this.buttonText.color = new Color(0.9f, 0.9f, 0.9f);
		}

		public SimpleSingleButton(MenuPage pge, string text, Action click, string tooltip) : this(pge.menuContents, text, click, tooltip)
		{
		}

		public SimpleSingleButton(ButtonGroup grp, string text, Action click, string tooltip) : this(grp.gameObject.transform, text, click, tooltip)
		{
		}
		public void SetAction(Action newAction)
		{
			this.buttonButton.onClick = new Button.ButtonClickedEvent();
			this.buttonButton.onClick.AddListener(newAction);
		}

	
		public void SetText(string newText)
		{
			this.buttonText.text = newText;
		}

		
		public void SetTooltip(string newTooltip)
		{
			this.buttonTooltip.field_Public_String_0 = newTooltip;
		}

	
		public void SetInteractable(bool val)
		{
			this.buttonButton.interactable = val;
		}

	
		public void SetActive(bool state)
		{
			this.gameObject.SetActive(state);
		}

	
		private readonly TextMeshProUGUI buttonText;

	
		private readonly Button buttonButton;

		private readonly UiTooltip buttonTooltip;

		
		public readonly GameObject gameObject;
	}
}
