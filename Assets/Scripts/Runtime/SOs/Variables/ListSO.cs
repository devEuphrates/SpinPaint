using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSO<T> : ScriptableObject, IEnumerable<T>
{
    [SerializeField] List<T> _values = new List<T>();
    public event Action<T> OnValueAdded;
    public event Action<T> OnValueRemoved;

    public int Count => _values.Count;

    public T GetValue(int index) => index > _values.Count - 1 || index < 0 ? default : _values[index];

    public T this [int index] => GetValue(index);

    public void AddValue(T val)
    {
        _values.Add(val);
        OnValueAdded?.Invoke(val);
    }

    public void RemoveValue(T val)
    {
        _values.Add(val);
        OnValueRemoved?.Invoke(val);
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index > _values.Count - 1)
            return;

        _values.RemoveAt(index);
    }

    public bool Exists(T val)
    {
        foreach (var item in _values)
        {
            if (item.Equals(val))
                return true;
        }

        return false;
    }

    public void RemoveAll(Predicate<T> predicate)
    {
        for (int i = _values.Count - 1; i >= 0 ; i--)
        {
            if (!predicate(_values[i]))
                continue;

            _values.RemoveAt(i);
        }
    }

    public void Clear() => _values.Clear();

    public IEnumerator<T> GetEnumerator() => new SOListEnum(_values.ToArray());

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

    public class SOListEnum : IEnumerator<T>
    {
        T[] _values;
        int _position = -1;

        public SOListEnum(T[] values)
        {
            _values = values;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _values[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        T IEnumerator<T>.Current => (T)Current;

        public void Dispose()
        {
            _position = -1;

        }

        public bool MoveNext() => ++_position < _values.Length;

        public void Reset() => _position = -1;
    }
}
