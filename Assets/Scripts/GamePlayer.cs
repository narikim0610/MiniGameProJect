using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayer : MonoBehaviour
{
    public string Playername;
    public int Score;
    public int Hp;
    public float GameTimer;
    public bool IsPlaying;

    private void Start()
    {

    }
    
    private void Update()
    {
        if (!IsPlaying)
        {
            Debug.Log("게임이 끝났습니다.");
            return;
        }

        GameTimer = GameTimer - Time.deltaTime;
        if (GameTimer < 0 )
        {
            IsPlaying = false;
        }
    }


    private void OnTriggerEnter (Collider other)
    {
        bool isEnemy = other.gameObject.tag == "Enemy";
        bool isItem = other.gameObject.tag == "Item";

        if (isEnemy)
        {
            Debug.Log("Enemy Check");
            Hp = Hp - 1;
            if (Hp <= 0)
            {
                IsPlaying = false;
            }
        }

        if (isItem)
        {
            Debug.Log("Item Check");
            Score = Score + 1;
        }
        Destroy(other.gameObject);
    }
}
