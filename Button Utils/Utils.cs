using System;
using UnityEngine;
using System.Linq;
using UnhollowerRuntimeLib;
using Il2CppSystem.Reflection;
using MelonLoader;

namespace GameObjectBegone.APi.Utils
{
    public class QMStuff
    {
        private static BoxCollider _quickMenuBackgroundReference;
        private static GameObject _singleButtonReference;
        private static GameObject _toggleButtonReference;
        private static GameObject _tabButtonReference;
        private static Transform _nestedButtonReference;
        private static QuickMenu _quickmenuInstance;
        private static VRCUiManager _vrcuimInstance;

        public static void Reset()
        {
            GetQuickMenuInstance().transform.Find("MicControls").gameObject.GetComponent<Canvas>().enabled = true;
        }

        public static BoxCollider GetQuickMenuBackground()
        {
            if (_quickMenuBackgroundReference == null)
                _quickMenuBackgroundReference = GetQuickMenuInstance().GetComponent<BoxCollider>();
            return _quickMenuBackgroundReference;
        }

        public static GameObject GetSingleButtonTemplate()
        {
            if (_singleButtonReference == null)
                _singleButtonReference = GetQuickMenuInstance().transform.Find("ShortcutMenu/WorldsButton").gameObject;
            return _singleButtonReference;
        }

        public static GameObject GetToggleButtonTemplate()
        {
            if (_toggleButtonReference == null)
                _toggleButtonReference = GetQuickMenuInstance().transform.Find("UserInteractMenu/BlockButton").gameObject;
            return _toggleButtonReference;
        }

        public static GameObject TabButtonTemplate()
        {
            if (_tabButtonReference == null)
                _tabButtonReference = GameObject.Find("/UserInterface/QuickMenu/QuickModeTabs/HomeTab");
            return _tabButtonReference;
        }

        public static Transform GetNestedMenuTemplate()
        {
            if (_nestedButtonReference == null)
                _nestedButtonReference = GetQuickMenuInstance().transform.Find("CameraMenu");
            return _nestedButtonReference;
        }

        public static QuickMenu GetQuickMenuInstance()
        {
            if (_quickmenuInstance == null)
                _quickmenuInstance = QuickMenu.prop_QuickMenu_0;
            return _quickmenuInstance;
        }
        public static VRCUiManager GetVRCUiMInstance()
        {
            if (_vrcuimInstance == null)
                _vrcuimInstance = VRCUiManager.prop_VRCUiManager_0;
            return _vrcuimInstance;
        }

        private static FieldInfo _currentPageGetter;
        private static GameObject _shortcutMenu;
        private static GameObject _userInteractMenu;

        public static void ShowQuickmenuPage(string pagename)
        {
            QuickMenu quickmenu = GetQuickMenuInstance();
            Transform pageTransform = quickmenu?.transform.Find(pagename);
            if (_currentPageGetter == null)
            {
                GameObject shortcutMenu = quickmenu.transform.Find("ShortcutMenu").gameObject;
                if (!shortcutMenu.activeInHierarchy)
                    shortcutMenu = quickmenu.transform.Find("UserInteractMenu").gameObject;


                FieldInfo[] fis = Il2CppType.Of<QuickMenu>().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Where((fi) => fi.FieldType == Il2CppType.Of<GameObject>()).ToArray();
                int count = 0;
                foreach (FieldInfo fi in fis)
                {
                    GameObject value = fi.GetValue(quickmenu)?.TryCast<GameObject>();
                    if (value == shortcutMenu && ++count == 2)
                    {
                        _currentPageGetter = fi;
                        break;
                    }
                }
                if (_currentPageGetter == null)
                     return;
            }

            _currentPageGetter.GetValue(quickmenu)?.Cast<GameObject>().SetActive(false);

            GetQuickMenuInstance().transform.Find("MicControls").gameObject.GetComponent<Canvas>().enabled = pagename == "ShortcutMenu";

            QuickMenuContextualDisplay quickmenuContextualDisplay = GetQuickMenuInstance().field_Private_QuickMenuContextualDisplay_0;
            quickmenuContextualDisplay.Method_Public_Void_QuickMenuContext_0(QuickMenuContextualDisplay.QuickMenuContext.NoSelection);

            pageTransform.gameObject.SetActive(true);

            _currentPageGetter.SetValue(quickmenu, pageTransform.gameObject);

            if (_shortcutMenu == null)
                _shortcutMenu = QuickMenu.prop_QuickMenu_0.transform.Find("ShortcutMenu")?.gameObject;

            if (_userInteractMenu == null)
                _userInteractMenu = QuickMenu.prop_QuickMenu_0.transform.Find("UserInteractMenu")?.gameObject;

            if (pagename == "ShortcutMenu")
            {
                SetIndex(0);
            }
            else if (pagename == "UserInteractMenu")
            {
                SetIndex(3);
            }
            else
            {
                SetIndex(-1);
                _shortcutMenu?.SetActive(false);
                _userInteractMenu?.SetActive(false);
            }
        }

        public static void SetIndex(int index)
        {
            GetQuickMenuInstance().field_Private_EnumNPublicSealedvaUnShEmUsEmNoCaMo_nUnique_0 = (QuickMenu.EnumNPublicSealedvaUnShEmUsEmNoCaMo_nUnique)index;
        }
    }
}