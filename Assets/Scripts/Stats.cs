using System;
using UnityEngine;
using System.Collections;

namespace StellarCore
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
        [SerializeField] private Charge _chargeUI;
        [SerializeField] private float _energy;
        [SerializeField] private int _charge;
        [SerializeField] private uint _neutrinos;

        public float Energy
        {
            get { return _energy; }
            set { _energy = value; }
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
        public RectTransform Negative;
        public RectTransform Positive;

        public void SetValue(float charge)
        {
            if (charge < 0)
            {
                Negative.localScale = new Vector3(Mathf.Clamp01(-charge), 1, 1);
                Positive.localScale = new Vector3(0, 1, 1);
            }
            else
            {
                Negative.localScale = new Vector3(0, 1, 1);
                Positive.localScale = new Vector3(Mathf.Clamp01(charge), 1, 1);
            }
        }
    }
}