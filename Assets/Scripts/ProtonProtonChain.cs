using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace StellarCore
{
    /// <summary>
    /// Energy amounts:
    /// http://www2.astro.psu.edu/users/rbc/a534/lec13.pdf
    /// </summary>
    public class ProtonProtonChain : MonoBehaviour
    {
        [SerializeField] private Stats _stats;
        [SerializeField] private Settings _settings;
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
                button.Amount = 10;
                var element = button.Element;
                button.GetComponent<Button>().onClick.AddListener(() => OnElementButtonClick(element));
            }
            _random.GetComponent<Button>().onClick.AddListener(() => OnElementButtonClick(null));
            CurrentElement = Elements.Proton;
        }

        private void Update()
        {
        }

        public void OnElementButtonClick(Elements? pressed)
        {
            if (pressed == null)
                pressed = CurrentElement;
            switch (pressed)
            {
                case Elements.Proton:
                    switch (CurrentElement)
                    {
                        case Elements.Proton:
                            Equation0();
                            break;
                        case Elements.H2:
                            Equation1();
                            break;
                        case Elements.He3:
                            Equation9();
                            break;
                        case Elements.Be7:
                            Equation6();
                            return;
                        case Elements.Li7:
                            Equation5();
                            break;
                        default:
                            Wrong();
                            return;
                    }
                    break;
                case Elements.Electron:
                    if (CurrentElement == Elements.Be7)
                    {
                        Equation4();
                        break;
                    }
                    _stats.Charge--;
                    return;
                case Elements.H2:
                    if (CurrentElement == Elements.Proton)
                    {
                        Equation1();
                        break;
                    }
                    Wrong();
                    return;
                case Elements.He3:
                    switch (CurrentElement)
                    {
                        case Elements.Proton:
                            Equation9();
                            break;
                        case Elements.He3:
                            Equation2();
                            break;
                        case Elements.He4:
                            Equation3();
                            break;
                        default:
                            Wrong();
                            return;
                    }
                    break;
                case Elements.He4:
                    if (CurrentElement == Elements.He3)
                    {
                        Equation3();
                        break;
                    }
                    Wrong();
                    return;
                case Elements.Be7:
                    switch (CurrentElement)
                    {
                        case Elements.Proton:
                            Equation6();
                            return;
                        case Elements.Electron:
                            Equation4();
                            break;
                        default:
                            Wrong();
                            return;
                    }
                    break;
                case Elements.Li7:
                    if (CurrentElement == Elements.Proton)
                    {
                        Equation5();
                        break;
                    }
                    Wrong();
                    return;
                case Elements.B8:
                    Equation7();
                    return;
                case Elements.Be8:
                    Equation8();
                    break;
                default:
                    Wrong();
                    return;
            }
            RandomChoose();
        }

        private void RandomChoose()
        {
            //TODO improve choose random element
            var value = Random.value;
            if (value < .2)
                CurrentElement = Elements.Proton;
            else if (value < .4)
                CurrentElement = Elements.H2;
            else if (value < .6)
                CurrentElement = Elements.He3;
            else if (value < .8)
                CurrentElement = Elements.He4;
            else if (value < .9)
                CurrentElement = Elements.Be7;
            else
                CurrentElement = Elements.Li7;
        }

        /// <summary>
        /// p+ + p+ -> H-2 + e+ + ve
        /// </summary>
        private void Equation0()
        {
            _H2.Amount++;
            _stats.Charge++;
            _stats.Neutrinos++;
            _stats.Energy += 0.420f;
        }

        /// <summary>
        /// H-2 + p+ -> He-3
        /// </summary>
        private void Equation1()
        {
            if (_H2.Amount < 1)
            {
                Wrong();
                return;
            }

            _H2.Amount--;
            _He3.Amount++;
            _stats.Energy += 5.493f;
        }

        /// <summary>
        /// He-3 + He-3 -> He-4 + p+ + p+
        /// </summary>
        private void Equation2()
        {
            if (_He3.Amount < 2)
            {
                Wrong();
                return;
            }

            _He3.Amount -= 2;
            _He4.Amount++;
            _stats.Energy += 12.859f;
        }

        /// <summary>
        /// He-3 + He-4 -> Be-7
        /// </summary>
        private void Equation3()
        {
            if (_He3.Amount < 1 || _He4.Amount < 1)
            {
                Wrong();
                return;
            }

            _He3.Amount--;
            _He4.Amount--;
            _Be7.Amount++;
            _stats.Energy += 1.586f;
        }

        /// <summary>
        /// Be-7 + e- -> Li-7 + ve
        /// </summary>
        private void Equation4()
        {
            if (_Be7.Amount < 1)
            {
                Wrong();
                return;
            }

            _Be7.Amount--;
            _Li7.Amount++;
            _stats.Neutrinos++;
            _stats.Energy += 0.861f;
        }

        /// <summary>
        /// Li-7 + p+ -> He-4 + He-4
        /// </summary>
        private void Equation5()
        {
            if (_Li7.Amount < 1)
            {
                Wrong();
                return;
            }

            _Li7.Amount--;
            _He4.Amount += 2;
            _stats.Energy += 17.347f;
        }

        /// <summary>
        /// Be-7 + p+ -> B-8
        /// </summary>
        private void Equation6()
        {
            if (_Be7.Amount < 1)
            {
                Wrong();
                return;
            }

            _Be7.Amount--;
            CurrentElement = Elements.B8;
            _stats.Energy += 0.135f;
        }

        /// <summary>
        /// B-8 -> Be-8 + e+ + ve
        /// </summary>
        private void Equation7()
        {
            CurrentElement = Elements.Be8;
            _stats.Charge++;
            _stats.Neutrinos++;
        }

        /// <summary>
        /// Be-8 -> He-4 + He-4
        /// </summary>
        private void Equation8()
        {
            _He4.Amount += 2;
            _stats.Energy += 17.051f;//Shared with (7)
        }

        /// <summary>
        /// He-3 + p+ -> He-4 + e+ + ve
        /// </summary>
        private void Equation9()
        {
            if (_He3.Amount < 1)
            {
                Wrong();
                return;
            }

            _He3.Amount--;
            _He4.Amount++;
            _stats.Charge++;
            _stats.Neutrinos++;
            _stats.Energy += 18.78f;
        }

        private void Wrong()
        {
            Debug.Log("Wrong!");
        }
    }
}