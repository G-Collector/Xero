using UnityEngine;
using System;
using MelonLoader;
using Xero;
using System.Windows.Forms;
using VRC.SDKBase;

namespace XeroButtons
{
    public class QMmenu // After a Huge update Everything here was broken and I keep it here for rememberance but also because I still use things here, I know I can move.

    {
        public static bool playeresp;
        public static Sprite ButtonImage = null;
        public static string avatarsPath = System.IO.Path.Combine(Environment.CurrentDirectory, "Xero\\Config\\AvatarFavorites.json");

        public static bool antiblock { get; private set; }
        public static object SelectedPlayer { get; private set; }
        public static object SelectedUserMenu { get; private set; }

        public static String DisplayNameOfSelectedUser = "Null";

        public static bool infjumpstate;
        public static bool objectesp;


        public static async void Wait()
        {
            await System.Threading.Tasks.Task.Delay(5000);
            MelonLogger.Msg("Loading UI...");
            Turnon();
        }
        public static void scenewasinitplz()
        {
            //Wait();
            //ButtonAPI.OnInit += () =>
            //{
            //    var Page = new MenuPage("Xero", "Xero Menu");
            //    var FunctionalGroup = new ButtonGroup(Page, "Functional Options");
            //    var userpage = new MenuPage("UserMenu2", "UserPage2");
            //    new Tab(Page, "Main Menu", (Environment.CurrentDirectory + "\\Xero\\Images\\Senko.png").LoadSpriteFromDisk());
            //    var s = new MenuPage("true", "true", true, true, false);
            //    var esp = new CollapsibleButtonGroup(Page, "ESP", "ESP");
            //    var Shmovement = new CollapsibleButtonGroup(Page, "Shmovement", "Movement stuff");
            //    var world = new CollapsibleButtonGroup(Page, "World", "Toggles The World Dropdown");
            //    var exploits = new CollapsibleButtonGroup(Page, "Exploits", "Toggles Exploit DropDown");
            //    var config = new ButtonGroup(Page, "Configuration");
            //    var options = new ButtonGroup(userpage, "Options");
            //    new SingleButton(options, "Force Clone Avatar", $"Force Clones the Avatar of The Selected User", () =>
            //    {
            //        string avatar;
            //        avatar = Useful.SelectedPlayer.prop_ApiAvatar_0.id;
            //        Useful.ChangeAVIFromString(avatar);
            //    }, false);
            //    #region DropDown World:
            //    new SingleButton(world, "Get World ID", "Get World ID", () =>
            //    {
            //        string wrld = RoomManager.field_Internal_Static_ApiWorld_0.id + ":" + Useful.GetInstance().instanceId;
            //        Clipboard.SetText(wrld);
            //    }, false);
            //    new SingleButton(world, "Join World ID", "Join The World ID by ClipBoard", () =>
            //    {
            //        Networking.GoToRoom(Clipboard.GetText());
            //        GameObject gameobject = new GameObject();
            //    }, false);
            //    new SingleButton(world, "Rejoin Instance", "Rejoins Current Instance", () =>
            //    {
            //        Networking.GoToRoom(RoomManager.field_Internal_Static_ApiWorld_0.id + ":" + Useful.GetInstance().instanceId);
            //    }, false);
            //    #endregion

            //    saveconfigbutton = new SingleButton(config, "Save Config", "Saves Config", () =>
            //    {
            //        Xero.Configer.Configuration.SaveConfig();
            //    }, false);

            //    new ToggleButton(exploits, "Turns On Exploit", "Turns off Exploits", "The Exploit is on", (abool) =>
            //    {
            //        xerolagx.XeroLag2.invalidobject = abool;
            //    }).SetToggleState(false, true);

            //    new ToggleButton(exploits, "Turns on Anti-Block", "Turns Off Anti-Block", "Anti-Block is on", (anti) =>
            //    {
            //        Xero.Configer.Configuration.JSONConfig.AntiBlock = anti;
            //    }).SetToggleState(false, true);

            //    new ToggleButton(Shmovement, "Infinite Jump", "Turns off Infinite Jump", "Infinite Jump is on", (Jump) =>
            //    {
            //        infjumpstate = Jump;
            //        Xero.Configer.Configuration.JSONConfig.InfiniteJump = Jump;
            //    }).SetToggleState(Xero.Configer.Configuration.JSONConfig.InfiniteJump, !Xero.Configer.Configuration.JSONConfig.InfiniteJump);
            //    new ToggleButton(exploits, "EarRape", "Turns off EarRape", "EarRape is on", (rape) =>
            //    {
            //        USpeaker.field_Internal_Static_Single_1 = rape ? float.MaxValue : 1;
            //    }).SetToggleState(false, true);
            //    new ToggleButton(exploits, "Funny Voice", "Turns off Funny Voice", "Funny Voice is on", (kys) =>
            //    {
            //        USpeaker.field_Internal_Static_Single_3 = kys ? (int)1.45 : 1;
            //    }).SetToggleState(false, true);
            //    new ToggleButton(esp, "Player ESP", "Turns off Player ESP", "Player ESP is on", (ESP) =>
            //    {
            //        playeresp = ESP;
            //        Xero.Configer.Configuration.JSONConfig.PlayerEsp = ESP;
            //        espon();
            //    }).SetToggleState(Xero.Configer.Configuration.JSONConfig.PlayerEsp, !Xero.Configer.Configuration.JSONConfig.PlayerEsp);
            //    new ToggleButton(esp, "Object ESP", "Turns off Object ESP", "Object ESP is on", (ESP) =>
            //    {
            //        objectesp = ESP;
            //        Xero.Configer.Configuration.JSONConfig.ObjectEsp = ESP;
            //        espon();
            //    }).SetToggleState(Xero.Configer.Configuration.JSONConfig.ObjectEsp, !Xero.Configer.Configuration.JSONConfig.ObjectEsp);
            //    new ToggleButton(exploits, "Event 7 Exploit", "Event 7 Exploit is off", "Event 7 Exploit is on", (seven) =>
            //    {
            //        xerolagx.XeroLag2.seveninvalidobject = seven;
            //    }).SetToggleState(false, true);
            //    new SingleButton(exploits, "Change Avatar", "Change Avatar Through ID", () =>
            //    {
            //        avatarid = Clipboard.GetText();
            //        Useful.ChangeAVIFromString(avatarid);
            //    });
            //    new SingleButton(exploits, "copyID", "Copies ID", () =>
            //    {
            //        Clipboard.SetText(Useful.LocalPlayer1.field_Private_ApiAvatar_0.id);
            //    });



            //};
            //var newpage = new MenuPage("Xero", "Xero Menu2");
            //var userpage = new MenuPage("UserMenu2", "UserPage2");
            //new Tab(newpage, "Main Menu2", (Environment.CurrentDirectory + "\\Xero\\Images\\Senko.png").LoadSpriteFromDisk());
            //var s = new MenuPage("true", "true", true, true, false);
            //var FunctionalGroup = new ButtonGroup(newpage, "Functions");
            //var esp = new CollapsibleButtonGroup(newpage, "ESP", "ESP");
            //var Shmovement = new CollapsibleButtonGroup(newpage, "Shmovement", "Movement stuff");
            //var world = new CollapsibleButtonGroup(newpage, "World", "Toggles The World Dropdown");
            //var exploits = new CollapsibleButtonGroup(newpage, "Exploits", "Toggles Exploit DropDown");
            //var config = new ButtonGroup(newpage, "Configuration");
            //var options = new ButtonGroup(userpage, "Options");






        }

