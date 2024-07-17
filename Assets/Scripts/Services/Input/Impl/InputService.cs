using UnityEngine;

namespace Services.Input.Impl
{
    public class InputService : IInputService
    {
        public void SetInput(Vector3 input)
        {
            Debug.Log($"SetInput {input}");
            Input = input;
        }

        public Vector3 Input { get; private set; }
    }
}