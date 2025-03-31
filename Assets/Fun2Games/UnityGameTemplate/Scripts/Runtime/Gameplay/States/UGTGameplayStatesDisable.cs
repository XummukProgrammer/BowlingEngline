using UnityGameTemplate.Starter.Installers;
using UnityGameTemplate.States.Interfaces;

namespace UnityGameTemplate.Gameplay.States
{
    public class UGTGameplayStatesDisable
        : UGTIExitableState
        , UGTIEnterableState
    {
        private readonly UGTGameplayData _gameplayData;

        public UGTGameplayStatesDisable(UGTGameplayData gameplayData)
        {
            _gameplayData = gameplayData;
        }

        public void Enter()
        {
            _gameplayData.Disable = true;
        }

        public void Exit()
        {
        }
    }
}
