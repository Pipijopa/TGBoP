using System.Collections;
using UnityEngine;

public class bab : MonoBehaviour
{
	private Animator animatorButterfly;

	private void Start()
	{
		animatorButterfly = GetComponent<Animator>();
		StartCoroutine("ButterflyFly");
	}


	IEnumerator ButterflyFly()
	{
		while (true)
		{
			animatorButterfly.SetBool("Bab", true);
			yield return new WaitForSeconds(0.1f);
			animatorButterfly.SetBool("Bab", false);
			yield return new WaitForSeconds(10f);
		}
	}
}
