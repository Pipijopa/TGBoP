using System.Collections;
using UnityEngine;

public class Bat : MonoBehaviour
{
	private Animator animator;

    private void Start()
    {
		animator = GetComponent<Animator>();
		StartCoroutine(BatFly());
	}


    IEnumerator BatFly()
	{
		while (true)
		{
			yield return new WaitForSeconds(3f);
			animator.SetBool("fly", true);
			yield return new WaitForSeconds(0.1f);
			animator.SetBool("fly", false);
			yield return new WaitForSeconds(10f);
		}
	}
}
