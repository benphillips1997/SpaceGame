using Arch.Core;
using Arch.Core.Extensions;
using TMPro;
using UnityEngine;

namespace UI
{
    public abstract class BaseText : MonoBehaviour
    {
        protected World _world;

        [SerializeField]
        protected TextMeshProUGUI text;

        private double _value = 0;

        protected Entity _entity;

        protected void UpdateText(string newValueText)
        {
            text.text = newValueText;
        }

        protected void UpdateText(double newValue)
        {
            if (newValue != _value)
                UpdateText(newValue.ToString());
        }
    }
}