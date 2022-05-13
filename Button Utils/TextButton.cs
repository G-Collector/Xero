using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements.Tooltips;

namespace Xero.Utils
{
	// Token: 0x02000027 RID: 39
	public class TextButton
	{
		// Token: 0x06000126 RID: 294 RVA: 0x00006C24 File Offset: 0x00004E24
		public TextButton(Transform parent, string text, Action click, string tooltip, string bigText)
		{
			this.gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.singleButtonBase, parent);
			this.buttonText = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>(true).First<TextMeshProUGUI>();
			this.buttonText.text = text;
			this.buttonTextBig = this.gameObject.GetComponentsInChildren<TextMeshProUGUI>(true).Last<TextMeshProUGUI>();
			this.buttonTextBig.text = bigText;
			this.buttonButton = this.gameObject.GetComponentInChildren<Button>(true);
			this.buttonButton.onClick = new Button.ButtonClickedEvent();
			this.buttonButton.onClick.AddListener(click);
			this.buttonTooltip = this.gameObject.GetComponentInChildren<UiTooltip>(true);
			this.buttonTooltip.field_Public_String_0 = tooltip;
		}

		// Token: 0x06000127 RID: 295 RVA: 0x00006CE6 File Offset: 0x00004EE6
		public TextButton(MenuPage pge, string text, Action click, string tooltip, string bigText) : this(pge.menuContents, text, click, tooltip, bigText)
		{
		}

		// Token: 0x06000128 RID: 296 RVA: 0x00006CFA File Offset: 0x00004EFA
		public TextButton(ButtonGroup grp, string text, Action click, string tooltip, string bigText) : this(grp.gameObject.transform, text, click, tooltip, bigText)
		{
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00006D13 File Offset: 0x00004F13
		public void SetAction(Action newAction)
		{
			this.buttonButton.onClick = new Button.ButtonClickedEvent();
			this.buttonButton.onClick.AddListener(newAction);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x00006D3B File Offset: 0x00004F3B
		public void SetText(string newText)
		{
			this.buttonText.text = newText;
		}

		// Token: 0x0600012B RID: 299 RVA: 0x00006D49 File Offset: 0x00004F49
		public void SetTooltip(string newTooltip)
		{
			this.buttonTooltip.field_Public_String_0 = newTooltip;
		}

		// Token: 0x0600012C RID: 300 RVA: 0x00006D57 File Offset: 0x00004F57
		public void SetBigText(string newText)
		{
			this.buttonTextBig.text = newText;
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00006D65 File Offset: 0x00004F65
		public void SetInteractable(bool val)
		{
			this.buttonButton.interactable = val;
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00006D73 File Offset: 0x00004F73
		public void SetActive(bool state)
		{
			this.gameObject.SetActive(state);
		}

		// Token: 0x04000070 RID: 112
		private readonly TextMeshProUGUI buttonText;

		// Token: 0x04000071 RID: 113
		private readonly TextMeshProUGUI buttonTextBig;

		// Token: 0x04000072 RID: 114
		private readonly Button buttonButton;

		// Token: 0x04000073 RID: 115
		private readonly UiTooltip buttonTooltip;

		// Token: 0x04000074 RID: 116
		public readonly GameObject gameObject;
	}
}
