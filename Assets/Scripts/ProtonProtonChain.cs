using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace StellarCore
{
    public class ProtonProtonChain : MonoBehaviour
    {
        [SerializeField] private ElementButton _proton;
        [SerializeField] private ElementButton _electron;
        [SerializeField] private ElementButton _H2;
        [SerializeField] private ElementButton _He3;
        [SerializeField] private ElementButton _He4;
        [SerializeField] private ElementButton _Be7;
        [SerializeField] private ElementButton _Li7;
        [SerializeField] private RandomButton _random;

        private ElementButton[] _buttons;
        private Elements _currentElement;

        public Elements CurrentElement
        {
            get { return _currentElement; }
            set
            {
                _currentElement = value;
                _random.Element = _currentElement;
            }
        }

        private void Awake()
        {
            _buttons = new[] {_proton, _electron, _H2, _He3, _He4, _Be7, _Li7};
        }

        private void Start()
        {
            foreach (var button in _buttons)
            {
                button.Amount = 0;
                var element = button.Element;
                button.GetComponent<Button>().onClick.AddListener(() => OnElementButtonClick(element));
            }
            CurrentElement = Elements.Proton;
        }

        private void Update()
        {
        }

        public void OnElementButtonClick(Elements element)
        {
            switch (element)
            {
                case Elements.Proton:
                    break;
                case Elements.Electron:
                    break;
                case Elements.H2:
                    break;
                case Elements.He3:
                    break;
                case Elements.He4:
                    break;
                case Elements.Be7:
                    break;
                case Elements.Li7:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("element", element, null);
            }
//            CurrentElement = element;
            //TODO choise random element
        }
    }
}