using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Views.Units
{
    public class EnemyView : UnitView
    {
        [SerializeField] private Color _onDamageColor;
        [SerializeField] private Renderer _renderer;
        [SerializeField] private float fadeDuration;

        private Color _normalColor;
        private Coroutine _current;

        private void Awake()
        {
            _normalColor = _renderer.material.color;
        }

        protected override void OnDamaged()
        {
            if (_current != null)
            {
                StopCoroutine(_current);
                _renderer.material.color = _normalColor;
            }
            
            _current = StartCoroutine(ColorBlink(_normalColor, _onDamageColor));
        }

        private IEnumerator ColorBlink(Color from, Color to)
        {
            float elapsedTime = 0f;

            while (elapsedTime < fadeDuration / 2f)
            {
                elapsedTime += Time.deltaTime;
                _renderer.material.color = Color.Lerp(from, to, elapsedTime / (fadeDuration /2 ));
                yield return null;
            }
            
            elapsedTime = 0f;
            
            while (elapsedTime < fadeDuration / 2f)
            {
                elapsedTime += Time.deltaTime;
                _renderer.material.color = Color.Lerp(to, from, elapsedTime / (fadeDuration /2 ));
                yield return null;
            }
        }
    }
}