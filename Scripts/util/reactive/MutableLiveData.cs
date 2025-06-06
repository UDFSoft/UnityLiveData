/*
 *    Copyright 2025 UDF Owner
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 *    More details: https://udfsoft.com/
 */

using System;
using System.Collections.Generic;
using UnityEngine;

public class MutableLiveData<T> : ILiveData<T>
{
    private T _value;
    private List<(MonoBehaviour owner, Action<T> callback)> _observers = new List<(MonoBehaviour, Action<T>)>();

    public MutableLiveData(T initialValue = default)
    {
        _value = initialValue;
    }

    public void Observe(MonoBehaviour owner, Action<T> callback)
    {
        _observers.Add((owner, callback));
        callback(_value); // сразу отправляем текущее значение
    }

    public void SetValue(T newValue)
    {
        _value = newValue;
        NotifyObservers();
    }

    private void NotifyObservers()
    {
        for (int i = _observers.Count - 1; i >= 0; i--)
        {
            var (owner, callback) = _observers[i];

            if (owner == null) // Если объект уничтожен
            {
                _observers.RemoveAt(i); // Убираем "мертвого" подписчика
            }
            else
            {
                callback(_value);
            }
        }
    }

    public T GetValue() => _value;
}
