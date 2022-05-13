using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VRC;
using BegoneGameObject;
using System.Reflection;
using UnhollowerRuntimeLib;
using System.Collections;
using System.IO;
using UnityEngine.Networking;
using VRC.SDKBase;
using VRC.Core;
using VRC.UI;
using MelonLoader;
using GameObjectBegone.APi.Utils;
using VRC.DataModel;
using UIExpansionKit;
using Patch = Patches.Patch;
using ReMod.Core.VRChat;
using UnityEngine.Audio;
using UnhollowerBaseLib;

namespace Xero
{
    public static class Useful
    {
        public static APIUser GetAPIUser(this VRC.Player player)
        {
            APIUser result;
            try
            {
                result = player.prop_APIUser_0;
            }
            catch
            {
                result = player.prop_APIUser_0;
            }
            return result;
        }
        public static VRC.Player GetPlayerUserID(string UserID)
        {
            VRC.Player result;
            try
            {
                Il2CppSystem.Collections.Generic.List<VRC.Player> field_Private_List_1_Player_ = PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0;
                VRC.Player player = null;
                for (int i = 0; i < field_Private_List_1_Player_.Count; i++)
                {
                    VRC.Player player2 = field_Private_List_1_Player_[i];
                    bool flag = player2.prop_APIUser_0.id == UserID;
                    if (flag)
                    {
                        player = player2;
                    }
                }
                result = player;
            }
            catch
            {
                result = null;
            }
            return result;
        }
        public static VRC.Player GetPlayerByMenu()
        {
            VRC.Player result;
            try
            {
                result = GetPlayerUserID(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").GetComponent<VRC.UI.Elements.Menus.SelectedUserMenuQM>().field_Private_IUser_0.prop_String_0);
            }
            catch
            {
                result = null;
            }
            return result;
        }
        public static List<Player> Players
        {
            get
            {
                return PlayerManager.field_Private_List_1_Player_0.ToArray().ToList<Player>();

            }
        }
        public static void AlertPopup(this VRCUiPopupManager manager, string title, string text)
        {
            manager.Method_Public_Void_String_String_Single_0(title, text, 10f);
        }
        public static PageUserInfo UserInfoInstance { get; private set; }
        public static MenuController MenuControllerInstance => UserInfoInstance.field_Public_MenuController_0;
        public static AudioMixerGroup GetVoiceAudioMixerGroup()
        {
            AudioMixerGroup result = VRCAudioManager.Method_Public_Static_AudioMixerGroup_0();
            Il2CppReferenceArray<AudioMixerGroup> il2CppReferenceArray = VRCAudioManager.field_Private_Static_VRCAudioManager_0.field_Public_AudioMixer_0.FindMatchingGroups("Voice");
            if (il2CppReferenceArray.Length <= 0)
            {
                return result;
            }
            return il2CppReferenceArray.First<AudioMixerGroup>();
        }
        public static AudioSource CreateAudioSource()
        {
            GameObject gameObject = new GameObject("Copy Player");
            UnityEngine.Object.DontDestroyOnLoad(gameObject);
            AudioSource audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.spatialBlend = 0f;
            return audioSource;
        }
        public static AudioClip CreateAudioClipFromStream(byte[] buffer)
        {
            AudioClip audioClip = AudioClip.Create("Copy Player", buffer.Length, 1, 48000, false);
            Il2CppStructArray<float> il2CppStructArray = new Il2CppStructArray<float>((long)buffer.Length);
            for (int i = 0; i < buffer.Length; i++)
            {
                il2CppStructArray[i] = ((float)buffer[i] - 128f) / 128f;
            }
            audioClip.SetData(il2CppStructArray, 0);
            return audioClip;
        }
        public static void PlayerSelected(Player player)
        {
            if (player != null)
            {
                Useful.QuickMenuInstance.Method_Public_Void_Player_0(player);
                SelectedQMPlayer = player;
            }
        }

        public static VRC.UI.Elements.Menus.SelectedUserMenuQM SelectedUserLocal { get; }


        public static VRC.Player XeroSelectedUser
        {
            get
            {
                IUser field_Private_IUser_ = QuickMenuEx.SelectedUserLocal.field_Private_IUser_0;
                Player player = PlayerManager.field_Private_Static_PlayerManager_0.GetPlayer(field_Private_IUser_.prop_String_0);
                VRCPlayer vrcplayer = player.GetVRCPlayer();

                return vrcplayer._player;
            }
        }
        public static Player GetPlayer(this VRCPlayer vrcPlayer)
        {
            return vrcPlayer._player;
        }

        public static APIUser SelectedUser
        {
            get
            {
                return UserSelectionManager.field_Private_Static_UserSelectionManager_0.field_Private_APIUser_1;
            }
        }

        public static object GetPhotonPlayer(this Player player)
        {
            PropertyInfo propertyInfo5 = typeof(Player).GetProperties().First((PropertyInfo p) => p.PropertyType == photonPlayerType);
            photonPlayerType = typeof(Player).GetProperties().First((PropertyInfo p) => p.GetGetMethod().Name == "get_PhotonPlayer").PropertyType;
            getPhotonPlayerMethod = ((propertyInfo5 != null) ? propertyInfo5.GetGetMethod() : null);
            return getPhotonPlayerMethod.Invoke(player, null);
        }
        internal static object CurrentRoom()
        {
            return m_getCurrentRoom.Invoke(null, null);
        }

        internal static object[] AllPlayers()
        {
            Dictionary<int, object> dictionary = new Dictionary<int, object>();
            foreach (object obj in ((IDictionary)m_getAllPlayers.Invoke(CurrentRoom(), null)))
            {
                DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
                dictionary.Add((int)dictionaryEntry.Key, dictionaryEntry.Value);
            }
            return dictionary.Values.ToArray<object>();
        }

        public static Player GetSelectedPlayer()
        {
            return GetPlayerUserID(GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_SelectedUser_Local").GetComponent<VRC.UI.Elements.Menus.SelectedUserMenuQM>().field_Private_IUser_0.prop_String_0);
        }


        public static void ChangeAVIFromString(string stwing)
        {
            try
            {
                avatarObject = new GameObject();
                avatarObject.name = "DESTROYMEPLEASE";
                var avatarPedestal = avatarObject.AddComponent<AvatarPedestal>();
                a = new ApiAvatar
                {
                    id = stwing
                };
                avatarPedestal.field_Private_ApiAvatar_0 = a;
                // Need to test these later.
                avatarPedestal.Method_Private_Void_4();
                GameObject.Destroy(avatarObject);
            }
            catch
            {
                if (stwing.StartsWith("avtr_"))
                {
                    MelonLogger.Msg("Avatar is Private!");
                }
                else
                {
                    MelonLogger.Msg("Invalid Avatar ID");
                }
                if (GameObject.Find("DESTROYMEPLEASE"))
                {
                    GameObject.Destroy(avatarObject);
                }
            }
        }

        public static void ApplyPatches()
        {
            try
            {
                if (SelectedQMPlayer != null)
                    QuickMenuPlayerSelect.QuickMenuPlayerSelected += PlayerSelected;
            }
            catch (Exception ex) { MelonLogger.Error($"Error in Patch (PlayerSelected) {ex.Message}"); }
        }


        public static void ChangeFromRawAvatar()
        {
            avatar = Useful.SelectedQMPlayer.prop_ApiAvatar_0;
            var avatarObject = new GameObject();
            var avatarPedestal = avatarObject.AddComponent<AvatarPedestal>();
            avatarPedestal.field_Private_ApiAvatar_0 = Useful.SelectedQMPlayer.prop_ApiAvatar_0;
            // need to test later.
            avatarPedestal.Method_Private_Void_2();
            // Method_Private_Void_PDM_7 = Old Method_Private_Void_PDM_ = new 
            // Method_Private_Void_PDM_11 = MultiSourceFrame
            // Method_Private_Void_PDM_3 - 5 - 7 - 10 = statusCode 
            // Method_Private_Void_PDM_8 = null
            // Method_Private_Void_PDM_0 - 1 - 2 - 4 - 6 - 9 - 12 - 13 - 14 - 15 - 16... = No Error but Do not work
            GameObject.Destroy(avatarObject);
        }


        public static void ChangeAvatar(string AvatarID)
        {
            new PageAvatar
            {
                field_Public_SimpleAvatarPedestal_0 = new SimpleAvatarPedestal
                {
                    field_Internal_ApiAvatar_0 = new ApiAvatar
                    {
                        id = AvatarID
                    }
                }
            }.ChangeToSelectedAvatar();
        }

        public static VRCUiPopupManager GetVRCUiPopupManager()
        {
            return Resources.FindObjectsOfTypeAll<VRCUiPopupManager>()[0];
        }
        public static Player localplayer2
        {
            get
            {
                return Player.prop_Player_0;
            }
        }
        public static VRCPlayerApi LocalPlayer
        {
            get
            {
                return Networking.LocalPlayer;
            }
        }
        public static string GetSteamID(this VRCPlayer player)
        {
            return player.field_Private_UInt64_0.ToString();
        }
        public static ApiWorldInstance GetInstance()
        {
            return RoomManager.field_Internal_Static_ApiWorldInstance_0;
        }
        public static PlayerManager PlayerManager
        {
            get
            {
                return GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            }
        }
        public static string SongDirectory
        {
            get
            {
                return Environment.CurrentDirectory + "\\Audio";
            }
        }
        public static VRCPlayer LocalPlayer1
        {
            get
            {
                return VRCPlayer.field_Internal_Static_VRCPlayer_0;
            }
        }
        public static bool IsInWorld()
        {
            return RoomManager.field_Internal_Static_ApiWorld_0 != null;
        }
        public static void FreezeLocalPlayer(bool Enabled)
        {
            if (LocalPlayerCollider == null)
            {
                LocalPlayerCollider = LocalPlayer1.GetComponent<Collider>();
            }
            LocalPlayerCollider.enabled = !Enabled;
        }


        public static class QuickMenuPlayerSelect
        {
            public static event Action<Player> _quickMenuPlayerSelected;

            public static event Action<Player> QuickMenuPlayerSelected
            {
                add => _quickMenuPlayerSelected += value;
                remove => _quickMenuPlayerSelected += value;
            }

            private static void Prefix(Player player)
            {
                _quickMenuPlayerSelected?.Invoke(player);
            }
        }
        public static QuickMenu QuickMenuInstance =>
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)").GetComponent<QuickMenu>();
        public static QuickMenu QuickMenuInstance2 =>
                GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)").GetComponent<QuickMenu>();

