using System.IO;
using UnityEngine;

namespace ModernMod.Code.Utils {
  public static class AssetUtils {
    /// <summary>
    /// Loads the byte contents of a file from the EmbeddedResources directory of ModernMod.
    /// </summary>
    /// <param name="path">A path pointing to a file in the EmbeddedResources directory of ModernMod, in the form of e.g. actors/maxim_spider.png. The path to EmbeddedResources is automatically appended.</param>
    /// <returns>The bytes stored at that path. Throws an exception if literally anything goes wrong in this process (there's 0 exception handling present).</returns>
    public static byte[] LoadEmbeddedResource(string path) {
      return File.ReadAllBytes(ModernMod.Instance.GetDeclaration().FolderPath + "/EmbeddedResources/" + path);
    }
    /// <summary>
    /// Loads a sprite from a PNG from the EmbeddedResources directory of ModernMod.
    /// </summary>
    /// <param name="path">A path pointing to a PNG in the EmbeddedResources directory of ModernMod, in the form of e.g. actors/maxim_spider. The path to EmbeddedResources and the .png are automatically appended.</param>
    /// <returns>A Sprite representing the PNG file loaded at that path. Throws an exception if literally anything goes wrong in this process (there's 0 exception handling present).</returns>
    public static Sprite LoadEmbeddedSprite(string path) {
      Texture2D spriteTexture = new Texture2D(1, 1, TextureFormat.ARGB32, false) {
        anisoLevel = 0,
        filterMode = FilterMode.Point
      };
      spriteTexture.LoadImage(LoadEmbeddedResource(path + ".png"));
      return Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), new Vector2(0.5f, 0.5f));
    }
  }
}