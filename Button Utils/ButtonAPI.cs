using System;
using System.Collections;
using System.Linq;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using VRC.UI.Elements;

namespace Xero.Utils
{
	public class ButtonAPI : MelonMod
	{
		public void OnUiManagerInit()
		{
			MelonCoroutines.Start(ButtonAPI.WaitForQMClone());
		}
		internal static QuickMenu GetQuickMenuInstance()
		{
			return Resources.FindObjectsOfTypeAll<QuickMenu>().FirstOrDefault<QuickMenu>();
		}

		internal static MenuStateController GetMenuStateControllerInstance()
		{
			return Resources.FindObjectsOfTypeAll<QuickMenu>().FirstOrDefault<QuickMenu>().gameObject.GetComponent<MenuStateController>();
		}

		public static IEnumerator WaitForQMClone()
		{
			while (GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/") == null)
			{
				yield return new WaitForEndOfFrame();
			}
			ButtonAPI.singleButtonBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions/Button_Respawn").gameObject;
			ButtonAPI.textButtonBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_Debug/Button_Build").gameObject;
			ButtonAPI.toggleButtonBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Settings/Panel_QM_ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UI_Elements_Row_1/Button_ToggleQMInfo").gameObject;
			ButtonAPI.buttonGroupBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_QuickActions").gameObject;
			ButtonAPI.buttonGroupHeaderBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard/ScrollRect/Viewport/VerticalLayoutGroup/Header_QuickActions").gameObject;
			ButtonAPI.menuPageBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").gameObject;
			ButtonAPI.menuTabBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings").gameObject;
			ButtonAPI.sliderBase = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_AudioSettings/Content/Audio/VolumeSlider_Master").gameObject;
			ButtonAPI.onIconSprite = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Notifications/Panel_NoNotifications_Message/Icon").GetComponent<Image>().sprite;
			ButtonAPI.plusIconSprite = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_WorldActions/Button_FavoriteWorld/Icon").GetComponent<Image>().sprite;
			ButtonAPI.xIconSprite = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Here/ScrollRect/Viewport/VerticalLayoutGroup/Buttons_WorldActions/Button_FavoriteWorld/Icon_Secondary").GetComponent<Image>().sprite;
			yield break;
		}

		internal static GameObject singleButtonBase;
		internal static GameObject textButtonBase;
		internal static GameObject toggleButtonBase;
		internal static GameObject buttonGroupBase;
		internal static GameObject buttonGroupHeaderBase;
		internal static GameObject menuPageBase;
		internal static GameObject menuTabBase;
		internal static GameObject sliderBase;
		internal static Sprite onIconSprite;
		internal static Sprite plusIconSprite;
		internal static Sprite xIconSprite;
	}
}
