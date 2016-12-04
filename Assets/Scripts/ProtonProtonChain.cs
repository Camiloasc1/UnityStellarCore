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

        public Elements CurrentElement
        {
            get { return _random.Element; }
            set { _random.Element = value; }
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
//            _random.GetComponent<Button>().onClick.AddListener(()=>OnElementButtonClick(CurrentElement));
            CurrentElement = Elements.Proton;
        }

        private void Update()
        {
        }

        public void OnElementButtonClick(Elements element)
        {
            switch (CurrentElement)
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
                case Elements.B8:
                    break;
                case Elements.Be8:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            CurrentElement = element;
            //TODO choise random element
        }

        private void Equation0()
        {
//            _proton.Amount -= 2;
            _H2.Amount++;
            //TODO charge++
            //TODO neutrinos++
            //TODO energy++
        }

        private void Equation1()
        {
//            _proton.Amount--;
            _H2.Amount--;
            _He3.Amount++;
            //TODO energy++
        }

        private void Equation2()
        {
            _He3.Amount -= 2;
            _He4.Amount++;
//            _proton.Amount += 2;
            //TODO energy++
        }

        private void Equation3()
        {
            _He3.Amount--;
            _He4.Amount--;
            _Be7.Amount++;
            //TODO energy++
        }

        private void Equation4()
        {
            _Be7.Amount--;
            //_electron.Amount--;
            _Li7.Amount++;
            //TODO neutrinos++
            //TODO energy++
        }

        private void Equation5()
        {
            _Li7.Amount--;
            //_proton.Amount--;
            _He4.Amount += 2;
            //TODO energy++
        }

        private void Equation6()
        {

        }

        private void Equation7()
        {
        }

        private void Equation8()
        {
        }

        private void Equation9()
        {
            _He3.Amount--;
//            _proton.Amount--;
            _He4.Amount ++;
            //TODO charge++
            //TODO neutrinos++
            //TODO energy++
        }
    }
}