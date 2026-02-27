using Arch.Core;
using Arch.Core.Extensions;
using TMPro;
using UI.Workers;
using UnityEngine;

namespace UI.Cash
{
    public class CashText : BaseText
    {
        private void Start()
        {
            _world = WorldFetcher.Instance;
            _entity = _world.Create(new CashTextComponent());
        }

        private void Update()
        {
            UpdateText(_entity.Get<CashTextComponent>().CashAmount);
        }
    }
}