using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Delegate
{
    public delegate void VoidDelegate();
    public delegate void BoolDelegate(bool value);
    public delegate void FloatDelegate(float value);
    public delegate void Vector3Delegate(Vector3 value);
    public delegate void StringDelegate(string value);
    public delegate void GameObjectDelegate(GameObject value);
    public delegate void KeyCodeDelegate(KeyCode value);

    public delegate void VoidGameObjectDelegate(GameObject gameObject);
    public delegate void BoolGameObjectDelegate(GameObject gameObject, bool value);
    public delegate void FloatGameObjectDelegate(GameObject gameObject, float value);
    public delegate void Vector3GameObjectDelegate(GameObject gameObject, Vector3 value);
    public delegate void StringGameObject(GameObject gameObject, Vector3 value);
    public delegate void KeyCodeGameObjectDelegate(GameObject gameObject, KeyCode value);
}
