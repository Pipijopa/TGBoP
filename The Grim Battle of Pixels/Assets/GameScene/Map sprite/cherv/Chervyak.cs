using System.Collections;
using UnityEngine;

public class Chervyak : MonoBehaviour
{
	private Animator animator;

	private void Start()
	{
		animator = GetComponent<Animator>();
		StartCoroutine("WormMove");
	}


	IEnumerator WormMove()
	{
		while (true)
		{
			yield return new WaitForSeconds(2f);
			animator.SetBool("che", true);
			yield return new WaitForSeconds(0.1f);
			animator.SetBool("che", false);
			yield return new WaitForSeconds(12f);
		}
	}
}
//15 библиотек для 3 строчек кода