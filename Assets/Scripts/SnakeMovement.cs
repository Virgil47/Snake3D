using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SnakeMovement : MonoBehaviour
{
    public float speed; 
    public float rotationSpeed; 
    public float zDisplacement = 0.5f; // расстояние, на которое будет помещаться новый участок тела змеи (К голове крепиться хвост)
    public GameObject tailPrefab; //элемент хвоста, добавляемый в массив.

    public List<GameObject> snakeTail = new List<GameObject>();

    public Text uiScore; //элемент текста в игре (очки)
    public Text uiTail; //элемент текста в игре (хвост)
    public int score = 0; //изменяемая переменная (очки)
    public int winScore = 0; //изменяемая переменная (победные очки)
    public int tailCount = 0; //изменяемая переменная (части хвоста)
    public Text uiWinScore; // элемент текста в игре (победные очки)
    public GameObject groupWin; //Группа UI элементов , которые выводят сообщения о победе.

    void Start()
    {
        snakeTail.Add(gameObject);
    }
    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow)) 
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime);
        }
        uiScore.text = score.ToString();
        uiTail.text = tailCount.ToString();
        uiWinScore.text = winScore.ToString();
    }

    public void AddNewPartOfTail()
    {
        Vector3 newTailPosition = snakeTail.Last().transform.position;
        newTailPosition.z -= zDisplacement; //отнимаем именно от .z (от оси z ось z, а не от всего вектора3)
        snakeTail.Add(GameObject.Instantiate(tailPrefab, newTailPosition, Quaternion.identity) as GameObject); // добавление нового элемента в массив и префаба на карту за головой змеи
        speed = speed + 0.2f;
        score = score + 10;
        winScore = winScore + 10;
        tailCount++;

        if (winScore == 150)
        {
            Time.timeScale = 0;
            groupWin.SetActive(true);
        }
    }
}
