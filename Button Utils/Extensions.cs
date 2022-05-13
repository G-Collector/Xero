using System;
using System.Linq;
using System.Reflection;
using Il2CppSystem;
using MelonLoader;
using UnhollowerRuntimeLib;
using UnhollowerRuntimeLib.XrefScans;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRC.DataModel;
using VRC.DataModel.Core;
using VRC.UI.Elements;
using VRC.UI.Elements.Controls;

namespace Xero.Utils
{

	public static class Extensions
	{
		
		public static GameObject FindObject(this GameObject parent, string name)
		{
			foreach (Transform transform in parent.GetComponentsInChildren<Transform>(true))
			{
				if (transform.name == name)
				{
					return transform.gameObject;
				}
			}
			return null;
		}

		
		public static string GetPath(this GameObject gameObject)
		{
			string text = "/" + gameObject.name;
			while (gameObject.transform.parent != null)
			{
				gameObject = gameObject.transform.parent.gameObject;
				text = "/" + gameObject.name + text;
			}
			return text;
		}

		public static void DestroyChildren(this Transform transform, System.Func<Transform, bool> exclude)
		{
			for (int i = transform.childCount - 1; i >= 0; i--)
			{
				if (exclude == null || exclude(transform.GetChild(i)))
				{
					UnityEngine.Object.DestroyImmediate(transform.GetChild(i).gameObject);
				}
			}
		}

		
		public static void DestroyChildren(this Transform transform)
		{
			transform.DestroyChildren(null);
		}

	
		public static Vector3 SetX(this Vector3 vector, float x)
		{
			return new Vector3(x, vector.y, vector.z);
		}


		public static Vector3 SetY(this Vector3 vector, float y)
		{
			return new Vector3(vector.x, y, vector.z);
		}


		public static Vector3 SetZ(this Vector3 vector, float z)
		{
			return new Vector3(vector.x, vector.y, z);
		}

		public static float RoundAmount(this float i, float nearestFactor)
		{
			return (float)System.Math.Round((double)(i / nearestFactor)) * nearestFactor;
		}


		public static Vector3 RoundAmount(this Vector3 i, float nearestFactor)
		{
			return new Vector3(i.x.RoundAmount(nearestFactor), i.y.RoundAmount(nearestFactor), i.z.RoundAmount(nearestFactor));
		}


		public static Vector2 RoundAmount(this Vector2 i, float nearestFactor)
		{
			return new Vector2(i.x.RoundAmount(nearestFactor), i.y.RoundAmount(nearestFactor));
		}


		public static Sprite ToSprite(this Texture2D tex)
		{
			Rect rect = new Rect(0f, 0f, (float)tex.width, (float)tex.height);
			Vector2 vector = new Vector2(0.5f, 0.5f);
			Vector4 zero = Vector4.zero;
			Sprite sprite = Sprite.CreateSprite_Injected(tex, ref rect, ref vector, 50f, 0U, SpriteMeshType.FullRect, ref zero, false);
			sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
			return sprite;
		}
		public static string ReplaceFirst(this string text, string search, string replace)
		{
			int num = text.IndexOf(search);
			if (num < 0)
			{
				return text;
			}
			return text.Substring(0, num) + replace + text.Substring(num + search.Length);
		}
		public static ColorBlock SetColor(this ColorBlock block, Color color)
		{
			return new ColorBlock
			{
				colorMultiplier = block.colorMultiplier,
				disabledColor = Color.grey,
				highlightedColor = color,
				normalColor = color / 1.5f,
				pressedColor = Color.white,
				selectedColor = color / 1.5f
			};
		}

		public static void DelegateSafeInvoke(this System.Delegate @delegate, params object[] args)
		{
			System.Delegate[] invocationList = @delegate.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				try
				{
					invocationList[i].DynamicInvoke(args);
				}
				catch (System.Exception ex)
				{
					MelonLogger.Msg("Error while executing delegate:\n" + ex.ToString());
				}
			}
		}

		public static string ToEasyString(this System.TimeSpan timeSpan)
		{
			if (Mathf.FloorToInt((float)(timeSpan.Ticks / 864000000000L)) > 0)
			{
				return string.Format("{0:%d} days", timeSpan);
			}
			if (Mathf.FloorToInt((float)(timeSpan.Ticks / 36000000000L)) > 0)
			{
				return string.Format("{0:%h} hours", timeSpan);
			}
			if (Mathf.FloorToInt((float)(timeSpan.Ticks / 600000000L)) > 0)
			{
				return string.Format("{0:%m} minutes", timeSpan);
			}
			return string.Format("{0:%s} seconds", timeSpan);
		}

		public static void ShowAlert(this QuickMenu qm, string message)
		{
			if (Extensions.ourShowAlertMethod == null)
			{
				foreach (MethodInfo methodInfo in typeof(ModalAlert).GetMethods())
				{
					MelonLogger.Msg(methodInfo.Name);
					if (methodInfo.Name.Contains("Method_Private_Void_") && !methodInfo.Name.Contains("PDM") && methodInfo.GetParameters().Length == 0)
					{
						qm.field_Private_Notification_0.message = message;
						methodInfo.Invoke(qm.field_Private_Notification_0, null);
						if (qm.transform.Find("Container/Window/QMParent/Modal_Alert/Background_Alert").gameObject.activeSelf)
						{
							Extensions.ourShowAlertMethod = methodInfo;
							return;
						}
					}
				}
				return;
			}
			qm.field_Private_Notification_0.message = message;
			Extensions.ourShowAlertMethod.Invoke(qm.field_Private_Notification_0, null);
		}

