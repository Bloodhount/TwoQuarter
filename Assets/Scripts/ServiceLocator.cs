using System;
using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;
using static UnityEngine.Debug;

public static class ServiceLocator
{
    private static Dictionary<Type, object> _services = new Dictionary<Type, object>();
    public static void RegisterService<T>(T service) where T : class
    {
        var typeVal = typeof(T);
        _services[typeVal] = service;
        //Log($"<color=red>{_services.Values}</color>");
        //Log($"<color=yellow>{_services.Count}</color>");
        //Log($"<color=green>{_services.GetType()}</color>");

    }

    public static void UnregisterService<T>() where T : class
    {
        var type = typeof(T);
        if (_services.ContainsKey(type))
        {
            _services.Remove(type);
        }
    }

    public static T GetService<T>() where T : class
    {
        if (_services != null)
        {
            _services.TryGetValue(typeof(T), out var fuoundService);
            // Log($"<color=green> {fuoundService} </color>");
            return fuoundService as T;
        }
        else
        {
            Debug.Log(" <color=red> ArgumentNullException </color>");
            throw new ArgumentNullException();
        }
    }
}
