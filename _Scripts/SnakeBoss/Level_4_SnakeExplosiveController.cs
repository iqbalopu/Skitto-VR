using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_4_SnakeExplosiveController : MonoBehaviour {

    public GameObject[] Explosives;
    public Transform Origin;
    Level_4_SnakeStatus snakeStatus;
    Level_4_SnakeAudio snakeAudio;
    public Transform Player;
    public float explosiveThrowSpeed=250f;
    private void Awake()
    {
        snakeStatus = GetComponent<Level_4_SnakeStatus>();
        snakeAudio = GetComponentInParent<Level_4_SnakeAudio>();
        /*Player =GameObject.FindGameObjectWithTag("Player").transform;*/
    }
   
    public void ThroExplosiveAtPlayer()
    {
        int Index = Random.Range(0, Explosives.Length);
        GameObject explosives = Instantiate(Explosives[Index], Origin.position, Quaternion.identity);
        Vector3 direction = Player.position - Origin.position;
        snakeAudio.PlayExplosiveThrowAudio();
        explosives.GetComponent<Level_4_SnakeExplosive>().SetDirection(direction);
    }
}
