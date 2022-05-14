using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("�z���S��")]
    public GameObject explosion;
    /// <summary>
    /// �z���}��
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        GameObject temp=Instantiate(explosion, transform.position, transform.rotation);
        Destroy(temp, .2f);
    }
}
