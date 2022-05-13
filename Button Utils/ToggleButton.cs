using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements.Controls;
using VRC.UI.Elements.Tooltips;

namespace Xero.Utils
{
    public class ToggleButton
    {
        public ToggleButton(Transform parent, string text, Action<bool> stateChanged, string offTooltip, string onTooltip, Sprite icon = null)
        {
            ToggleButton f = this;
            this.gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.toggleButtonBase, parent);
            this.buttonText = this.gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
            this.buttonText.text = text;
            this.buttonToggle = this.gameObject.GetComponentInChildren<Toggle>(true);
            this.buttonToggle.onValueChanged = new Toggle.ToggleEvent();
            this.buttonToggle.isOn = false;
            buttonToggle.onValueChanged.AddListener((Action<bool>)delegate (bool val)
            {
                if (f._stateInvoke)
                {
                    stateChanged(val);
                }

            });


            this.toggleTooltip = this.gameObject.GetComponentInChildren<UiToggleTooltip>(true);
            this.toggleTooltip.field_Public_String_0 = onTooltip;
            this.toggleTooltip.field_Public_String_1 = offTooltip;
            this.toggleTooltip.field_Private_Boolean_0 = true;
            this.buttonImage = this.gameObject.transform.Find("Icon_On").GetComponentInChildren<Image>(true);
            if (icon != null)
            {
                this.buttonImage.sprite = icon;
                this.buttonImage.overrideSprite = icon;
                return;
            }
            this.buttonImage.sprite = ButtonAPI.onIconSprite;
            this.buttonImage.overrideSprite = ButtonAPI.onIconSprite;
        }


        public ToggleButton(MenuPage pge, string text, Action<bool> stateChanged, string offTooltip, string onTooltip, Sprite icon = null) : this(pge.menuContents, text, stateChanged, offTooltip, onTooltip, icon)
        {
        }

        public ToggleButton(ButtonGroup grp, string text, Action<bool> stateChanged, string offTooltip, string onTooltip, Sprite icon = null) : this(grp.gameObject.transform, text, stateChanged, offTooltip, onTooltip, icon)
        {
        }

        public void SetAction(Action<bool> newAction)
        {
            this.buttonToggle.onValueChanged = new Toggle.ToggleEvent();
            this.buttonToggle.onValueChanged.AddListener((Action<bool>)delegate (bool val)
            {
                newAction(val);
            });
        }


        public void SetText(string newText)
        {
            this.buttonText.text = newText;
        }


        public void SetTooltip(string newOffTooltip, string newOnTooltip)
        {
            this.toggleTooltip.field_Public_String_0 = newOnTooltip;
            this.toggleTooltip.field_Public_String_1 = newOffTooltip;
        }


        public void SetIcon(Sprite newIcon)
        {
            if (newIcon == null)
            {
                this.buttonImage.gameObject.SetActive(false);
                return;
            }
            this.buttonImage.sprite = newIcon;
            this.buttonImage.overrideSprite = newIcon;
            this.buttonImage.gameObject.SetActive(true);
        }


        public void SetToggleState(bool newState, bool invoke = false)
        {
            this._stateInvoke = false;
            this.buttonToggle.isOn = newState;
            this.buttonToggle.onValueChanged.Invoke(newState);
            this._stateInvoke = true;
            if (invoke)
            {
                this.buttonToggle.onValueChanged.Invoke(newState);
            }
        }

        public void SetActive(bool state)
        {
            this.gameObject.SetActive(state);
        }


        private readonly TextMeshProUGUI buttonText;


        private readonly Image buttonImage;


        private readonly Toggle buttonToggle;

        private readonly UiToggleTooltip toggleTooltip;


        public readonly GameObject gameObject;

        private bool _stateInvoke = true;
    }
}
