using GameObjectReflection;
using MelonLoader;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;
using System.Linq;
using System.IO;
using Xero;
using Xero.Configer;

namespace GameObjectBegone
{
    class Colors
    {
        public static System.Collections.IEnumerator MenuColors()
        {
            if (Configuration.JSONConfig.FoxxString == "thisiswhyyourmommaleftyoubignosehavingasswhatyousaytomeboiimma99912932131243524328234234823429123249081234021834-02194320-49235812-352349-2-213")
            {
                //waitforme();
                Color cowaw = new Color(0.8307f, 0f, 2f, 1f);
                Color owange = new Color(1, 0.42f, 0.016f, 1.2f);
                ColorBlock colors = new ColorBlock
                {

                    colorMultiplier = 1f,
                    disabledColor = Color.grey,
                    highlightedColor = owange * 1.5f,
                    normalColor = cowaw / 1.5f,
                    pressedColor = new Color(1f, 1f, 1f, 1f),
                    fadeDuration = 0.1f,
                    selectedColor = cowaw / 1.5f
                };
                ColorBlock Purple = new ColorBlock
                {

                    colorMultiplier = 1f,
                    disabledColor = Color.grey,
                    highlightedColor = cowaw * 1.5f,
                    normalColor = cowaw / 1.5f,
                    pressedColor = new Color(1f, 1f, 1f, 1f),
                    fadeDuration = 0.1f,
                    selectedColor = cowaw / 1.5f
                };
                ColorBlock Orange = new ColorBlock
                {

                    colorMultiplier = 1f,
                    disabledColor = Color.grey,
                    highlightedColor = owange * 1.5f,
                    normalColor = owange / 1.5f,
                    pressedColor = new Color(1f, 1f, 1f, 1f),
                    fadeDuration = 0.1f,
                    selectedColor = owange / 1.5f
                };










                //GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendsGroup3/Title").GetComponent<Button>().colors = Purple;
                //GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendsGroup2/Title").GetComponent<Button>().colors = Orange;
                //GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendsGroup1/Title").GetComponent<Button>().colors = Purple;
                //GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/InRoom/Title").GetComponent<Button>().colors = Orange;
                //GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendRequests/Title").GetComponent<Button>().colors = Purple;
                //GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OnlineFriends/Title").GetComponent<Button>().colors = Orange;
                //GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OfflineFriends/Title").GetComponent<Button>().colors = Purple;
                //GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/Active/Title").GetComponent<Button>().colors = Orange;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendsGroup1/Title").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendsGroup2/Title").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendsGroup3/Title").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/Active/Button").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/UserProfileAndStatusSection/ViewProfileButton").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/SelfButtons/ChangeProfilePicButton").GetComponent<Button>().colors = Orange;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/UserProfileAndStatusSection/Status/EditStatusButton").GetComponent<Button>().colors = Orange;
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/ViewUserOnVRChatWebsiteButton").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/Buttons/RightSideButtons/RightUpperButtonColumn/EditStatusButton").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/Buttons/RightSideButtons/RightUpperButtonColumn/EditBioButton").GetComponent<Button>().colors = Orange;
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/Buttons/RightSideButtons/RightUpperButtonColumn/PlaylistsButton").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/User Panel/PanelHeaderBackground").GetComponent<Image>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/Worlds/CurrentWorld/TitleText").GetComponent<Text>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendRequests/Button/TitleText").GetComponent<Text>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OnlineFriends/Button/TitleText").GetComponent<Text>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/InnerDashRing").GetComponent<Image>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OnlineFriends/Button").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendsGroup1/Button").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/InRoom/Button/TitleText").GetComponent<Text>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendsGroup2/Button").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/Search/InputField").GetComponent<Button>().colors = Orange;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OfflineFriends/Button").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/FriendRequests/Button").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/InRoom/Button").GetComponent<Button>().colors = Purple;
                //GameObject.Find("").GetComponent<Button>().colors = Purple;
                //GameObject.Find("").GetComponent<Button>().colors = Orange;    
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/ButtonRight").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/ButtonMiddle").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/ButtonLeft").GetComponent<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/ArrowLeft").GetComponent<Image>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/ArrowRight").GetComponent<Image>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/Rectangle").GetComponent<Image>().color = new Color(.8f, 0.4f, 0.014f, .98f);
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/TitleText").GetComponent<Text>().color = new Color(1, 0.52f, 0.019f, 1f);
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/TitleText").GetComponent<Outline>().effectColor = new Color(1, 0.42f, 0.016f, 1f);
                GameObject.Find("UserInterface/MenuContent/Popups/StandardPopup/RingGlow").GetComponent<Image>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Backdrop/Backdrop/Background").GetComponent<Image>().color = new Color(1, 0.42f, 0.016f, .5f);
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Panel_Backdrop").GetComponent<Image>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Left").GetComponent<Image>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Right").GetComponent<Image>().color = new Color(0.4307f, 0f, 1f, 2f);
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/GoButton").GetComponent<Button>().colors = Orange;
                GameObject.Find("UserInterface/MenuContent/Popups/LoadingPopup/ButtonMiddle").GetComponent<Button>().colors = Purple;
                //GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/SitButton/Toggle_States_StandingEnabled/ON").GetComponent<Image>().m_Color = new Color(1, 0.42f, 0.016f, 1);
                //GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/SitButton/Toggle_States_StandingEnabled/OFF").GetComponent<Image>().m_Color = new Color(1, 0.42f, 0.016f, 1);
                GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/WorldsPageTab").GetComponentInChildren<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/AvatarPageTab").GetComponentInChildren<Button>().colors = Orange;
                GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SocialPageTab").GetComponentInChildren<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SettingsPageTab").GetComponentInChildren<Button>().colors = Orange;
                GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/SafetyPageTab").GetComponentInChildren<Button>().colors = Purple;
                GameObject.Find("UserInterface/MenuContent/Screens/Worlds/Current Room/ThisWorldButton").GetComponent<Button>().colors = Purple;

                try
                {
                    Colors.normalColorImage = new List<Image>();
                    GameObject gameObject = QMUtils.GetVRCUiMInstance().menuContent();
                    Colors.normalColorImage.Add(gameObject.transform.Find("Screens/Settings_Safety/_Description_SafetyLevel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Custom/ON").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_None/ON").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Normal/ON").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Maxiumum/ON").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/InputKeypadPopup/Rectangle/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/InputKeypadPopup/InputField").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/StandardPopupV2/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/StandardPopup/InnerDashRing").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/StandardPopup/RingGlow").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/UpdateStatusPopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/InputPopup/InputField").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/UpdateStatusPopup/Popup/InputFieldStatus").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/AdvancedSettingsPopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/AddToPlaylistPopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/BookmarkFriendPopup/Popup/Panel (2)").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/EditPlaylistPopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/PerformanceSettingsPopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/AlertPopup/Lighter").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/RoomInstancePopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/ReportWorldPopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/ReportUserPopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/AddToAvatarFavoritesPopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/SearchOptionsPopup/Popup/Panel (1)").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/SendInvitePopup/SendInviteMenu/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/RequestInvitePopup/RequestInviteMenu/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/ControllerBindingsPopup/Popup/Panel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/ChangeProfilePicPopup/Popup/PanelBackground").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Popups/ChangeProfilePicPopup/Popup/TitlePanel").GetComponent<Image>());
                    Colors.normalColorImage.Add(gameObject.transform.Find("Screens/UserInfo/User Panel/PanelHeaderBackground").GetComponent<Image>());
                    foreach (Transform transform in from x in gameObject.GetComponentsInChildren<Transform>(true)
                                                    where x.name.Contains("Panel_Header")
                                                    select x)
                    {
                        foreach (Image item in transform.GetComponentsInChildren<Image>())
                        {
                            Colors.normalColorImage.Add(item);
                        }
                    }
                    foreach (Transform transform2 in from x in gameObject.GetComponentsInChildren<Transform>(true)
                                                     where x.name.Contains("Handle")
                                                     select x)
                    {
                        foreach (Image item2 in transform2.GetComponentsInChildren<Image>())
                        {
                            Colors.normalColorImage.Add(item2);
                        }
                    }
                    try
                    {
                        Colors.normalColorImage.Add(gameObject.transform.Find("Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Panel_Backdrop").GetComponent<Image>());
                        Colors.normalColorImage.Add(gameObject.transform.Find("Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Left").GetComponent<Image>());
                        Colors.normalColorImage.Add(gameObject.transform.Find("Popups/LoadingPopup/ProgressPanel/Parent_Loading_Progress/Decoration_Right").GetComponent<Image>());
                        Colors.normalColorImage.Add(gameObject.transform.Find("Popups/LoadingPopup/MirroredElements/ProgressPanel (1)/Parent_Loading_Progress/Panel_Backdrop").GetComponent<Image>());
                        Colors.normalColorImage.Add(gameObject.transform.Find("Popups/LoadingPopup/MirroredElements/ProgressPanel (1)/Parent_Loading_Progress/Decoration_Left").GetComponent<Image>());
                        Colors.normalColorImage.Add(gameObject.transform.Find("Popups/LoadingPopup/MirroredElements/ProgressPanel (1)/Parent_Loading_Progress/Decoration_Right").GetComponent<Image>());
                    }
                    catch (Exception)
                    {
                        new Exception();
                    }
                }
                catch
                { MelonLogger.Error("Error in coloring!"); }

                if (Colors.dimmerColorImage == null || Colors.dimmerColorImage.Count == 0)
                {
                    Colors.dimmerColorImage = new List<Image>();
                    GameObject gameObject2 = QMUtils.GetVRCUiMInstance().menuContent();
                    Colors.dimmerColorImage.Add(gameObject2.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Custom/ON/TopPanel_SafetyLevel").GetComponent<Image>());
                    Colors.dimmerColorImage.Add(gameObject2.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_None/ON/TopPanel_SafetyLevel").GetComponent<Image>());
                    Colors.dimmerColorImage.Add(gameObject2.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Normal/ON/TopPanel_SafetyLevel").GetComponent<Image>());
                    Colors.dimmerColorImage.Add(gameObject2.transform.Find("Screens/Settings_Safety/_Buttons_SafetyLevel/Button_Maxiumum/ON/TopPanel_SafetyLevel").GetComponent<Image>());
                    Colors.dimmerColorImage.Add(gameObject2.transform.Find("Popups/ChangeProfilePicPopup/Popup/BorderImage").GetComponent<Image>());
                    foreach (Transform transform3 in from x in gameObject2.GetComponentsInChildren<Transform>(true)
                                                     where x.name.Contains("Fill")
                                                     select x)
                    {
                        foreach (Image item3 in transform3.GetComponentsInChildren<Image>())
                        {
                            Colors.dimmerColorImage.Add(item3);

                        }
                    }
                }
                if (Colors.normalColorText == null || Colors.normalColorText.Count == 0)
                {
                    Colors.normalColorText = new List<Text>();
                    GameObject gameObject4 = QMUtils.GetVRCUiMInstance().menuContent();
                    foreach (Text item5 in gameObject4.transform.Find("Popups/InputPopup/Keyboard/Keys").GetComponentsInChildren<Text>(true))
                    {
                        Colors.normalColorText.Add(item5);
                    }
                    foreach (Text item6 in gameObject4.transform.Find("Popups/InputKeypadPopup/Keyboard/Keys").GetComponentsInChildren<Text>(true))
                    {
                        Colors.normalColorText.Add(item6);
                    }
                }
                if (QMUtils.GetVRCUiMInstance().menuContent() != null)
                {
                    GameObject gameObject5 = QMUtils.GetVRCUiMInstance().menuContent();
                    try
                    {
                        Transform transform5 = gameObject5.transform.Find("Popups/InputPopup");
                        cowaw.a = 0.8f;
                        transform5.Find("Rectangle").GetComponent<Image>().color = cowaw;
                        cowaw.a = 0.5f;
                        cowaw.a = 0.8f;
                        transform5.Find("Rectangle/Panel").GetComponent<Image>().color = color;
                        cowaw.a = 0.5f;
                        Transform transform6 = gameObject5.transform.Find("Backdrop/Header/Tabs/ViewPort/Content/Search");
                        transform6.Find("SearchTitle").GetComponent<Text>().color = color;
                        transform6.Find("InputField").GetComponent<Image>().color = color;
                    }
                    catch (Exception)
                    {
                        MelonLogger.Msg("Coloring");
                        foreach (Image image in Colors.normalColorImage)
                        {
                            image.color = cowaw;
                        }
                        foreach (Image image2 in Colors.dimmerColorImage)
                        {
                            image2.color = cowaw;
                        }
                        MelonLogger.Msg("Coloring text elements...");
                        foreach (Text text in Colors.normalColorText)
                        {
                            text.color = cowaw;
                        }
                    }




                    //GameObject.Find("UserInterface/MenuContent/Screens/Worlds/Current Room/Text").GetComponent<Text>().color = new Color(.4307f, 0f, 1f, 2f);
                    ////GameObject.Find("UserInterface/MenuContent/Screens/Worlds/Vertical Scroll View/Viewport/Content/Hot/Button").GetComponent<Button>().colors = Purple;
                    ////GameObject.Find("UserInterface/MenuContent/Screens/Worlds/Vertical Scroll View/Viewport/Content/World Jam: Obstacle Course/Button").GetComponent<Button>().colors = Purple;
                    ////xero1 = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusMiniBanner").gameObject;
                    ////xero1 = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner").gameObject;
                    ////xero1 = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner/Panel").gameObject;
                    ////xero1 = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBannerCrest").gameObject;
                    ////Xero2 = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner").gameObject;
                    //GameObject.DestroyImmediate(Xero2);
                    //GameObject.Destroy(xero1);
                    //MelonLogger.Msg("Added MenuColors!!");

                    //color = new Color(0.4307f / 2.25f, 0 / 2.25f, 1 / 2.25f);
                    //Color2 = new Color32(153, 57, 255, 4);
                    //Color MouseBall = new Color();
                    //MouseColor = new Color(0.4307f, 0f, 1f, 1f);
                    ////MouseBall = GameObject.Find("_Application/CursorManager/BlueFireballMouse/Ball").GetComponentInChildren<ParticleSystem>().startColor = MouseColor;
                    ////MouseBall2 = GameObject.Find("_Application/CursorManager/BlueFireballMouse/Ball").GetComponentInChildren<ParticleSystem>().startColor;
                    //imageColor = DefaultMicColor;
                    ////GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDot").GetComponent<Image>().color = imageColor;
                    ////GameObject.Find("UserInterface/UnscaledUI/HudContent/Hud/VoiceDotParent/VoiceDotDisabled").GetComponent<Image>().color = imageColor;


                    //if (MouseBall == MouseBall2)
                    //{
                    //    MelonLogger.Msg("MouseColor Changed");
                    //}
                    //if (MouseBall != MouseBall2)
                    //{
                    //    MelonLogger.Error("MouseBall Did NOT Change");
                    //}
                    //Color MouseGlow = new Color();
                    //GlowColor = new Color(0.4307f, 0f, 1f, 1f);
                    ////MouseGlow = GameObject.Find("_Application/CursorManager/BlueFireballMouse/Glow").GetComponentInChildren<ParticleSystem>().startColor = GlowColor;
                    ////MouseGlow2 = GameObject.Find("_Application/CursorManager/BlueFireballMouse/Glow").GetComponentInChildren<ParticleSystem>().startColor;
                    //if (MouseGlow == MouseGlow2)
                    //{
                    //    MelonLogger.Msg("GlowColor Changed");
                    //}
                    //if (MouseGlow != MouseGlow2)
                    //{
                    //    MelonLogger.Error("MouseGlow Did NOT Change!");
                    //}
                    //Color MouseTrail = new Color();
                    //TrailColor = new Color(0.4307f, 0f, 1f, 1f);
                    ////MouseTrail = GameObject.Find("_Application/CursorManager/BlueFireballMouse/Trail").GetComponentInChildren<ParticleSystem>().startColor = TrailColor;
                    ////MouseTrail2 = GameObject.Find("_Application/CursorManager/BlueFireballMouse/Trail").GetComponentInChildren<ParticleSystem>().startColor;
                    //if (MouseTrail == MouseTrail2)
                    //{
                    //    MelonLogger.Msg("TrailColor Changed");
                    //}
                    ////if (MouseTrail != TrailColor)
                    ////    MelonLogger.Error("TrailColor Did NOT Change!");
                    //{
                    //    //GameObject.Find("UserInterface/QuickMenu/ShortcutMenu").GetComponentInChildren<UnityEngine.UI.Image>().m_Color = MenuColor;
                    //    //foreach (UnityEngine.UI.Image image9 in GameObject.Find("UserInterface/QuickMenu/QuickModeMenus/QuickModeNotificationsMenu/ScrollRect").GetComponentsInChildren<UnityEngine.UI.Image>(true))
                    //    {
                    //        //if (image9.transform.name == "Background")
                    //        {
                    //            //image9.color = new Color(0.4307f / 2.25f, 0 / 2.25f, 1 / 2.25f);
                    //        }
                    //    }
                    //    //foreach (MonoBehaviourPublicObCoGaCoObCoObCoUnique monoBehaviourPublicObCoGaCoObCoObCoUnique in GameObject.Find("UserInterface/QuickMenu/QuickModeTabs").GetComponentsInChildren<MonoBehaviourPublicObCoGaCoObCoObCoUnique>())
                    //    {
                    //        Color c = new Color(0.4307f / 2.25f, 0 / 2.25f, 1 / 2.25f);
                    //        //monoBehaviourPublicObCoGaCoObCoObCoUnique.field_Public_Color32_0 = c;
                    //    }
                }










                //    gameObject5 = GameObject.Find("QuickMenu");
                //    foreach (Button button2 in gameObject5.GetComponentsInChildren<Button>(true))
                //    {
                //        if (button2.gameObject.name != "rColorButton" && button2.gameObject.name != "gColorButton" && button2.gameObject.name != "bColorButton" && button2.gameObject.name != "ColorPickPreviewButton" && button2.transform.parent.name != "SocialNotifications" && button2.transform.parent.parent.name != "EmojiMenu" && button2.transform.parent.parent.name != "Post-Processing" && !button2.transform.parent.name.Contains("NotificationUiPrefab"))
                //        {
                //            button2.colors = colors;

                //        }
                //    }
                //    try
                //    {
                //        color2 = new Color(0.4307f, 0f, 1f, 1f);
                //        //Colors.loadingBackground = QMUtils.GetVRCUiMInstance().menuContent().transform.Find("Popups/LoadingPopup/3DElements/LoadingBackground_TealGradient/SkyCube_Baked").gameObject;
                //        Colors.loadingBackground.GetComponent<MeshRenderer>().material.SetTexture("_Tex", Useful.blankGradient);
                //        Colors.loadingBackground.GetComponent<MeshRenderer>().material.SetColor("_Tint", new Color32(255, 129, 0, 4));
                //        Colors.loadingBackground.GetComponent<MeshRenderer>().material.SetTexture("_Tex", Useful.blankGradient);
                //        //Colors.initialLoadingBackground = GameObject.Find("LoadingBackground_TealGradient_Music/SkyCube_Baked");
                //        Colors.initialLoadingBackground.GetComponent<MeshRenderer>().material.SetTexture("_Tex", Useful.blankGradient);
                //        Colors.initialLoadingBackground.GetComponent<MeshRenderer>().material.SetColor("_Tint", new Color32(255, 129, 0, 4));
                //        Colors.initialLoadingBackground.GetComponent<MeshRenderer>().material.SetTexture("_Tex", Useful.blankGradient);
                //    }

                //    catch (Exception ex)
                //    {
                //        {
                //            MelonLogger.Error(ex.ToString());
                //        }
                //        {
                //        }
                yield break;
                //    }
                //}

            }
        }







        public static async void waitforme()
        {
            await System.Threading.Tasks.Task.Delay(10000);
            //GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou/ThankYou Character/Character").GetComponent<Image>().color = new Color(1, 1, 1, 1);
            //GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou/ThankYou Character/Character").GetComponent<Image>().m_Color = new Color(1, 1, 1, 1);
            //GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/VRC+PageTab").SetActive(false);

            //Xero1 = GameObject.Find("UserInterface/MenuContent/Backdrop/Header/Tabs/ViewPort/Content/VRC+PageTab").gameObject;
            //GameObject.Destroy(Xero1);
            //if (GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner"))
            //{
            //    Xero2 = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/HeaderContainer/VRCPlusBanner").gameObject;
            //    GameObject.DestroyImmediate(Xero2);
            //}
            MelonLogger.Msg("Removing VRC+");
            await System.Threading.Tasks.Task.Delay(2000);
            if (Directory.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "Xero\\Images")))
            {
                if (File.Exists(System.IO.Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Senko.png")))
                {
                    //xero1 = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou/ThankYou Character/Character").gameObject;
                    xero1.active = true;
                    try
                    {
                        if (xero1.active)
                        {
                            //var cattofoxx = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou/ThankYou Character/Character").GetComponent<Image>();
                            //cattofoxx.sprite = $"{System.IO.Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Senko.png")}".LoadSpriteFromDisk();
                        }
                        else
                        {
                            //xero1.active = true; var cattofoxx = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou/ThankYou Character/Character").GetComponent<Image>();
                            //cattofoxx.sprite = $"{System.IO.Path.Combine(Environment.CurrentDirectory, "Xero/Images/Senko.png")}".LoadSpriteFromDisk();
                        }
                    }
                    catch (Exception ex) { MelonLogger.Error("Error in Replacing VRC+ " + ex + " "); }
                }
                else { MelonLogger.Msg("Missing Senko Image ask Foxx for this please!"); }
            }
            else { MelonLogger.Msg("Missing Images Directory...\n Creating Directory..."); File.Create(System.IO.Path.Combine(Environment.CurrentDirectory, "Xero/Images")); }
            xero1 = GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/GalleryButton").gameObject;
            //GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou/ThankYou Character/Dialog Bubble/Bubble").active = true;
            //GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou/ThankYou Character/Dialog Bubble/Bubble").GetComponentInChildren<Text>().m_Text = "Thank You for Choosing Xero";
            //GameObject.Find("UserInterface/QuickMenu/ShortcutMenu/VRCPlusThankYou/ThankYou Character/Dialog Bubble/Bubble/Text").GetComponent<Text>().text = "Thank You for Choosing Xero";
            //GameObject.DestroyImmediate(xero1);
            //GameObject.Destroy(xero1);
        }

        //public static void DevTags()
        //{
        //    foreach (var player in Useful.Players)
        //    {
        //        if (player?.prop_APIUser_0.id == "usr_77979962-76e0-4b27-8ab7-ffa0cda9e223" || player?.prop_APIUser_0.id == "usr_39c054aa-1f3d-4791-9a9e-6e796d035f32")
        //            try
        //            {
        //                player?.transform.Find("Player Nameplate/Canvas/Nameplate/Contents/Main/Dev Circle").gameObject.SetActive(true);
        //                if (player?.prop_APIUser_0.id == null)
        //                    return;


        //            }
        //            catch
        //            {


        //            }
        //    }
        //}
        private static List<Image> normalColorImage;
        private static List<Image> dimmerColorImage;
        private static List<Text> normalColorText;
        public static Color BackDrop { get => new Color(0.4307f, 0f, 1f, 1f); }
        public static Color MouseColor;
        public static Color GlowColor;
        public static Color TrailColor;
        public static Color MenuColor { get => new Color(0.4307f, 0f, 1f, 1f); }
        public static Color32 Color2 { get; private set; }
        public static Color MouseBall2 { get; private set; }

        private static Color imageColor;

        public static Color MouseGlow2 { get; private set; }
        public static Color MouseTrail2 { get; private set; }

        public Color newColor = new Color(0.79f, 1.00f, 0.50f);
        private static Color color;
        private static GameObject gameObject5;
        private static GameObject loadingBackground;
        private static GameObject initialLoadingBackground;
        public static Color DefaultMicColor { get => new Color32(255, 209, 209, 1); }
        public static GameObject Xero2 { get; private set; }
        public static GameObject Xero1 { get; private set; }

        private static Color color2;
        private static GameObject xero1;
#pragma warning disable CS0169 // The field 'Colors.name2' is never used
        private static string name2;
#pragma warning restore CS0169 // The field 'Colors.name2' is never used
#pragma warning disable CS0169 // The field 'Colors.name1' is never used
        private static GameObject name1;
#pragma warning restore CS0169 // The field 'Colors.name1' is never used
#pragma warning disable CS0169 // The field 'Colors.a' is never used
        private static GameObject a;
#pragma warning restore CS0169 // The field 'Colors.a' is never used
    }
}



