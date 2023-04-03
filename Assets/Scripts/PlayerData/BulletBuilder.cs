using System.Collections;
using System.Collections.Generic;
using Asteroids;
using UnityEngine;

public class BulletBuilder //: MonoBehaviour
{
    protected GameObject _gameObject;
    public BulletBuilder()
    {
        _gameObject = new GameObject();
    }
    public BulletBuilder(GameObject gameObject)
    {
        _gameObject = gameObject;
    }

    public BulletBuilder GetTransform(Transform transform, float scale2D)
    {
        _gameObject.transform.position = transform.position;
        _gameObject.transform.localScale = new Vector3(scale2D, scale2D);
        _gameObject.layer = 8;
        return this;
    }
    public BulletBuilder GetName(string name)
    {
        _gameObject.name = name;
        return this;
    }
    public BulletBuilder GetOrAddSprite(Sprite sprite)
    {
        var component = GetOrAddComponent<SpriteRenderer>();
        component.sprite = sprite;
        component.color = Color.cyan;
        return this;
    }
    public BulletBuilder GetOrAddRigidbody()
    {
        var component = GetOrAddComponent<Rigidbody>();
        component.interpolation = RigidbodyInterpolation.Interpolate;
       // component.collisionDetectionMode = CollisionDetectionMode.Continuous; // при выстреле по€вл€ютс€ фризы
        component.mass = 0.03f;
        component.drag = 5.1f;
        component.angularDrag = 0.1f;
        return this;
    }
    public BulletBuilder GetOrAddCollider()
    {
        var component = GetOrAddComponent<SphereCollider>();
        component.radius = 0.2f;
        return this;
    }
    public BulletBuilder GetOrAddComponentBullet()
    {
        var component = GetOrAddComponent<Bullet>();
       // component.enabled = true;
        return this;
    }

    //
    public static implicit operator GameObject(BulletBuilder builder)
    {
        return builder._gameObject;
    }

    // Update is called once per frame
    private T GetOrAddComponent<T>() where T : Component
    {
        var result = _gameObject.GetComponent<T>();
        if (!result)
        {
            result = _gameObject.AddComponent<T>();
        }
        return result;
    }
}
