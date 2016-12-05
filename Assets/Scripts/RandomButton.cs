using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace StellarCore
{
    public class RandomButton : MonoBehaviour
    {
        [SerializeField] private Text _elementText;
        private Elements _element;

        public Elements Element
        {
            get { return _element; }
            set
            {
                _element = value;
                _elementText.text = _element.GetText();
            }
        }
    }
}