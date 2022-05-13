using System;
using System.Collections.Generic;
using System.Linq;
using Il2CppSystem.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Core.Styles;
using VRC.UI.Elements;
using VRC.UI.Elements.Menus;
using VRC.UI.Elements.Tooltips;

namespace Xero.Utils
{
	public class MenuPage
	{
		public MenuPage(string menuName, string pageTitle, bool root = true, bool backButton = true, bool extButton = false, Action extButtonAction = null, string extButtonTooltip = "", Sprite extButtonSprite = null, bool preserveColor = false)
		{
			gameObject = UnityEngine.Object.Instantiate<GameObject>(ButtonAPI.menuPageBase, ButtonAPI.menuPageBase.transform.parent);
			gameObject.name = "Menu_" + menuName;
			gameObject.transform.SetSiblingIndex(5);
			gameObject.SetActive(false);
			UnityEngine.Object.DestroyImmediate(gameObject.GetComponent<MonoBehaviourPublicBoVoBoScVoLoIEScLoStUnique>());
			page = gameObject.AddComponent<UIPage>();
			page.field_Public_String_0 = menuName;
			page.field_Private_Boolean_1 = true;
			page.field_Protected_MenuStateController_0 = ButtonAPI.GetMenuStateControllerInstance();
			page.field_Private_List_1_UIPage_0 = new Il2CppSystem.Collections.Generic.List<UIPage>();
			page.field_Private_List_1_UIPage_0.Add(page);
			ButtonAPI.GetMenuStateControllerInstance().field_Private_Dictionary_2_String_UIPage_0.Add(menuName, page);
			if (root)
			{
				System.Collections.Generic.List<UIPage> list = ButtonAPI.GetMenuStateControllerInstance().field_Public_ArrayOf_UIPage_0.ToList<UIPage>();
				list.Add(page);
				ButtonAPI.GetMenuStateControllerInstance().field_Public_ArrayOf_UIPage_0 = list.ToArray();
			}
			gameObject.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup").DestroyChildren();
			menuContents = gameObject.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup");
			menuContents.GetComponent<VerticalLayoutGroup>().childControlHeight = false;
			pageTitleText = gameObject.GetComponentInChildren<TextMeshProUGUI>(true);
			pageTitleText.text = pageTitle;
			isRoot = root;
			backButtonGameObject = gameObject.transform.GetChild(0).Find("LeftItemContainer/Button_Back").gameObject;
			extButtonGameObject = gameObject.transform.GetChild(0).Find("RightItemContainer/Button_QM_Expand").gameObject;
			backButtonGameObject.SetActive(backButton);
			backButtonGameObject.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
			backButtonGameObject.GetComponentInChildren<Button>().onClick.AddListener((Action)delegate
			{
				if (isRoot)
				{
					ButtonAPI.GetMenuStateControllerInstance().Method_Public_Void_String_Boolean_0("QuickMenuDashboard");
				}
				else
				{
					page.Method_Protected_Virtual_New_Void_0();
				}
			});
			extButtonGameObject.SetActive(extButton);
			extButtonGameObject.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
			extButtonGameObject.GetComponentInChildren<Button>().onClick.AddListener(extButtonAction);
			extButtonGameObject.GetComponentInChildren<UiTooltip>().field_Public_String_0 = extButtonTooltip;
			if (extButtonSprite != null)
			{
				extButtonGameObject.GetComponentInChildren<Image>().sprite = extButtonSprite;
				extButtonGameObject.GetComponentInChildren<Image>().overrideSprite = extButtonSprite;
				if (preserveColor)
				{
					extButtonGameObject.GetComponentInChildren<Image>().color = Color.white;
					extButtonGameObject.GetComponentInChildren<StyleElement>(true).enabled = false;
				}
			}
			preserveColor = preserveColor;
			menuMask = menuContents.parent.gameObject.GetComponent<RectMask2D>();
			menuMask.enabled = true;
			gameObject.transform.Find("ScrollRect").GetComponent<ScrollRect>().enabled = true;
			gameObject.transform.Find("ScrollRect").GetComponent<ScrollRect>().verticalScrollbar = gameObject.transform.Find("ScrollRect/Scrollbar").GetComponent<Scrollbar>();
			gameObject.transform.Find("ScrollRect").GetComponent<ScrollRect>().verticalScrollbarVisibility = ScrollRect.ScrollbarVisibility.AutoHide;
		}

		public void AddExtButton(Action onClick, string tooltip, Sprite icon)
		{
			GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(extButtonGameObject, extButtonGameObject.transform.parent);
			gameObject.SetActive(true);
			gameObject.GetComponentInChildren<Button>().onClick = new Button.ButtonClickedEvent();
			gameObject.GetComponentInChildren<Button>().onClick.AddListener(onClick);
			gameObject.GetComponentInChildren<Image>().sprite = icon;
			gameObject.GetComponentInChildren<Image>().overrideSprite = icon;
			gameObject.GetComponentInChildren<UiTooltip>().field_Public_String_0 = tooltip;
		}

		public void OpenMenu()
		{
			if (isRoot)
			{
				ButtonAPI.GetMenuStateControllerInstance().Method_Public_Void_String_UIContext_Boolean_0(page.field_Public_String_0, null, false);
				return;
			}
			ButtonAPI.GetMenuStateControllerInstance().Method_Public_Void_String_UIContext_Boolean_0(page.field_Public_String_0, null, false);
		}

		public void CloseMenu()
		{
			page.Method_Public_Virtual_New_Void_0();
		}


		private readonly UIPage page;


		private readonly GameObject gameObject;


		public readonly Transform menuContents;


		private readonly TextMeshProUGUI pageTitleText;

		private readonly bool isRoot;

		
		private readonly GameObject backButtonGameObject;

		private readonly GameObject extButtonGameObject;
		public readonly RectMask2D menuMask;
	}
}
