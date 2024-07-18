using System;
using System.Collections;
using UnityEngine;

namespace Services.Coroutine.Impl
{
    public class CoroutineDispatcher : MonoBehaviour, ICoroutineDispatcher
    {
        public void RunCoroutine(IEnumerator enumerator, Action onComplete)
        {
            StartCoroutine(CreateCoroutine(enumerator, onComplete));
        }

        public void RunCoroutine(IEnumerator enumerator)
        {
            StartCoroutine(enumerator);
        }

        public void Delay(float time, Action onComplete)
        {
            var delay = Delay(time);

            StartCoroutine(CreateCoroutine(delay, onComplete));
        }

        public void InvokeRepeatedly(Action action, float delay, int nums)
        {
            StartCoroutine(Run(action, delay, nums));
        }

        private IEnumerator Run(Action action, float delay, int nums)
        {
            for (int i = 0; i < nums; i++)
            {
                yield return Delay(delay);

                action();
            }
        }

        private IEnumerator CreateCoroutine(IEnumerator coroutine, Action action)
        {
            yield return coroutine;

            action();
        }

        private IEnumerator Delay(float time)
        {
            var wait = time;
            
            while (wait > 0f)
            {
                wait -= Time.deltaTime;

                yield return null;
            }
        }
    }
}