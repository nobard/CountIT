using UnityEngine;

public class Crack : MonoBehaviour
{
    public int CountToBreak;

    void OnMouseDown()
    {
        CountToBreak--;
        if(CountToBreak < 1)
        {
            Destroy(gameObject);
        }
    }
}