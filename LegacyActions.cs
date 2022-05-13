using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BegoneGameObject;
using GameObjectBegone;
using MelonLoader;
using UnityEngine;

namespace Xero
{
    class LegacyActions // This was the first thing that I created in this project Some Code Seems really dumb because it is... But I want to remember my first Class even though it looks dumb.
    {
        public static async void Turnoff()
        {
            await System.Threading.Tasks.Task.Delay(2000);
            XeroCore._extremesearch = false;
        }
        public static void LegacyFinder()
        {
            XeroCore._extremesearchbuttonon = Input.GetKeyDown(KeyCode.Backslash);
            XeroCore._extremesearchbuttonoff = Input.GetKeyDown(KeyCode.Alpha0);
            XeroCore._buttonstateon = Input.GetKeyDown(KeyCode.F9);
            XeroCore._buttonstateoff = Input.GetKeyDown(KeyCode.F10);
            if (Input.GetKeyDown(KeyCode.Slash))
            {
                SpaceRemoval.clear();
                booltest();
            }
            if (Input.GetKeyDown(KeyCode.Period))
            {
                XeroCore.s = GameObject.Find("New Game Object");
                if (XeroCore.s)
                {
                    GameObject.Destroy(XeroCore.s);
                }
            }
            if (XeroCore._buttonstateon)
            {
                MelonLogger.Msg("GameObjectXero is Enabled");
                XeroCore. _gameObjectsearch = true;
            }
            if (XeroCore._buttonstateoff)
            {
                MelonLogger.Warning("GameObjectXero is Disabled");
                XeroCore._gameObjectsearch = false;
            }
            if (XeroCore._extremesearchbuttonon)
            {
                MelonLogger.Warning("Extreme Search is Enabled THIS WILL LAG, ONCE FINISHED PRESS 0");
                XeroCore._extremesearch = true;
                Turnoff();
            }
            if (XeroCore._extremesearchbuttonoff)
            {
                MelonLogger.Msg("Extreme Search Disabled");
                XeroCore._extremesearch = false;
            }
            if (XeroCore._extremesearch)
            {
                foreach (string hidename in File.ReadAllLines(Environment.CurrentDirectory + "\\Mods\\List\\GameObjectList.txt"))
                {
                    foreach (string name in File.ReadAllLines(Environment.CurrentDirectory + "\\Mods\\List\\GameObjectList.txt"))
                    {
                        foreach (var player in Useful.Players)
                        {
                            try
                            {
                                XeroCore._hiddenobject = player?.transform.Find("ForwardDirection/Avatar").Find(name);
                                XeroCore._hiddenobjectHideCloneName = VRC.Player.prop_Player_0.transform.Find("ForwardDirection").transform.Find("_AvatarMirrorClone").Find(name);
                                XeroCore._hiddenobjectHideName = VRC.Player.prop_Player_0.transform.Find("ForwardDirection").transform.Find("_AvatarShadowClone").Find(name);
                            }
                            catch { MelonLogger.Msg($"Error in finding GameObject inside of {player.prop_APIUser_0.displayName}"); };

                            if (XeroCore._hiddenobject)
                            {
                                GameObject.Destroy(XeroCore._hiddenobject.gameObject);
                                MelonLogger.Msg($"Caught a Hidden GameObject >'* {name} *'<  Found in {player.prop_APIUser_0.displayName}");
                            }
                            if (XeroCore._hiddenobjectHideName)
                            {
                                GameObject.Destroy(XeroCore._hiddenobjectHideName.gameObject);
                            }
                            if (XeroCore._hiddenobjectHideCloneName)
                            {
                                GameObject.Destroy(XeroCore._hiddenobjectHideCloneName.gameObject);
                            }
                            if (XeroCore._extrahidden)
                            {
                                GameObject.Destroy(XeroCore._extrahidden);
                            }
                            if (XeroCore._extrahidden2)
                            {
                                GameObject.Destroy(XeroCore._extrahidden2);
                            }
                        }
                    }
                }
            }
            if (XeroCore._gameObjectsearch)
            {
                foreach (string name in File.ReadAllLines(Environment.CurrentDirectory + "\\Mods\\List\\GameObjectList.txt"))
                {
                    if (GameObject.Find(name))
                    {
                        XeroCore._nameobject = GameObject.Find(name);
                        MelonLogger.Msg("Caught a Wild GameObject! >'* " + name + " *'< ");
                        UnityEngine.Object.DestroyObject(XeroCore._nameobject);
                        XeroCore._nameobject.SetActive(false);
                        XeroCore._nameobject.active = false;
                    }
                }
            }
        }
        public static void booltest()
        {
            if (XeroCore._gameObjectsearch == false)
            {
                MelonLogger.Msg("GameObjectXero Is Disabled");
            }
            if (XeroCore._gameObjectsearch == true)
            {
                MelonLogger.Msg("GameObjectXero Is Enabled");
            }
            if (XeroCore._extremesearch == false)
            {

            }
            if (XeroCore._extremesearch == true)
            {
                MelonLogger.Msg("Extreme Search is Enabled");
            }
        }
    }
}
