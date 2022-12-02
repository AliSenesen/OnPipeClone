using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace UnityTemplateProjects.Signals
{
    public class InputSignals : MonoSingleton<InputSignals>
    {
        public  UnityAction<bool> onInputTaken = delegate {  };
        public  UnityAction<bool> onInputRelease = delegate {  };
    }
}