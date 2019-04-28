﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fx
{

    public class DeceaseFx : MonoBehaviour
    {

        [SerializeField] private ParticleSystem _particleSystemPrefab;
        
        private ParticleSystem _particleSystem;
        private bool _triggered;
        private Utilities.FxComplete _callback;
        
        private void Awake()
        {
            if (_particleSystemPrefab != null)
            {
                _particleSystem = Instantiate(_particleSystemPrefab);
                _particleSystem.transform.parent = transform;
                _particleSystem.transform.localPosition = Vector3.zero;
            }

            _triggered = false;
            _callback = null;
        }

        public void Trigger(Utilities.FxComplete callback)
        {
            if (_particleSystem != null)
            {
                _particleSystem.Play();
            }

            _triggered = true;
            _callback = callback;
        }

        void Update()
        {
            
            if (_triggered && _particleSystem != null)
            {
                
                if (!_particleSystem.IsAlive() && _callback != null)
                {
                    _callback();
                    _callback = null;
                }
                
                
                /*if (_particleSystem.isPlaying)
                {
                    _particleSystem.Stop();
                }*/

            }

        }
    }

}