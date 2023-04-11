using Facade;
using UnityEngine;

namespace Asteroids
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] AsteroidFactory<Unit> unitGO;
        [SerializeField] Sprite goSprite;
        private int countCreateAsUn = 0;
        private UnitFactoryFacade unitFactoryFacade;

        BulletsPool bulletsPoolService;
        EnemiesPool enemiesPoolService;

        private void Start()
        {
            unitFactoryFacade = new UnitFactoryFacade(unitGO, goSprite, countCreateAsUn);

            enemiesPoolService = EnemiesPool.Instance;
            ServiceLocator.RegisterService<EnemiesPool>(enemiesPoolService);

            bulletsPoolService = BulletsPool.Instance;
            ServiceLocator.RegisterService<BulletsPool>(bulletsPoolService);

        }
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                // EnemiesPool.instance.GetEnemy_1<Enemy>(); // типа синглтон...
                // or use ServiceLocator
                var enemies = ServiceLocator.GetService<EnemiesPool>();
                enemies.GetEnemy_1<Enemy>();

            }
            unitFactoryFacade.NumButton1();
            unitFactoryFacade.NumButton2();
            unitFactoryFacade.NumButton3(gameObject);
            unitFactoryFacade.NumButton4(gameObject);
            //_______________________________________________
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                if (!gameObject.GetComponent<EnemiesPool>().enabled)
                {
                    gameObject.GetComponent<EnemiesPool>().enabled = true;
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                Debug.Log(" KeyCode (0)  <color=yellow>Log</color>");
                Debug.ClearDeveloperConsole();
            }
        }
    }
}