        public static void SelectedPlayerQM(Player player)
        {
            QMStuff.ShowQuickmenuPage("");
            Useful.QuickMenuInstance.Method_Public_Void_Player_0(player);
        }
        public static void InitOnPlayerJoinLeavePatch()
        {
            MethodInfo[] array = (from m in typeof(NetworkManager).GetMethods()
                                  where m.Name.Contains("Method_Public_Void_Player_") && !m.Name.Contains("PDM")
                                  select m).ToArray<MethodInfo>();
            new Patch(typeof(NetworkManager), typeof(XeroCore), array[0].Name, "OnPlayerLeft", BindingFlags.Static, BindingFlags.NonPublic);
            new Patch(typeof(NetworkManager), typeof(XeroCore), array[1].Name, "OnPlayerJoined", BindingFlags.Static, BindingFlags.NonPublic);
            new Patch(typeof(NetworkManager), typeof(XeroCore), "Method_Public_Virtual_Final_New_Void_EventData_0", "OnEvent", BindingFlags.Static, BindingFlags.NonPublic);
        }
        private static Cubemap LoadCubemap(string cubemap)
        {
            UnityWebRequest assetBundleRequest;
            assetBundleRequest = null;
            File.WriteAllBytes(Path.Combine(Useful.dependenciesPath, "Useful.XeroCore"), assetBundleRequest.downloadHandler.data);
            AssetBundleCreateRequest dlBundle = AssetBundle.LoadFromMemoryAsync(assetBundleRequest.downloadHandler.data);
            Useful.Bundle = dlBundle.assetBundle;
            Cubemap cubemap2 = Useful.Bundle.LoadAsset(cubemap, Il2CppType.Of<Cubemap>()).Cast<Cubemap>();
            cubemap2.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            return cubemap2;
        }
        public static IEnumerator LoadResources()
        {
            Useful.blankGradient = Useful.LoadCubemap("Gradient.png");

            yield break;
        }
        public static GameObject GetVRCamera
        {
            get
            {
                if (VRCamera == null)
                {
                    VRCamera = GameObject.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck/Camera (eye)");
                }
                return (GameObject)VRCamera;
            }
        }


