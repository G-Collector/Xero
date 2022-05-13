using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;

namespace Xero
{
    public static class SpriteExtensions
    {
        public static Sprite LoadSpriteFromDisk(this string path)
        {
            if (string.IsNullOrEmpty(path))
                return null;

            byte[] array = File.ReadAllBytes(path);
            if (array == null || array.Length == 0)
                return null;

            Texture2D texture2D = new Texture2D(512, 512);
            if (!Il2CppImageConversionManager.LoadImage(texture2D, array))
                return null;

            Sprite sprite = Sprite.CreateSprite(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f, 0U, 0, default(Vector4), false);
            sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            return sprite;
        }

        public static void LoadSpriteFromUrl(this Image Instance, string url)
        {
            if (string.IsNullOrEmpty(url))
                return;

            byte[] array = new WebClient().DownloadData(url);
            if (array == null || array.Length == 0)
                return;

            Texture2D texture2D = new Texture2D(512, 512);
            if (!Il2CppImageConversionManager.LoadImage(texture2D, array))
                return;

            Sprite sprite = Sprite.CreateSprite(texture2D, new Rect(0f, 0f, texture2D.width, texture2D.height), new Vector2(0.5f, 0.5f), 100f, 0U, 0, default(Vector4), false);
            sprite.hideFlags |= HideFlags.DontUnloadUnusedAsset;
            Instance.sprite = sprite;
            Instance.color = Color.white;
        }
    }
}




