using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SPD.Utilities
{
    public interface IUndoable
    {
        void Undo();
    }

    public abstract class Command
    {
        public abstract void Execute();
    }

    public abstract class Command<T>
    {
        public abstract void Execute(T actor);
    }
}