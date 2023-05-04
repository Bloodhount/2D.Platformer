using TMPro;
using UnityEngine;

namespace PlatformerMVC
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private ParalaxManager _paralaxManager;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _cannonTransform;

        [SerializeField] private InteractiveObjectView _playerView;
        [SerializeField] private CannonView _cannonView;

        [SerializeField] private PlayerController _playerController;
        [SerializeField] private CannonController _cannonController;
        [SerializeField] private BulletsEmitter _emitterController;

        [SerializeField] private CoinsManager _coinsManager;

        private void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _cannonController = new CannonController(_cannonView.MuzzleTransform, _playerView.transform);
            _emitterController = new BulletsEmitter(_cannonView.Bullets, _cannonView.EmitterTransform);
        }

        void Update()
        {
            _playerController.Update(); MessageText($"player.<color=green>Hp</color>: <color=red>{_playerController.Hp.ToString()}</color>");
            _cannonController.Update();
            _emitterController.Update();
        }
        [SerializeField] TextMeshProUGUI text;
        void MessageText(string s)
        {
            text.text = s;
        }
    }
}
