using Newtonsoft.Json.Linq;
using UnityEngine;

public class DataQuestions : MonoBehaviour
{

    private static DataQuestions _instance;
    public static DataQuestions Instance
    {
        get
        {
            if (_instance == null)
                _instance = FindObjectOfType<DataQuestions>();
            return _instance;
        }
    }

    private string _questions = @"{
        '1' : [
            { 'question' : '0', 'answer' : 'True' },
            { 'question' : '1', 'answer' : 'False' },
            { 'question' : '2', 'answer' : 'True' },
            { 'question' : '3', 'answer' : 'False' },
            { 'question' : '4', 'answer' : 'True' },
            { 'question' : '5', 'answer' : 'False' },
            { 'question' : '6', 'answer' : 'True' },
            { 'question' : '7', 'answer' : 'False' },
            { 'question' : '8', 'answer' : 'True' },
            { 'question' : '9', 'answer' : 'False' },
            { 'question' : '10', 'answer' : 'True' },
            { 'question' : '11', 'answer' : 'False' },
            { 'question' : '12', 'answer' : 'True' },
            { 'question' : '13', 'answer' : 'False' },
            { 'question' : '14', 'answer' : 'True' },
            { 'question' : '15', 'answer' : 'False' },
            { 'question' : '16', 'answer' : 'True' },
            { 'question' : '17', 'answer' : 'False' },
            { 'question' : '18', 'answer' : 'True' },
            { 'question' : '19', 'answer' : 'False' },
            { 'question' : '20', 'answer' : 'True' },
            { 'question' : '21', 'answer' : 'False' },
            { 'question' : '22', 'answer' : 'True' },
            { 'question' : '23', 'answer' : 'False' },
        ]
    }";

    public JToken GetQuestions(string topic, int id)
    {
        var array = JObject.Parse(_questions).SelectToken(topic);
        var q = array[id];
        return q;
    }

}
