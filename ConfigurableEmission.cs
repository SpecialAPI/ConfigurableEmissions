using DiskCardGame;
using InscryptionAPI.Card;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ConfigurableEmissions
{
    public class ConfigurableEmission : CardAppearanceBehaviour
    {
        public override void ApplyAppearance()
        {
            try
            {
                if (Card.Info.TryGetColorFromCardInfo("customEmissionColor", out var configolor))
                {
                    Card.StatsLayer.SetEmissionColor(configolor);
                }
            }
            catch(Exception ex)
            {
                Debug.LogError("Failed setting custom emission color: " + ex);
            }
        }

        public override void ResetAppearance()
        {
            try
            {
                Card.StatsLayer.SetEmissionColor(GameColors.Instance.glowSeafoam);
            }
            catch(Exception ex)
            {
                Debug.LogError("Failed resetting custom emission color: " + ex);
            }
        }
    }
}
