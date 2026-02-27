using Arch.Core;
using Arch.Core.Extensions;
using TMPro;
using UI.Workers;
using UnityEngine;

namespace UI.Metal
{
    public class MetalText : BaseText
    {
        private void Start()
        {
            _world = WorldFetcher.Instance;
            _entity = _world.Create(new MetalTextComponent());
        }

        private void Update()
        {
            UpdateText(_entity.Get<MetalTextComponent>().Amount);
        }
    }
}