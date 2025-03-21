using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Difficulty { 
Easy,
Medium,
Hard
}

public class EnemyManager : MonoBehaviour
{
    // Singleton set up
    private static EnemyManager _instance;
    public static EnemyManager Instance { get {return _instance; } }

    [SerializeField] GameObject spawnArea;
    [SerializeField] List<GameObject> enemyTypes;
    List<GameObject> enemies;

    // Difficulty setup
    // easy
    [SerializeField] float spawnIntervalEasy=6f;
    [SerializeField] float spawnAmountEasy=1f;
    // medium
    [SerializeField] float spawnIntervalMedium=5f;
    [SerializeField] float spawnAmountMedium=3f;
    // hard
    [SerializeField] float spawnIntervalHard = 4f;
    [SerializeField] float spawnAmountHard = 4f;

    // Spawn interval reduce 
    [SerializeField] float intervalReduceRate = 0.2f;
    [SerializeField] float intervalReduceInterval=1f;

    // Set up difficulty mode
    Dictionary<string, float> _easyMode;
    Dictionary<string, float> _mediumMode;
    Dictionary<string, float> _hardMode;
    Dictionary<string, float> _currentMode;

    [SerializeField] Difficulty defaultDiff;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
        }
        else
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // set up easy mode parameter
        _easyMode = new Dictionary<string, float>();
        _easyMode["SpawnAmount"] = spawnAmountEasy;
        _easyMode["SpawnInterval"] = spawnIntervalEasy;

        // set up medium mode parameter
        _mediumMode = new Dictionary<string, float>();
        _mediumMode["SpawnAmount"] = spawnAmountMedium;
        _mediumMode["SpawnInterval"] = spawnIntervalMedium;

        // set up hard mode parameter
        _hardMode = new Dictionary<string, float>();
        _hardMode["SpawnAmount"] = spawnAmountHard;
        _hardMode["SpawnInterval"] = spawnIntervalHard;

        if (_currentMode == null){
            SwitchMode(defaultDiff);
        }

        // set up enemies list to reference later if necessary
        enemies = new List<GameObject>();

        //SpawnEnemy();
        StartCoroutine(RepeatlySpawn());
        //interval reduce 
        StartCoroutine(RepeatlyReduceInterval());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator RepeatlyReduceInterval()
    {
        // start reduce after 2 seconds
        yield return new WaitForSeconds(2f);

        while (true)
        {
            //Every interval 
            yield return new WaitForSeconds(intervalReduceInterval);
            ReduceInterval();
        }
    }
    void ReduceInterval()
    {
        if (_currentMode != null)
        {
            //_currentMode["SpawnInterval"] -= intervalReduceRate;
            _currentMode["SpawnInterval"] = _currentMode["SpawnInterval"] > 1 ? _currentMode["SpawnInterval"] - intervalReduceRate : 1;
        }
    }
    IEnumerator RepeatlySpawn()
    {
        while (true)
        {
            // Spawn enemy
            SpawnEnemy();

            // Wait for second
            yield return new WaitForSeconds(_currentMode["SpawnInterval"]);
        }
    }

    void SpawnEnemy()
    {
        SpriteRenderer _spawnArea = spawnArea.GetComponent<SpriteRenderer>();
        if (_spawnArea != null) {

            for (int i = 0; i < _currentMode["SpawnAmount"];i++)
            {
                // Get random x from range (round to nearest 5 so they wou)
                float x = Mathf.Round(Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x) /2)*2;
                float y = Mathf.Round(Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y));
                Vector2 pos = new Vector2(x,y);

                GameObject randomEnemyObj = enemyTypes[Random.Range(0,enemyTypes.Count)];
                //GameObject newEnemy = randomEnemyObj.GetComponent<EnemyClass>().DeepClone(pos);

                GameObject newEnemy = Instantiate(randomEnemyObj, pos, Quaternion.Euler(0,0,-90));
                enemies.Add(newEnemy);
            }
        }
        else
        {
            Debug.Log("have not assign Spawn Area");
        }
    }

    public void DestroyEnemy(GameObject enemy)
    {
        enemies.Remove(enemy);
        Destroy(enemy);
    }

    public void DisplayDic(Dictionary<string, float> dic)
    {
        foreach (KeyValuePair<string, float> kvp in dic)
        {
            Debug.Log("Key: " + kvp.Key + " , Value: " + kvp.Value);
        }
    }

    // Function for switching difficulty. called by DiificultyAdjustDropdown.cs
    public void SwitchDifficulty(string dif)
    {
        switch (dif)
        {
            case "Easy":
                SwitchMode(Difficulty.Easy);
                break;
            case "Normal":
                SwitchMode(Difficulty.Medium);
                break;
            case "Hard":
                SwitchMode(Difficulty.Hard);
                break;
            default:
                Debug.Log("Keyword not found");
                break;
        }
    }
    void SwitchMode(Difficulty dif)
    {
        switch (dif)
        {
            case Difficulty.Easy:
                _currentMode = _easyMode;
                break;
            case Difficulty.Medium:
                _currentMode = _mediumMode;
                break;
            case Difficulty.Hard:
                _currentMode = _hardMode;
                break;
            default:
                Debug.Log("value not found");
                break;
        }
    }
}
