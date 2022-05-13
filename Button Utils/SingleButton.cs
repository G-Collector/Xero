using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements.Tooltips;

namespace Xero.Utils
{
	public class SingleButton
	{
		public SingleButton(Transform parent, string text, Action click, string tooltip, Sprite icon = null, bool preserveColor = false)
		{
			this.gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.singleButtonBase, parent);
			this.buttonText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
			this.buttonText.text = text;
			this.buttonButton = this.gameObject.GetComponentInChildren<Button>(true);
			this.buttonButton.onClick = new Button.ButtonClickedEvent();
			this.buttonButton.onClick.AddListener(click);
			this.buttonTooltip = this.gameObject.GetComponentInChildren<UiTooltip>(true);
			this.buttonTooltip.field_Public_String_0 = tooltip;
			this.buttonImage = this.gameObject.transform.Find("Icon").GetComponentInChildren<Image>(true);
			if (icon != null)
			{
				this.buttonImage.sprite = icon;
				this.buttonImage.overrideSprite = icon;
				this.buttonImage.gameObject.SetActive(true);
				if (preserveColor)
				{
					this.buttonImage.color = Color.white;
					this.buttonImage.GetComponent<StyleElement>().enabled = false;
					return;
				}
			}
			else
			{
				this.buttonImage.gameObject.SetActive(false);
			}
		}

		public SingleButton(MenuPage pge, string text, Action click, string tooltip, Sprite icon = null, bool preserveColor = false) : this(pge.menuContents, text, click, tooltip, icon, preserveColor)
		{
		}


		public SingleButton(ButtonGroup grp, string text, Action click, string tooltip, Sprite icon = null, bool preserveColor = false) : this(grp.gameObject.transform, text, click, tooltip, icon, preserveColor)
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


		public void SetIcon(Sprite newIcon, bool preserveColor = false)
		{
			if (newIcon == null)
			{
				this.buttonImage.gameObject.SetActive(false);
				return;
			}
			this.buttonImage.sprite = newIcon;
			this.buttonImage.overrideSprite = newIcon;
			this.buttonImage.gameObject.SetActive(true);
			if (preserveColor)
			{
				this.buttonImage.color = Color.white;
			}
		}


		public void SetIconColor(Color color)
		{
			this.buttonImage.color = color;
			this.buttonImage.GetComponent<StyleElement>().enabled = false;
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

		
		private readonly Image buttonImage;

		
		private readonly Button buttonButton;

	
		private readonly UiTooltip buttonTooltip;

		public readonly GameObject gameObject;
	}
}