        public static void espon()
        {
            if (Useful.IsInWorld())
            {
                var allPlayers = Useful.Players;
                var allObjects = GameObject.FindObjectsOfType<VRC_Pickup>();

                foreach (var player in allPlayers)
                    if (!player.prop_APIUser_0.IsSelf)
                        HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion").GetComponent<MeshRenderer>(), playeresp);

                foreach (var pickup in allObjects)
                    HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(pickup.GetComponent<MeshRenderer>(), objectesp);
            }
        }
        public static void updatemeplease()
        {
            if (infjumpstate)
            {
                if (VRCInputManager.Method_Public_Static_VRCInput_String_0("Jump").prop_Boolean_3)
                {
                    Vector3 velocity = Networking.LocalPlayer.GetVelocity();
                    velocity.y = Networking.LocalPlayer.GetJumpImpulse();
                    Networking.LocalPlayer.SetVelocity(velocity);
                }

            }
        }
        public static void Turnon()
        {
            //if (Configuration.JSONConfig.AntiBlock)
            if (Xero.Configer.Configuration.JSONConfig.ObjectEsp)
                objectesp = true;
            if (Xero.Configer.Configuration.JSONConfig.PlayerEsp)
                playeresp = true;
            if (Xero.Configer.Configuration.JSONConfig.InfiniteJump)
                infjumpstate = true;
            //if (Configuration.JSONConfig.Event1)
            //    event1.Invoke();
            //if (Configuration.JSONConfig.Event2)
            //    event2.Invoke();
            //if (Configuration.JSONConfig.Event3)
            //    event3.Invoke();
            //if (Configuration.JSONConfig.Event4)
            //    event4.Invoke();
            //if (Configuration.JSONConfig.Event5)
            //    event5.Invoke();
            //if (Configuration.JSONConfig.Event6)
            //    event6.Invoke();
            //if (Configuration.JSONConfig.Event9)
            //    event9.Invoke();
        }

    }
}
#region Old Buttons and stuff.
//        #region so basically its buttons but like below it is what i use to start it lol      
//        //public static bool isFly = false;
//        //public static int flySpeed = 18;
//        //public static float yes = Configuration.JSONConfig.CustomFOV;

//        //public static NestedButton mainMenuP1;
//        //public static NestedButton mainMenuP2;
//        //public static NestedButton mainMenuP3;
//        //public static NestedButton AvatarMenuP1;
//        //public static NestedButton AvatarMenuP2;
//        //public static NestedButton AvatarMenuP3;
//        //public static NestedButton Voices;
//        //public static NestedButton Voicesp1;
//        //public static NestedButton Voicesp2;

//        //public static NestedButton Sitonplayer { get; private set; }
//        //public static NestedButton Sitonplayer3 { get; private set; }
//        //public static NestedButton Sitonplayer2 { get; private set; }

//        //public static NestedButton worldMenuP1;
//        //public static NestedButton worldMenuP2;
//        //public static NestedButton worldMenuP3;
//        //public static NestedButton PlayerMenuP1;
//        //public static NestedButton PlayerMenuP2;
//        //public static NestedButton PlayerMenuP3;
//        //public static NestedButton userMenuP1;
//        //public static NestedButton userMenuP2;
//        //public static NestedButton userMenuP3;
//        //public static NestedButton SecondButton;
//        //public static NestedButton SecondButtonP2;
//        //public static NestedButton SecondButtonP3;
//        //public static NestedButton Fly;
//        //public static SingleButton FirstButton;
//        //public static NestedButton CameraP1 { get; private set; }
//        //public static NestedButton CameraP2 { get; private set; }
//        //public static NestedButton CameraP3 { get; private set; }
//        //public static NestedButton VoicesMain { get; private set; }
//        //public static NestedButton VoicesMainp1 { get; private set; }
//        //public static NestedButton VoicesMainp2 { get; private set; }
//        //public static NestedButton ExploitsP1 { get; private set; }
//        //public static NestedButton ExploitsP2 { get; private set; }


////        public static void thatsmymomma()
////        {
////            if (Configuration.JSONConfig.CustomFOV != 60)
////            {
////                GameObject gameObject = GameObject.Find("Camera (eye)");
////                if (gameObject == null)
////                {
////                    gameObject = GameObject.Find("CenterEyeAnchor");
////                }
////                if (gameObject != null)
////                {
////                    Camera component = gameObject.GetComponent<Camera>();
////                    if (component != null)
////                    {
////                        component.fieldOfView = (float)Configuration.JSONConfig.CustomFOV;
////                    }
////                }
////            }
////        }
////        public static ToggleButton FLYBUTTONS { get; private set; }
////        public static ToggleButton NOCLIPBUTTONS { get; private set; }

////        private static bool m_State;
////#pragma warning disable CS0649 // Field 'QMmenu.cloneButton' is never assigned to, and will always have its default value null
////        private GameObject cloneButton;
////#pragma warning restore CS0649 // Field 'QMmenu.cloneButton' is never assigned to, and will always have its default value null
////        public static SingleButton speedResetButton;

////        public static float FovFloat { get; private set; }
////        public static float CustomFOV { get; private set; }
////        public static ToggleButton Infjump { get; private set; }

////        private static NestedButton fov;

////        public static QMSlider FOVSLIDER;

////        public static ToggleButton FPS { get; private set; }
////        public static bool FPSState { get; private set; }
////        public static bool Spectatortoggle { get; private set; }
////        public static GameObject Ears { get; private set; }
////        public static SingleButton Kid { get; private set; }

////        private static string inputtext;
////#pragma warning disable CS0169 // The field 'QMmenu.net' is never used
////        private static Action<string> net;
////#pragma warning restore CS0169 // The field 'QMmenu.net' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.confirm' is never used
////        private static Action<string> confirm;
////#pragma warning restore CS0169 // The field 'QMmenu.confirm' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.blackscreen' is never used
////        private static ToggleButton blackscreen;
////#pragma warning restore CS0169 // The field 'QMmenu.blackscreen' is never used
////        private static bool infjumpstate;
////        public static ToggleButton spectatebutton;
////        private static string inputtext2;
////        private static GameObject selectedplayer;
////        private static SingleButton FavButton;
////#pragma warning disable CS0169 // The field 'QMmenu.crazyposition' is never used
////        private static Vector3 crazyposition;
////#pragma warning restore CS0169 // The field 'QMmenu.crazyposition' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.mainpositionchest' is never used
////        private static Vector3 mainpositionchest;
////#pragma warning restore CS0169 // The field 'QMmenu.mainpositionchest' is never used

////        public static Animator Animatornotime { get; private set; }
////        public static bool Event6 { get; private set; }
////        public static NestedButton UtilsNested { get; private set; }

////        private static ToggleButton blackscreenbutton;

