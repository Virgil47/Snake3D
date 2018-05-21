using UnityEngine;
using UnityEngine.UI;
using Assets.Scripts;

public class Boarders : MonoBehaviour
{
    public AudioSource deathSound;
    public GameObject groupDeath; //группа UI элементов , которые выводят сообщения о смерти.
    public SnakeMovement deathSnake; 
    public Text uiDeathScore; //элемент UI, показывающий очки в момент смерти. 

    void Start()
    {
        deathSound = GetComponent<AudioSource>();
        
        deathSnake = GameObject.FindGameObjectWithTag("SnakeHead").GetComponent<SnakeMovement>();//чтобы воспользоваться победными очками из SnakeMovement,ищем экземпляр класса именно по тегу.
    }

    /// <summary>
    /// При столкновении с бордюром игра ставится на паузу и выводится картинка
    /// </summary>
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SnakeHead"))
        {
            uiDeathScore.text = deathSnake.winScore.ToString();
            deathSound.Play();
            Time.timeScale = 0; 
            groupDeath.SetActive(true);
            var name = ProfileSettingsLoader.Get().Name;
            var jsonScore = deathSnake.winScore;
            new Serializer().Write(name, jsonScore);  //вызов метода Write класса Serializer для записи имени и очков.
        }
    }
}
