using UnityEditor;
using UnityEngine;
using UnityGameTemplate.States.Interfaces;

namespace UnityGameTemplate.Starter.States
{
    public class UGTStarterStatesDisable
        : UGTIExitableState
        , UGTIEnterableState
    {
        public void Enter()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void Exit()
        {
        }
    }
}
