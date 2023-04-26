using UnityEngine;

namespace KartGame.KartSystems
{
    public class KeyboardInput : BaseInput
    {
        [Header("Turn Input")]
        public string TurnInputName = "Horizontal";
        public bool Reversed;

        [Space]

        public string AccelerateButtonName = "Accelerate";
        public string BrakeButtonName = "Brake";

        public override InputData GenerateInput()
        {
            var turnInput = Input.GetAxis(TurnInputName);

            return new InputData
            {
                Accelerate = Input.GetButton(AccelerateButtonName),
                Brake = Input.GetButton(BrakeButtonName),
                TurnInput = Reversed ? turnInput * -1 : turnInput
            };
        }
    }
}
