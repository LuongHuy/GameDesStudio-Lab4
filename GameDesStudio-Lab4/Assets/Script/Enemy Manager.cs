using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.VFX;

public enum Difficulty { 
Easy,
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
    [SerializeField] float spawnIntervalEasy;
    [SerializeField] float spawnIntervalHard;
    [SerializeField] float spawnAmountEasy;
    [SerializeField] float spawnAmountHard;
    Dictionary<string, float> _easyMode;
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SwitchMode(Difficulty dif)
    {
        if (dif == Difficulty.Easy)
        {
            _currentMode = _easyMode;
        }
        else if (dif == Difficulty.Hard) { 
            _currentMode = _hardMode;
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

                GameObject newEnemy = Instantiate(randomEnemyObj, pos, Quaternion.identity);
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
        Debug.Log("Destroy enemy outside of screen");
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
}