////        public static NestedButton Experimtental { get; private set; }
////        public static NestedButton EventButton { get; private set; }
////        public static bool Event1 { get; private set; }
////        public static bool Event2 { get; private set; }
////        public static bool Event3 { get; private set; }
////        public static bool Event4 { get; private set; }
////        public static bool Event5 { get; private set; }
////        public static bool Event9 { get; private set; }
////        public static bool flybool { get; private set; }
////        public static bool zoom { get; private set; }

////        private static ToggleButton event1;
////        private static ToggleButton event2;
////        private static ToggleButton event3;
////        private static ToggleButton event4;
////        private static ToggleButton event5;
////        private static Animator animatormine1;
////        public static bool objectesp;

////        private static ToggleButton playerespbutton;
////        public static ToggleButton antiblockbutton;
////        private static ToggleButton objectespbutton;
////        private static ToggleButton newspinnyt;

////        public static NestedButton Keybind { get; private set; }
////        public static ToggleButton RespawnKeybindButton { get; private set; }
////        public static ToggleButton ZoomKeybindButton { get; private set; }
////        public static ToggleButton FreeCamKeybindButton { get; private set; }
////        public static ToggleButton ThirdPersonKeybindButton { get; private set; }
////        public static ToggleButton FlyKeybindButton { get; private set; }
////#pragma warning disable CS0169 // The field 'QMmenu.newspinny' is never used
////        private static SingleButton newspinny;
////#pragma warning restore CS0169 // The field 'QMmenu.newspinny' is never used
////        private static ToggleButton copyhead;
////#pragma warning disable CS0169 // The field 'QMmenu.cachethis' is never used
////        private static Quaternion cachethis;
////#pragma warning restore CS0169 // The field 'QMmenu.cachethis' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.cachelocalrotation' is never used
////        private static Quaternion cachelocalrotation;
////#pragma warning restore CS0169 // The field 'QMmenu.cachelocalrotation' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.cachethis2' is never used
////        private static Vector3 cachethis2;
////#pragma warning restore CS0169 // The field 'QMmenu.cachethis2' is never used
////#pragma warning disable CS0649 // Field 'QMmenu.cachethis3' is never assigned to, and will always have its default value
////        private static Quaternion cachethis3;
////#pragma warning restore CS0649 // Field 'QMmenu.cachethis3' is never assigned to, and will always have its default value
////#pragma warning disable CS0169 // The field 'QMmenu.selectedplayersheads' is never used
////        private static Vector3 selectedplayersheads;
////#pragma warning restore CS0169 // The field 'QMmenu.selectedplayersheads' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.selectedplayershead' is never used
////        private static Quaternion selectedplayershead;
////#pragma warning restore CS0169 // The field 'QMmenu.selectedplayershead' is never used
////        private static bool thiscrazything;
////        private static List<SingleButton> buttonsl = new List<SingleButton>();
////        private static NestedButton PlayerList;
////        public static void CloneApplicationButton()
////        {
////            GameObject cloneButton = new GameObject();

////            cloneButton = GameObject.Find("UserInterface/QuickMenu/UserInteractMenu/CloneAvatarButton");
////            mainMenuP1 = new NestedButton("ShortcutMenu", 2, -1, false, "Xero", "Xero Beta Menu");
////            mainMenuP2 = new NestedButton(mainMenuP1.MenuPath, 5, 4, true, "Page 2", "Page 2");
////            mainMenuP3 = new NestedButton(mainMenuP2.MenuPath, 5, 4, true, "Page 3", "3");
////            AvatarMenuP1 = new NestedButton(mainMenuP1, 2, 0, false, "Avatar", "Everything Related to Avatars");
////            AvatarMenuP2 = new NestedButton(AvatarMenuP1.MenuPath, 5, 4, true, "Page 2", "Page 2");
////            AvatarMenuP3 = new NestedButton(AvatarMenuP2.MenuPath, 5, 4, true, "Page 3", "Page 3");
////            CameraP1 = new NestedButton(mainMenuP1, 3, 0, false, "Camera", "All things Camera");
////            CameraP2 = new NestedButton(CameraP1.MenuPath, 5, 4, true, "Page 2", "Page 2");
////            CameraP3 = new NestedButton(CameraP2.MenuPath, 5, 4, true, "Page 3", "Page 3");
////            ExploitsP1 = new NestedButton(mainMenuP1, 4, 0, false, "Exploits", "All of Xero Exploits");
////            ExploitsP2 = new NestedButton(ExploitsP1.MenuPath, 5, 4, true, "Page 2", "Page 2");
////            ExploitsP3 = new NestedButton(ExploitsP2.MenuPath, 5, 4, true, "Page 3", "Page 3");

////            VoicesMain = new NestedButton(ExploitsP1.MenuPath, 2, 0, false, "Voices", "Voices To change server side");
////            VoicesMainp1 = new NestedButton(VoicesMain.MenuPath, 5, 4, true, "Page 2", "Page 2");
////            VoicesMainp2 = new NestedButton(VoicesMainp1.MenuPath, 5, 4, true, "Page 3", "Page 3");



////            worldMenuP1 = new NestedButton(mainMenuP1, 1, 0, false, "World", "Everything Related to Worlds");
////            worldMenuP2 = new NestedButton(worldMenuP1.MenuPath, 5, 4, true, "Page 2", "Page 2");
////            worldMenuP3 = new NestedButton(worldMenuP2.MenuPath, 5, 4, true, "Page 3", "Page 3");

////            SecondButton = new NestedButton("ShortcutMenu", 3, -1, false, "Movement", "Movement Menu");
////            SecondButtonP2 = new NestedButton(SecondButton.MenuPath, 5, 4, true, "Page 2", "Page 2");
////            SecondButtonP3 = new NestedButton(SecondButtonP2.MenuPath, 5, 4, true, "Page 3", "Page 3");

////            Fly = new NestedButton(QMmenu.SecondButton, 1, 0, false, "Fly", "Fly Buttons");

////            userMenuP1 = new NestedButton("UserInteractMenu", 5, 3, false, "Xero \n On Player", "Xero On Selected User");
////            userMenuP2 = new NestedButton(userMenuP1.MenuPath, 5, 4, true, "Page 2", "User Useful Menu Page 2");
////            userMenuP3 = new NestedButton(userMenuP2.MenuPath, 5, 4, true, "Page 3", "User Useful Menu Page 3");
////            Voices = new NestedButton(QMmenu.userMenuP1, 2, 0, false, "Voices", "Mess with players voices");
////            Voicesp1 = new NestedButton(Voices.MenuPath, 5, 4, true, "Page 2", "Page 2");
////            Voicesp2 = new NestedButton(Voicesp1.MenuPath, 5, 4, true, "Page 3", "Page 3");
////            Sitonplayer = new NestedButton(QMmenu.userMenuP1.MenuPath, 4, 1, false, $"Mess with user", "choose from many fine options!");
////            Sitonplayer3 = new NestedButton(Sitonplayer.MenuPath, 5, 4, true, "Page 2", "Page 2");
////            Sitonplayer2 = new NestedButton(Sitonplayer.MenuPath, 5, 4, true, "Page 3", "Page 3");
////            FirstButton = new SingleButton("ShortcutMenu", 4, -1, false, "SelectYourself", "Select Yourself", delegate ()
////            {
////                Useful.QMSelectPlayer(VRC.Player.prop_Player_0);
////            });
////            PlayerList = new NestedButton(mainMenuP1.MenuPath, 1, 1, false, "Players Menu", "Each player... in a Menu!", delegate ()
////            { QMmenu.List(); }, Color.white);
////            #endregion
////            #region Fly Buttons TO MANY
////            FLYBUTTONS = new ToggleButton(Fly.MenuPath, 1, 0, false, "Toggle Fly", "Toggle Fly Button", delegate (bool state)
////            {
////                isFly = !isFly;
////                Useful.LocalPlayer.gameObject.GetComponent<CharacterController>().enabled = !isFly;

