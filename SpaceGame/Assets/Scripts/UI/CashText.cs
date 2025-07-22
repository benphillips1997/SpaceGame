using Arch.Core;
using Arch.Core.Extensions;
using TMPro;
using UnityEngine;

namespace UI.Cash
{
    public class CashText : MonoBehaviour
    {
        private World _world;

        [SerializeField]
        private TextMeshProUGUI cashText;

        private double _cashValue = 0;

        private Entity _entity;

        private void Start()
        {
            _world = WorldFetcher.Instance;
            _entity = _world.Create(new CashTextComponent());
        }

        private void UpdateText(string newValueText)
        {
            cashText.text = newValueText;
        }

        private void UpdateText(double newValue)
        {
            if (newValue != _cashValue)
                UpdateText(newValue.ToString());
        }

        private void Update()
        {
            UpdateText(_entity.Get<CashTextComponent>().CashAmount);
        }
    }
}