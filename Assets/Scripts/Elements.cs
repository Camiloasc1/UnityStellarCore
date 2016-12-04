using System;
using UnityEngine;
using System.Collections;

namespace StellarCore
{
    public enum Elements
    {
        Proton,
        Electron,
        H2,
        He3,
        He4,
        Be7,
        Li7,
        B8,
        Be8
    }

    public static class ElementsExt
    {
        public static string GetText(this Elements element)
        {
            switch (element)
            {
                case Elements.Proton:
                    return "p+";
                case Elements.Electron:
                    return "e-";
                case Elements.H2:
                    return "H-2";
                case Elements.He3:
                    return "He-3";
                case Elements.He4:
                    return "He-4";
                case Elements.Be7:
                    return "Be-7";
                case Elements.Li7:
                    return "Li-7";
                case Elements.B8:
                    return "B-8";
                case Elements.Be8:
                    return "Be-8";
                default:
                    throw new ArgumentOutOfRangeException("element", element, null);
            }
        }
    }
}