        public static GameObject LocalPlayerCamera
        {
            get
            {
                return GameObject.Find("Camera (eye)");
            }
        }

        public static GameObject CreateCamera(float fov, bool forwards, float DistanceMultiplier = 2f, bool AttachToPlayer = true)
        {
            GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);
            UnityEngine.Object.Destroy(gameObject.GetComponent<MeshRenderer>());
            gameObject.transform.localScale = Camera.transform.localScale;
            Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
            gameObject.GetComponent<Collider>().enabled = false;
            gameObject.GetComponent<Renderer>().enabled = false;
            Camera camera = gameObject.AddComponent<Camera>();
            camera.nearClipPlane = 0.01f;
            if (AttachToPlayer)
            {
                gameObject.transform.parent = Camera.transform;
            }
            gameObject.transform.SetPositionAndRotation(Camera.transform.position, Camera.transform.rotation);
            if (forwards)
            {
                gameObject.transform.Rotate(0f, 180f, 0f);
                gameObject.transform.position += -gameObject.transform.forward * DistanceMultiplier;
            }
            else
            {
                gameObject.transform.position += -gameObject.transform.forward * DistanceMultiplier;
            }
            Camera.enabled = false;
            Camera component = gameObject.GetComponent<Camera>();
            component.fieldOfView = fov;
            component.enabled = false;
            return gameObject;
        }

