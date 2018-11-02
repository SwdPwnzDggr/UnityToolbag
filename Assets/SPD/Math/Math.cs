using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPD
{
    static class Math
    {
        public static int GetNearestMultiple(this int value, int multiple)
        {
            int rem = value % multiple;
            int result = value - rem;
            if (rem > (multiple / 2))
                result += multiple;

            return result;
        }

        /// <summary>
        /// Moves our Follower 10% Closer to our Target
        /// </summary>
        /// <param name="follower">Value you want to move</param>
        /// <param name="target">Value you want follower to move towards</param>
        /// <returns>Returns follower's new value</returns>
        public static float AsymptoticAverage(float follower, float target, float weight)
        {
            // follower += (target - follower * weight * timeScale
            return ((1 - (weight * Time.timeScale)) * follower) + ((weight * Time.timeScale) * target);
        }

        #region DIMINISHING_ADD
        /// <summary>
        /// Multiplication that Drives up towards 1.
        /// <para/> 1 + x = 1. 
        /// <para/>0 + x = x.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static float DiminishingAdd(float a, float b)
        {
            return 1 - (1 - a) * (1 - b);
        }

        /// <summary>
        /// Multiplication that Drives up towards 1.
        /// <para/> 1 + x = 1. 
        /// <para/>0 + x = x.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static float DiminishingAdd(float a, float b, float c)
        {
            return 1 - (1 - a) * (1 - b) * (1 - c);
        }

        /// <summary>
        /// Multiplication that Drives up towards 1.
        /// <para/> 1 + x = 1. 
        /// <para/>0 + x = x.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        public static float DiminishingAdd(float a, float b, float c, float d)
        {
            return 1 - (1 - a) * (1 - b) * (1 - c) * (1 - d);
        }

        /// <summary>
        /// Multiplication that Drives up towards 1.
        /// <para/> 1 + x = 1. 
        /// <para/>0 + x = x.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public static float DiminishingAdd(params float[] arguments)
        {
            float retrunValue = (1-arguments[0]);
            for(int argCount = 1; argCount < arguments.Length; argCount++)
            {
                retrunValue *= (1 - arguments[argCount]);
            }
            return 1 - retrunValue;
        }
        #endregion

        #region TRANFORM_METHODS
        /// <summary>
        /// Sets the X value of the transform.position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x"></param>
        public static void SetPositionX(this Transform transform, float x)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        /// <summary>
        /// Sets the Y value of the transform.position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x"></param>
        public static void SetPositionY(this Transform transform, float y)
        {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        /// <summary>
        /// Sets the Z value of the transform.position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x"></param>
        public static void SetPositionZ(this Transform transform, float z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }

        /// <summary>
        /// Sets the XY values of the transform.position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x"></param>
        public static void SetPositionXY(this Transform transform, float x, float y)
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }

        /// <summary>
        /// Sets the XYZ values of the transform.position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x"></param>
        public static void SetPosition(this Transform transform, float x, float y, float z)
        {
            transform.position = new Vector3(x, y, z);
        }

        /// <summary>
        /// Adds to the XYZ values to the transform.position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void AddToPosition(this Transform transform, float x, float y, float z)
        {
            transform.position += new Vector3(x, y, z);
        }

        /// <summary>
        /// Adds to the XYZ values * the multiplier to the transform.position
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="multiplier">Used to scale the XYZ values. E.G. Time.deltaTime</param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public static void AddToPositionWithScaling(this Transform transform, float multiplier, float x, float y, float z)
        {
            transform.position += new Vector3(x, y, z);
        }

        public static void SetLocalPositionX(this Transform transform, float x)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
        }

        public static void SetLocalPositionY(this Transform transform, float y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        }

        public static void SetLocalPositionZ(this Transform transform, float z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
        }

        public static void SetLocalPositionXY(this Transform transform, float x, float y)
        {
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
        }

        public static void SetLocalPosition(this Transform transform, float x, float y, float z)
        {
            transform.localPosition = new Vector3(x, y, z);
        }

        public static void SetAbsLocalPositionX(this Transform transform, float x)
        {
            if (transform.lossyScale.x > 0f)
            {
                transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
            }
            else
            {
                transform.localPosition = new Vector3(-x, transform.localPosition.y, transform.localPosition.z);
            }
        }

        public static void SetLocalScaleX(this Transform transform, float x)
        {
            transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
        }

        public static void SetLocalScale(this Transform transform, float x, float y, float z)
        {
            transform.localScale = new Vector3(x, y, z);
        }

        public static void SetAbsLocalScaleX(this Transform transform, float x)
        {
            if (transform.lossyScale.x > 0f)
            {
                transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(-x, transform.localScale.y, transform.localScale.z);
            }
        }
        #endregion

        public static class Random
        {
            /// <summary>
            /// Seeds SPD.Math.Random with System.DateTime.Now.Ticks.
            /// </summary>
            public static void Seed() { UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks); }


            /// <summary>
            /// Uses value to Seed SPD.Math.Random
            /// </summary>
            /// <param name="value"></param>
            public static void Seed(int value) { UnityEngine.Random.InitState(value); }

            /// <summary>
            /// Returns a random int between min and max (inclusive.)
            /// </summary>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            public static int Range(int min, int max) { return Random.Range( min, max + 1); }

            /// <summary>
            /// Returns a random float between min and max (inclusive).
            /// </summary>
            /// <param name="min"></param>
            /// <param name="max"></param>
            /// <returns></returns>
            public static float Range(float min, float max) { return Random.Range(min, max); }

            // returns a gaussian-distributed random int.
            public static int Gaussian(int mean, int standard_deviation)
            {
                return mean + (int)Gaussian() * standard_deviation;
            }

            // returns a gaussian-distributed random int
            // between min and max (inclusive.)
            public static int Gaussian(int mean, int standard_deviation, int min, int max)
            {
                int x;
                do
                {
                    x = Gaussian(mean, standard_deviation);
                } while (x < min || x > max);

                return x;
            }

            // returns a gaussian-distributed random float.
            public static float Gaussian(float mean, float standard_deviation)
            {
                return mean + Gaussian() * standard_deviation;
            }

            // returns a gaussian-distributed random float
            // between min and max (inclusive.)
            public static float Gaussian(float mean, float standard_deviation, float min, float max)
            {
                float x;
                do
                {
                    x = Gaussian(mean, standard_deviation);
                } while (x < min || x > max);

                return x;
            }

            // returns a gaussian-distributed float.
            public static float Gaussian()
            {
                float v1, v2, s;
                do
                {
                    v1 = 2.0f * Random.Range(0f, 1f) - 1.0f;
                    v2 = 2.0f * Random.Range(0f, 1f) - 1.0f;
                    s = v1 * v1 + v2 * v2;
                } while (s >= 1.0f || s <= (0f));

                s = Mathf.Sqrt((-2.0f * Mathf.Log(s)) / s);

                return v1 * s;
            }

            // returns a random int between min and max (inclusive,)
            // and divisible by two.
            public static int RangeDivTwo(int min, int max)
            {
                int x = Random.Range(min, max + 1);
                while (x % 2 != 0) { x--; }

                return x;
            }

            // returns a random int between min and max (inclusive,)
            // and divisible by four.
            public static int RangeDivFour(int min, int max)
            {
                int x = Random.Range(min, max + 1);
                while (x % 4 != 0) { x--; }

                return x;
            }

            // returns a gaussian-distributed int between min and max (inclusive,)
            // and divisible by four.
            public static int GaussianDivFour(int mean, int standard_deviation, int min, int max)
            {
                int x;
                do
                {
                    x = Gaussian(mean, standard_deviation);
                } while (x < min || x > max);

                while (x % 4 != 0)
                {
                    x++;
                }

                return x;
            }
        }
    }

}

