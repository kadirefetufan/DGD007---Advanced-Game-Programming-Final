using System;
using strange.extensions.signal.impl;

namespace Runtime.Signals
{
    public class LevelSignals
    {
        public Signal onInitializeLevel = new Signal();
        public Signal onDestroyLevel = new Signal();
        public Func<byte> onGetLevelActiveLevelCount = new Func<byte>(() => 0);
        public Signal onLevelSuccessful = new Signal();
        public Signal onLevelFailed = new Signal();
    }
}