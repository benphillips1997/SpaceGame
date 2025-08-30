using Arch.Core;
using UnityEngine;

namespace UI {
    public class BuyWorkerButton : MonoBehaviour
    {
        private World _world;

        private void Start()
        {
            _world = WorldFetcher.Instance;
        }
        public void OnClick()
        {
            _world.Create(new BuyWorkerButtonClickedEvent());
        }
    }
}

public struct BuyWorkerButtonClickedEvent { }