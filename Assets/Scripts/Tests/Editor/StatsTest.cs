using UnityEngine;
using System.Collections;
using NUnit.Framework;

namespace StellarCore.Test
{
    public class StatsTest
    {
        private GameObject _gameObject;
        private Stats _stats;

        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject();
            _stats = _gameObject.AddComponent<Stats>();
        }

        [Test]
        public void ChargeChange1()
        {
            Assert.That(_stats.Energy, Is.EqualTo(0).Within(.001));
            Assert.AreEqual(_stats.Charge, 0);

            _stats.Charge++;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 0).Within(.001));
            Assert.AreEqual(_stats.Charge, 1);

            _stats.Charge++;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 0).Within(.001));
            Assert.AreEqual(_stats.Charge, 2);

            _stats.Charge--;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 1).Within(.001));
            Assert.AreEqual(_stats.Charge, 1);

            _stats.Charge--;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 2).Within(.001));
            Assert.AreEqual(_stats.Charge, 0);

            _stats.Charge--;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 2).Within(.001));
            Assert.AreEqual(_stats.Charge, -1);

            _stats.Charge--;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 2).Within(.001));
            Assert.AreEqual(_stats.Charge, -2);

            _stats.Charge++;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 3).Within(.001));
            Assert.AreEqual(_stats.Charge, -1);

            _stats.Charge++;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 4).Within(.001));
            Assert.AreEqual(_stats.Charge, 0);
        }

        [Test]
        public void ChargeChange2()
        {
            Assert.That(_stats.Energy, Is.EqualTo(0).Within(.001));
            Assert.AreEqual(_stats.Charge, 0);

            _stats.Charge += 2;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 0).Within(.001));
            Assert.AreEqual(_stats.Charge, 2);

            _stats.Charge = 0;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 2).Within(.001));
            Assert.AreEqual(_stats.Charge, 0);

            _stats.Charge = -2;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 2).Within(.001));
            Assert.AreEqual(_stats.Charge, -2);

            _stats.Charge += 4;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 4).Within(.001));
            Assert.AreEqual(_stats.Charge, 2);

            _stats.Charge = -2;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 6).Within(.001));
            Assert.AreEqual(_stats.Charge, -2);

            _stats.Charge = 0;
            Assert.That(_stats.Energy, Is.EqualTo(1.022 * 8).Within(.001));
            Assert.AreEqual(_stats.Charge, 0);
        }
    }
}