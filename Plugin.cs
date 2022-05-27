using BepInEx;
using DiskCardGame;
using InscryptionAPI.Card;
using System;

namespace ConfigurableEmissions
{
    [BepInPlugin(GUID, NAME, VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        public const string GUID = "spapi.inscryption.configemissions";
        public const string NAME = "Configurable Emissions";
        public const string VERSION = "1.0.0";

        public void Awake()
        {
            CardAppearanceBehaviourManager.Add(GUID, "ConfigurableEmissionColor", typeof(ConfigurableEmission));
            CardAppearanceBehaviourManager.Add(GUID, "ConfigurableBackground", typeof(ConfigurableBackground));
            CardAppearanceBehaviourManager.Add(GUID, "ConfigurableStatColors", typeof(ConfigurableStatColors));
            CardAppearanceBehaviourManager.Add(GUID, "ExpandedPortrait", typeof(ExpandedPortrait));
        }
    }
}
