using DiskCardGame;
using InscryptionAPI.Card;
using InscryptionAPI.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ConfigurableEmissions
{
    public class ConfigurableBackground : CardAppearanceBehaviour
    {
        public static Dictionary<string, Texture2D> pathToTexture = new();

        public override void ApplyAppearance()
        {
            try
            {
                Texture2D tex = null;
                string path = Card.Info.GetExtendedProperty("customBackground");
                if(path != null)
                {
                    if (!pathToTexture.TryGetValue(path, out tex))
                    {
                        pathToTexture.Add(path, tex = TextureHelper.GetImageAsTexture(path));
                    }
                    if (tex != null)
                    {
                        Card.RenderInfo.baseTextureOverride = tex;
                    }
                }
            }
            catch(Exception ex)
            {
                Debug.LogError("Failed setting custom background: " + ex);
            }
        }

        public override void ResetAppearance()
        {
            Card.RenderInfo.baseTextureOverride = ResourceBank.Get<Texture>("Art/Cards/card_empty");
        }
    }
}
