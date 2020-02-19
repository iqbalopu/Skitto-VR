using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_FruitSpawner : MonoBehaviour
{
    public static Level_3_FruitSpawner Instance;

    [Header("________Spawn Positions________")]
    #region SpawnPositions Variables
    public  Transform SpawnPosition_Parent;
    private Transform[] _spawnPositions;

    #endregion

    [Header("________General Fruits________")]
    #region SpawnPositions Variables
    public Transform fruit_parent;
    public Level_3_Fruit[] _allFruits;
    float GeneralForce = 30;
    #endregion

    //rrrr[Header("________Special Fruits________")]
    //#region SpawnPositions Variables
    //public Transform special_fruit_parent;
    //private Fruit[] _allSpecialFruits;
    //private int nt_count_fruitSpawn;
    //private int nt_Fire_Freeze_Selection;
    //private bool isTimeForBomb;
    //#endregion
    
    // Use this for initialization

    private void Awake()
    {
        //rrrr nt_Fire_Freeze_Selection = 0;
        //nt_count_fruitSpawn = 0;
        //isTimeForBomb = true;
        Instance = this;

        _allFruits          = fruit_parent.GetComponentsInChildren<Level_3_Fruit>();

        //rrrr _allSpecialFruits   = special_fruit_parent.GetComponentsInChildren<Fruit>();
        _spawnPositions     = new Transform[SpawnPosition_Parent.childCount];

        for (int i = 0; i < SpawnPosition_Parent.childCount; i++)
        {
            _spawnPositions[i] = SpawnPosition_Parent.GetChild(i);
        }

        // enable bomb
        // Invoke("EnableBombFruitClass", 4);
    }

    public void EnableBombFruitClass()
    {
        _allFruits[_allFruits.Length - 1].GetComponent<Level_3_Fruit>().enabled = true;
        _allFruits[_allFruits.Length - 1].GetComponent<Level_3_Fruit>().SetupBombParticle();
        // Debug.LogError("Enable bomb fruit!!"); 
    }

    void Start()
    {
        // StartCoroutine("LeftWave");
    }

    //rrrr public void ResetTimeForBomb()
    //{
    //    isTimeForBomb = false;
    //}

    public void StartSpawning()
    {
        InvokeRepeating("CallRandomSpawn_Invoke", 1, 3);
    }

    public void StopSpawning()
    {
        CancelInvoke("CallRandomSpawn_Invoke");
    }

    public void StartFreezeSpawning()
    {
        StopSpawning();
        InvokeRepeating("CallRandomSpawn_Invoke", 0.5f, 1.5f);
    }

    public void StopFreezeSpawning()
    {
        CancelInvoke("CallRandomSpawn_Invoke");
        StartSpawning();
    }

    public void CallRandomSpawn_Invoke()
    {
        switch (Random.Range(0, 9))
        {
            case 0: { StartCoroutine(LeftWave()); } break;
            case 1: { StartCoroutine(RightWave()); } break;
            case 2: { StartCoroutine(MidWave()); } break;
            case 3: { StartCoroutine(UWave()); } break;
            case 4: { StartCoroutine(AllWave()); } break;
            case 5: { StartCoroutine(ModularLeft()); } break;
            case 6: { StartCoroutine(ModularRight()); } break;
            case 7: { StartCoroutine(RandomRight()); } break;
            case 8: { StartCoroutine(RandomLeft()); } break;
            default:
                break;
        }

        // Count the number of wave spwned
        //rrrr ++nt_count_fruitSpawn;
    }

    public void EndSpawning()
    {
        CancelInvoke("CallRandomSpawn_Invoke");
    }

    public void PauseSpawning()
    {

    }

    public void ShootRandomFromHoleNumber(int hole)
    {

    }

    #region WaveGeneraion
    IEnumerator LeftWave()
    {
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            enableUniqueFruit(_spawnPositions[i]);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator RightWave()
    {
        for (int i = _spawnPositions.Length - 1; i >= 0; i--)
        {
            enableUniqueFruit(_spawnPositions[i]);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator MidWave()
    {
        int leftDirection = _spawnPositions.Length / 2;
        int rightDirection = _spawnPositions.Length / 2 + 1;

        for (int i = leftDirection, j = rightDirection; i >= 0; i--, j++)
        {
            enableUniqueFruit(_spawnPositions[i]);
            if (j < _spawnPositions.Length)
                enableUniqueFruit(_spawnPositions[j]);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator UWave()
    {
        int leftDirection = _spawnPositions.Length / 2;
        int rightDirection = _spawnPositions.Length / 2 + 1;

        for (int i = 0, j = _spawnPositions.Length - 1; i <= leftDirection; i++, j--)
        {
            enableUniqueFruit(_spawnPositions[i]);
            if (j > leftDirection)
                enableUniqueFruit(_spawnPositions[j]);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator AllWave()
    {
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            enableUniqueFruit(_spawnPositions[i]);
        }

        yield return new WaitForSeconds(0.2f);
    }

    IEnumerator ModularLeft()
    {
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            if (i % 2 == 0)
            {
                enableUniqueFruit(_spawnPositions[i]);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    IEnumerator ModularRight()
    {
        for (int i = _spawnPositions.Length - 1; i >= 0; i--)
        {
            if (i % 2 == 0)
            {
                enableUniqueFruit(_spawnPositions[i]);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    IEnumerator RandomRight()
    {
        for (int i = _spawnPositions.Length - 1; i >= 0; i--)
        {
            if (Random.Range(1, 5) % 2 == 0)
            {
                enableUniqueFruit(_spawnPositions[i]);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    IEnumerator RandomLeft()
    {
        for (int i = 0; i < _spawnPositions.Length; i++)
        {
            if (Random.Range(1, 5) % 2 == 0)
            {
                enableUniqueFruit(_spawnPositions[i]);
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    int nt_skeep = 0;

    void enableUniqueFruit(Transform t)
    {
        float appliedForce = GeneralForce;
        if (Level_3_GameController.Instance.OnFreeze)
        {
            appliedForce = GeneralForce * 2;
        }

        int r = -1;
        int ntWhileCount = 0;

        while (true)
        {
            ++ntWhileCount;

            if (ntWhileCount > 50) // infinity breaking code
            {
                return;
            }

            r = Random.Range(0, _allFruits.Length - 2);
            if (!_allFruits[r].isFruitPicked)
            {
                break;
            }
            else
            {
                continue;
            }
        }

        // _allFruits[r].Enable(positon, Vector3.up * Random.Range(25,35));
        //if (nt_count_fruitSpawn > 5)
        //{
        //    //rrrr nt_count_fruitSpawn = 0;

        //    // nt_Fire_Freeze_Selection = nt_Fire_Freeze_Selection == 0 ? 1 : 0;

        //    // Spawn special fruit

        //    //_allSpecialFruits[nt_Fire_Freeze_Selection].Enable(t.position + new Vector3(0, 0.20f, 0), new Vector3(0, 1, 0)
        //      //  * Random.Range(appliedForce, appliedForce + 5) /* + new Vector3(Random.Range(5, 10), 0, Random.Range(5, 10))*/);
        //    // canon animation
        //    Canon c = t.gameObject.GetComponentInChildren<Canon>();
        //    c.fire();
        //    return;
        //}

        //rrrr Bomb spawn
        //if (_allFruits[r].type == Fruit.FruitType.bomb)
        //{
        //    ++nt_skeep;
        //    if (nt_skeep > 3)
        //    {
        //        nt_skeep = 0;

        //        int nt_rand_bomb = Random.Range(_allFruits.Length - 3, _allFruits.Length);
        //        if (!_allFruits[nt_rand_bomb].isFruitPicked)
        //        {
        //            _allFruits[nt_rand_bomb].Enable(t.position + new Vector3(0, 0.20f, 0), new Vector3(0, 1, 0)
        //                           * Random.Range(appliedForce, appliedForce + 5) /* + new Vector3(Random.Range(5, 10), 0, Random.Range(5, 10))*/);
        //            // Debug.LogError("time for bomb fruit is: " + _allFruits[r].type + "Name of the fruit is: " + _allFruits[r].gameObject.name);
        //            // canon animation
        //            Canon c = t.gameObject.GetComponentInChildren<Canon>();
        //            c.fire();
        //        }
        //    }
        //    //if (isTimeForBomb)
        //    //{
        //    //    isTimeForBomb = false;
        //    //    Invoke("ResetTimeForBomb", 3);
        //    // through the bomb and return
        //}
        //else {
            // General fruit spawn
            _allFruits[r].Enable(t.position + new Vector3(0, 0.20f, 0), new Vector3(0, 1, 0)
                * Random.Range(appliedForce, appliedForce + 5) /* + new Vector3(Random.Range(5, 10), 0, Random.Range(5, 10))*/);
        // Debug.LogError("fruit is: " + _allFruits[r].type); 
        // canon animation
        Level_3_Canon c = t.gameObject.GetComponentInChildren<Level_3_Canon>();
            c.fire();
        // }
    }
    #endregion
}