        private static Camera Camera
        {
            get
            {
                return CameraObject.GetComponent<Camera>();
            }
        }
        public static VRCUiManager GetVRCUiMInstance()
        {
            return VRCUiManager.prop_VRCUiManager_0;
        }
        public static QuickMenu GetQuickMenuInstance()
        {
            return QuickMenu.prop_QuickMenu_0;
        }
        private static GameObject CameraObject
        {
            get
            {
                return Useful.LocalPlayerCamera;
            }
        }





        public static object VRCamera { get; private set; }
        public static object selectQM { get; private set; }
        public static VRCPlayer NewPlayerMethod { get; private set; }

        public static Player SelectedQMPlayer;
        public static VRCPlayer NewMethod(VRCPlayer vrCPlayer)
        {
            IUser field_Private_IUser_ = QuickMenuEx.SelectedUserLocal.field_Private_IUser_0;
            if (field_Private_IUser_ != null)
            {
                Player player = PlayerManager.field_Private_Static_PlayerManager_0.GetPlayer(field_Private_IUser_.prop_String_0);
                if (player != null)
                {
                    VRCPlayer vrcPlayer = player.GetVRCPlayer();
                    if (vrcPlayer != null)
                        NewPlayerMethod = vrcPlayer;
                }
            }
            return vrCPlayer = NewPlayerMethod;
        }

