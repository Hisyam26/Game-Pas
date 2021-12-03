
<!-- class movement object player -->
public class Movement : MonoBehaviour
{   
<!-- deklarasi field yang diperlukan -->
    public float kecepatan;
    Rigidbody rb;
    Animator anim;
    public Transform playerRotate;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Bergerak();
    }
    void Bergerak()
    {
<!--   menggerakan player secara horizontal    -->
        float gerak = Input.GetAxis("Horizontal");
        rb.velocity = Vector3.right * gerak * kecepatan;
<!--        animasi player  -->
        anim.SetFloat("kecepatan", Mathf.Abs(gerak), 0.1f, Time.deltaTime);
        playerRotate.localEulerAngles = new Vector3(0, gerak * 90, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
<!--   kondisi jika player terkena objek virus maka akan di destroy seolah olah player mati  -->
        if (collision.collider.CompareTag("virus"))
        {
            Time.timeScale = 0;
            Destroy(gameObject);
        }
    }
}


<!-- class untuk memunculkan virus -->
public class MunculVirus : MonoBehaviour
{
    public GameObject virus;
    public float waktumin, waktumax;
    public float tempatmin, tempatmax;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MunculinVirus());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator MunculinVirus()
    {
<!--     instansiasi virus keluar secara random berdasarkan posisi tempat dan waktu -->
        Instantiate(virus, transform.position + Vector3.right * Random.Range(tempatmin, tempatmax)
            , Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(waktumin, waktumax));
        StartCoroutine(MunculinVirus());

    }
}
<!-- class restart jika posisi gamover -->
public class Restart : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
<!--    kondisi jika tekan "R" maka load scene -->
        if (Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
    }
}

<!-- class mengatur jumlah score -->
public class score : MonoBehaviour
{
    public float scores;
    public Text textUi;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
<!--     kondisi jika virus terkena collider maka point akan tambah 10 -->
        if (collision.collider.CompareTag("virus"))
        {
            scores = scores + 10;
<!--           menampilkan point yang di dapatkan ke dalam UI TEXT   -->
            textUi.text = "Score : " + scores.ToString();
            Destroy(collision.collider.gameObject);
        }
    }
}
