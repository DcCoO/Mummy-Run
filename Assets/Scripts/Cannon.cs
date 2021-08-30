using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float cooldown;
    [SerializeField] float timeToDestroy; 

    float time = 0;


    // Update is called once per frame
    void Update()
    {
        if(time > cooldown)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform);
            bullet.transform.position = transform.position;
            Destroy(bullet, timeToDestroy);
            time = 0;
        }
        time += Time.deltaTime;
    }
}
