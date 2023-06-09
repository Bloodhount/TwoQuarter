﻿using System;
using UnityEngine;

[Serializable]
public sealed class SavedData
{
    public string Name;
    public Vector3 Position;
   // public Vector3Serializable Position;
    public bool IsEnabled;

    //public static implicit operator SavedData(SavedData v)
    //{
    //    throw new NotImplementedException();
    //}
}

[Serializable]
public struct Vector3Serializable
{
    public float X;
    public float Y;
    public float Z;
    private Vector3Serializable(float valueX, float valueY, float valueZ)
    {
        X = valueX;
        Y = valueY;
        Z = valueZ;
    }
    public static implicit operator Vector3(Vector3Serializable value)
    {
        return new Vector3(value.X, value.Y, value.Z);
    }
}