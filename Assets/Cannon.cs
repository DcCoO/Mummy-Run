using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] bool isRight;
    [SerializeField] GameObject bulletPrefab;

    float time = 0;
    float cooldown = 3;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > cooldown)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.transform.position = transform.position;
            bullet.GetComponent<Bullet>().SetDirection(isRight);
            time = 0;
        }
        time += Time.deltaTime;
    }
}