		public static MethodInfo ShowOKDialogMethod
		{
			get
			{
				if (Extensions.ourShowOKDialogMethod != null)
				{
					return Extensions.ourShowOKDialogMethod;
				}
				Extensions.ourShowOKDialogMethod = typeof(QuickMenu).GetMethods().First(delegate (MethodInfo it)
				{
					if (it != null && it.GetParameters().Length == 3 && it.Name.Contains("_PDM") && it.GetParameters().First<ParameterInfo>().ParameterType == typeof(string) && it.GetParameters().Last<ParameterInfo>().ParameterType == typeof(Il2CppSystem.Action))
					{
						return XrefScanner.XrefScan(it).Any(delegate (XrefInstance jt)
						{
							if (jt.Type == XrefType.Global)
							{
								Il2CppSystem.Object @object = jt.ReadAsObject();
								return ((@object != null) ? @object.ToString() : null) == "ConfirmDialog";
							}
							return false;
						});
					}
					return false;
				});
				return Extensions.ourShowOKDialogMethod;
			}
		}

		public static void ShowOKDialog(this QuickMenu qm, string title, string message, System.Action okButton = null)
		{
			Extensions.ShowOKDialogMethod.Invoke(qm, new object[]
			{
				title,
				message,
				DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(okButton)
			});
		}
		public static MethodInfo ShowConfirmDialogMethod
		{
			get
			{
				if (Extensions.ourShowConfirmDialogMethod != null)
				{
					return Extensions.ourShowConfirmDialogMethod;
				}
				Extensions.ourShowConfirmDialogMethod = typeof(QuickMenu).GetMethods().First((MethodInfo it) => it != null && it.GetParameters().Length == 4 && it.Name.Contains("_PDM") && it.GetParameters()[0].ParameterType == typeof(string) && it.GetParameters()[1].ParameterType == typeof(string) && it.GetParameters()[2].ParameterType == typeof(Il2CppSystem.Action) && it.GetParameters()[3].ParameterType == typeof(Il2CppSystem.Action) && XrefScanner.UsedBy(it).ToList<XrefInstance>().Count > 30);
				return Extensions.ourShowConfirmDialogMethod;
			}
		}


		public static void ShowConfirmDialog(this QuickMenu qm, string title, string message, System.Action yesButton = null, System.Action noButton = null)
		{
			Extensions.ShowConfirmDialogMethod.Invoke(qm, new object[]
			{
				title,
				message,
				DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(yesButton),
				DelegateSupport.ConvertDelegate<Il2CppSystem.Action>(noButton)
			});
		}


		public static void ShowCustomDialog(this QuickMenu qm, string title, string message, string button1Text, string button2Text, string button3Text, System.Action button1Action = null, System.Action button2Action = null, System.Action button3Action = null)
		{
            //qm.Method_Public_Void_String_String_String_String_String_Action_Action_Action_PDM_0(title, message, button1Text, button2Text, button3Text, button1Action, button2Action, button3Action);
        }


		public static MethodInfo AskConfirmOpenURLMethod
		{
			get
			{
				if (Extensions.ourAskConfirmOpenURLMethod != null)
				{
					return Extensions.ourAskConfirmOpenURLMethod;
				}
				Extensions.ourAskConfirmOpenURLMethod = typeof(QuickMenu).GetMethods().First(delegate (MethodInfo it)
				{
					if (it != null && it.GetParameters().Length == 1 && it.Name.Contains("_Virtual_Final_New") && it.GetParameters().First<ParameterInfo>().ParameterType == typeof(string))
					{
						return XrefScanner.XrefScan(it).Any((XrefInstance jt) => jt.Type == XrefType.Global && jt.ReadAsObject() != null && jt.ReadAsObject().ToString().Contains("This link will open in your web browser."));
					}
					return false;
				});
				return Extensions.ourAskConfirmOpenURLMethod;
			}
		}


		public static void AskConfirmOpenURL(this QuickMenu qm, string url)
		{
			Extensions.AskConfirmOpenURLMethod.Invoke(qm, new object[]
			{
				url
			});
		}


		public static MethodInfo ToIUserMethod
		{
			get
			{
				if (Extensions._apiUserToIUser == null)
				{
					System.Type type2 = typeof(VRCPlayer).Assembly.GetTypes().First(delegate (System.Type type)
					{
						if (type.GetMethods().FirstOrDefault((MethodInfo method) => method.Name.StartsWith("Method_Private_Void_Action_1_ApiWorldInstance_Action_1_String_")) != null)
						{
							return type.GetMethods().FirstOrDefault((MethodInfo method) => method.Name.StartsWith("Method_Public_Virtual_Final_New_Observable_1_List_1_String_")) == null;
						}
						return false;
					});
					Extensions._apiUserToIUser = typeof(DataModelCache).GetMethod("Method_Public_TYPE_String_TYPE2_Boolean_0");
					Extensions._apiUserToIUser = Extensions._apiUserToIUser.MakeGenericMethod(new System.Type[]
					{
						type2,
						typeof(APIUser)
					});
				}
				return Extensions._apiUserToIUser;
			}
		}


		public static IUser ToIUser(this APIUser value)
		{
			return ((Il2CppSystem.Object)Extensions._apiUserToIUser.Invoke(DataModelManager.field_Private_Static_DataModelManager_0.field_Private_DataModelCache_0, new object[]
			{
				value.id,
				value,
				false
			})).Cast<IUser>();
		}


		private static MethodInfo ourShowAlertMethod;

		private static MethodInfo ourShowOKDialogMethod;


		private static MethodInfo ourShowConfirmDialogMethod;


		private static MethodInfo ourAskConfirmOpenURLMethod;

		private static MethodInfo _apiUserToIUser;
	}
}
