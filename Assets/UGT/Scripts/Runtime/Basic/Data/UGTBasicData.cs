using UGT.Common.Gameplay;

namespace UGT.Basic.Data
{
    public class UGTBasicData
    {
        public UGTGameplayType GameplayType { get; set; } = UGTGameplayType.Undefined;
        public UGTGameplayType NewGameplayType { get; set; } = UGTGameplayType.Undefined;

        public bool ReadyToChangeGameplay { get; set; } = false;
    }
}
