using UnityEngine;

namespace Helpers
{
    public class Test : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log($"OnTriggerEnter");
        }
    }
}