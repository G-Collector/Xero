using UnityEngine;
using VRC.Core;
using VRC.SDKBase;
using VRC.UI;
using Xero;

namespace PortalInstance
{
internal class PortalToInst
{
    internal static void PortalToInstance()
    {
        bool flag = Time.time > PortalToInst.last_portal_drop;
        if (flag)
        {
            PortalToInst.last_portal_drop = Time.time + 30f;
            Transform transform = GameObject.Find("Screens").transform.Find("UserInfo");
            PageUserInfo componentInChildren = transform.transform.GetComponentInChildren<PageUserInfo>();
            bool flag2 = componentInChildren == null;
            if (!flag2)
            {
                APIUser field_Public_APIUser_ = componentInChildren.field_Private_APIUser_0;
                bool flag3 = field_Public_APIUser_ != null;
                if (flag3)
                {
                    VRCPlayer field_Internal_Static_VRCPlayer_ = VRCPlayer.field_Internal_Static_VRCPlayer_0;
                    bool flag4 = field_Public_APIUser_.location == "private";
                    if (flag4)
                    {
                        Useful.GetVRCUiPopupManager().AlertPopup("<color=red>Error</color>", "<color=white>User is in private world</color>");
                    }
                    else
                    {
                        bool flag5 = field_Public_APIUser_.id == APIUser.CurrentUser.id;
                        if (flag5)
                        {
                            Useful.GetVRCUiPopupManager().AlertPopup("<color=red>Error</color>", "<color=white>Cant drop a portal to yourself</color>");
                        }
                        else
                        {
                            bool flag6 = field_Public_APIUser_.location == null || field_Public_APIUser_.location == "";
                            if (flag6)
                            {
                                Useful.GetVRCUiPopupManager().AlertPopup("<color=red>Error</color>", "<color=white>Player not in any world</color>");
                            }
                            else
                            {
                                string[] array = field_Public_APIUser_.location.Split(new char[]
                                {
                                        ':'
                                });
                                GameObject gameObject = Networking.Instantiate(VRC_EventHandler.VrcBroadcastType.Always, "Portals/PortalInternalDynamic", field_Internal_Static_VRCPlayer_.transform.position + field_Internal_Static_VRCPlayer_.transform.forward * 1.5f, field_Internal_Static_VRCPlayer_.transform.rotation);
                                string text = array[0];
                                string text2 = array[1];
                                int value = 0;
                                RPC.Destination targetClients = RPC.Destination.AllBufferOne;
                                GameObject targetObject = gameObject;
                                string methodName = "ConfigurePortal";
                                Il2CppSystem.Object[] array2 = new Il2CppSystem.Object[3];
                                array2[0] = text;
                                array2[1] = text2;
                                int num = 2;
                                Il2CppSystem.Int32 @int = default(Il2CppSystem.Int32);
                                @int.m_value = value;
                                array2[num] = @int.BoxIl2CppObject();
                                Networking.RPC(targetClients, targetObject, methodName, array2);
                            }
                        }
                    }
                }
            }
        }
        else
        {
            float num2 = PortalToInst.last_portal_drop - Time.time;
            Useful.GetVRCUiPopupManager().AlertPopup("<color=red>Error</color>", "<color=white>Cooldown: Please wait" + System.Math.Floor((double)num2).ToString() + " seconds before trying again!</color>");
        }
    }
        internal static float last_portal_drop;
    }
}