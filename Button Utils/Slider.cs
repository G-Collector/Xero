using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements.Tooltips;

namespace Xero.Utils
{
	public class Slides3
	{
		public Slides3(Transform parent, string text, Action<float> onSlidesAdjust, string tooltip, float maxValue = 100f, float defaultValue = 50f, bool floor = false, bool percent = true)
		{
			Slides3 random = this;
			this.gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.sliderBase, parent);
			this.sliderText = this.gameObject.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>(true);
			this.sliderText.text = text;
			this.sliderPercentText = this.gameObject.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>(true);
			this.sliderPercentText.text = "0" + (percent ? "%" : "");
			this.sliderSlides = this.gameObject.GetComponentInChildren<Slider>();
			this.sliderSlides.onValueChanged = new Slider.SliderEvent();
			this.sliderSlides.maxValue = maxValue;
			this.sliderSlides.value = defaultValue;
			sliderSlides.onValueChanged.AddListener((Action<float>)delegate (float val)
			{
				sliderPercentText.text = (_floor ? Mathf.Floor(val) : val) + (_percent ? "%" : "");
				onSlidesAdjust(val);
			});
			this.sliderTooltip = this.gameObject.GetComponentInChildren<UiTooltip>(true);
			this.sliderTooltip.field_Public_String_0 = tooltip;
			this._floor = floor;
			this._percent = percent;
		}


		public Slides3(MenuPage pge, string text, Action<float> onSlidesAdjust, string tooltip, float maxValue = 100f, float defaultValue = 50f, bool floor = false, bool percent = true) : this(pge.menuContents, text, onSlidesAdjust, tooltip, maxValue, defaultValue, floor, percent)
		{
		}


		public Slides3(ButtonGroup grp, string text, Action<float> onSlidesAdjust, string tooltip, float maxValue = 100f, float defaultValue = 50f, bool floor = false, bool percent = true) : this(grp.gameObject.transform, text, onSlidesAdjust, tooltip, maxValue, defaultValue, floor, percent)
		{
		}


		public void SetAction(Action<float> newAction)
		{
			this.sliderSlides.onValueChanged = new Slider.SliderEvent();
			sliderSlides.onValueChanged.AddListener((Action<float>)delegate (float val)
			{
				sliderPercentText.text = (_floor ? Mathf.Floor(val) : val) + (_percent ? "%" : "");
				newAction(val);
			});
		}


		public void SetText(string newText)
		{
			this.sliderText.text = newText;
		}


		public void SetTooltip(string newTooltip)
		{
			this.sliderTooltip.field_Public_String_0 = newTooltip;
		}


		public void SetInteractable(bool val)
		{
			this.sliderSlides.interactable = val;
		}

		public void SetActive(bool state)
		{
			this.sliderSlides.gameObject.SetActive(state);
			this.sliderTooltip.gameObject.SetActive(state);
			this.sliderPercentText.gameObject.SetActive(state);
		}

	
		public void SetValue(float newValue, bool invoke = false)
		{
			Slider.SliderEvent onValueChanged = this.sliderSlides.onValueChanged;
			this.sliderSlides.onValueChanged = new Slider.SliderEvent();
			this.sliderSlides.value = newValue;
			this.sliderSlides.onValueChanged = onValueChanged;
			if (invoke)
			{
				this.sliderSlides.onValueChanged.Invoke(newValue);
			}
		}

		
		private readonly TextMeshProUGUI sliderText;

		private readonly TextMeshProUGUI sliderPercentText;

	
		private readonly Slider sliderSlides;

		
		private readonly UiTooltip sliderTooltip;

		
		private bool _floor;

		
		private bool _percent;

		
		public readonly GameObject gameObject;
	}
}
