using System;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using DiskCardGame;
using InscryptionAPI.Card;

namespace ConfigurableEmissions
{
    public static class CustomColorHelper
    {
        public static bool TryGetColorFromCardInfo(this CardInfo card, string prefix, out Color color)
        {
            return
                TryGetColorFromHex(card.GetExtendedProperty($"{prefix}HEX"), out color) ||
                TryGetRGBFromString32(card.GetExtendedProperty($"{prefix}255"), out color) ||
                TryGetRGBFromString(card.GetExtendedProperty($"{prefix}1"), out color) ||
                TryGetRGBFromHSVString32(card.GetExtendedProperty($"{prefix}HSV"), out color) ||
                TryGetRGBFromHSVString(card.GetExtendedProperty($"{prefix}HSV1"), out color) ||
                TryGetColorFromHex(card.GetExtendedProperty(prefix), out color) ||
                TryGetRGBFromString32(card.GetExtendedProperty(prefix), out color);
        }

        public static bool TryGetRGBFromString(string str, out Color c)
        {
            if(str != null)
            {
                try
                {
                    string[] vals = str.Split(',');
                    if (vals.Length > 0)
                    {
                        float.TryParse(vals[0].Trim(), out var r);
                        float g = 0f;
                        float b = 0f;
                        float a = 1f;
                        if (vals.Length > 1)
                        {
                            float.TryParse(vals[1].Trim(), out g);
                            if (vals.Length > 2)
                            {
                                float.TryParse(vals[2].Trim(), out b);
                                if (vals.Length > 3)
                                {
                                    float.TryParse(vals[3].Trim(), out a);
                                }
                            }
                        }
                        c = new Color(r, g, b, a);
                        return true;
                    }
                }
                catch { }
            }
            c = Color.clear;
            return false;
        }

        public static bool TryGetRGBFromHSVString(string str, out Color c)
        {
            if (str != null)
            {
                try
                {
                    string[] vals = str.Split(',');
                    if (vals.Length > 0)
                    {
                        float.TryParse(vals[0].Trim(), out var h);
                        float s = 0f;
                        float v = 0f;
                        float a = 1f;
                        if (vals.Length > 1)
                        {
                            float.TryParse(vals[1].Trim(), out s);
                            if (vals.Length > 2)
                            {
                                float.TryParse(vals[2].Trim(), out v);
                                if (vals.Length > 3)
                                {
                                    float.TryParse(vals[3].Trim(), out a);
                                }
                            }
                        }
                        c = Color.HSVToRGB(h, s, v);
                        c.a = a;
                        return true;
                    }
                }
                catch { }
            }
            c = Color.clear;
            return false;
        }

        public static bool TryGetRGBFromHSVString32(string str, out Color c)
        {
            if (str != null)
            {
                try
                {
                    string[] vals = str.Split(',');
                    if (vals.Length > 0)
                    {
                        byte.TryParse(vals[0].Trim(), out var h);
                        byte s = 0;
                        byte v = 0;
                        byte a = 1;
                        if (vals.Length > 1)
                        {
                            byte.TryParse(vals[1].Trim(), out s);
                            if (vals.Length > 2)
                            {
                                byte.TryParse(vals[2].Trim(), out v);
                                if (vals.Length > 3)
                                {
                                    byte.TryParse(vals[3].Trim(), out a);
                                }
                            }
                        }
                        c = Color.HSVToRGB(h / 360f, s / 100f, v / 100f);
                        c.a = a / 255f;
                        return true;
                    }
                }
                catch { }
            }
            c = Color.clear;
            return false;
        }

        public static bool TryGetRGBFromString32(string str, out Color c)
        {
            if (str != null)
            {
                try
                {
                    string[] vals = str.Split(',');
                    if (vals.Length > 0)
                    {
                        byte.TryParse(vals[0].Trim(), out var r);
                        byte g = 0;
                        byte b = 0;
                        byte a = 255;
                        if (vals.Length > 1)
                        {
                            byte.TryParse(vals[1].Trim(), out g);
                            if (vals.Length > 2)
                            {
                                byte.TryParse(vals[2].Trim(), out b);
                                if (vals.Length > 3)
                                {
                                    byte.TryParse(vals[3].Trim(), out a);
                                }
                            }
                        }
                        c = new Color32(r, g, b, a);
                        return true;
                    }
                }
                catch { }
            }
            c = Color.clear;
            return false;
        }

        public static bool TryGetColorFromHex(string hex, out Color c)
        {
            try
            {
                return ColorUtility.TryParseHtmlString(hex, out c);
            }
            catch
            {
                c = Color.clear;
                return false;
            }
        }
    }
}
