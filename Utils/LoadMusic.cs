using MelonLoader;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using Xero;

namespace Music
{
	public class LoadMusic
	{
		public static bool menumusic = Xero.Configer.Configuration.JSONConfig.menumusic;

		public static IEnumerator Init()
		{
			if (menumusic == true)
			{


				if (!Directory.Exists(Environment.CurrentDirectory + "\\Xero\\Music"))
				{
					Directory.CreateDirectory(Environment.CurrentDirectory + "\\Xero\\Music");
				}
				if (!Directory.Exists(Environment.CurrentDirectory + "\\Xero\\Music\\MultipleMusic"))
				{
					Directory.CreateDirectory(Environment.CurrentDirectory + "\\Xero\\Music\\MultipleMusic");
				}

				if (File.Exists(Environment.CurrentDirectory + "\\Xero\\Music\\custommenu.ogg"))
				{
					try
					{
						File.Move(Path.Combine(Environment.CurrentDirectory + "\\Xero\\Music\\custommenu.ogg"), Path.Combine(Environment.CurrentDirectory + "\\Xero\\Music\\MultipleMusic\\custommenu.ogg"));
					}
					catch (Exception)
					{
						new Exception();
						MelonLogger.Error("Please put custom menu music in the Ogg Vorbis format instead.");
					}
				}
				string[] files = Directory.GetFiles(Environment.CurrentDirectory + "\\Xero\\Music\\MultipleMusic");
				if (files.Length >= 1)
				{
					MelonLogger.Msg("Processing custom menu music.");
					int num = new System.Random().Next(files.Length);
					MelonLogger.Msg($"Picked track: {num} ");
					GameObject loadingMusic = GameObject.Find("LoadingBackground_TealGradient_Music/LoadingSound");
					GameObject loadingMusic2 = Useful.GetVRCUiMInstance().menuContent().transform.Find("Popups/LoadingPopup/LoadingSound").gameObject;
					if (loadingMusic != null)
					{
						loadingMusic.GetComponent<AudioSource>().Stop();
					}
					if (loadingMusic2 != null)
					{
						loadingMusic2.GetComponent<AudioSource>().Stop();
					}
					UnityWebRequest CustomLoadingMusicRequest = UnityWebRequest.Get(string.Format("file://{0}", files[num]).Replace("\\", "/"));
					CustomLoadingMusicRequest.SendWebRequest();
					while (!CustomLoadingMusicRequest.isDone)
					{
						yield return null;
					}
					MelonLogger.Msg("Request sent and returned");
					AudioClip audioClip = null;
					if (CustomLoadingMusicRequest.isHttpError)
					{
						MelonLogger.Msg("Could not load music file: " + CustomLoadingMusicRequest.error);
					}
					else
					{
						audioClip = WebRequestWWW.InternalCreateAudioClipUsingDH(CustomLoadingMusicRequest.downloadHandler, CustomLoadingMusicRequest.url, false, false, AudioType.UNKNOWN);
					}
					if (audioClip != null)
					{
						if (loadingMusic != null)
						{
							loadingMusic.GetComponent<AudioSource>().clip = audioClip;
							loadingMusic.GetComponent<AudioSource>().Play();
						}
						if (loadingMusic2 != null)
						{
							loadingMusic2.GetComponent<AudioSource>().clip = audioClip;
							loadingMusic2.GetComponent<AudioSource>().Play();
						}
					}
					loadingMusic = null;
					loadingMusic2 = null;
					CustomLoadingMusicRequest = null;
				}
			}
		}
	}
}


