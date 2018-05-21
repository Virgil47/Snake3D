using UnityEngine;

public class TailConnector : MonoBehaviour
{
    public float speed;
    public int tailID; 
    public Vector3 preLastTailElementPos;
    public GameObject preLastTailElement; 
    public GameObject uiDeath; // элемент UI с картинкой смерти.
    public SnakeMovement snakeMovement;

    void Start()
    {
        
        snakeMovement = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>(); //экземпляр класса SnakeMovement, из которого тянем массив snakeTail 

        preLastTailElement = snakeMovement.snakeTail[snakeMovement.snakeTail.Count - 2]; //предпоследний элемент массива
        speed = snakeMovement.speed+1.6f; 
        tailID = snakeMovement.snakeTail.IndexOf(gameObject);
    }

    void Update ()
    {
        preLastTailElementPos = preLastTailElement.transform.position; 
        
        transform.position = Vector3.Lerp(transform.position, preLastTailElementPos, Time.deltaTime * speed);//transform - это свойство компонента, объекта тела, на который повешен скрипт TailConnector
	}

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            if (tailID > 2)
            {
                Time.timeScale = 0;
                uiDeath.SetActive(true);
            }
        }
    }
}
