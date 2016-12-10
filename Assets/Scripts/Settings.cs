using System;
using UnityEngine;
using System.Collections;

namespace StellarCore
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private float _chargeScale = 25;
        [SerializeField] private float _massLossRate = 1;
        [SerializeField] private AnimationCurve _massLossCurve;
        [SerializeField] private float _energyScale = 1000;
        [SerializeField] private Gradient _energyColorGradient;

        public float MassLossRate
        {
            get { return _massLossRate; }
            private set { _massLossRate = value; }
        }

        public AnimationCurve MassLossCurve
        {
            get { return _massLossCurve; }
            private set { _massLossCurve = value; }
        }

        public float ChargeScale
        {
            get { return _chargeScale; }
            private set { _chargeScale = value; }
        }

        public float EnergyScale
        {
            get { return _energyScale; }
            private set { _energyScale = value; }
        }

        public Gradient EnergyColorGradient
        {
            get { return _energyColorGradient; }
            private set { _energyColorGradient = value; }
        }
    }
}