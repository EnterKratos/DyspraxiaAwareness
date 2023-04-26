using UnityEngine;

namespace KartGame.KartSystems
{
    public class KeyboardInput : BaseInput
    {
        [Header("Turn Input")]
        public string TurnInputName = "Horizontal";
        public bool Reversed;
        public bool RandomDirectionChange;

        [Range(-1, 1)]
        public float DirectionChangeProbability;
        [Tooltip("The amount of time between between direction change reevaluation")]
        public float TimeRemaining = 10.0f;
        private float _currentTime;

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

        private void Update()
        {
            _currentTime += Time.deltaTime;

            if (!(_currentTime >= TimeRemaining))
            {
                return;
            }

            if (!RandomDirectionChange || Random.value < DirectionChangeProbability)
            {
                return;
            }

            Reversed = !Reversed;
            _currentTime = 0;
        }
    }
}
