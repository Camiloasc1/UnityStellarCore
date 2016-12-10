using UnityEngine;
using System.Collections;

namespace StellarCore
{
    public class Stats : MonoBehaviour
    {
        [SerializeField] private Settings _settings;
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
            }
        }

        public uint Neutrinos
        {
            get { return _neutrinos; }
            set { _neutrinos = value; }
        }
    }
}