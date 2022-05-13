using System;
using System.IO;
using System.Reflection;
using MelonLoader;
using UnityEngine;
using Photon.Realtime;
using Music;
using ThirdPersonSetup;
using ExitGames.Client.Photon;
using HarmonyLib;
using UnityEngine.UI;
using System.Diagnostics;
using System.Threading;
using GameObjectBegone;
using System.Net;
using Xero;
using Photon.Pun;
using XeroButtons;
using ReMod.Core;
using ReMod.Core.Managers;
using System.Collections.Generic;
using Configuration = Xero.Configer.Configuration;
using ReMod.Core.UI.QuickMenu;
using System.Linq;
using VRC.DataModel;
using VRC;
using ReMod.Core.VRChat;

namespace BegoneGameObject // This is more then just a mod its how I learned c# and its what made me fall in love with the language, you'll see new code and old code and see how I progressively gotten better as the time passes, but also the progress that I have made to learn more.
{

    public class XeroCore : MelonMod // : MelonMod is part of MelonLoader which gives the assemblies to modify the game which also allows us to override functions such as OnApplicationStart, OnUpdate, and so on!
    {

        private static bool OnEvent(EventData __0) // This is Patched Below which when recieved event will allow the user to return the event differently or do things on the event! 
        {
            try
            {
                if (__0.Code == 1 && Useful.GetActorNumber(Useful.LocalPlayer1._player) != __0.sender && copytheirvoice)
                {
                    IUser field_Private_IUser_2 = QuickMenuEx.SelectedUserLocal.field_Private_IUser_0;
                    if (field_Private_IUser_2 != null)
                    {
                        VRC.Player player2 = PlayerManager.field_Private_Static_PlayerManager_0.GetPlayer(field_Private_IUser_2.prop_String_0);

                        if (player2 != null)
                        {
                            VRCPlayer vrcplayer2 = player2.GetVRCPlayer();
                            if (__0.sender == Useful.GetActorNumber(vrcplayer2._player))
                            {
                                byte[] array2 = Serialization.ToByteArray(__0.Parameters[245]); // I'm turning the Event Data (1) to be coppied then resent through myself seen:
                                System.Buffer.BlockCopy(System.BitConverter.GetBytes(photonHandler.field_Private_LoadBalancingClient_0.field_Private_LoadBalancingPeer_0.ServerTimeInMilliSeconds), 0, array2, 4, 4);
                                OP.OpRaiseEventlb(__0.Code, array2, new RaiseEventOptions // here!
                                {
                                    field_Public_EventCaching_0 = EventCaching.DoNotCache,
                                    field_Public_ReceiverGroup_0 = ReceiverGroup.All
                                }, SendOptions.SendUnreliable);
                                try
                                {
                                    MelonLogger.Msg("Code: " + __0.Code);
                                    MelonLogger.Msg("----------------------------------------------------------------------");
                                    MelonLogger.Msg($"Event sender: [{__0.Sender}]"); // Sender is Found by Matching ActorNumber (The Player Number of that World) between the sender
                                    MelonLogger.Msg("customData: " + __0.customData); // This is a IL2CPP Object
                                    MelonLogger.Msg("Parameters: " + __0.Parameters); // This includes all of the extra metadata!
                                    MelonLogger.Msg("----------------------------------------------------------------------");
                                    MelonLogger.Msg($"Selected [{vrcplayer2._player.prop_APIUser_0.displayName}] ActorNumber: " + Useful.GetActorNumber(vrcplayer2.prop_Player_0));
                                    MelonLogger.Msg("|                                                                    |");
                                    MelonLogger.Msg("----------------------------------------------------------------------");
                                    MelonLogger.Msg("From: Client User [{0}]", Useful.LocalPlayer1._player.prop_APIUser_0.displayName);
                                    MelonLogger.Msg("----------------------------------------------------------------------");
                                }
                                catch { MelonLogger.Error("Error in Capturing Data.."); }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { MelonLogger.Error("Error in Copy Voice {0}", ex.Message); }
            try
            {
                foreach (var player in Useful.Players)
                {
                if (Useful.GetActorNumber(Useful.LocalPlayer1._player) != __0.sender && Useful.GetActorNumber(player) == __0.sender)
                            MelonLogger.Msg(player.prop_APIUser_0.displayName + " Sent a Join Request");

                }
                if (Event3off == true)
                    if (Useful.LocalPlayer.isMaster && __0.Sender != Useful.GetActorNumber(Useful.LocalPlayer1._player))
                    { if (__0.Code == 3) return false; }
            }
            catch (Exception ex)
            {
                MelonLogger.Error("Error in Events! [{0}]", ex.Message);
            }
            return CaptureAllEvents;
        }

        //List of Events And What they are used for 
        #region Events
        // 1 : Voice Which is also known as USpeak.
        // 2 : Plugin Message Which is sent when Kicked.
        // 3 : Master Client Sync Request.
        // 4 : Master Client Sync Buffer.
        // 5 : Master Client Sync Flush This is sent when joining!
        // 6 : VRCEvent / RPC.
        // 7 : Player Update This updates Player / Object and is Unreliable.
        // 8 : Update Quality.
        // 9 : Avatar3Sync This is Player Sync but reliable. 
        // 15 : Listed as "BigData" But also Syncs Chairs. 
        // 33 : Moderation (Kicks, Bans, Mutes, Blocks)
        // 40 : VRC Photon Event.
        // 200 : RPC.
        // 201 : Send Serialize. 
        // 202 : Photon Instantiation.
        // 203 : Close Connection.
        // 204 : Labeled as "Destroy."
        // 206 : SendSerialize Reliable. 
        // 207 : Labeled as "Destroy Player"
        // 208 : Assign Master. (of Instance)
        // 209 : Ownership Request. (of Instance)
        // 210 : OwnerShip Transfer. (of Instance)
        // 211 : Labeled as "Vacant View IDs."
        // 223 : Authentication Values.
        // 226 : Join Room. <-- Though when you're joining it is event 255 that is used instead.
        // 230 : Authenticate.
        // 252 : Labeled as "Set Properties."
        // 253 : Labeled as "Update Properties."
        // 254 : Leave
        // 255 : Join
        #endregion


        private async void AuthenticationLocal() // Local Authentication That checks user id when they are not null and process if they are authenticated or not. If not their game is closed and the .dll is deleted.
        {

            if (Useful.LocalPlayer1?.prop_Player_0.prop_APIUser_0.id != null)
            {
                MelonLogger.Msg($"Checking authentication... [{Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id}]");

                if (Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_ada3d9bd-ed16-4bcb-8f58-80c575b8a4c2" || // PingMasterOfPong || 1
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_e38913b0-8676-40f8-b68a-15b1f59fd55b" || // Swerly Jeans || 2
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_65b45fcd-1145-47c4-924a-cb391dbf0c52" || // luumaa || 3
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_cb8123b5-b06e-478c-80fa-9df0f0b57cee" || // Me || 4
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_00f07c8a-7277-463e-9e2c-9098dbf9aded" ||
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_d44296db-1974-4449-a690-c0a94e1e9f9a" ||
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_e77593f4-e276-4987-864a-02681d37d56c" || // me
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_051481da-0204-4901-9bdd-4cd5907bc71c" || // damienk2 || 5
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_39c054aa-1f3d-4791-9a9e-6e796d035f32" || // A A A A A A || 6 
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_77979962-76e0-4b27-8ab7-ffa0cda9e223" || // PFC || 7
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_608fd837-5ac0-4681-9e44-01a5e1de2968" || // VRCHAT || 8 
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_6f00b75d-0a45-4cc4-85f8-8c5d38d9df74" || // Allegory || 9 
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_150644a3-8f80-44ab-b8eb-803b0b385393" || // Fako || 10
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_76a47483-3449-4853-a59c-d477bee9944e" || // My Alt || 11
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_72670f51-e7c3-400e-beeb-be5512d27fbb" || // AJ || 12
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_e8bfe5c3-d577-4516-bc68-113a60e85386" || // Price || 13
                    Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.id == "usr_7c44587f-c54c-4456-9e07-1cbb3b72a32a")   // Xero Developer || 14
                {
                    MelonLogger.Msg($"Welcome {Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.displayName} and again"); MelonLogger.Msg("Thank you for purchasing Xero!");
                }
                else
                {

                    thisisIT = true;
                    bool thiis = true;
                    if (thiis)
                    {
                        Timeout = false;
                        if (Timeout == false)
                        {
                            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "Mods\\Xero.dll")))
                            {
                                MelonLogger.Msg("Thank You, Although I don't Forgive you your game will be closed do not try again!!");
                                await System.Threading.Tasks.Task.Delay(2000);
                                Application.Quit();
                                Thread.Sleep(2500);
                            }
                            else { MelonLogger.Error("No... "); File.Delete(Path.Combine(Environment.CurrentDirectory, "Mods\\Xero.dll")); await System.Threading.Tasks.Task.Delay(4000); thiis = false; Timeout = true; }
                        }
                    }
                };
            }
        }
        public override void OnApplicationQuit()
        {
            if (thisisIT == true)
            {
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Mods\\Xero.dll")))
                {
                    File.Delete(Path.Combine(Environment.CurrentDirectory, "Mods\\Xero.dll"));
                }
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic\\Senko San zOpening.ogg")))
                {
                    File.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic\\Senko San zOpening.ogg"));
                }
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic\\Senko zSan Ending.mp3")))
                {

                    File.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic/Senko zSan Ending.mp3"));
                }
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Senko.png")))
                {

                    File.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Senko.png"));
                }
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Foxx.jpg")))
                {

                    File.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Images\\Foxx.jpg"));
                }
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic\\Inside Joke.ogg")))
                {

                    File.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic\\Inside Joke.ogg"));
                }
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic\\bakajanainoni.ogg")))
                {

                    File.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic\\bakajanainoni.ogg"));
                }
                if (Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Images")))
                {
                    Directory.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Images"));

                }
                if (Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic")))
                {
                    Directory.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Music\\MultipleMusic"));

                }
                if (Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Music")))
                {
                    Directory.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Music"));

                }
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Config\\config.json")))
                {
                    File.Delete(Path.Combine(Environment.CurrentDirectory, "Xero\\Config\\config.json"));
                }
                if (Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Config")))
                {

                }
                if (Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero")))
                {
                    Directory.Delete(Path.Combine(Environment.CurrentDirectory, "Xero"));

                }

            }
        }

        private async static void UPDATETIME() //This is a Check for me and the users it checks on application late start and if its not me or someone with a specified string it will update
        {
            if (Configuration.JSONConfig.FoxxString == "thisiswhyyourmommaleftyoubignosehavingasswhatyousaytomeboiimma99912932131243524328234234823429123249081234021834-02194320-49235812-352349-2-213") // Stops Update.. (Helps So I don't have to build every time I restart Game.)
            {
                MelonLogger.Msg("Welcome back Foxx.. Long Time no see!");
            }
            else
            {
                MelonLogger.Msg("Standard User Initialized");
                if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Mods\\Xero.dll")))
                {
                    File.Delete(Path.Combine(Environment.CurrentDirectory, "Mods\\Xero.dll"));
                    MelonLogger.Msg("Deleted Xero.dll Installing New Version...");
                    await System.Threading.Tasks.Task.Delay(999);
                    WebClient webClient2 = new WebClient();
                    webClient2.DownloadFile(String.Format("https://raw.githubusercontent.com/genericname02/nothingspecial/main/Xero.dll"), Path.Combine(Environment.CurrentDirectory, "Mods\\Xero.dll"));
                }
            }
        }


        public override void OnApplicationLateStart()
        {
            //UpdateTime();
            MelonLogger.Msg("Downloading Updated Client on Late Start");
            try
            {
                photonHandler = GameObject.FindObjectsOfType<Photon.Pun.PhotonHandler>()[0]; // This is used during events to calculate time in server miliseconds.
            }
            catch (Exception ex) { MelonLogger.Error("photonHandler Not Found", ex.Message); ; }
        }
        #region Text for Startup


        private System.Collections.IEnumerator HookOnUiManagerInit()
        {
            while (VRCUiManager.field_Private_Static_VRCUiManager_0 == null)
            {
                yield return null;
            }
            OnUiManagerInit(); // This is called when the UI is being created so that way I can start to implement my buttons as well!
        }

        private static void CreateFiles()
        {
            if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Log")))
                Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Xero\\Log"));
            if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero\\Log\\UserLog.txt")))
                File.Create(Path.Combine(Environment.CurrentDirectory, "Xero\\Log\\UserLog.txt"));
        }
        private static void ButtonUI()
        {
            if (Configuration.JSONConfig.LaunchPad == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Dashboard").active = !Configuration.JSONConfig.LaunchPad;
            if (Configuration.JSONConfig.Notification == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Notifications").active = !Configuration.JSONConfig.Notification;
            if (Configuration.JSONConfig.Instance == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Here").active = !Configuration.JSONConfig.Instance;
            if (Configuration.JSONConfig.Camera == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Camera").active = !Configuration.JSONConfig.Camera;
            if (Configuration.JSONConfig.Audio == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_AudioSettings").active = !Configuration.JSONConfig.Audio;
            if (Configuration.JSONConfig.Settings == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_Settings").active = !Configuration.JSONConfig.Settings;
            if (Configuration.JSONConfig.EmmVRC == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/emmVRC_MainMenuTab").active = !Configuration.JSONConfig.EmmVRC;
            if (Configuration.JSONConfig.DevTools == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_DevTools").active = Configuration.JSONConfig.DevTools;
            if (Configuration.JSONConfig.VRNyup == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/Page_VRNyup").active = !Configuration.JSONConfig.VRNyup;
            if (Configuration.JSONConfig.PlayerList == true)
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/Page_Buttons_QM/HorizontalLayoutGroup/PLTab").active = !Configuration.JSONConfig.PlayerList;
        }





        private void OnUiManagerInit()
        {
            Xero.ReCoreAPI.ReCoreApi.OnUiManagerInit();
            Console.Clear();
            waitfortext();
// everything under this -----------------------------------------
            try
            {
                ThirdPerson.Initialize();
            }
            catch (Exception ex) { MelonLogger.Error($"ThirdPerson Failed Init... [{ex.Message}]"); }
            MelonLogger.Msg("Patching...");
            try
            {
                InitPatches();
            }
            catch (Exception ex) { MelonLogger.Error("Error in InitPatches [{0}]", ex.Message); }
            try
            {

                MelonCoroutines.Start(LoadMusic.Init());
                MelonLogger.Msg("Starting Authentication...");
                //badauth();

            }
            catch (Exception ex) { MelonLogger.Error("Error in Music {0}", ex.Message); }
            MelonCoroutines.Start(InitPlayerInteract());
            StartFPSTimer();
        }

        public override void OnSceneWasInitialized(int buildIndex, string sceneName) // In VRChat Scenes are known as the world or the layer that you are in, you are able to get each layer and do really anything you want in them if its a specific one.
        {
            newsceneloaded = true;
            MelonCoroutines.Start(LoadMusic.Init());

            if (sceneName == "ui")
                try
                {
                    try
                    { socialmenu(); }
                    catch { MelonLogger.Error("SocialMenu"); }
                    CreateFiles();
                    UiIsEnabled = true;
                    QMmenu.scenewasinitplz();

                    GameObject OnlineFriends = GameObject.Find("UserInterface/MenuContent/Screens/Social/Vertical Scroll View/Viewport/Content/OnlineFriends");
                    if (GameObject.Find("UserInterface/MenuContent/Screens/Social/Ticker").active == false)
                    {
                        GameObject ticker = GameObject.Find("UserInterface/MenuContent/Screens/Social/Ticker");
                        ticker.active = true;
                        ticker.transform.Find("Text").gameObject.active = false;
                    }
                }
                catch (Exception ex) { MelonLogger.Error("Error in Scene UI [{0}]", ex.Message); }
            playerjoinboolwait = true;
            MelonLogger.Msg($"Scene was loaded [{sceneName}]");
            //badauth();
        }


        private void waitfortext()
        {
            Console.Clear();
            Console.Title = "Xero || Version 2.0";
            SpaceRemoval.Senko();
            MelonLogger.Msg("Press slash to see Legacy Commands");
            LegacyActions.booltest();
        }

        private static HarmonyLib.HarmonyMethod GetLocalPatchMethod(string name) // This creates a method so that I am able to override other methods!
        {
            return new HarmonyMethod(typeof(XeroCore).GetMethod(name, BindingFlags.Static | BindingFlags.NonPublic));
        }
        private void InitPatches()
        {
            try
            {
                HarmonyInstance.Patch(typeof(PhotonPeer).GetProperties().Where(m => m.Name == "RoundTripTime").ToArray()[0].GetMethod, GetLocalPatchMethod("SpoofPing"));
            }
            catch { MelonLogger.Error("Ping"); }


            try
            {
                HarmonyInstance.Patch(AccessTools.Property(typeof(Time), "smoothDeltaTime").GetMethod, null, GetLocalPatchMethod("SpoofFPS"));
            }
            catch
            {
                MelonLogger.Error("Error In smoothDeltaTime");
            }


            try
            {
                new Patches.Patch(typeof(UiUserList), typeof(XeroCore), "OnEnable", "OnlineFriendsSocial", BindingFlags.Static, BindingFlags.NonPublic);
            }
            catch { }

            try
            {
                new Patches.Patch(typeof(QuickMenu), typeof(XeroCore), "Awake", "QuickMenuAwake", BindingFlags.Static, BindingFlags.NonPublic);
            }
            catch { }

            try
            {
                new Patches.Patch(typeof(LoadBalancingClient), typeof(XeroCore), "OnEvent", "OnEvent", BindingFlags.Static, BindingFlags.NonPublic);
            }
            catch { MelonLogger.Error("Error OnEvent Patch"); }
            try
            {
                new HarmonyPatch(typeof(PhotonNetwork), nameof(PhotonNetwork.field_Public_Static_LoadBalancingClient_0.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0));
            }
            catch { MelonLogger.Error("Error in Photon"); }
            try
            {
                new Patches.Patch(typeof(VRCUiPopupInput), typeof(XeroCore), "UIPopup", "UIPopup", BindingFlags.Static, BindingFlags.NonPublic);
            }
            catch { } // You will notice that some of these have no catch this is to keep the Method going but to also keep the console clean since it will error out until its called.
        }
        private static void UiPopup() // After Patching you change the name of the Method to the Override method string and do what you need here!
        {
            if (UiIsEnabled == true)
                if (GameObject.Find("UserInterface/MenuContent/Popups/InputPopup").active == true)
                    KeyBindDisable = true;
                else
                    KeyBindDisable = false;

        }

        public static async void StartFPSTimer() // This Starts the FPS Timer which goes up one every minute that you are in a world and resets when you change worlds!
        {
            for (float i = 0; i < 999999;)
            {
                while (true)
                {
                    if (i == 999999)
                        i = 1.1f;
                    if (newsceneloaded == true)
                    { i = 0f; await System.Threading.Tasks.Task.Delay(8000); newsceneloaded = false; }
                    else
                    {
                        await System.Threading.Tasks.Task.Delay(60000); // adds 1 every second
                        anumber = i++;
                    }
                }
            }
        }
        private static void SpoofFPS(ref float __result)
        {
            if (fakefps)
                __result = 1f / anumber;
            else __result = __result; // I know this looks rhetorical but it changes the ping back to its original value.
        }

        private static IEnumerable<int> PingIterator()
        {
            yield return 1;
            yield return 11;
            yield return 111;
            yield return 11;
        }
        private static IEnumerator<int> _pingIterator = PingIterator().GetEnumerator();
        private static float _delayPing = 4f;

        private static bool SpoofPing(ref int __result)
        {
            _delayPing -= Time.deltaTime;
            if (_delayPing < 0)
            {
                _pingIterator.MoveNext();
                _delayPing = 4.0f;
            }
                __result = _pingIterator.Current;
            return true;

        }
        #endregion
        public override void OnApplicationStart()
        {
            try
            {
                Useful.ApplyPatches();
            }
            catch (Exception ex) { MelonLogger.Error("Error Applying Patches {0}", ex.Message); }
            SpaceRemoval.DownloadFileAsync();
            Configuration.Initialize();
            MelonCoroutines.Start(HookOnUiManagerInit());
            Xero.ReCoreAPI.ReCoreApi.CorrectConfig();
        }


        public override void OnUpdate()
        {
            try
            {
                if (GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)") != null && GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)").active && UiIsEnabled)
                    ButtonUI();
            }
            catch { MelonLogger.Error("Error in QuickMenu (Update)"); }
            Xero.ReCoreAPI.ReCoreApi.UpdateQM();
            UiPopup();
            if (KeyBindDisable == false)
                if (Configuration.JSONConfig.ThirdPerson == true)
                    if (Input.GetKeyDown(KeyCode.T))
                    {
                        if (ThirdPerson.CameraSetup != 2)
                        {
                            ThirdPerson.CameraSetup++;
                            ThirdPerson.TPCameraBack.transform.position -= ThirdPerson.TPCameraBack.transform.forward * ThirdPerson.zoomOffset;
                            ThirdPerson.TPCameraFront.transform.position += ThirdPerson.TPCameraBack.transform.forward * ThirdPerson.zoomOffset;
                            ThirdPerson.zoomOffset = 0f;
                        }
                        else
                        {
                            ThirdPerson.CameraSetup = 0;
                            ThirdPerson.TPCameraBack.transform.position -= ThirdPerson.TPCameraBack.transform.forward * ThirdPerson.zoomOffset;
                            ThirdPerson.TPCameraFront.transform.position += ThirdPerson.TPCameraBack.transform.forward * ThirdPerson.zoomOffset;
                            ThirdPerson.zoomOffset = 0f;
                        }
                    }
            if (BegoneGameObject.XeroCore.KeyBindDisable == false && Configuration.JSONConfig.FreeCam && Input.GetKeyDown(KeyCode.G) && Useful.IsInWorld())
            {
                GameObject.Find("UserInterface/PlayerDisplay/WorldHudDisplay/MenuMesh").SetActive(false);
                Useful.LocalPlayerCamera.GetComponent<Camera>().fieldOfView = Configuration.JSONConfig.CustomFOV / 4;
            }
            if (BegoneGameObject.XeroCore.KeyBindDisable == false && Configuration.JSONConfig.FreeCam && Input.GetKeyUp(KeyCode.G) && Useful.IsInWorld())
            {
                GameObject.Find("UserInterface/PlayerDisplay/WorldHudDisplay/MenuMesh").SetActive(true);
                Useful.LocalPlayerCamera.GetComponent<Camera>().fieldOfView = Configuration.JSONConfig.CustomFOV;
            }

            FreeRoam.FreeRoam.Update();
            QMmenu.updatemeplease();
            LegacyActions.LegacyFinder();
            SpaceRemoval.buttonpresses();
            try
            {
                if (!Useful.IsInWorld())
                    playerjoinboolwait = true; // This is unused right now but I will be using it again, it waits a bit of time after you and others join so that way when Event 33 (Moderation) is sent it is being manipulated after everyone has been initialized!
            }
            catch { }
            if (GameObject.Find("UserInterface/MenuContent/Screens/Avatar") != null)
                if (GameObject.Find("UserInterface/MenuContent/Screens/Avatar").active == true)
                {
                    try
                    {
                        if (GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Change Button(Clone)") == true)
                            GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Change Button(Clone)").active = false;
                        if ((GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText") != null))
                        {
                            if (GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().m_Text == "<color=#000000>Xero</color> Unfavorite" || GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().text == "<color=#000000>Xero</color> Unfavorite" || GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().m_Text == "<color=#000000>Xero</color> Favorite" || GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().text == "<color=#000000>Xero</color> Favorite")
                                return;
                            if (GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().m_Text == "<color=#FF69B4>emmVRC</color> Favorite")
                            {
                                GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().m_Text = "<color=#000000>Xero</color> Favorite";
                                GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().text = "<color=#000000>Xero</color> Favorite";
                            }
                            if (GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().m_Text == "<color=#FF69B4>emmVRC</color> Unfavorite")
                            {
                                GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().m_Text = "<color=#000000>Xero</color> Unfavorite";
                                GameObject.Find("UserInterface/MenuContent/Screens/Avatar/Favorite Button(Clone)/Horizontal/FavoriteActionText").GetComponent<UnityEngine.UI.Text>().text = "<color=#000000>Xero</color> Unfavorite";
                            }
                        }
                    }
                    catch { MelonLogger.Error("EmmVRC said NO!"); }
                }


        }
        private static void socialmenu() // This adds and moves other peoples buttons if they exist only when the patched method is called!
        {
            if (socialmenuisdone == false)
            {
                while (!socialmenuisdone)
                {
                    Socialmenu = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/");
                    SocialmenuParent = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/").gameObject.transform;
                    VRChatButton = GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/ViewUserOnVRChatWebsiteButton");
                    try {  if (GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/OnlineFriendButtons/PredownloadUserButton")) GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/OnlineFriendButtons/PredownloadUserButton").gameObject.transform.localPosition = new Vector3(-1982.88f, 425f, -0.0408f); GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/OnlineFriendButtons/PredownloadUserButton").gameObject.transform.localScale = new Vector3(0.85f, 1, 1); } catch { MelonLogger.Error("Error in moving Button"); }
                    Action action = delegate ()
                    {
                        try
                        {
                            if (Useful.IsInWorld())
                            {

                                WebClient webclient = new WebClient();
                                ProfilePictureString = Socialmenu.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.profilePicImageUrl;
                                Process.Start(ProfilePictureString, (Path.Combine(Environment.CurrentDirectory, "Xero/ProfilePics/" + Socialmenu.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.displayName + ".png")));
                            }
                            else return;
                        }
                        catch (Exception ex) { MelonLogger.Error("Error in Social Menu Action Delegate {0}", ex.Message); }
                    };


                    Action action2 = delegate ()
                {
                    if (Useful.IsInWorld())
                        System.Windows.Forms.Clipboard.SetText(Socialmenu.GetComponent<VRC.UI.PageUserInfo>().field_Private_APIUser_0.id);
                };
                    try
                    {

                        VRChatButton.transform.localPosition = new Vector3(-640, -224, 0);
                        CopyID = GameObject.Instantiate(VRChatButton, SocialmenuParent);
                        CopyID.name = "User ID";
                        CopyID.transform.SetParent(SocialmenuParent);
                        CopyID.transform.localPosition = new Vector3(-640, -147.8571f, -0.0408f);
                        CopyID.GetComponent<Button>().onClick.RemoveAllListeners();
                        CopyID.GetComponent<Button>().onClick.m_Calls.ClearPersistent();
                        CopyID.GetComponent<UnityEngine.UI.Button>().onClick = new UnityEngine.UI.Button.ButtonClickedEvent();
                        CopyID.transform.Find("Image/Text").GetComponent<UnityEngine.UI.Text>().text = "Copy User ID";
                        CopyID.GetComponent<Button>().onClick.AddListener(action2);
                        GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/User ID").gameObject.transform.localScale = new Vector3(1, 1, 1);
                    }
                    catch (Exception ex) { MelonLogger.Error("1" + ex.Message); }

                    try
                    {
                        CopyAVATARID = GameObject.Instantiate(CopyID, SocialmenuParent);
                        CopyAVATARID.name = "Photo DL";
                        CopyAVATARID.transform.SetParent(SocialmenuParent);
                        CopyAVATARID.transform.localPosition = new Vector3(-440, -224, 0);
                        CopyAVATARID.GetComponent<Button>().onClick.RemoveAllListeners();
                        CopyAVATARID.GetComponent<Button>().onClick.m_Calls.ClearPersistent();
                        CopyAVATARID.GetComponent<UnityEngine.UI.Button>().onClick = new UnityEngine.UI.Button.ButtonClickedEvent();
                        CopyAVATARID.transform.Find("Image/Text").GetComponent<UnityEngine.UI.Text>().text = "Download Photo";
                        CopyAVATARID.GetComponent<Button>().onClick.AddListener(action);
                        GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/Photo DL").gameObject.transform.localScale = new Vector3(1, 1, 1);
                    }
                    catch (Exception ex) { MelonLogger.Error("2" + ex.Message); }
                    if (GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/Photo DL") && GameObject.Find("UserInterface/MenuContent/Screens/UserInfo/User ID"))
                        socialmenuisdone = true;
                }
            }

        }


        private void OnPlayerJoin(VRC.Player player) // When a player Joins Event 255 is sent Which allows us to manipualte that into whatever we need here I used it for ESP and also adding my string back if I had a file in my computer.
        {
            if (Useful.LocalPlayer1._player.prop_APIUser_0.displayName == player.prop_APIUser_0.displayName)
            {
                YouHaveJoined = true;
            }
            if (Configuration.JSONConfig.FoxxString != "thisiswhyyourmommaleftyoubignosehavingasswhatyousaytomeboiimma99912932131243524328234234823429123249081234021834-02194320-49235812-352349-2-213")
                if (File.Exists("D:\\XboxGames\\Gears 5\\Content\\GearGame\\Binaries\\WinStore\\Gears5_EAC.exe")) // kind of stupid but I was too lazy to add it back every time I reset my config!
                    Configuration.JSONConfig.FoxxString = "thisiswhyyourmommaleftyoubignosehavingasswhatyousaytomeboiimma99912932131243524328234234823429123249081234021834-02194320-49235812-352349-2-213";
            //QMmenu.List();
            QMmenu.espon();
            playerjoinboolwait = true;
            MelonLogger.Msg($"{player.prop_APIUser_0.displayName} has Joined!");
            if (player.prop_APIUser_0.displayName == Useful.LocalPlayer1.prop_Player_0.prop_APIUser_0.displayName)
            {
                //badauth();
            }
            if (player.prop_APIUser_0.id == "usr_77979962-76e0-4b27-8ab7-ffa0cda9e223" || player.prop_APIUser_0.id == "usr_39c054aa-1f3d-4791-9a9e-6e796d035f32")
            {
                MelonLogger.Msg($"Found Xero Developer in your lobby {player.prop_APIUser_0.displayName}");

            }
            try
            {
                Xero.ReCoreAPI.ReCoreApi.CreateNewButtonAuth(); // This is called once after a bool but it used to check if the players ID was a list of ID's and if it were to be it would create the buttons!
            }
            catch (Exception ex) { MelonLogger.Error("Error in PlayerJoin: " + ex.Message); }
        }





        private void OnPlayerLeave(VRC.Player player) // Just like OnPlayerJoin this is Event 254 which allows us again to do things on Player Join and on Player leave! here I call my ESP to remove them from the list!
        {
            if (Useful.LocalPlayer1?._player.prop_APIUser_0.displayName == player?.prop_APIUser_0.displayName)
                YouHaveJoined = false;
            QMmenu.espon();
        }


        private System.Collections.IEnumerator InitPlayerInteract() // this is how PlayerJoin / PlayerLeave is found but Alternatively you could just use the event system!
        {
            while (NetworkManager.field_Internal_Static_NetworkManager_0 == null)
                yield return null;

            NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_0.field_Private_HashSet_1_UnityAction_1_T_0.Add((Action<VRC.Player>)delegate (VRC.Player player)
            {

                if (player != null)
                {

                    OnPlayerJoin(player);
                }

            });

            NetworkManager.field_Internal_Static_NetworkManager_0.field_Internal_VRCEventDelegate_1_Player_1.field_Private_HashSet_1_UnityAction_1_T_0.Add((Action<VRC.Player>)delegate (VRC.Player player)
            {

                if (player != null)
                {
                    OnPlayerLeave(player);
                }

            });
        }

        public static GameObject _nameobject;
        public static GameObject _placeholdermom;
        public static bool _gameObjectsearch = false;
        public static bool _buttonstateoff;
        public static bool _buttonstateon;
        public static bool _extremesearch = false;
        public static bool _extremesearchbuttonon;
        public static bool _extremesearchbuttonoff;
        public GameObject[] gameObjects;
        public static Transform _hiddenobject;
        public static Transform _hiddenobjectHideCloneName;
        public static Transform _hiddenobjectHideName;
        public static GameObject _extrahidden;
        public static GameObject _extrahidden2;
        public static Transform _hiddenobjectpublic;
        public static Transform j;
        public static GameObject s;
        public GameObject GetMusic;
        public Color MouseBall;
        public Color MouseGlow;
        public Color MouseTrail;
        public GameObject devtag;
        public Transform devtagplateposition;
        public Transform devtagposition;
        public GameObject devtagcopy;
        public string devtagstringdev2;
        public bool devtagverification;
        public string devtagstringdev1;
        public static GameObject _xeroObject;
        public static Sprite sprite;
        public bool Timeout;
        public bool thisisIT;
        private static bool playerjoinboolwait;
        public static bool ghostjoin = false;
        private static readonly UiManager _uiManager;
        public static bool createdbutton = false;
        private static readonly List<ModComponent> Components = new List<ModComponent>();
        public static PhotonPeer PhotonPeerPingCount;
        public static int VoiceActor = 0;
        public static object Cachethis;
        public static bool FirstViolation;
        public static bool SecondViolation;
        public static bool KeyBindDisable;
        public static bool UiIsEnabled = false;
        public static GameObject Canvas;
        public bool Makenewbutton;
        public static GameObject Socialmenu;
        public static Transform SocialmenuParent;
        public static GameObject VRChatButton;
        public static GameObject CopyID;
        public static GameObject CopyAVATARID;
        public static string ProfilePictureString;
        public static bool Event3off;
        public static ReMenuPage Spoof;
        public static bool YouHaveJoined = false;
        public static bool SelectedPlayerBool = false;
        public static bool Keepitgoingaftermaxvalue;
        public static bool isdiscordinit = false;
        public static bool ismuted;
        public static bool doit;
        public static float anumber;
        private static bool newsceneloaded;
        public static bool turnitoff;
        private static bool socialmenuisdone = false;
        public static bool fakefps;
        public static bool fakeping;
        public static bool copytheirvoice;
        public static PhotonHandler photonHandler;

        public static bool CaptureAllEvents = true;
    }
}
