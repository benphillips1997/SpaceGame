using Arch.Core;
using Arch.Core.Extensions;
using TMPro;
using UnityEngine;

namespace UI.Workers
{
    public class WorkersText : MonoBehaviour
    {
        // Can probably Abstract a lot of this behaviour
        private World _world;

        [SerializeField]
        private TextMeshProUGUI cashText;

        private double _workersAmount = 0;

        private Entity _entity;

        private void Start()
        {
            _world = WorldFetcher.Instance;
            _entity = _world.Create(new WorkersTextComponent());
        }

        private void UpdateText(string newValueText)
        {
            cashText.text = newValueText;
        }

        private void UpdateText(int newValue)
        {
            if (newValue != _workersAmount)
                UpdateText(newValue.ToString());
        }

        private void Update()
        {
            UpdateText(_entity.Get<WorkersTextComponent>().Amount);
        }
    }
}