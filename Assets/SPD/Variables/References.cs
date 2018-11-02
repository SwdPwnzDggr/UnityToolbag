using System;

namespace SPD.Variables
{
    public class PlaceholderReference<T> { public T Value; }

    [Serializable]
    public class Reference<T>
    {
        public bool useConstant = true;
        public T constantValue;
        public PlaceholderReference<T> Variable;

        public T Value
        {
            get { return useConstant ? constantValue : Variable.Value; }
        }

        public static implicit operator T(Reference<T> reference)
        {
            return reference.Value;
        }
    }


    [Serializable]
    public class FloatReference : Reference<float>
    {
        public new FloatVariable Variable;

        public FloatReference() { }
        public FloatReference(int value)
        {
            useConstant = true;
            constantValue = value;
        }
    }

    [Serializable]
    public class IntReference : Reference<int>
    {
        public new IntVariable Variable;

        public IntReference() { }
        public IntReference(int value)
        {
            useConstant = true;
            constantValue = value;
        }

    }

    [Serializable]
    public class Vector3Reference : Reference<UnityEngine.Vector3>
    {
        public new Vector3Variable Variable;

        public Vector3Reference() { }
        public Vector3Reference(UnityEngine.Vector3 value)
        {
            useConstant = true;
            constantValue = value;
        }
    }

    [Serializable]
    public class StringReference : Reference<string>
    {
        public new StringVariable Variable;

        public StringReference() { }
        public StringReference(string value)
        {
            useConstant = true;
            constantValue = value;
        }
    }

    [Serializable]
    public class BoolReference : Reference<bool>
    {
        public new BoolVariable Variable;

        public BoolReference() { }
        public BoolReference(bool value)
        {
            useConstant = true;
            constantValue = value;
        }

    }

}