namespace GGinfoSite.CafeQuiz
{
    public class Quiz
    {
        private List<Question> _questions = new List<Question>();

        public Quiz()
        {
            _questions.Add(new Question()
            {
                Q = "What country is the largest producer of coffee in the world?",
                A = "Brazil"
            });

            _questions.Add(new Question()
            {
                Q = "What is the term for coffee brewed by forcing hot water through finely-ground coffee beans?",
                A = "Espresso"
            });

            _questions.Add(new Question()
            {
                Q = "Which popular coffee chain originated in Seattle, Washington in 1971?",
                A = "Starbucks"
            });

            _questions.Add(new Question()
            {
                Q = "What is the name of the method of brewing coffee by allowing " +
                "coarse grounds to steep in cold water for an extended period?",
                A = "Cold Brew"
            });

            _questions.Add(new Question()
            {
                Q = "What does the Italian term “macchiato” mean in English?",
                A = "Stained"
            });

            _questions.Add(new Question()
            {
                Q = "What is the term for coffee beans that have been roasted to a dark brown " +
                "or almost black color, often with an oily surface?",
                A = "French Roast"
            });

            _questions.Add(new Question()
            {
                Q = "What country invented the flat white?",
                A = "Australia"
            });

            _questions.Add(new Question()
            {
                Q = "What is a single shot of espresso called?",
                A = "Solo"
            });
        }

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
