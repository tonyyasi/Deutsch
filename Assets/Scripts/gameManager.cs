using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour {

	public static int score = 0;

	public BierQuestions[] questions;
	private static List<BierQuestions> unansweredQuestions;
	private BierQuestions currentQuestion;

	[SerializeField]
	private Text questionText; 

	[SerializeField]
	private float delay = 1f;

	[SerializeField]
	private Text qA;

	[SerializeField]
	private Text qB;

	[SerializeField]
	private Text qC;

	[SerializeField]
	private Text qD;

	[SerializeField]
	private Text animationText;

	[SerializeField]
	private Animator animator;

	void Start(){
		if (unansweredQuestions == null || unansweredQuestions.Count == 0) {
			unansweredQuestions = questions.ToList<BierQuestions>();
		}

		GetRandomQuestion ();
	}

	void GetRandomQuestion(){
	
		int index = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [index];
		questionText.text = currentQuestion.question; 
		qA.text = currentQuestion.possibleAnswers [0];
		qB.text = currentQuestion.possibleAnswers [1];
		qC.text = currentQuestion.possibleAnswers [2];
		qD.text = currentQuestion.possibleAnswers [3];
	 }

	IEnumerator nextQuestion(){

		unansweredQuestions.Remove (currentQuestion);
		yield return new WaitForSeconds (delay);
		if (unansweredQuestions.Count == 0) {
			yield return new WaitForSeconds (delay);
			animationText.text = score + " out of 3 ";
			animator.SetTrigger ("ans");
		} else {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

	}

	public void userSelectA(){
	
		animator.SetTrigger ("ans");
		if (currentQuestion.answer == currentQuestion.possibleAnswers [0]) {
			Debug.Log ("Correct");
			score++;
			animationText.text = "Richtig";
		} else {
			Debug.Log ("Incorrect");
			animationText.text = "Falsch"; 
		}
		StartCoroutine (nextQuestion ());
	}



	public void userSelectB(){
		animator.SetTrigger ("ans");
		if (currentQuestion.answer == currentQuestion.possibleAnswers [1]) {
			Debug.Log ("Correct");
			score++;
			animationText.text = "Richtig";
		} else {
			Debug.Log ("Incorrect");
			animationText.text = "Falsch";
		}
		StartCoroutine (nextQuestion ());
	}

	public void userSelectC(){
		animator.SetTrigger ("ans");
		if (currentQuestion.answer == currentQuestion.possibleAnswers [2]) {
			Debug.Log ("Correct");
			score++;
			animationText.text = "Richtig";
		} else {
			Debug.Log ("Incorrect");
			animationText.text = "Falsch";
		}
		StartCoroutine (nextQuestion ());
	}

	public void userSelectD(){
		animator.SetTrigger ("ans");
		if (currentQuestion.answer == currentQuestion.possibleAnswers [3]) {
			Debug.Log ("Correct");
			score++;
			animationText.text = "Richtig";
		} else {
			Debug.Log ("Incorrect");
			animationText.text = "Falsch";
		}
		StartCoroutine (nextQuestion ());
	}
}