////            }, Color.red, Color.white);
////            new SingleButton(Fly.MenuPath, 2, 0, true, $"▲", $"Increase Speed", delegate ()
////             {
////                 flySpeed++;

////                 speedResetButton.SetButtonText($"Current Speed\n [{flySpeed}]");
////             }, Color.white);
////            new SingleButton(Fly.MenuPath, 2, 1, true, $"▼", $"Decrease Speed", delegate ()
////            {
////                flySpeed--;

////                if (flySpeed <= 0)
////                    flySpeed = 1;
////                speedResetButton.SetButtonText($"Current Speed\n [{flySpeed}]");
////            }, Color.white);
////            speedResetButton = new SingleButton(Fly.MenuPath, 4, 0, false, $"Current Speed[{flySpeed}]", "Reset Speed", delegate ()
////            {
////                flySpeed = 18;
////                speedResetButton.SetButtonText($"Current Speed\n [{flySpeed}]");
////            }, Color.white);
////            #endregion
#endregion

//            new SingleButton(QMmenu.worldMenuP1.MenuPath, "ReJoin Instance", "Rejoins This Instance", () =>
//            {
//                Networking.GoToRoom(Useful.GetInstance().worldId + ":" + Useful.GetInstance().instanceId);
//            }, false);

//            // new ToggleButton(QMmenu.ExploitsP1.MenuPath, 1, 0, false, "WorldLagger", "Lags everyone in the world could be some anti's", delegate (bool zoom)
//            // {

//            //     xerolagx.XeroLag2.invalidobject = zoom;
//            //     MelonLogger.Msg("WorldLagger Is enabled!");
//            // }, Color.red, Color.white);
//            // new SingleButton(QMmenu.worldMenuP1.MenuPath, 1, 0, true, "Copy World ID", "Copy Current World ID", delegate ()
//            // {
//            //     string wrld = RoomManager.field_Internal_Static_ApiWorld_0.id + ":" + Useful.GetInstance().instanceId;
//            //     Clipboard.SetText(wrld);
//            // }, Color.white);
//            // new SingleButton(QMmenu.Sitonplayer.MenuPath, 3, 0, false, "Make Them Small", "They small Cuz!", delegate ()
//            // {
//            //     Useful.SelectedPlayer.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>();
//            // }, Color.white);
//            // new SingleButton(QMmenu.Sitonplayer.MenuPath, 2, 0, false, "Make Them Tweak", "They Tweakin' Cuz!", delegate ()
//            // {
//            //     Useful.SelectedPlayer.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().speed = 3;
//            // }, Color.white);
//            // new SingleButton(QMmenu.Sitonplayer.MenuPath, 1, 0, false, "Copy Player", "Sit on players Head!", delegate ()
//            //  {
//            //      Animatornotime = Useful.SelectedPlayer.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>();
//            //      animatormine1 = Useful.LocalPlayer.gameObject.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>();
//            //      animatormine1 = Useful.LocalPlayer1.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>();
//            //      animatormine1 = Useful.localplayer2.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>();
//            //      animatormine1 = Animatornotime;
//            //  }, Color.white);
//            // new SingleButton(QMmenu.worldMenuP1.MenuPath, 4, 0, false, "Join World ID", "Join World by World ID", delegate ()
//            // {
//            //     Popup.CreateInputPopup("World Id", "text here", inputtext, "cancel", "confirm", UnityEngine.UI.InputField.InputType.Standard, false, delegate (string inputtext2)
//            //     {

//            //         {
//            //             try
//            //             {
//            //                 inputtext = inputtext2;
//            //                 Networking.GoToRoom(inputtext2);

//            //             }
//            //             catch
//            //             {
//            //                 MelonLogger.Msg("Either World ID is false or not copied!");
//            //                 MelonLogger.Msg($"Your Clipboard Contains {Clipboard.GetText()}");
//            //             }
//            //         }
//            //     }, null, null);
//            // }, Color.white);
//            // Infjump = new ToggleButton(QMmenu.SecondButton.MenuPath, 2, 0, false, "Infinite Jump", "allows   you to jump as much as you want", delegate (bool state)
//            //   {
//            //       infjumpstate = state;
//            //       Configuration.JSONConfig.InfiniteJump = infjumpstate;
//            //   }, Color.red, Color.white);
//            // new SingleButton(QMmenu.SecondButton.MenuPath, 4, 5, true, "Save Config", "Save Config For later use!", delegate ()
//            // { Configuration.SaveConfig(); }, Color.white);
//            // new SingleButton(QMmenu.mainMenuP1.MenuPath, 4, 5, true, "Save Config", "Save Config For later use!", delegate ()
//            // { Configuration.SaveConfig(); }, Color.white);
//            // fov = new NestedButton(QMmenu.CameraP1.MenuPath, 1, 0, false, "Fov Changer", "Change Fov");
//            // FOVSLIDER = new QMSlider(QMmenu.fov.MenuPath, 1, 0, delegate (float nothing)
//            //  {

//            //      Useful.LocalPlayerCamera.GetComponent<Camera>().fieldOfView = nothing;
//            //      yes = Useful.LocalPlayerCamera.GetComponent<Camera>().fieldOfView;

//            //  }, Configuration.JSONConfig.CustomFOV);
//            // FPS = new ToggleButton(QMmenu.CameraP1.MenuPath, 2, 0, false, "Unlimited Fps", "Turns off FPS limit Desktop mode only!", delegate (bool russki)
//            // {
//            //     FPSState = russki;
//            //     QualitySettings.vSyncCount = russki ? 1 : 0;
//            //     Configuration.JSONConfig.UnlimitedFps = FPSState;