        public static VRCPlayerApi GetVRCPlayerApi(this Player player)
        {
            return player.field_Private_VRCPlayerApi_0;
        }
        public static int GetActorNumber(Player player)
        {
            return player.GetVRCPlayerApi().playerId;
        }

        public static void SendVRCEvent(VRC_EventHandler.VrcEvent vrcEvent, VRC_EventHandler.VrcBroadcastType type, GameObject instagator)
        {
            if (Useful.handler == null)
            {
                Useful.handler = Resources.FindObjectsOfTypeAll<VRC_EventHandler>().FirstOrDefault<VRC_EventHandler>();
            }
            vrcEvent.ParameterObject = Player.prop_Player_0.prop_USpeaker_0.gameObject;
            Useful.handler.TriggerEvent(vrcEvent, type, instagator, 0f);
        }

        internal static class Misc
        {
            public static IEnumerator DelayAction(float delay, System.Action action)
            {
                yield return new WaitForSeconds(delay);
                action();
                yield break;
            }
        }
        public static VRCPlayer LocalVRCPlayer
        {
            get
            {
                return VRCPlayer.field_Internal_Static_VRCPlayer_0;
            }
        }
        public static APIUser LocalAPIUser
        {
            get
            {
                return APIUser.CurrentUser;
            }
        }
        public static USpeaker LocalUSpeaker
        {
            get
            {
                return Useful.LocalVRCPlayer.field_Private_USpeaker_0;
            }
        }
        public static VRCPlayerApi LocalVRCPlayerAPI
        {
            get
            {
                return Useful.LocalVRCPlayer.field_Private_VRCPlayerApi_0;
            }
        }
        public static PlayerManager PManager
        {
            get
            {
                return PlayerManager.field_Private_Static_PlayerManager_0;
            }
        }
        public static ApiAvatar GetAPIAvatar(this Player player)
        {
            return player.prop_ApiAvatar_0;
        }

        public static PlayerNet GetPlayerNet(this Player player)
        {
            return player.prop_PlayerNet_0;
        }

