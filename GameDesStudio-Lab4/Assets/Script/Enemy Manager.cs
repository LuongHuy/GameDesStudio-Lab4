using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
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
        _easyMode = new Dictionary<string, float>();
        _easyMode["SpawnAmount"] = spawnAmountEasy;
        _easyMode["SpawnInterval"] = spawnIntervalEasy;

        _hardMode = new Dictionary<string, float>();
        _hardMode["SpawnAmount"] = spawnAmountHard;
        _hardMode["SpawnInterval"] = spawnIntervalHard;

        if (_currentMode == null){
            SwitchMode(defaultDiff);
        }


        SpawnEnemy();

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

    public void SpawnEnemy()
    {
        SpriteRenderer _spawnArea = spawnArea.GetComponent<SpriteRenderer>();
        if (_spawnArea != null) {

            for (int i = 0; i < _currentMode["SpawnAmount"];i++)
            {
                float x = Mathf.Round(Random.Range(_spawnArea.bounds.min.x, _spawnArea.bounds.max.x)*10)/10;
                float y = Mathf.Round(Random.Range(_spawnArea.bounds.min.y, _spawnArea.bounds.max.y)*10)/10;
                Vector2 pos = new Vector2(x,y);

                //Instantiate(spawn_soldier, pos, Quaternion.identity);
            }
        }
        else
        {
            Debug.Log("have not assign Spawn Area");
        }
    }

    public void DisplayDic(Dictionary<string, float> dic)
    {
        foreach (KeyValuePair<string, float> kvp in dic)
        {
            Debug.Log("Key: " + kvp.Key + " , Value: " + kvp.Value);
        }
    }
}