//            // }, Color.red, Color.white);
//            // new SingleButton(QMmenu.userMenuP1.MenuPath, 1, 3, true, "Download VRCA", "Download Selected Users Avatar", delegate ()
//            //{
//            //    Process.Start(Useful.SelectedPlayer.prop_ApiAvatar_0.assetUrl);
//            //}, Color.white);
//            // Kid = new SingleButton(QMmenu.Voices.MenuPath, 1, 0, false, "Kid", "Makes them sound like a child", delegate ()
//            //  {
//            //      selectedplayer = Useful.SelectedPlayer.gameObject;
//            //      selectedplayer.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/USpeak").GetComponent<AudioSource>().pitch = 1.3f;
//            //  }, Color.white);
//            // new SingleButton(QMmenu.Voices.MenuPath, 4, 0, false, "Disable Weird Voice", "Makes them sound normal and unprioritizes speaker", delegate ()
//            // {
//            //     selectedplayer = Useful.SelectedPlayer.gameObject;
//            //     selectedplayer.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/USpeak").GetComponent<AudioSource>().pitch = 1f;
//            //     selectedplayer.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/USpeak").GetComponent<AudioSource>().volume = 1f;
//            //     selectedplayer.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/USpeak").GetComponent<AudioSource>().priority = 6;
//            // }, Color.white);
//            // new SingleButton(QMmenu.Voices.MenuPath, 3, 0, false, "Deep Voice", "Makes them sound Deep", delegate ()
//            // {
//            //     selectedplayer = Useful.SelectedPlayer.gameObject;
//            //     selectedplayer.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/USpeak").GetComponent<AudioSource>().pitch = 0.82f;
//            // }, Color.white);
//            // new SingleButton(QMmenu.Voices.MenuPath, 4, 2, false, "Prioritize Speaker", "Prioitizes the Speaker if they are to quiet", delegate ()
//            // {
//            //     selectedplayer = Useful.SelectedPlayer.gameObject;
//            //     selectedplayer.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/USpeak").GetComponent<AudioSource>().volume = 1.3f;
//            //     selectedplayer.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/USpeak").GetComponent<AudioSource>().priority = 0;
//            // }, Color.white);
//            // new ToggleButton(QMmenu.VoicesMain.MenuPath, 1, 0, false, "Ear Rape", "EarRape", delegate (bool earrape)
//            //  {
//            //      USpeaker.field_Internal_Static_Single_1 = earrape ? float.MaxValue : 1f;
//            //  }, Color.red, Color.white);
//            // copyhead = new ToggleButton(QMmenu.Sitonplayer.MenuPath, 4, 0, false, "Copy Head Movement", "Copy them lol", delegate (bool mom)
//            // {
//            //     thiscrazything = mom;
//            // }, Color.red, Color.white);
//            // new ToggleButton(QMmenu.Voices.MenuPath, 1, 1, false, "Say what they say", "crazy", delegate (bool mymomma)
//            //  {
//            //      uspeakbool = mymomma;

//            //  }, Color.red, Color.white);
//            // new SingleButton(QMmenu.Voices.MenuPath, 2, 0, false, "Change Voice Level", "Makes them sound how you wish", delegate ()
//            // {
//            //     Popup.CreateInputPopup("Change Voice Level \nThe Higher you go the faster the audio gets sent \nThe lower the Longer it takes.", "Float Value Here", inputtext2, "Cancel", "Confirm", UnityEngine.UI.InputField.InputType.Standard, false, delegate (string inputtext3)
//            //     {

//            //         {

//            //             {
//            //                 inputtext2 = inputtext3;
//            //                 float f = float.Parse(inputtext2);
//            //                 selectedplayer = Useful.SelectedPlayer.gameObject;
//            //                 selectedplayer.transform.Find("AnimationController/HeadAndHandIK/HeadEffector/USpeak").GetComponent<AudioSource>().pitch = f;


//            //             }
//            //         }
//            //     }, null, null);

//            // }, Color.white);
//            // new SingleButton(QMmenu.userMenuP1.MenuPath, 2, 1, false, "Teleport to user", "Teleports to Selected User", delegate ()
//            //  { Useful.LocalPlayer1.transform.position = Useful.SelectedPlayer.transform.position; }, Color.white);
//            // UtilsNested = new NestedButton(QMmenu.mainMenuP1.MenuPath, 4, 1, false, "Utils", "Useful stuff");
//            // blackscreenbutton = new ToggleButton(QMmenu.UtilsNested.MenuPath, 1, 0, false, "Remove\nBlackScreen", "removes the black screen from loading in worlds", delegate (bool black)
//            // { blackscreenbool = black; Configuration.JSONConfig.BlackScreenBool = black; if (black) GameObject.Find("UserInterface/PlayerDisplay/BlackFade/inverted_sphere").active = false; }, Color.red, Color.white);
//            // Experimtental = new NestedButton(QMmenu.UtilsNested.MenuPath, 3, 0, false, "Experimental", "Experimental Features!");
//            // EventButton = new NestedButton(QMmenu.UtilsNested.MenuPath, 4, 0, false, "Events", "Block Events!");
//            // event1 = new ToggleButton(EventButton.MenuPath, 1, 0, true, "Event 1", "Toggle This Event!", delegate (bool event1)
//            // { Event1 = event1; Configuration.JSONConfig.Event1 = event1; }, Color.red, Color.white);
//            // event2 = new ToggleButton(EventButton.MenuPath, 2, 0, true, "Event 2", "Toggle This Event!", delegate (bool event2)
//            // { Event2 = event2; Configuration.JSONConfig.Event2 = event2; }, Color.red, Color.white);
//            // event3 = new ToggleButton(EventButton.MenuPath, 3, 0, true, "Event 3", "Toggle This Event!", delegate (bool event3)
//            // { Event3 = event3; Configuration.JSONConfig.Event3 = event3; }, Color.red, Color.white);
//            // event4 = new ToggleButton(EventButton.MenuPath, 4, 0, true, "Event 4", "Toggle This Event!", delegate (bool event4)
//            // { Event4 = event4; Configuration.JSONConfig.Event4 = event4; }, Color.red, Color.white);
//            // event5 = new ToggleButton(EventButton.MenuPath, 1, 1, true, "Event 5", "Toggle This Event!", delegate (bool event5)
//            // { Event5 = event5; Configuration.JSONConfig.Event5 = event5; }, Color.red, Color.white);
//            // event6 = new ToggleButton(EventButton.MenuPath, 2, 1, true, "Event 6", "Blocks stuff like portals, and emoji spam!", delegate (bool event6)
//            // { Event6 = event6; Configuration.JSONConfig.Event6 = event6; }, Color.red, Color.white);
//            // event9 = new ToggleButton(EventButton.MenuPath, 3, 1, true, "AntiCrash!", "Blocks new Exploit", delegate (bool event6)
//            // { Event9 = event6; Configuration.JSONConfig.Event6 = event6; }, Color.red, Color.white);
//            // new ToggleButton(QMmenu.Experimtental.MenuPath, 1, 0, false, "Ghost Join", "Join without anyone seeing you except master of course", delegate (bool status)
//            // {
//            //     XeroCore.ghostjoin = status;
//            // }, Color.red, Color.white);
//            // antiblockbutton = new ToggleButton(Experimtental.MenuPath, 2, 0, false, "Anti Block", "This is still in BETA", delegate (bool anti)
//            // {
//            //     antiblock = anti;
//            //     Configuration.JSONConfig.AntiBlock = anti;
//            // }, Color.red, Color.white);


//            // new SingleButton(QMmenu.userMenuP1.MenuPath, 1, 2, true, "Force Clone", "Force Clone Selected Users Avatar", delegate ()
//            //  {
//            //      if (Useful.SelectedPlayer.prop_ApiAvatar_0.releaseStatus != "private")
//            //      {
//            //          MelonLogger.Msg($"trying to change into Name: {Useful.SelectedPlayer.prop_ApiAvatar_0.name} ID: {Useful.SelectedPlayer.prop_ApiAvatar_0.id}");
//            //          {
//            //              try
//            //              {
//            //                  Useful.ChangeFromRawAvatar();
//            //              }
//            //              catch
//            //              {
//            //                  MelonLogger.Msg("Failed to Clone avatar... Trying Method 2");