        public static USpeaker GetUSpeaker(this Player player)
        {
            return player.prop_USpeaker_0;
        }
        public static bool IsQuest(this Player player)
        {
            return player.GetAPIUser().IsOnMobile;
        }
        public static void ToggleBlock(this Player player)
        {
            PageUserInfo pageUserInfo = player.GetPageUserInfo();
            if (!player.IsLocalPlayer())
            {
                pageUserInfo.ToggleBlock();
            }
        }
        public static void ToggleMute(this Player player)
        {
            PageUserInfo pageUserInfo = player.GetPageUserInfo();
            if (!player.IsLocalPlayer())
            {
                pageUserInfo.ToggleMute();
            }
        }
        private static PageUserInfo GetPageUserInfo(this Player player)
        {
            PageUserInfo component = GameObject.Find("Screens").transform.Find("UserInfo").GetComponent<PageUserInfo>();
            component.field_Private_APIUser_0 = new APIUser
            {
                id = player.GetAPIUser().id
            };
            return component;
        }
        public static GameObject InstantiatePrefab(string PrefabNAME, Vector3 position, Quaternion rotation)
        {
            return Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, PrefabNAME, position, rotation);
        }

        public static void Mute(bool toggle)
        {
            DefaultTalkController.field_Private_Static_Boolean_0 = toggle;
        }

        public static void SetVolume(this Player player, float vol)
        {
            player.GetUSpeaker().field_Private_SimpleAudioGain_0.field_Public_Single_0 = vol;
        }

        public static float GetVolume(this Player player)
        {
            return player.GetUSpeaker().field_Private_SimpleAudioGain_0.field_Public_Single_0;
        }
        public static bool IsLocalMuted(this Player player)
        {
            return player.GetVolume() == 0f;
        }
        public static void LocalMute(this Player player)
        {
            player.SetVolume(0f);
        }

        public static void LocalUnMute(this Player player)
        {
            player.SetVolume(1f);
        }

        public static bool IsInVR(this Player player)
        {
            return player.GetVRCPlayerApi().IsUserInVR();
        }

        public static void Teleport(this Player player)
        {
            Useful.LocalVRCPlayer.transform.position = player.GetVRCPlayer().transform.position;
        }
        public static void ReloadAvatar(this Player player)
        {
            VRCPlayer.Method_Public_Static_Void_APIUser_0(player.GetAPIUser());
        }
        public static QuickMenu GetQuickMenu()
        {
            return GameObject.Find("UserInterface/QuickMenu").GetComponent<QuickMenu>();
        }
        public static void ReloadAllAvatars()
        {
            Useful.LocalVRCPlayer.Method_Public_Void_Boolean_0(false);
        }

        public static VRCAvatarManager GetVRCAvatarManager(this VRCPlayer player)
        {
            return player.prop_VRCAvatarManager_0;
        }
        public static string GetName(this Player player)
        {
            return player.GetAPIUser().displayName;
        }

        public static float LocalGain
        {
            get
            {
                return USpeaker.field_Internal_Static_Single_1;
            }
            set
            {
                USpeaker.field_Internal_Static_Single_1 = value;
            }
        }
        public static float AllGain
        {
            get
            {
                return USpeaker.field_Internal_Static_Single_0;
            }
            set
            {
                USpeaker.field_Internal_Static_Single_0 = value;
            }
        }

        public static float DefaultGain
        {
            get
            {
                return 1f;
            }
        }
        public static float MaxGain
        {
            get
            {
                return float.MaxValue;
            }
        }

        public static GameObject CachedPlayerCamera { get; private set; }
        public static AssetBundle Bundle { get; private set; }
        public static Collider LocalPlayerCollider { get; private set; }

        public static bool IsMaster(this Player player)
        {
            return player.GetVRCPlayerApi().isMaster;
        }



        public static int GetPlayerFrames(this Player player)
        {
            if (player.GetPlayerNet().field_Private_Byte_0 == 0)
            {
                return 0;
            }
            return (int)(1000f / (float)player.GetPlayerNet().field_Private_Byte_0);
        }

        public static int GetPlayerPing(this Player player)
        {
            return (int)player.GetPlayerNet().field_Private_Int16_0;
        }
        public static void ToggleBlock(string player)
        {
        }

        public static bool IsLocalPlayer(this Player player)
        {
            return player.GetAPIUser().id == APIUser.CurrentUser.id;
        }
        public static void SetGain(float Gain)
        {
            Useful.LocalGain = Gain;
        }

        public static void ResetGain()
        {
            USpeaker.field_Internal_Static_Single_1 = Useful.DefaultGain;
        }

        public static Player[] GetAllPlayers()
        {
            return PlayerManager.field_Private_Static_PlayerManager_0.field_Private_List_1_Player_0.ToArray();
        }
        public static GameObject menuContent(this VRCUiManager mngr)
        {
            return mngr.field_Public_GameObject_0;
        }

        private static VRC_EventHandler handler;
        private static Cubemap blankGradient;
        private static ApiAvatar avatar;
        public static GameObject SingleButtonReference;
        public static GameObject ToggleButtonReference;
        public static Transform NestedButtonReference;
        private static Vector3 QuickMenuColliderSizeNormal = Vector3.zero;
        private static Vector3 QuickMenuColliderPositionNormal = Vector3.zero;
        public static FieldInfo currentPageGetter;
        internal static MethodInfo m_getCurrentRoom;
        public static string dependenciesPath = Path.Combine(Environment.CurrentDirectory, "Dependencies");
        private static ApiAvatar a;
        private static GameObject avatarObject;
        private static Type photonPlayerType;
        internal static MethodInfo m_getAllPlayers;
        private static MethodInfo getPhotonPlayerMethod;
        internal static object _selectedUserManagerObject;

    }

}
