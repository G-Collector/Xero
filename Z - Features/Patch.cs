using System;
using System.Reflection;
using Harmony;

namespace XeroPatchAPI
{
	public class Patch
	{
		public Patch(Type PatchClass, Type YourClass, string Method, string ReplaceMethod, BindingFlags stat = BindingFlags.Static, BindingFlags pub = BindingFlags.NonPublic)
		{
			Patch.HInstance.Patch(AccessTools.Method(PatchClass, Method, null, null), this.GetPatch(YourClass, ReplaceMethod, stat, pub), null, null);
		}
		private HarmonyMethod GetPatch(Type YourClass, string MethodName, BindingFlags stat, BindingFlags pub)
		{
			return new HarmonyMethod(YourClass.GetMethod(MethodName, stat | pub));
		}
		public static Type GetPatch(string v)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04000020 RID: 32
		public static readonly HarmonyInstance HInstance = HarmonyInstance.Create("Patches");

		// Token: 0x04000021 RID: 33
		internal static readonly HarmonyInstance HInstance2 = HarmonyInstance.Create("Patches");
	}
}
