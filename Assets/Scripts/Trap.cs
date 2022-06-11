using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("�nĲ�o���ɤl")]
    public ParticleSystem ps;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "���a")
        {
            ps.Play();
            collision.GetComponent<Player>().Dead("����");
        }
    }
}
