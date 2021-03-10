using System.Collections;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    public float dodge;
    public float smoothing;
    public float tilt;

    public float xMin;
    public float xMax;
    public float zMin;
    public float zMax;

    public Vector2 startWait;

    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    private float targetManeuver;
    private Rigidbody rb;
    private enemyMove enemyMove;

    private void Start()
    {
        enemyMove = GetComponent<enemyMove>();
        enemyMove.enabled = false;
        rb = GetComponent<Rigidbody>();

        StartCoroutine(Evade());
    }

    private IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));
        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    private void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);

        //Unityde normalde çalıştırdığınız fonksiyonlar bilgisayarın çalışma hızına endekslidir.deltaTime ile performanstan bağımsız olarak fonksiyon çalıştırabilirsiniz.Örneğin bir nesneyi ileriye hareket ettirecekseniz deltaTime kullanmadan hareket ettireceğiniz bu cisim yavaşlayıp hızlanacaktır çünkü ileri gitme komutu bilgisayarınız hızlı çalıştıkça hızlıca, yavaş çalıştıkça yavaşça verilecektir.
        //deltaTime ile sadece zamanı baz alarak çalıştıracağınız komutu aynı aralıklarla çalıştırırsınız.
        //Peki Nasıl Çalışır?
        //Bilgisayarınızın 10 frame aldığını düşünelim.time.deltaTime'ı okuyunca 1/10 = 0.1 döndürecektir.
        //Time.deltaTime'ı tekrar okuyunca çalışma hızı 5 frame'e düşerse time.deltaTime 0.2 döndürecektir.

        rb.velocity = new Vector2(newManeuver, 0.0f);

        rb.position = new Vector3(
            Mathf.Clamp(rb.position.x, xMin, xMax),
            0.0f,
            Mathf.Clamp(rb.position.z, zMin, zMax)
            );

        rb.rotation = Quaternion.Euler(
            0.0f,
            0.0f,
            rb.velocity.x * -tilt
        );
    }
}