using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        Jump = 2
    }

    [CreateAssetMenu(fileName = "SpriteAnimationsConfig", menuName = "Configs / Animations", order = 1)]
    public class AnimationConfig : ScriptableObject
    {
        [Serializable]
        public class SpritesSequence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpritesSequence> Sequences = new List<SpritesSequence>();
    }
}
