using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class BobFlying : MonoBehaviour
{
    [SerializeField] private float hitPower; 
    private Rigidbody2D rb;
    [SerializeField] private GameObject SkipText;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
    public void BeanFly()
    {
        rb.velocity = new Vector2(hitPower * 0.5f, hitPower * 2);
        SkipText.SetActive(false);

    }
    
    public void EndStartScene()
    {
        SceneManager.LoadScene("Falling");
    }
}
