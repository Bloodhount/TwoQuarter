using Adapter;
using UnityEngine;

namespace Asteroids.Factories
{
    public static class StaticUnitFactory
    {
        public static GameObject CreateUnit(Sprite spriteTest) 
        {
            var go = new GameObject();
            go.transform.position = new Vector3(10, 0, -1);
            go.name = "StaticUnitFactory CreateUnit name \"new Asteroid\" !";

            go.AddComponent<Unit>();

            go.AddComponent<SpriteRenderer>();
            if (go.TryGetComponent(out SpriteRenderer spriteComponent))
            {
                spriteComponent.sprite = spriteTest;
            }

            go.AddComponent<DestroySelfGO>();
            if (go.TryGetComponent(out DestroySelfGO destroySelfComponent))
            {
                int timeTodestruct = 5;
                destroySelfComponent._timeToSelfdestruct = timeTodestruct;
            }

            go.AddComponent<UnitAsterFactory>();
            if (go.TryGetComponent(out UnitAsterFactory unitAsterFactoryComponent))
            {
                if (unitAsterFactoryComponent.TryGetComponent(out Unit unitComponent))
                {
                    unitAsterFactoryComponent.InitUnit(unitComponent, go.transform);
                }
            }

            go.AddComponent<UnitAdapter>();

            Debug.Log("<color=yellow>go.name </color>" + $"<color=green>{go.name} </color>");
            return go;
        }
    }
}
