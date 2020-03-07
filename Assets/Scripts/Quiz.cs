using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine;

public class Quiz : MonoBehaviour
{
    private string topic = "1"; // TODO: PlayerPrefs.GetString("topic"); 
    private int score = 0;

    void Start()
    {
        Menu m = Menu.Game;
        IController.Instance.ShowMenu(m);
        CreateQuestions();
    }


    #region Game
    // Widgets
    public Text question_text;
    public Text answer_text;
    public Text score_text;

    // For count answer
    private int q_id = 0;
    public int _question_count = 10;

    // Parse json
    private string answer = "";
    private string question = "";

    public void CreateQuestions()
    {
        // Get and parse answer
        DataQuestions data = new DataQuestions();
        var q = data.GetQuestions(topic, GetId());
        question = q["question"].ToString();
        answer = q["answer"].ToString();

        //Count answer id
        q_id++;

        // IElements
        question_text.text = question;
        continue_button.SetActive(false);
        answer_text.text = "";
    }

    private int GetId()
    {
        // Random array int
        var nums = Enumerable.Range(1, _question_count).ToList();
        int[] result = new int[_question_count];
        System.Random rand = new System.Random();
        for (int i = 0; i < _question_count; i++)
        {
            int pos = rand.Next(0, nums.Count);
            result[i] = nums[pos];
            nums.RemoveAt(pos);
        }
        if (q_id >= _question_count - 1) End();
        return result[q_id];
    }

    public void Answer(bool answ)
    {
        // IElements
        answer_text.text = answer;
        continue_button.SetActive(true);

        //Check answer
        if (answer.Equals(answ.ToString()))
        {
            score++;
            score_text.text = score.ToString();
        }
    }
    #endregion


    #region End
    public Text result_text;
    public GameObject continue_button;

    private void End()
    {
        // IElements
        Menu m = Menu.End;
        IController.Instance.ShowMenu(m);
        result_text.text = "Your result: " + score;
    }

    public void Retry()
    {
        // IElements
        Menu m = Menu.Game;
        IController.Instance.ShowMenu(m);
        score_text.text = "0";

        //Zeroing variables
        q_id = 0;
        score = 0;

        CreateQuestions();
    }
    #endregion





}
