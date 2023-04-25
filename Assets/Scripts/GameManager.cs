using Facade;
using TMPro;
using UnityEngine;

namespace Asteroids
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] AsteroidFactory<Unit> unitGO;
        [SerializeField] Sprite goSprite;
        [SerializeField] private TextMeshProUGUI _textGO;
        private const string TextMeshProUGUIName_1 = "Text for tests (TMP)  (3)";
        private const string TextMeshProUGUIName_2 = "Text for tests (TMP)  (2)";

        public int TimeToSpawn = 5;
        private int _timeUnit = 1;
        private int _timerCount = 0;
        private float timer;
        private int _countCreateAsUn = 0;
        private UnitFactoryFacade unitFactoryFacade;

        BulletsPool bulletsPoolService;
        EnemiesPool enemiesPoolService;

        private void Start()
        {
            unitFactoryFacade = new UnitFactoryFacade(unitGO, goSprite, _countCreateAsUn);

            enemiesPoolService = EnemiesPool.Instance;
            ServiceLocator.RegisterService<EnemiesPool>(enemiesPoolService);

            bulletsPoolService = BulletsPool.Instance;
            ServiceLocator.RegisterService<BulletsPool>(bulletsPoolService);
            _timerCount = TimeToSpawn;
        }
        private void Update()
        {
            AsteroidGenerator();

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
            // unitFactoryFacade.CreateAsteroidUnit(gameObject);
            //_______________________________________________
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                if (!gameObject.GetComponent<EnemiesPool>().enabled)
                {
                    gameObject.GetComponent<EnemiesPool>().enabled = true;

                    TextMessager.TextMessageUpdate("<color=red>EnemiesPool>().enabled</color>");

                    _textGO = GameObject.Find(TextMeshProUGUIName_2).gameObject.GetComponent<TextMeshProUGUI>();
                    TextMessager.TextMessageUpdate(_textGO, "<color=red>EnemiesPool>().enabled</color>");
                }
            }
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                string str1 = $" KeyCode (0)  <color=yellow>\"0\" Key Down</color>";
                UpdateUIText(str1);

                Debug.Log(str1);
                Debug.ClearDeveloperConsole();
            }
        }

        private void AsteroidGenerator()
        {
            timer -= UnityEngine.Time.deltaTime;
            if (timer <= 0)
            {
                _timerCount--;
                UpdateUIText(TextMeshProUGUIName_1, _timerCount.ToString("0"));
                timer = _timeUnit;
                //unitFactoryFacade.CreateAsteroidUnit(gameObject);
            }
            UpdateUIText(TextMeshProUGUIName_2, timer.ToString("0.0"));
            if (_timerCount <= 0)
            {
                _timerCount = TimeToSpawn + 1;
                unitFactoryFacade.CreateAsteroidUnit(gameObject);
            }
        }

        private void UpdateUIText(string text)
        {
            _textGO = GameObject.Find(TextMeshProUGUIName_2).GetComponent<TextMeshProUGUI>();
            _textGO.text = text;
        }
        private void UpdateUIText(string gameObject, string text)
        {
            _textGO = GameObject.Find(gameObject).GetComponent<TextMeshProUGUI>();
            _textGO.text = text;
        }
    }
}