//            //              }
//            //          }
//            //      }
//            //      else
//            //      {
//            //          MelonLogger.Msg($"Avatar {Useful.SelectedPlayer.prop_ApiAvatar_0.name} is Private");
//            //      }
//            //  }, Color.white);
//            // spectatebutton = new ToggleButton(QMmenu.userMenuP1.MenuPath, 4, 0, false, "Spectate User", "Allows you to spectate selected user", delegate (bool toggle)
//            // {
//            //     Spectatortoggle = toggle;
//            //     Spectator.SpectatorBool(toggle);
//            // }, Color.red, Color.white);

//            // var menu = new NestedButton(QMmenu.CameraP1.MenuPath, 3, 0, false, "ESP Menu", "ESP Menu");

//            // playerespbutton = new ToggleButton(menu.MenuPath, 1, 0, false, "ESP Players", "Toggles Esp For Players", delegate (bool state)
//            //  {
//            //      playeresp = state;
//            //      Configuration.JSONConfig.PlayerEsp = state;
//            //      espon();
//            //  }, Color.red, Color.white);
//            // objectespbutton = new ToggleButton(menu.MenuPath, 2, 0, false, "ESP Objects", "Toggles Esp For Objects", delegate (bool state)
//            //  {
//            //      objectesp = state;
//            //      espon();
//            //      Configuration.JSONConfig.ObjectEsp = state;
//            //  }, Color.red, Color.white);
//            // newspinnyt = new ToggleButton(CameraP1.MenuPath, 4, 0, false, "Spin Until \nYou faint", "Spin your brains out", delegate (bool state)
//            // {
//            //     mymainsyoudontknow = state;
//            // }, Color.red, Color.white);
//            // Keybind = new NestedButton(QMmenu.UtilsNested.MenuPath, 2, 0, false, "KeyBinds", "Turn on and off Keybinds");
//            // new SingleButton(QMmenu.Keybind.MenuPath, 1, 0, false, "Enable All", "Enables all Keybinds", delegate ()
//            //  {
//            //      if (!Configuration.JSONConfig.Respawn)
//            //          RespawnKeybindButton.Invoke();
//            //      if (!Configuration.JSONConfig.ThirdPerson)
//            //          ThirdPersonKeybindButton.Invoke();
//            //      if (!Configuration.JSONConfig.Fly)
//            //          FlyKeybindButton.Invoke();
//            //      if (!Configuration.JSONConfig.Zoom)
//            //          ZoomKeybindButton.Invoke();
//            //      if (!Configuration.JSONConfig.FreeCam)
//            //          FreeCamKeybindButton.Invoke();
//            //  }, Color.white);
//            // new SingleButton(QMmenu.Keybind.MenuPath, 4, 0, false, "Disable All", "Disables all Keybinds", delegate ()
//            // {
//            //     if (Configuration.JSONConfig.Respawn)
//            //         RespawnKeybindButton.Invoke();
//            //     if (Configuration.JSONConfig.ThirdPerson)
//            //         ThirdPersonKeybindButton.Invoke();
//            //     if (Configuration.JSONConfig.Fly)
//            //         FlyKeybindButton.Invoke();
//            //     if (Configuration.JSONConfig.Zoom)
//            //         ZoomKeybindButton.Invoke();
//            //     if (Configuration.JSONConfig.FreeCam)
//            //         FreeCamKeybindButton.Invoke();
//            // }, Color.white);
//            // RespawnKeybindButton = new ToggleButton(QMmenu.Keybind.MenuPath, 2, 0, true, "Respawn Keybind", "Disables / Enables This KeyBind", delegate (bool nuts)
//            //   {
//            //       Configuration.JSONConfig.Respawn = nuts;
//            //       SpaceRemoval.Respawn = nuts;
//            //   }, Color.red, Color.white);
//            // ZoomKeybindButton = new ToggleButton(QMmenu.Keybind.MenuPath, 2, 1, true, "Zoom Keybind", "Disables / Enables This KeyBind", delegate (bool nuts)
//            // {
//            //     Configuration.JSONConfig.Zoom = nuts;
//            //     zoom = nuts;

//            // }, Color.red, Color.white);
//            // FreeCamKeybindButton = new ToggleButton(QMmenu.Keybind.MenuPath, 3, 0, true, "FreeCam", "Disables / Enables This KeyBind", delegate (bool nuts)
//            // {
//            //     Configuration.JSONConfig.FreeCam = nuts;
//            //     FreeRoam.FreeRoam.freecambool = nuts;
//            // }, Color.red, Color.white);
//            // ThirdPersonKeybindButton = new ToggleButton(QMmenu.Keybind.MenuPath, 3, 1, true, "ThirdPerson Keybind", "Disables / Enables This KeyBind", delegate (bool nuts)
//            // {
//            //     Configuration.JSONConfig.ThirdPerson = nuts;
//            //     SpaceRemoval.ThirdPersonBool = nuts;

//            // }, Color.red, Color.white);
//            // FlyKeybindButton = new ToggleButton(QMmenu.Keybind.MenuPath, 2, 2, true, "Fly Keybind", "Disables / Enables This KeyBind", delegate (bool nuts)
//            // {
//            //     Configuration.JSONConfig.Fly = nuts;
//            //     flybool = nuts;
//            // }, Color.red, Color.white);
//            // new SingleButton(QMmenu.AvatarMenuP1.MenuPath, 1, 0, false, "Avatar ID Change", "Change into avatar by ID", delegate ()
//            // {
//            //     Popup.CreateInputPopup("Change Into Avatar by ID", "Avatar ID Here", inputtext, "Cancel", "Confirm", UnityEngine.UI.InputField.InputType.Standard, false, delegate (string inputtext2)
//            //     {

//            //         {

//            //             {
//            //                 inputtext = inputtext2;

//            //                 Useful.ChangeAVIFromString(inputtext2);

//            //             }

//            //             catch
//            //             {
//            //                 if (inputtext2.StartsWith("avtr_"))
//            //                 { MelonLogger.Msg("Avatar Is Private!"); }

//            //                 if (!inputtext2.StartsWith("avtr_"))
//            //                 {
//            //                     MelonLogger.Msg("Avtr ID is not copied!");
//            //                     MelonLogger.Msg($"Your Clipboard Contains {Clipboard.GetText()}");
//            //                 }

//            //             }

//            //         }
//            //     }, null, null);
//            // }, Color.white);
//            // new ToggleButton(QMmenu.userMenuP1.MenuPath, 1, 0, false, "Objects to head", "Just a Test", delegate (bool ObjectHead)
//            // {
//            //     m_State = ObjectHead;

