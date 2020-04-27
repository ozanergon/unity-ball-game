using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDestroyer : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f); // Eğer atılan bomba boşa tarafa gidiyorsa 2 saniye sonra yok et
    }
}
