using Arch.Core;
using Arch.Core.Extensions;
using TMPro;
using UI.Workers;
using UnityEngine;

namespace UI.Wood
{
    public class WoodText : BaseText
    {
        private void Start()
        {
            _world = WorldFetcher.Instance;
            _entity = _world.Create(new WoodTextComponent());
        }

        private void Update()
        {
            UpdateText(_entity.Get<WoodTextComponent>().Amount);
        }
    }
}