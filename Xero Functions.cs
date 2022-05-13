using ReMod.Core;
using ReMod.Core.UI.QuickMenu;
using ReMod.Core.Managers;
using System;
using System.IO;
using MelonLoader;
using System.Windows.Forms;
using VRC.SDKBase;
using UnityEngine;
using VRC;
using Xero.Configer;
using XeroButtons;
using System.Net;
using VRC.Core;
using System.Diagnostics;
using VRC.DataModel;
using ReMod.Core.VRChat;
using System.Threading.Tasks;
using BegoneGameObject;
using Il2CppSystem.Collections.Generic;
using System.Globalization;
using System.Collections;
using UnityEngine.Networking;
using ExitGames.Client.Photon;
using Photon.Realtime;
using Player = VRC.Player;
//------------------------------------------------------\\
namespace Xero.ReCoreAPI
{
    public class ReCoreApi : ModComponent
    {
        #region MakeNewButton
        public static void CreateNewButtonAuth()
        {
            if (XeroCore.createdbutton == false)
            {
                MelonLogger.Msg("Creating Button for Foxx");
                try
                {
                    // used to be auth to create buttons for certain people..
                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddToggle("Toggle Music", "Toggles the music on for loading in", delegate (bool muz)
                    {
                        Music.LoadMusic.menumusic = muz;
                        Configuration.JSONConfig.menumusic = muz;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.menumusic);
                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddToggle("Plays music in the world", "Plays songs", delegate (bool mus)
                    {
                        if (mus == true)
                        {

                            GameObject game = new GameObject();
                            MelonLogger.Msg("Instantiating music player.");
                            game.name = "Foxx Music Player.";
                            game.transform.position = Useful.LocalPlayer.gameObject.transform.position;
                            game.AddComponent<UnityEngine.AudioSource>();
                            game.GetComponent<AudioSource>().volume = 0.50000000f;
                            game.GetComponent<AudioSource>().loop = true;
                            MelonCoroutines.Start(Inits());
                        }
                        else
                        {
                            GameObject isgameAlive = GameObject.Find("Foxx Music Player.");
                            if (isgameAlive == true)
                            {
                                MelonLogger.Msg("Deleting Object.");
                                GameObject.Destroy(isgameAlive);
                            }

                        }
                    }, false);

                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddButton("Randomize Music Playing", "Random", delegate ()
                    { MelonCoroutines.Start(Inits()); }, null);
                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddToggle("<color=#9200e0>Mute</color>", "Mute", delegate (bool muz)
                    {
                        GameObject isgameAlive = GameObject.Find("Foxx Music Player.");
                        if (isgameAlive == true)
                            isgameAlive.GetComponent<AudioSource>().mute = muz;
                        XeroCore.ismuted = muz;
                    }, false);
                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddButton("<color=green>+.1</color>", "Turn Music Up by 1", delegate ()
                    {
                        GameObject isgameAlive = GameObject.Find("Foxx Music Player.");
                        if (isgameAlive == true)
                            isgameAlive.GetComponent<AudioSource>().volume += 0.0999999999999f;
                    }, null);
                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddButton("<color=red>-.1</color>", "Turn Music Down by 1", delegate ()
                    {
                        GameObject isgameAlive = GameObject.Find("Foxx Music Player.");
                        if (isgameAlive == true)
                            isgameAlive.GetComponent<AudioSource>().volume -= 0.0999999999999f;
                    }, null);
                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddToggle("Turn off all music", "Turn off all music", delegate (bool wrld)
                    {
                        XeroCore.doit = GameObject.FindObjectOfType<GameObject>().GetComponent<AudioSource>().mute = wrld;
                        if (GameObject.Find("Foxx Music Player.") == true)
                            GameObject.Find("Foxx Music Player.").GetComponent<AudioSource>().mute = XeroCore.ismuted;


                    }, false);
                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddButton("", "Holder", delegate ()
                    { }, null);

                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddButton("<color=green>+.01</color>", "Turn Music Up by 1", delegate ()
                    {
                        GameObject isgameAlive = GameObject.Find("Foxx Music Player.");
                        if (isgameAlive == true)
                            isgameAlive.GetComponent<AudioSource>().volume += 0.00999999999999f;
                    }, null);
                    Xero.ReCoreAPI.ReCoreApi.MusicXero.AddButton("<color=red>-.01</color>", "Turn Music Down by 1", delegate ()
                    {
                        GameObject isgameAlive = GameObject.Find("Foxx Music Player.");
                        if (isgameAlive == true)
                            isgameAlive.GetComponent<AudioSource>().volume -= 0.00999999999999f;
                    }, null);
                    Xero.ReCoreAPI.ReCoreApi.exploitbutton.AddToggle("False on Join Requests", "Returns False on Event 3", delegate (bool ev3)
                    {
                        if (Useful.IsInWorld())
                        {
                            Configuration.JSONConfig.Event3 = ev3;
                            Configuration.SaveConfig();
                            XeroCore.Event3off = ev3;
                        }
                    }, Configuration.JSONConfig.Event3);
                    Xero.ReCoreAPI.ReCoreApi.exploitbutton.AddButton("Transfer Master  \n<color=red>EXPERIMENTAL</color>", "Requests Owner of world", delegate ()
                    {
                        byte[] array = Convert.FromBase64String(Useful.LocalPlayer1._player.prop_APIUser_0.id);
                        {
                            OP.OpRaiseEvent(208, array, new RaiseEventOptions
                            {
                                field_Public_ReceiverGroup_0 = ReceiverGroup.Others,
                                field_Public_EventCaching_0 = EventCaching.DoNotCache
                            }, default(SendOptions));
                        }
                    });
                    Xero.ReCoreAPI.ReCoreApi.exploitbutton.AddToggle("Turns Off All Events", "Sends False on All Events", delegate (bool ev)
                      { XeroCore.CaptureAllEvents = !ev; }, false);
                    XeroCore.Spoof = Xero.ReCoreAPI.ReCoreApi.exploitbutton.AddMenuPage("Spoof", "Spoof FPS / Ping maybe More", null);
                    if (Configuration.JSONConfig.FakeFPS == null)
                        Configuration.JSONConfig.FakeFPS = true;
                    if (Configuration.JSONConfig.FakePing == null)
                        Configuration.JSONConfig.FakePing = true;
                    XeroCore.Spoof.AddToggle("FakeFPS", "Turn on or off fake fps", delegate (bool val)
                    {
                        Configuration.JSONConfig.FakeFPS = val;
                        XeroCore.fakefps = val; Configuration.SaveConfig();
                    }, Configuration.JSONConfig.FakeFPS);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Remove LaunchPad Button", "Remove Page Button", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Dashboard"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Dashboard").active = !button;
                        Configuration.JSONConfig.LaunchPad = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.LaunchPad);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Remove Notification Tools Button", "Remove Notification Button", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Notifications"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Notifications").active = !button;
                        Configuration.JSONConfig.Notification = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.Notification);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Remove Instance Button", "Remove Instance Button", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Here"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Here").active = !button;
                        Configuration.JSONConfig.Instance = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.Instance);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Remove Camera Button", "Remove Camera Button", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera").active = !button;
                        Configuration.JSONConfig.Camera = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.Camera);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Remove Audio Button", "Remove Audio Button", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_AudioSettings"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_AudioSettings").active = !button;
                        Configuration.JSONConfig.Audio = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.Audio);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Remove Settings Button", "Remove Settings Button", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings").active = !button;
                        Configuration.JSONConfig.Settings = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.Settings);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Remove EmmVRC Button", "Remove EmmVRC Button", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/emmVRC_MainMenuTab"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/emmVRC_MainMenuTab").active = !button;
                        Configuration.JSONConfig.EmmVRC = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.EmmVRC);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Add / Remove Developer Tools Button", "Remove Developer Button", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools").active = button;
                        Configuration.JSONConfig.DevTools = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.DevTools);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Remove VRNyup Button", "Remove VRNyup Button", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_VRNyup"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_VRNyup").active = !button;
                        Configuration.JSONConfig.VRNyup = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.VRNyup);
                    Xero.ReCoreAPI.ReCoreApi.UIButtonXero.AddToggle("Remove PlayerList", "Remove PlayerList", delegate (bool button)
                    {
                        if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/PLTab"))
                            GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/PLTab").active = !button;
                        Configuration.JSONConfig.PlayerList = button;
                        Configuration.SaveConfig();
                    }, Configuration.JSONConfig.PlayerList);
                    Xero.ReCoreAPI.ReCoreApi.UserMenu.AddToggle("Copy Voice\n<color=red>Experimental</color>", "Copies Selected Players Voice", delegate (bool copy)
                    {
                        XeroCore.copytheirvoice = copy;
                    }, false);



                    if (Configuration.JSONConfig.Event3 == true)
                        XeroCore.Event3off = true;
                    if (Configuration.JSONConfig.FakeFPS == true)
                        XeroCore.fakefps = true;
                    if (Configuration.JSONConfig.FakePing == true)
                        XeroCore.fakeping = true;
                    XeroCore.createdbutton = true;
                }
                catch (Exception ex) { MelonLogger.Error(ex.Message); }
            }

        }
        #endregion End

        #region Music
        public static IEnumerator Inits()
        {

            string[] files = Directory.GetFiles(Environment.CurrentDirectory + "\\Xero\\Music\\MultipleMusic");
            if (files.Length >= 1)
            {
                MelonLogger.Msg("Processing custom menu music.");
                int num = new System.Random().Next(files.Length);
                MelonLogger.Msg($"Picked track: {num} ");
                GameObject loadingMusic = GameObject.Find("Foxx Music Player.");
                if (loadingMusic != null)
                {
                    loadingMusic.GetComponent<AudioSource>().Stop();
                }

                UnityWebRequest CustomLoadingMusicRequest = UnityWebRequest.Get(string.Format("file://{0}", files[num]).Replace("\\", "/"));
                CustomLoadingMusicRequest.SendWebRequest();
                while (!CustomLoadingMusicRequest.isDone)
                {
                    yield return null;
                }
                MelonLogger.Msg("Request sent and returned");
                AudioClip audioClip = null;
                if (CustomLoadingMusicRequest.isHttpError)
                {
                    MelonLogger.Msg("Could not load music file: " + CustomLoadingMusicRequest.error);
                }
                else
                {
                    audioClip = WebRequestWWW.InternalCreateAudioClipUsingDH(CustomLoadingMusicRequest.downloadHandler, CustomLoadingMusicRequest.url, false, false, AudioType.UNKNOWN);
                }
                if (audioClip != null)
                {
                    if (loadingMusic != null)
                    {
                        loadingMusic.GetComponent<AudioSource>().clip = audioClip;
                        loadingMusic.GetComponent<AudioSource>().Play();
                    }
                }
                loadingMusic = null;
                CustomLoadingMusicRequest = null;
            }
        }
        #endregion
        //Testing all Buttons Stuff
        public static void OnUiManagerInit()
        {
            try
            {


                try
                {
                    _uiManager = new UiManager("<color=#755985>Xero</color> Main Menu", null);
                    TestPage = _uiManager.MainMenu.AddMenuPage("Avatar", "Avatar Options", null);
                }
                catch { MelonLogger.Msg("Error in Senko PNG"); }



                TestPage.AddButton("Your Avatar ID", "Grabs Avatar ID to Clipboard", delegate
                {
                    Clipboard.SetText(Useful.LocalPlayer1.prop_ApiAvatar_0.id);

                }, null);


                TestPage.AddButton("Apply Avatar ID", "Put on Avatar By ID from Clipboard", delegate
                {
                    XeroPopup.Popup.CreateInputPopup("Avatar ID", "ID Here...", inputavatarid, "Cancel", "Confirm", UnityEngine.UI.InputField.InputType.Standard, false, delegate (string inputtext2)
                   {
                       try
                       {
                           Useful.ChangeAVIFromString(inputtext2);
                       }

                       catch { MelonLogger.Error("Text Entered was " + Color.red + "NOT" + Color.white + " an Avatar ID"); }
                   }, null, null);
                }, null);



                WorldPage = _uiManager.MainMenu.AddMenuPage("World", "World Options", null);

                TestPage.AddButton("Download VRCA", "Downloads Your VRCA", delegate
                { Process.Start(Useful.XeroSelectedUser.prop_ApiAvatar_0.assetUrl); }, null);

                WorldPage.AddButton("Get World ID", "Gets Current World id to clipboard", delegate
                {
                    string wrld = RoomManager.field_Internal_Static_ApiWorld_0.id + ":" + Useful.GetInstance().instanceId;
                    Clipboard.SetText(wrld);
                }, null);


                WorldPage.AddButton("Join World ID", "Joins World ID In Clipboard", delegate
                {
                    XeroPopup.Popup.CreateInputPopup("Wrld ID", "ID Here...", inputWorldid, "Cancel", "Confirm", UnityEngine.UI.InputField.InputType.Standard, false, delegate (string inputtext2)
                    {
                        try
                        {
                            Networking.GoToRoom(inputWorldid);
                        }
                        catch { MelonLogger.Error("Text Entered was " + Color.red + "NOT" + Color.white + " a Wrld ID"); }
                    }, null, null);
                }, null);
                MusicXero = WorldPage.AddMenuPage("<color=red>Music</color> Menu", "Idk maybe?", null);
                UserMenu = _uiManager.TargetMenu.AddMenuPage("<color=red>User</color> Menu", "Idk maybe?", null);

                AvatarMenu = _uiManager.TargetMenu.AddMenuPage("<color=green>Avatar</color> Page", "Avatar Options");

                PlayerMenu = _uiManager.TargetMenu.AddMenuPage("<color=purple>Player</color> Page", "Player Options");

                VoicePlayer = PlayerMenu.AddMenuPage("Voice", "Mess With Player Voice");

                FunnyVoiceEnabler = VoicePlayer.AddToggle("Funny Voice", "Changes The Pitch of the voice", delegate (bool t) { FunnyVoice = t; }, false);

                VoicePlayer.AddButton("Change Pitch", "Change Pitch of the Player Voice", delegate ()
                {
                    if (FunnyVoice == true)
                    {
                        XeroPopup.Popup.CreateInputPopup("Change Pitch", "", "1.0", "Cancel", "Change", UnityEngine.UI.InputField.InputType.Standard, false, delegate (string inputtext3)
                            {
                                IUser field_Private_IUser_ = QuickMenuEx.SelectedUserLocal.field_Private_IUser_0;
                                if (field_Private_IUser_ == null)
                                {
                                    return;
                                }
                                Player player = PlayerManager.field_Private_Static_PlayerManager_0.GetPlayer(field_Private_IUser_.prop_String_0);
                                if (player == null)
                                {
                                    return;
                                }
                                VRCPlayer vrcplayer = player._vrcplayer;
                                float val = float.Parse(inputtext3, CultureInfo.InvariantCulture.NumberFormat);
                                Useful.XeroSelectedUser._vrcplayer.prop_PlayerAudioManager_0.field_Private_AudioSource_0.pitch = val;
                            }, null, null);

                    }
                }, null);

                AvatarName = AvatarMenu.AddButton("[]", "Selected Player's Avatar", delegate ()
                {
                    Clipboard.SetText(Useful.XeroSelectedUser.prop_ApiAvatar_0.name);
                }, null);

                AuthorName = AvatarMenu.AddButton("[]", "Author Name", delegate ()
                {
                Process.Start("https://vrchat.com/home/user/" + Useful.XeroSelectedUser.prop_ApiAvatar_0.authorId);
                }, null);

                ReleaseStatusButt = AvatarMenu.AddButton("[]", "Release Status", null, null);

                CreationDate = AvatarMenu.AddButton("[]", "Creation Date", null, null);


                AvatarMenu.AddButton("Copy Avatar ID", "Copies Avatar ID", delegate ()
                {
                    Clipboard.SetText(Useful.XeroSelectedUser.prop_ApiAvatar_0.id);
                }, null);
                AvatarMenu.AddButton("Unity Package URL", "Unity Package Url", delegate ()
                {
                    try
                    {
                        Process.Start(Useful.XeroSelectedUser.prop_ApiAvatar_0.unityPackageUrl);
                    }
                    catch (Exception ex)
                    {
                        MelonLogger.Error("Error in Unity Package URL \n" + Useful.XeroSelectedUser.prop_ApiAvatar_0.unityPackageUrl + "\n Exception: {0}", ex.Message);
                    }
                }, null);
                AvatarMenu.AddButton($"Download VRCA", "Downloads Their avatar", delegate
                {
                    Process.Start(Useful.XeroSelectedUser.prop_ApiAvatar_0.assetUrl);
                }, null);
                AvatarMenu.AddButton("Force Clone", "Force Clones Their Avatar", delegate
                {
                    Useful.ChangeAVIFromString(Useful.XeroSelectedUser.prop_ApiAvatar_0.id);
                }, null);
                cameraButton = _uiManager.MainMenu.AddMenuPage("Camera (ESP)", "All Things That you see");
                cameraButton.AddToggle("Player ESP", "Toggle ESP On / OFF", delegate (bool e)
                { Configuration.JSONConfig.PlayerEsp = e; QMmenu.playeresp = e; QMmenu.espon(); Configuration.SaveConfig(); }, Configuration.JSONConfig.PlayerEsp);
                cameraButton.AddToggle("Object ESP", "Toggle ESP On / OFF", delegate (bool e)
                { Configuration.JSONConfig.ObjectEsp = e; QMmenu.objectesp = e; QMmenu.espon(); Configuration.SaveConfig(); }, Configuration.JSONConfig.ObjectEsp);

                cameraButton.AddToggle("VSYNC \n(Unlocks FPS)", "Disable / Enable VSYNC", delegate (bool f)
                {
                    QualitySettings.vSyncCount = f ? 1 : 0;
                }, Configuration.JSONConfig.UnlimitedFps);
                cameraButton.AddButton("ThirdPerson Disable", "Disable if Stuck", delegate ()
                {
                    ThirdPersonSetup.ThirdPerson.CameraSetup = 0;
                    var instance = new ReCoreApi();
                    instance.Tes();
                }, null);

                MovemintButton = _uiManager.MainMenu.AddMenuPage("Movement", "Movement");
                MovemintButton.AddToggle("Infinite Jump", "Turns Infinite Jump ON", delegate (bool f)
                { Configuration.JSONConfig.InfiniteJump = f; QMmenu.infjumpstate = f; Configuration.SaveConfig(); }, Configuration.JSONConfig.InfiniteJump);
                MovemintButton.AddButton("Add Jump", "Allows you to jump", delegate
                {
                    bool flag = Useful.LocalPlayer1.gameObject.GetComponent<PlayerModComponentJump>();
                    if (!flag)
                    {

                        PlayerModComponentJump playerModComponentJump = Useful.LocalPlayer1.gameObject.AddComponent<PlayerModComponentJump>();
                        playerModComponentJump.field_Private_Single_0 = 2f;
                        playerModComponentJump.field_Private_Single_1 = 2f;
                    }
                }, null);
                try
                {
                    KeyBindButton = _uiManager.MainMenu.AddMenuPage("KeyBinds", "Disable KeyBinds");

                }
                catch (Exception ex) { MelonLogger.Error("Error in inherit {0}", ex.Message); }

                FreeCamKeybindButton = KeyBindButton.AddToggle("KeyBind B (FreeCam)", "KeyBind B", delegate (bool t)
                {
                    Configuration.JSONConfig.FreeCam = t;
                }, Configuration.JSONConfig.FreeCam);

                ZoomKeybindButton = KeyBindButton.AddToggle("KeyBind G (Zoom)", "KeyBind G", delegate (bool t)
                {
                    Configuration.JSONConfig.Zoom = t;
                }, Configuration.JSONConfig.Zoom);

                ThirdPersonKeybindButton = KeyBindButton.AddToggle("KeyBind T (ThirdPerson)", "KeyBind T", delegate (bool t)
                {
                    Configuration.JSONConfig.ThirdPerson = t;
                }, Configuration.JSONConfig.ThirdPerson);

                exploitbutton = _uiManager.MainMenu.AddMenuPage("Exploits", "<color=red>IF</color> I have any");
                exploitbutton.AddToggle("Loud Mic", "Loud Mic", delegate (bool Loud)
                { USpeaker.field_Internal_Static_Single_1 = Loud ? float.MaxValue : 1; }, false);
                try
                {
                    UserMenu.AddButton($"Teleport To", $"Teleports you to", delegate
                    {

                        Useful.LocalPlayer1.transform.position = Useful.XeroSelectedUser.gameObject.transform.position;
                    }, null);
                    inftele = UserMenu.AddToggle("Force Teleport Inf", "Inf", delegate (bool mama)
                      {
                          ForceTeleport = mama;
                      }, false);
                    UIButtonXero = _uiManager.MainMenu.AddMenuPage("Ui", "Add and remove buttons", null);

                    AvatarMenu.AddButton($"Log", $"Logs {SelectedPlayer}", delegate
                    {

                        MelonLogger.Msg("Console Version:");
                        MelonLogger.Msg($"----------------------- {Useful.XeroSelectedUser.prop_APIUser_0.displayName} -----------------------");
                        MelonLogger.Msg($"User Joined Date: {Useful.XeroSelectedUser.prop_APIUser_0.date_joined}");
                        MelonLogger.Msg($"Old Name {Useful.XeroSelectedUser.prop_APIUser_0.username}");
                        MelonLogger.Msg($"ID {Useful.XeroSelectedUser.prop_APIUser_0.id}");
                        MelonLogger.Msg($"Current Status {Useful.XeroSelectedUser.prop_APIUser_0.status}");
                        MelonLogger.Msg($"Profile Picture {Useful.XeroSelectedUser.prop_APIUser_0.profilePicImageUrl}");
                        MelonLogger.Msg($"Avatar Version {Useful.XeroSelectedUser.prop_ApiAvatar_0.unityVersion}");
                        MelonLogger.Msg($"Avatar Release Status {Useful.XeroSelectedUser.prop_ApiAvatar_0.releaseStatus}");
                        MelonLogger.Msg($"Avatar Picture {Useful.XeroSelectedUser.prop_ApiAvatar_0.thumbnailImageUrl}");
                        MelonLogger.Msg($"Avatar Name {Useful.XeroSelectedUser.prop_ApiAvatar_0.name}");
                        MelonLogger.Msg($"Avatar ID {Useful.XeroSelectedUser.prop_ApiAvatar_0.id}");
                        MelonLogger.Msg($"Avatar Download {Useful.XeroSelectedUser.prop_ApiAvatar_0.assetUrl}");
                        MelonLogger.Msg($"Avatar Author Name {Useful.XeroSelectedUser.prop_ApiAvatar_0.authorName}");
                        MelonLogger.Msg($"----------------------- {System.DateTime.Now} -----------------------");

                        if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Log\\UserLog.txt")))
                            File.Create(Path.Combine(Environment.CurrentDirectory, "Xero\\Log\\UserLog.txt"));
                        File.AppendAllText(Path.Combine(Environment.CurrentDirectory, "Xero\\Log\\UserLog.txt"), string.Concat(new string[]
                            {
                     "[-----------------------------------------------------------]",
                     Environment.NewLine,
                     $"DisplayName: {Useful.XeroSelectedUser.prop_APIUser_0.displayName}",
                     Environment.NewLine,
                     $"UserName: {Useful.XeroSelectedUser.prop_APIUser_0.username}",
                     Environment.NewLine,
                     $"Profile Picture {Useful.XeroSelectedUser.prop_APIUser_0.profilePicImageUrl}",
                     Environment.NewLine,
                     $"Avatar ID: {Useful.XeroSelectedUser.prop_ApiAvatar_0.id}",
                     Environment.NewLine,
                     $"Avatar VRCA: {Useful.XeroSelectedUser.prop_ApiAvatar_0.assetUrl}",
                     Environment.NewLine,
                     $"Avatar Unity Version: {Useful.XeroSelectedUser.prop_ApiAvatar_0.unityVersion}",
                     Environment.NewLine,
                     $"Avatar Version: {Useful.XeroSelectedUser.prop_ApiAvatar_0.version}",
                     Environment.NewLine,
                     $"Avatar Thumbnail: {Useful.XeroSelectedUser.prop_ApiAvatar_0.imageUrl}",
                     Environment.NewLine,
                     $"Avatar Release Status: {Useful.XeroSelectedUser.prop_ApiAvatar_0.releaseStatus}",
                     Environment.NewLine,
                    $"[------------------- {DateTime.Now} -------------------]",
                     Environment.NewLine,
                     "⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇   ⬇",
                     Environment.NewLine

                            }));


                    }, null);

                }
                catch (Exception ex) { MelonLogger.Error("Error in Logging Avatar {0}",ex.Message); }
                AvatarButton();
                TickerButton();

            }
            catch (Exception ex) { MelonLogger.Error($"{ex.Message}"); }
        }
        private static void TickerButton()
        {
            TickerObject = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Ticker");
            TickerObject.active = true;
        }
        public static void AvatarButton()
        {
            Action action = delegate ()
            {
                Downloadlink = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/AvatarPreviewBase/MainRoot/MainModel").GetComponent<SimpleAvatarPedestal>().field_Internal_ApiAvatar_0.assetUrl;
                Process.Start(Downloadlink);
            };
            selectbutton = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Select Button");
            ParentTransform = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/");
            GameObject select = new GameObject();
            select = GameObject.Instantiate<GameObject>(selectbutton, ParentTransform.transform);
            select.GetComponent<UnityEngine.UI.Button>().onClick.RemoveAllListeners();
            select.GetComponent<UnityEngine.UI.Button>().onClick.m_Calls.ClearPersistent();
            select.GetComponent<UnityEngine.UI.Button>().onClick = new UnityEngine.UI.Button.ButtonClickedEvent();
            select.GetComponent<UnityEngine.UI.Button>().onClick.AddListener(action);
            select.gameObject.name = "Download VRCA";
            select.gameObject.transform.localPosition = new Vector3(-462.5492f, 149.2558f, 0.0414f);
            select.GetComponentInChildren<UnityEngine.UI.Text>().text = "VRCA";
            select.gameObject.transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("UserInterface/MenuContent/Screens/Avatar/TitlePanel (1)").active = false;
        }
        public static async void wait()
        {
            await System.Threading.Tasks.Task.Delay(10000);
            if (GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().text == "")
                GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().text = "<color=#755985>Xero</color> Favorite";
        }

        public void Tes()
        {
            ThirdPersonReset = true;
            ThirdPersonReset = false;
        }
        public static void UpdateQM()
        {
            try
            {
                if (Useful.IsInWorld() && XeroCore.YouHaveJoined == true)
                {
                    if (Useful.XeroSelectedUser != null)
                        AvatarName.Text = Useful.XeroSelectedUser.prop_ApiAvatar_0.name;
                    try
                    {

                        if (Useful.XeroSelectedUser.prop_ApiAvatar_0.releaseStatus == "public")
                            ReleaseStatusButt.Text = "<color=green>Public</color>";
                        else { ReleaseStatusButt.Text = "<color=red>Private</color>"; }
                    }
                    catch { MelonLogger.Error("Error on Release Status"); }
                    try
                    {

                        AuthorName.Text = Useful.XeroSelectedUser.prop_ApiAvatar_0.authorName;
                    }
                    catch (Exception ex) { MelonLogger.Error("Error in Author Name \n Exception: {0}", ex.Message); }
                    try
                    {
                        CreationDate.Text = Useful.XeroSelectedUser.prop_ApiAvatar_0.created_at.ToString();
                    }
                    catch (Exception ex) { MelonLogger.Error("Could Not Fetch Creation Date \n Exception: {0}", ex.Message); }
                    if (FunnyVoice == true)
                        FunnyVoiceEnabler.Text = "<color=green>Funny</color> Voice";
                    else { FunnyVoiceEnabler.Text = "<color=red>Funny</color> Voice"; }

                }
            }
            catch {  } // Selected User isnt Specified Until a bit after...

            try
            {
                if (Useful.IsInWorld())
                {
                    SimpleAvatarPedestal simpleAvatarPedestal = GameObject.Find("UserInterface/MenuContent/Screens/Avatar/AvatarPreviewBase/MainRoot/MainModel").GetComponent<SimpleAvatarPedestal>();
                    TickerObject.GetComponentInChildren<UnityEngine.UI.Text>().text =
                    $"{simpleAvatarPedestal.field_Internal_ApiAvatar_0.name} | [{simpleAvatarPedestal.field_Internal_ApiAvatar_0.releaseStatus}]";
                }
            }
            catch { } // I dont call anything here because it will error until its being used!
            if (StickToplayer == true)
            {
                Useful.LocalPlayer1.gameObject.transform.position = Useful.XeroSelectedUser.transform.position;
                if (Input.GetKeyDown(KeyCode.Space))
                    StickToplayerButton.Toggle(false);
            }

            if (ForceTeleport == true)
            {
                if (Useful.XeroSelectedUser != null)

                    if (Useful.XeroSelectedUser != null)
                        Useful.LocalPlayer1.transform.position = Useful.XeroSelectedUser.gameObject.transform.position;
                    else
                    { inftele.Toggle(false); }

                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.Space)))
                    inftele.Toggle(false);
            }
        }

        public static void CorrectConfig()
        {
            QMmenu.playeresp = Configuration.JSONConfig.PlayerEsp;
            QMmenu.objectesp = Configuration.JSONConfig.ObjectEsp;
            QMmenu.infjumpstate = Configuration.JSONConfig.InfiniteJump;
        }


        private static UiManager _uiManager;
        public static ReMenuPage TestPage;
        public static ReMenuPage WorldPage;
        private static ReMenuPage cameraButton;
        public static ReMenuPage MovemintButton;
        public static ReMenuPage KeyBindButton;
        public static ReMenuToggle FreeCamKeybindButton;
        public static ReMenuToggle ZoomKeybindButton;
        public static ReMenuToggle ThirdPersonKeybindButton;
        public static ReMenuButton SaveConfigButtonBottom;
        public static ReMenuPage MusicXero;
        public static ReMenuPage UserMenu;
        public static ReMenuPage AvatarMenu;
        public static ReMenuPage PlayerMenu;
        public static ReMenuPage VoicePlayer;
        public static ReMenuToggle FunnyVoiceEnabler;
        public static ReMenuButton AvatarName;
        public static ReMenuPage UserButtonGroup;
        public static UnityEngine.UI.Button.ButtonClickedEvent FavoriteButton;
        public static SimpleAvatarPedestal MainModel;
        public static string SelectedPlayer;
        public static bool StickToplayer;
        public static ReMenuToggle StickToplayerButton;
        public static ReMenuPage AvatarGroup;
        public static GameObject TickerObject;
        public static string AvatarNameFromMenu;
        public static object AvatarReleaseStatus;
        public static bool ForceTeleport;
        public static ReMenuToggle Loops;
        public static bool SpyIsOn;
        public static Transform SelectedPlayersHead;
        public static GameObject Ears;
        public static Vector3 EarsSave;
        public static ReMenuPage exploitbutton;
        public static Player selectedplayers;
        private static GameObject selectbutton;
        private static GameObject ParentTransform;
        private static string Downloadlink;
        private static ReMenuToggle inftele;
        public static ReMenuPage UIButtonXero;
        public static ReMenuToggle SpyCamButton;
        public static string S;
        public static Action<string, List<KeyCode>, UnityEngine.UI.Text> ActionString;
        public bool ThirdPersonReset;
        public static ReMenuButton ReleaseStatusButt;
        public static ReMenuButton CreationDate;
        public static ReMenuButton AuthorName;
        public static bool FunnyVoice;
        private static string inputWorldid;
        private static string inputavatarid;
    }
}

