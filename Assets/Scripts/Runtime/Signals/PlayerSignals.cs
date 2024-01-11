using strange.extensions.signal.impl;
using UnityEngine;

namespace Runtime.Signals
{
    public class PlayerSignals
    {
        public Signal<Transform> onForceCommand = new Signal<Transform>();
    }
}