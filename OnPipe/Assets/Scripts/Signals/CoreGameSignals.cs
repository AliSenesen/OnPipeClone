using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onPlay = delegate {  };
        public UnityAction onInit = delegate {  };
        public UnityAction onReset = delegate {  };
        public UnityAction onWin = delegate {  };
        public UnityAction onFail = delegate {  };
        
    }
}