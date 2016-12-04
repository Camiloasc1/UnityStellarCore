using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace StellarCore
{
    [ExecuteInEditMode]
    public class ElementButton : MonoBehaviour
    {
        [SerializeField] private Elements _element;
        [SerializeField] private Text _elementText;
        [SerializeField] private Text _amountText;
        [SerializeField] private uint _amount;

        public uint Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                _amountText.text = _amount.ToString();
            }
        }

        private void Update()
        {
#if UNITY_EDITOR
            _elementText.text = _element.GetText();
#endif
        }
    }

    public enum Elements
    {
        Proton,
        Electron,
        H2,
        He3,
        He4,
        Be7,
        Li7
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
                default:
                    throw new ArgumentOutOfRangeException("element", element, null);
            }
        }
    }
}