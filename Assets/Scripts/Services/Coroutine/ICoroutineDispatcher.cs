using System;
using System.Collections;

namespace Services.Coroutine
{
    public interface ICoroutineDispatcher
    {
        void RunCoroutine(IEnumerator enumerator, Action onComplete);
        void RunCoroutine(IEnumerator enumerator);
        void Delay(float time, Action onComplete);
    }
}