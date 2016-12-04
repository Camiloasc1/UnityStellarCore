using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace StellarCore
{
    [ExecuteInEditMode]
    public class ElementButton : MonoBehaviour
    {
        [SerializeField] private Elements _element;
        [SerializeField] private Text _elementText;
        [SerializeField] private Text _amountText;
        [SerializeField] private uint _amount;

        public uint Amount
        {
            get { return _amount; }
            set
            {
                _amount = value;
                _amountText.text = _amount.ToString();
            }
        }

        private void Start()
        {
            InitTextLabels();
        }

        private void Update()
        {
#if UNITY_EDITOR
            InitTextLabels();
#endif
        }

        private void InitTextLabels()
        {
            _elementText.text = _element.GetText();
            _amountText.gameObject.SetActive(!(_element == Elements.Proton || _element == Elements.Electron));
        }
    }
}