using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlatformerMVC
{
    public class ElevatorManager : IDisposable
    {
        private List<LevelObjectView> _liftViews;
        private List<LevelObjectView> _turnTriggers;
        private JointMotor2D _jointMotor;
        public ElevatorManager(List<LevelObjectView> liftViews, List<LevelObjectView> turnTriggers)
        {
            _liftViews = liftViews;
            _turnTriggers = turnTriggers;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
