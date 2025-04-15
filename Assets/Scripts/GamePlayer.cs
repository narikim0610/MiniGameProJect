using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GamePlayer : MonoBehaviour
{
    public string PlayerName;
    public int Score;
    public int Hp;
    public float GameTimer;
    public bool IsPlaying;

    public GameObject txtTimer;
    public GameObject txtName;
    public GameObject txtScoreValue;
    public GameObject txtHPValue;

    public GameObject coinPrefab;
    public GameObject enemyPrefab;

    public GameObject itemCotainer;
    public GameObject enemyCotainer;

    public int ItemCount = 30;
    public int enemyCount = 10;
    public int MapSize = 30;


    private void Start()
    {
        txtName.GetComponent<TMP_Text>().text = PlayerName;
        txtHPValue.GetComponent<TMP_Text>().text = Hp.ToString();

        //생성: Instantiate(대상);

        //파괴: Destroy(대상);

        //활성화/비활성화: 대상.SetActive(true);/대상.SetActive(false);

        //컴포넌트 접근: GetComponent<대상>()

        //   시작       끝      변화
        int count;
        for (count = 1; count<=ItemCount; count++)
        {
            Debug.Log("반복중입니다");
            GameObject item = Instantiate(coinPrefab, itemCotainer.transform);
            //변수
            float halfSize = MapSize / 2; // 20/2 = 20 * 0.5f
            float ramdomX = Random.Range(halfSize * -1, halfSize);
            float ramdomZ = Random.Range(halfSize * -1, halfSize);
            item.transform.position = new Vector3(ramdomX, 1, ramdomZ);
        }

        for (count = 1; count <= enemyCount; count++)
        {
            Debug.Log("반복중입니다");
            GameObject enemy = Instantiate(enemyPrefab, enemyCotainer.transform);
            //변수
            float halfSize = MapSize / 2; // 20/2 = 20 * 0.5f
            float ramdomX = Random.Range(halfSize * -1, halfSize);
            float ramdomZ = Random.Range(halfSize * -1, halfSize);
            enemy.transform.position = new Vector3(ramdomX, 1, ramdomZ);
        }

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
        txtTimer.GetComponent<TMP_Text>().text = GameTimer.ToString("F1");

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
        txtHPValue.GetComponent<TMP_Text>().text = Hp.ToString();

        if (isItem)
        {
            Debug.Log("Item Check");
            Score = Score + 1;
        }
        Destroy(other.gameObject);
        txtScoreValue.GetComponent<TMP_Text>().text = Score.ToString();
    }
}