//            // }, Color.red, Color.white);
//            // lookbetter();
//        }
//        private static async void wait()
//        {
//            await System.Threading.Tasks.Task.Delay(1000);
//        }
//        public static void callvrcuistart()
//        {
//            //Useful.GetPlayerCamera.GetComponent<Camera>().fieldOfView = Configuration.JSONConfig.CustomFOV;
//            //if (Configuration.JSONConfig.CustomFOV != 60)
//            //    Useful.LocalPlayerCamera.GetComponent<Camera>().fieldOfView = (float)Configuration.JSONConfig.CustomFOV;
//            //if (Configuration.JSONConfig.UnlimitedFps)
//            //    FPS.Invoke();
//            //if (Configuration.JSONConfig.InfiniteJump)
//            //    Infjump.Invoke();
//            //if (Configuration.JSONConfig.PlayerEsp)
//            //    playerespbutton.Invoke();
//            //if (Configuration.JSONConfig.ObjectEsp)
//            //    objectespbutton.Invoke();
//            //if (Configuration.JSONConfig.AntiBlock)
//            //    antiblockbutton.Invoke();
//            //if (Configuration.JSONConfig.Event1)
//            //    event1.Invoke();
//            //if (Configuration.JSONConfig.Event2)
//            //    event2.Invoke();
//            //if (Configuration.JSONConfig.Event3)
//            //    event3.Invoke();
//            //if (Configuration.JSONConfig.Event4)
//            //    event4.Invoke();
//            //if (Configuration.JSONConfig.Event5)
//            //    event5.Invoke();
//            //if (Configuration.JSONConfig.Event6)
//            //    event6.Invoke();
//            //if (Configuration.JSONConfig.Event9)
//            //    event9.Invoke();
//            //if (Configuration.JSONConfig.FreeCam)
//            //    FreeCamKeybindButton.Invoke();
//            //if (Configuration.JSONConfig.ThirdPerson)
//            //    ThirdPersonKeybindButton.Invoke();
//            //if (Configuration.JSONConfig.Respawn)
//            //    RespawnKeybindButton.Invoke();
//            //if (Configuration.JSONConfig.Zoom)
//            //    ZoomKeybindButton.Invoke();
//            //if (Configuration.JSONConfig.Fly)
//            //    FlyKeybindButton.Invoke();
//            //if (Configuration.JSONConfig.BlackScreenBool)
//            //    blackscreenbutton.Invoke();
//        }
//        public static void update()
//        {
//            FreeRoam.FreeRoam.Update();
//            //buttons();
//            objecthead();
//            Spectator.update();
//        }
//        #region Every method so that onupdate looks clean!!
//        public static void objecthead()
//        {
//            //    if (mymainsyoudontknow)
//            //    {
//            //        Useful.LocalPlayerCamera.transform.rotation = Quaternion.Inverse(Useful.LocalPlayerCamera.transform.rotation);
//            //    }
//            //    if (thiscrazything)
//            //        Useful.LocalPlayerCamera.transform.rotation = Useful.SelectedPlayer.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Head).transform.rotation;
////if (m_State)
////{
////    var objects = UnityEngine.Object.FindObjectsOfType<VRC_Pickup>();

////    for (int i = 0; i < objects.Count; i++)
////        try
////        {
////            {
////                //Useful.LocalPlayerCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition
////                if (Networking.GetOwner(objects[i].gameObject) != Useful.LocalPlayer1.field_Private_VRCPlayerApi_0)
////                    Networking.SetOwner(Networking.LocalPlayer, objects[i].gameObject);
////                objects[i].transform.position = Useful.SelectedPlayer.transform
////                    .Find("ForwardDirection/Avatar").GetComponent<Animator>()
////                    .GetBoneTransform(HumanBodyBones.Head).FindChild("HmdPivot").transform.position;

////            }
////        }
////        catch
////        {
////        }
////}
//            //}
//        }
//    }
//
////public static void List()
//////{
//////    foreach (var people in buttonsl)
//////        people.Destroy();

//////    int x = 1, y = 0;
//////    foreach (var player in Useful.Players)
//////    {
//////        buttonsl.Add(new SingleButton(PlayerList.MenuPath, x, y, true, $"{player.prop_APIUser_0.displayName}", "Select This User", delegate ()
//////        {
//////            Useful.QMSelectPlayer(player);
//////        }, ModColors.TrustColor(player?.prop_APIUser_0), player.prop_APIUser_0.isFriend ? Color.yellow : ModColors.ButtonDefaultBackground));
//////        if (x < 4)
//////            x++;
//////        else
//////        {
//////            x = 1;
//////            y++;
//////        }
//////    }
////}
////public static void buttons()
////{
////if (uspeakbool)
////{
////    user123sbytess = Useful.SelectedPlayer.prop_USpeaker_0.field_Private_ArrayOf_Byte_0;
////    foreach (var uspeak in USpeaker.field_Internal_Static_List_1_USpeaker_0)
////        USpeaker.Method_Public_Static_USpeaker_Object_0(uspeak).field_Private_AudioSource_0 = Useful.SelectedPlayer.prop_USpeaker_0.field_Private_AudioSource_0;
////}
////if (mymainsyoudontknow)
////{
////    if (Input.GetKeyDown(KeyCode.W))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        newspinnyt.Invoke();
////    }
////    if (Input.GetKeyDown(KeyCode.A))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        newspinnyt.Invoke();
////    }
////    if (Input.GetKeyDown(KeyCode.S))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        newspinnyt.Invoke();
////    }
////    if (Input.GetKeyDown(KeyCode.D))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        newspinnyt.Invoke();
////    }
////    if (Input.GetKeyDown(KeyCode.Escape))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        newspinnyt.Invoke();
////    }
////}
////if (thiscrazything)
////{
////    if (Useful.SelectedPlayer == null)
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        copyhead.Invoke();

////    }
////    if (Input.GetKeyDown(KeyCode.W))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        copyhead.Invoke();
////        copyhead.Invoke();
////    }
////    if (Input.GetKeyDown(KeyCode.A))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        copyhead.Invoke();
////    }
////    if (Input.GetKeyDown(KeyCode.S))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        copyhead.Invoke();
////    }
////    if (Input.GetKeyDown(KeyCode.D))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        copyhead.Invoke();
////    }
////    if (Input.GetKeyDown(KeyCode.Escape))
////    {

////        Useful.LocalPlayerCamera.transform.localRotation = cachethis3;
////        copyhead.Invoke();
////    }
////}
////if (zoom)
////{
////    if (Input.GetKeyDown(KeyCode.G) && Useful.IsInWorld())

////    {
////        GameObject.Find("UserInterface/PlayerDisplay/WorldHudDisplay/MenuMesh").SetActive(false);
////        Useful.LocalPlayerCamera.GetComponent<Camera>().fieldOfView = Configuration.JSONConfig.CustomFOV / 4;
////    }

////    if (Input.GetKeyUp(KeyCode.G) && Useful.IsInWorld())
////    {
////        GameObject.Find("UserInterface/PlayerDisplay/WorldHudDisplay/MenuMesh").SetActive(true);
////        Useful.LocalPlayerCamera.GetComponent<Camera>().fieldOfView = Configuration.JSONConfig.CustomFOV;
////    }
////}
////if (Input.GetKeyDown(KeyCode.F) && Useful.IsInWorld())
////    QMmenu.FLYBUTTONS.Invoke();

////if (isFly)
////{
////    if (flybool)
////    {
////        if (Input.mouseScrollDelta.y != 0)
////        {
////            flySpeed += (int)Input.mouseScrollDelta.y;

////            if (flySpeed <= 0)
////                flySpeed = (int).4;

////            QMmenu.speedResetButton.SetButtonText($"Current Speed\n[{flySpeed}]");
////        }

