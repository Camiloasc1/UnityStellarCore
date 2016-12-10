using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace StellarCore
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
        [SerializeField] private Charge _chargeUI;
        [SerializeField] private Energy _energyUI;
        [SerializeField] private Neutrinos _neutrinosUI;
        [SerializeField] private float _energy;
        [SerializeField] private int _charge;
        [SerializeField] private uint _neutrinos;

        public float Energy
        {
            get { return _energy; }
            set
            {
                _energy = value;
                _energyUI.SetValue(_energy / _settings.EnergyScale, _settings.EnergyColorGradient);
            }
        }

        public int Charge
        {
            get { return _charge; }
            set
            {
                if (_charge > 0 && value < _charge)
                    Energy += 1.022f * (_charge - Mathf.Max(value, 0));
                if (_charge < 0 && value > _charge)
                    Energy += 1.022f * Mathf.Min(value - _charge, -_charge);
                _charge = value;
                _chargeUI.SetValue(_charge / _settings.ChargeScale);
            }
        }

        public uint Neutrinos
        {
            get { return _neutrinos; }
            set { _neutrinos = value; }
        }

        private void Start()
        {
            Energy = 0;
            Charge = 0;
            Neutrinos = 0;
        }
    }

    [Serializable]
    public struct Charge
    {
        public GameObject Negative;
        public GameObject Positive;

        public void SetValue(float value)
        {
            if (value < 0)
            {
                Negative.GetComponent<RectTransform>().localScale = new Vector3(Mathf.Clamp01(-value), 1, 1);
                Positive.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
            }
            else
            {
                Negative.GetComponent<RectTransform>().localScale = new Vector3(0, 1, 1);
                Positive.GetComponent<RectTransform>().localScale = new Vector3(Mathf.Clamp01(value), 1, 1);
            }
        }
    }

    [Serializable]
    public struct Energy
    {
        public GameObject Image;

        public void SetValue(float value, Gradient gradient)
        {
            value = Mathf.Clamp01(value);
            Image.GetComponent<RectTransform>().localScale = new Vector3(value, 1, 1);
            Image.GetComponent<Image>().color = gradient.Evaluate(value);
        }
    }

    [Serializable]
    public struct Neutrinos
    {
    }
}