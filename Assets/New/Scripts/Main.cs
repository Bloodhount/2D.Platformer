using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{

    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private ParalaxManager _paralaxManager;
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private Transform _cannonTransform;
        [SerializeField] private CannonView _cannonView;

        [SerializeField] private PlayerController _playerController;
        [SerializeField] private CannonController _cannonController;
        [SerializeField] private BulletsEmitter _emitterController;
        // [SerializeField] private AimingMuzzle _cannon;

        private void Awake()
        {
            _playerController = new PlayerController(_playerView);
            _cannonController = new CannonController(_cannonView.MuzzleTransform, _playerView.transform);
            _emitterController = new BulletsEmitter(_cannonView.Bullets, _cannonView.EmitterTransform);

        }

        void Update()
        {
            _playerController.Update();
            _cannonController.Update();
            _emitterController.Update();
            // _paralaxManager.Update();
        }

    }
}
