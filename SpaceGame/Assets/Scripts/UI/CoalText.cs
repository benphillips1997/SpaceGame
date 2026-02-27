using Arch.Core;
using Arch.Core.Extensions;
using TMPro;
using UI.Workers;
using UnityEngine;

namespace UI.Coal
{
    public class CoalText : BaseText
    {
        private void Start()
        {
            _world = WorldFetcher.Instance;
            _entity = _world.Create(new CoalTextComponent());
        }

        private void Update()
        {
            UpdateText(_entity.Get<CoalTextComponent>().Amount);
        }
    }
}