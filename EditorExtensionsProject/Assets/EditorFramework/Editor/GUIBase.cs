using System;
using UnityEngine;

/// <summary>
/// GUI¿âµÄ¿ò¼Ü
/// </summary>
public abstract class GUIBase : IDisposable
{
    public bool mDisposed { get; private set; }
    public Rect mPosition { get; private set; }


    public virtual void OnGUI(Rect position)
    {
        mPosition = position;
    }

    public virtual void Dispose()
    {
        if (mDisposed) return;
        OnDisposed();
        mDisposed = true;
    }

    protected abstract void OnDisposed();
}
