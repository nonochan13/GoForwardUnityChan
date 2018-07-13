using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -0.2f;

    // 消滅位置
    private float deadLine = -10;

    // AudioSorceを格納する変数の宣言
    private AudioSource audioSource;

    // Use this for initialization
    void Start()
    {
        // AudioSorceコンポーネントを追加し、変数に代入.
        audioSource = GetComponent<AudioSource>();
        // 鳴らす音(変数)を格納.
        //audioSource.clip = sound;
        // 音のループなし。
        //audioSource.loop = false;
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        // 音を鳴らす.

        if (col.collider.tag == "Cube" || col.collider.tag == "Ground")
        {
            audioSource.PlayOneShot(audioSource.clip);
        }
    }
}