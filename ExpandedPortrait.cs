using DiskCardGame;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ConfigurableEmissions
{
    public class ExpandedPortrait : CardAppearanceBehaviour
    {
        public override void ApplyAppearance()
        {
            try
            {
                Card.RenderInfo.expandedPortrait = true;
            }
            catch (Exception ex)
            {
                Debug.Log("Failed setting expanded portrait: " + ex);
            }
        }

        public override void ResetAppearance()
        {
            try
            {
                Card.RenderInfo.expandedPortrait = false;
            }
            catch (Exception ex)
            {
                Debug.LogError("Failed resetting expanded portrait: " + ex);
            }
        }
    }
}
