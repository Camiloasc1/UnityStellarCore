using System;
using UnityEngine;
using System.Collections;

namespace StellarCore
{
    public class Settings : MonoBehaviour
    {
        [SerializeField] private float _massLossRate = 1;
        [SerializeField] private AnimationCurve _massLossCurve;
        [SerializeField] private float _chargeScale = 25;
        [SerializeField] private float _energyScale = 1000;
    }
}