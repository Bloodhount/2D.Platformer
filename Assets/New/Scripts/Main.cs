using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{

    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelObjectView _playerView;
        [SerializeField] private PlayerController _playerController;
        [SerializeField] private ParalaxManager _paralaxManager;
        [SerializeField] private Transform _camera;
        [SerializeField] private Transform _back;

        private void Awake()
        {
            _playerController = new PlayerController(_playerView);

            //_camera = FindObjectOfType<Camera>().transform;
            //_back = GameObject.Find("backgroundLayer1").transform;
            //  _paralaxManager = new ParalaxManager(_camera, _back);
        }

        void Update()
        {
            _playerController.Update();
            // _paralaxManager.Update();
        }

    }
}
