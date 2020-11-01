using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleScript : MonoBehaviour
{
    public string thisCollectibleIs;
    public Animator anim;

    private void OnEnable()
    {
        anim = this.GetComponent<Animator>();
    }

    public void EnablePoof()
    {
        anim.SetTrigger("isDestroyed");
    }

    public void DestroyObject()
    {
       Destroy(this.gameObject);
    }

}
