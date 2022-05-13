using MelonLoader;
using System;
using System.IO;
using UnityEngine;
using TinyJson.Xero;
using GameObjectBegone.APi.Utils;
using Xero.tinyJSON;

namespace Xero.Configer
{
	public class Configuration
	{

		public static void Initialize()
		{
			if (!Directory.Exists(Path.Combine(Environment.CurrentDirectory, "Xero/Config")))
				Directory.CreateDirectory(Path.Combine(Environment.CurrentDirectory, "Xero/Config"));
			if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.json")))

			{
				MelonLogger.Msg($"Yes Foxx File Exists it is in");
				MelonLogger.Msg((Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.json")));
				try
				{
					Configuration.JSONConfig = Decoder.Decode(File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.json"))).Make<Config>();
					if (Configuration.JSONConfig == null)
					{
						MelonLogger.Error("An error occured while parsing the config file. It has been moved to config.old.json, and a new one has been created.");
						MelonLogger.Error("Error: The parsed config was null...");
						File.Move(Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.json"), Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.old.json"));
						Configuration.JSONConfig = new Config();
					}
					return;
				}
				catch (Exception ex)
				{
					MelonLogger.Error("An error occured while parsing the config file. It has been moved to config.old.json, and a new one has been created.");
					MelonLogger.Error("Error: " + ex.ToString());
					if (File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.old.json")))
					{
						File.Delete(Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.old.json"));
					}
					File.Move(Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.json"), Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.old.json"));
					Configuration.JSONConfig = new Config();
					return;
				}
			}
			else{																}
			Configuration.JSONConfig = new Config();
			if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.json")))
			{ File.Create(Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.json")); }
		}

		public static void SaveConfig()
		{
			Configuration.JSONConfig.CustomFOV = Useful.LocalPlayerCamera.GetComponent<Camera>().fieldOfView;
			File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "Xero/Config/config.json"), Encoder.Encode(Configuration.JSONConfig, EncodeOptions.PrettyPrint));
			MelonLogger.Msg("Config Saved!");
		}
		public static Config JSONConfig;
	}
}
