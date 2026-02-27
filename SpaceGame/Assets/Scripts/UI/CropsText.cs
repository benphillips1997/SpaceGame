using Arch.Core;
using Arch.Core.Extensions;
using TMPro;
using UI.Workers;
using UnityEngine;

namespace UI.Crops
{
    public class CropsText : BaseText
    {
        private void Start()
        {
            _world = WorldFetcher.Instance;
            _entity = _world.Create(new CropsTextComponent());
        }

        private void Update()
        {
            UpdateText(_entity.Get<CropsTextComponent>().Amount);
        }
    }
}