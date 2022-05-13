using System;
using ExitGames.Client.Photon;
using Il2CppSystem;
using Photon.Pun;
using Photon.Realtime;

namespace Xero
{
	internal static class OP
	{
		public static void OpRaiseEvent(byte code, object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
		{
			Il2CppSystem.Object customObject2 = Serialization.FromManagedToIL2CPP<Il2CppSystem.Object>(customObject);
			OpRaiseEvent(code, customObject2, RaiseEventOptions, sendOptions);
		}

		public static void OpRaiseEvent(byte code, Il2CppSystem.Object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
		{
			PhotonNetwork.Method_Private_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0(code, customObject, RaiseEventOptions, sendOptions);
		}
		public static void OpRaiseEventlb(byte code, object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
		{
			Il2CppSystem.Object Object = Serialization.FromManagedToIL2CPP<Il2CppSystem.Object>(customObject);
			OpRaiseEventlb(code, Object, RaiseEventOptions, sendOptions);
		}
		public static void OpRaiseEventlb(byte code, Il2CppSystem.Object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
   => BegoneGameObject.XeroCore.photonHandler.field_Private_LoadBalancingClient_0.Method_Public_Virtual_New_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0(code, customObject, RaiseEventOptions, sendOptions);



	}
}