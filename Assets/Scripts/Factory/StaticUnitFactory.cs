using UnityEngine;

namespace Asteroids.Factories
{
    public static class StaticUnitFactory
    {
        //[SerializeField] private Texture _texture;
        // TODO enemy: -> unit
        public static Enemy CreateEnemy()
        {
            return new Enemy();
        }
        public static Unit CreateUnit()
        {
            var go = new GameObject();
            go.transform.position = new Vector3(0, 0, -1);
            go.name = "StaticUnitFactory new Unit";
            var unit = go.AddComponent<Unit>(); 
            Sprite sprite111 = Resources.Load<Sprite>("Prefabs/asteroids1");
            go.AddComponent<SpriteRenderer>().sprite =sprite111;// Resources.Load<Sprite>("Prefabs/asteroids1");
            //Texture2D texture = GameObject.Find("asteroids1").GetComponentInChildren<Texture2D>();
            //go.AddComponent<SpriteRenderer>().sprite = Sprite.Create(texture, new Rect(0, 0, 200, 200), Vector2.zero);
            //var unit = new Unit();              
            unit.Config("fafsfdsa");
            Debug.Log(unit.name);
            return unit;
        }
    }
}
