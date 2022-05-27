using DiskCardGame;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ConfigurableEmissions
{
    public class ConfigurableStatColors : CardAppearanceBehaviour
    {
        public override void ApplyAppearance()
        {
            try
            {
                if (Card.Info.TryGetColorFromCardInfo("customPortraitColor", out var configolor))
                {
                    Card.RenderInfo.portraitColor = configolor;
                }
                if (Card.Info.TryGetColorFromCardInfo("customAttackColor", out configolor))
                {
                    Card.RenderInfo.attackTextColor = configolor;
                }
                if (Card.Info.TryGetColorFromCardInfo("customHealthColor", out configolor))
                {
                    Card.RenderInfo.healthTextColor = configolor;
                }
                if (Card.Info.TryGetColorFromCardInfo("customNameColor", out configolor))
                {
                    Card.RenderInfo.nameTextColor = configolor;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Failed setting custom portrait color: " + ex);
            }
        }

        public override void ResetAppearance()
        {
            try
            {
                Card.RenderInfo.portraitColor = Color.black;
            }
            catch(Exception ex)
            {
                Debug.LogError("Failed resetting custom portrait color: " + ex);
            }
        }
    }
}
