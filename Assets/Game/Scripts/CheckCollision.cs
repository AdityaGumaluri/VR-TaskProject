using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public struct AddCollisionChecks
{
    public string tagName;
    public UnityEvent OnGotHit;
}

public class CheckCollision : MonoBehaviour
{
    public AddCollisionChecks[] collisionChecks;

    private void OnCollisionEnter(Collision collision)
    {
        foreach(var item in collisionChecks)
        {
            if (collision.gameObject.CompareTag(item.tagName))
            {
                item.OnGotHit?.Invoke();
                print($"Got hit by{collision.gameObject.name}");
            }
        }
    }
}
