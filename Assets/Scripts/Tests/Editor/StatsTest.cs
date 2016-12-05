using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace StellarCore.Test
{
    public class StatsTest
    {
        [Test]
        public void ChargeChange()
        {
            var gameObject = new GameObject();
            var stats = gameObject.AddComponent<Stats>();

            Assert.AreEqual(stats.Energy, 0);
            Assert.AreEqual(stats.Charge, 0);
            Assert.AreEqual(stats.Neutrinos, 0);
        }
    }
}