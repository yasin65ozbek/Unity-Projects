using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public float bulletDamage, lifeTime;//hasarGücü, ne kadar sonra yok olsun
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime); //3 saniye sonra kurşun yok olsun
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
