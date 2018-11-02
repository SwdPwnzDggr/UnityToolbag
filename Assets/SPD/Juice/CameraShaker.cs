using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPD.Juice
{
    public class CameraShaker
    {
        public enum CAMERASHAKETYPE { TwoDimensional, ThreeDimensional };
        public enum TRAUMATYPE { Squared, Cubed };

        const float
            maxTrauma = 1,
            minTrauma = 0,
            max2DAngle = 5,
            maxYaw = 5,
            maxPitch = 5,
            maxRoll = 5,
            maxOffset = 2;


        private float
            _currentTrauma,
            _duration,
            _shake,
            _perlinSeed;

        private Camera
            _cam;

        private CAMERASHAKETYPE _shakeType;
        private TRAUMATYPE _traumaType;

        public CameraShaker(Camera cam, float duration = 1.0f, CAMERASHAKETYPE shakeType = CAMERASHAKETYPE.TwoDimensional, TRAUMATYPE traumaType = TRAUMATYPE.Squared)
        {
            _duration = duration;
            _shakeType = shakeType;
            _traumaType = traumaType;
            _cam = cam;
        }

        /// <summary>
        /// Range 0-1.
        /// Use smaller vaules that scale to impact levels of Stress or Damage.
        /// </summary>
        public void AddTrauma(float amt)
        {
            _currentTrauma += amt;
            RollSeed();
        }

        /// <summary>
        /// Call once per frame to update the camera. 
        /// Does nothing if the trauma level is at or below 0
        /// </summary>
        public void UpdateShake()
        {
            if (_currentTrauma <= 0) return;

            _shake = _currentTrauma * (_traumaType == TRAUMATYPE.Squared ? _currentTrauma : _currentTrauma * _currentTrauma);
            Shake();
            ReduceTrauma();
        }

        private void ReduceTrauma()
        {
            _currentTrauma -= Time.deltaTime / _duration;
            if (_currentTrauma < 0) _currentTrauma = 0;
        }

        private void Shake()
        {
            switch (_shakeType)
            {
                case CAMERASHAKETYPE.TwoDimensional:
                    Shake2D(_cam.transform);
                    break;
                case CAMERASHAKETYPE.ThreeDimensional:
                    Shake3D(_cam.transform);
                    break;
                default:
                    break;
            }
        }

        private void RollSeed()
        {
            _perlinSeed = Random.Range(0f, 1f);
        }

        private void Shake2D(Transform cam)
        {
            float angle = max2DAngle * _shake * Mathf.PerlinNoise(Time.time, _perlinSeed);
            float offsetX = maxOffset * _shake * Mathf.PerlinNoise(Time.time, _perlinSeed + 1);
            float offsetY = maxOffset * _shake * Mathf.PerlinNoise(Time.time, _perlinSeed + 2);
            cam.position += new Vector3(offsetX, offsetY, 0);
            cam.eulerAngles += angle * Vector3.forward; // Make sure we are only adding to the Z angle
        }

        private void Shake3D(Transform cam)
        {
            float yaw = maxYaw * _shake * Mathf.PerlinNoise(Time.time, _perlinSeed);
            float pitch = maxPitch * _shake * Mathf.PerlinNoise(Time.time, _perlinSeed + 1);
            float roll = maxRoll * _shake * Mathf.PerlinNoise(Time.time, _perlinSeed + 2);
            cam.eulerAngles = new Vector3(roll, pitch, yaw);
            //float offsetX = maxOffset * _shake * Mathf.PerlinNoise(Time.time, _perlinSeed + 3);
            //float offsetY = maxOffset * _shake * Mathf.PerlinNoise(Time.time, _perlinSeed + 4);
            //float offsetZ = maxOffset * _shake * Mathf.PerlinNoise(Time.time, _perlinSeed + 5);
            //cam.position += new Vector3(offsetX, offsetY, offsetZ);
        }
    }
}