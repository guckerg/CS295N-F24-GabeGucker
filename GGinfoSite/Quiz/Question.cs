namespace GGinfoSite.CafeQuiz
{
    public class Question
    {
        //provided question
        public string Q { get; set; }

        //correct asnwer to provided question
        public string A { get; set; }

        //user's asnwer to quiz question
        public string UserA { get; set; }

        //store if answer is correct
        public bool isRight {  get; set; }
    }
}