////        if (Input.GetKey(KeyCode.W))
////            Useful.LocalPlayer.gameObject.transform.position += Useful.LocalPlayerCamera.transform.forward * flySpeed * Time.deltaTime;
////        if (Input.GetKey(KeyCode.A))
////            Useful.LocalPlayer.gameObject.transform.position -= Useful.LocalPlayerCamera.transform.right * flySpeed * Time.deltaTime;
////        if (Input.GetKey(KeyCode.S))
////            Useful.LocalPlayer.gameObject.transform.position -= Useful.LocalPlayerCamera.transform.forward * flySpeed * Time.deltaTime;
////        if (Input.GetKey(KeyCode.D))
////            Useful.LocalPlayer.gameObject.transform.position += Useful.LocalPlayerCamera.transform.right * flySpeed * Time.deltaTime;

////        if (Input.GetKey(KeyCode.E))
////            Useful.LocalPlayer.gameObject.transform.position += Vector3.up * flySpeed * Time.deltaTime;
////        if (Input.GetKey(KeyCode.Q))
////            Useful.LocalPlayer.gameObject.transform.position -= Vector3.up * flySpeed * Time.deltaTime;

////        if (Math.Abs(Input.GetAxis("Joy1 Axis 2")) > 0f)
////            Useful.LocalPlayer.gameObject.transform.position += Useful.LocalPlayerCamera.transform.forward * flySpeed * Time.deltaTime * (Input.GetAxis("Joy1 Axis 2") * -1f);
////        if (Math.Abs(Input.GetAxis("Joy1 Axis 1")) > 0f)
////            Useful.LocalPlayer.gameObject.transform.position += Useful.LocalPlayerCamera.transform.right * flySpeed * Time.deltaTime * Input.GetAxis("Joy1 Axis 1");
////    }
////}

////if (infjumpstate)
////{
////    if (VRCInputManager.Method_Public_Static_VRCInput_String_0("Jump").prop_Boolean_3)
////    {
////        Vector3 velocity = Networking.LocalPlayer.GetVelocity();
////        velocity.y = Networking.LocalPlayer.GetJumpImpulse();
////        Networking.LocalPlayer.SetVelocity(velocity);
////    }
////    else
////    { };
////    if (Spectatortoggle)
////    {

////        if (Useful.SelectedPlayer == null)
////        {
////            Ears = GameObject.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck/Camera (head)/Camera (ears)").gameObject;
////            Ears.transform.position = Useful.LocalPlayer1.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Head).FindChild("HmdPivot").transform.position;
////            Useful.LocalPlayerCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
////            spectatebutton.Invoke();
////        }
////        if (Input.GetKeyDown(KeyCode.Escape))
////        {
////            Ears = GameObject.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck/Camera (head)/Camera (ears)").gameObject;
////            Ears.transform.position = Useful.LocalPlayer1.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Head).FindChild("HmdPivot").transform.position;
////            Useful.LocalPlayerCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
////            spectatebutton.Invoke();
////        }
////        if (Input.GetKeyDown(KeyCode.W))
////        {
////            Ears = GameObject.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck/Camera (head)/Camera (ears)").gameObject;
////            Ears.transform.position = Useful.LocalPlayer1.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Head).FindChild("HmdPivot").transform.position;
////            Useful.LocalPlayerCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
////            spectatebutton.Invoke();
////        }
////        if (Input.GetKeyDown(KeyCode.A))
////        {
////            Ears = GameObject.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck/Camera (head)/Camera (ears)").gameObject;
////            Ears.transform.position = Useful.LocalPlayer1.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Head).FindChild("HmdPivot").transform.position;
////            Useful.LocalPlayerCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
////            spectatebutton.Invoke();
////        }
////        if (Input.GetKeyDown(KeyCode.S))
////        {
////            Ears = GameObject.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck/Camera (head)/Camera (ears)").gameObject;
////            Ears.transform.position = Useful.LocalPlayer1.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Head).FindChild("HmdPivot").transform.position;
////            Useful.LocalPlayerCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
////            spectatebutton.Invoke();
////        }
////        if (Input.GetKeyDown(KeyCode.D))
////        {
////            Ears = GameObject.Find("_Application/TrackingVolume/TrackingSteam(Clone)/SteamCamera/[CameraRig]/Neck/Camera (head)/Camera (ears)").gameObject;
////            Ears.transform.position = Useful.LocalPlayer1.transform.Find("ForwardDirection/Avatar").GetComponent<Animator>().GetBoneTransform(HumanBodyBones.Head).FindChild("HmdPivot").transform.position;
////            Useful.LocalPlayerCamera.transform.rotation = new Quaternion(0, 0, 0, 0);
////            spectatebutton.Invoke();
////        }
////    }
////}


////        public static void espon()
////        {
////            if (Useful.IsInWorld())
////            {
////                var allPlayers = Useful.Players;
////                var allObjects = GameObject.FindObjectsOfType<VRC_Pickup>();

////                foreach (var player in allPlayers)
////                    if (!player.prop_APIUser_0.IsSelf)
////                        HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(player.gameObject.transform.Find("SelectRegion").GetComponent<MeshRenderer>(), playeresp);

////                foreach (var pickup in allObjects)
////                    HighlightsFX.prop_HighlightsFX_0.Method_Public_Void_Renderer_Boolean_0(pickup.GetComponent<MeshRenderer>(), objectesp);
////            }
////        }
////        public static void lookbetter()
////        {
////            FOVSLIDER.slider.GetComponent<UnityEngine.UI.Slider>().maxValue = 120f;
////            FOVSLIDER.slider.GetComponent<UnityEngine.UI.Slider>().minValue = 40f;
////            FOVSLIDER.slider.GetComponent<UnityEngine.UI.Slider>().value = (float)Configuration.JSONConfig.CustomFOV;
////            FOVSLIDER.slider.GetComponent<RectTransform>().sizeDelta *= new Vector2(2f, 1f);
////            FOVSLIDER.slider.GetComponent<RectTransform>().anchoredPosition += new Vector2(480f, -104f);
////        }
////        private static Vector3 x = new Vector3(0, 0, 0);
////#pragma warning disable CS0169 // The field 'QMmenu.quar2t' is never used
////        private static Quaternion quar2t;
////#pragma warning restore CS0169 // The field 'QMmenu.quar2t' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.zaxis' is never used
////        private static float zaxis;
////#pragma warning restore CS0169 // The field 'QMmenu.zaxis' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.me2' is never used
////        private static Quaternion me2;
////#pragma warning restore CS0169 // The field 'QMmenu.me2' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.me' is never used
////        private static float me;
////#pragma warning restore CS0169 // The field 'QMmenu.me' is never used
////#pragma warning disable CS0169 // The field 'QMmenu.themes' is never used
////        private static float themes;
////#pragma warning restore CS0169 // The field 'QMmenu.themes' is never used
////        private static bool mymainsyoudontknow;
////        private static bool uspeakbool;
////        private static Il2CppStructArray<byte> user123sbytess;
////        public static bool antiblock;
////        private static ToggleButton event6;
////        private static ToggleButton event9;
////        private static bool blackscreenbool;
////        private static bool somethingabout;
////        private static bool somethingimmakingup;

////        public void OnLateUpdate()
////        {
////            if (cloneButton != null)
////                cloneButton.SetActive(false);
////        }
////        #endregion ok time to go back now
////    }
////}

//#endregion