using UnityEngine;

public class EggGeneration : MonoBehaviour
{

    public double xSize = 8.8; // координаты для оси х, в пределах которых еда для змеи будет появляться на поле.
    public double zSize = 8.8; 

    public GameObject foodPrefab; 
    public Vector3 foodPosition; 
    public GameObject curFood;// текущий объект еды.
    public AudioSource eggSound;

    void Start()
    {
        eggSound = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (!curFood)
        {
            AddNewEgg();
            eggSound.Play();
        }
        else return;
    }
    /// <summary>
    /// метод создает новую еду каждый раз как змея ее съедает.
    /// </summary>
    void AddNewEgg()
    {
        FoodRandomPos();
        curFood = GameObject.Instantiate(foodPrefab, foodPosition, Quaternion.identity) as GameObject; //клонирует объект и возвращает его клон (объект, расположение, вращение).
    }
    /// <summary>
    /// Метод делает рэндомную позицию для еды, каждый раз как вызывается.
    /// </summary>
    void FoodRandomPos()
    {
        foodPosition = new Vector3(Random.Range((float)xSize * -1, (float)xSize), 0.20f, Random.Range((float)zSize * -1, (float)zSize));
    }
}
