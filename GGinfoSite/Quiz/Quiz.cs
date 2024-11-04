namespace GGinfoSite.Quiz
{
    public class Quiz
    {
        private List<Question> _questions = new List<Question>();
        public List<Question> Questions
        {
            get { return _questions; }
        } 

        public bool checkAnswer(Question q)
        {
            return q.UserA == q.A;
        }
    }
}
