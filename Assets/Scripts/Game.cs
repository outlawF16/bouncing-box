using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    float spawnTimer = 0;
    public static int score = 0;
    public Text scoreDisplay;
    
    void Update()
    {
        scoreDisplay.text = score.ToString();

        if (spawnTimer <= 0)
        {
            int random = Random.Range(1, 4);
            string shape = "Prefabs/Shape" + random.ToString();
            GameObject prefab = Resources.Load<GameObject>(shape);
            Obstacle script = prefab.GetComponent<Obstacle>();

            int spawnLocation = Random.Range(1, 3);
            if (spawnLocation == 2)
            {
                script.direction = 2;
                Instantiate(prefab, new Vector2(9.5f, Random.Range(-3f, 2.8f)), transform.rotation);
            }
            else
            {
                script.direction = 1;
                Instantiate(prefab, new Vector2(-9.5f, Random.Range(-3f, 2.8f)), transform.rotation);
            }
            Debug.Log(spawnLocation);

            spawnTimer = 1.8f;
        }

        spawnTimer -= Time.deltaTime;
    }
}
