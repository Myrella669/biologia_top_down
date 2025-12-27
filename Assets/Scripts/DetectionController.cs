using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionController : MonoBehaviour
{
    // Tag que o inimigo vai procurar (no caso, o "Player")
    public string _tagTargetDetection = "Player";

    // Lista de objetos que estão dentro da área de visão
    public List<Collider2D> _detectedObjs = new List<Collider2D>();

    // Quando alguém ENTRA na área
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _tagTargetDetection)
        {
            _detectedObjs.Add(collision);
        }
    }

    // Quando alguém SAI da área
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == _tagTargetDetection)
        {
            _detectedObjs.Remove(collision);
        }
    }
}