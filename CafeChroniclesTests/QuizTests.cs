using GGinfoSite.CafeQuiz;

namespace CafeChroniclesTests
{
    public class QuizTests
    {
        Quiz _testQuiz = new Quiz();

        [Fact]
        public void CheckCorrectAnswer()
        {
            //Arrange - Set up in constructor
            Question q1 = new Question()
            {
                Q = "What is Gabe's favorite espresso roast?",
                A = "Angel Wing",
                UserA = "Angel Wing"
            };
            _testQuiz.Questions.Add(q1);

            // Act
            bool isCorrect = _testQuiz.CheckAnswer(_testQuiz.Questions.Last());

            //Assert
            Assert.True(isCorrect);
        }

        [Fact]
        public void CheckWrongAnswer()
        {
            //Arrange
            Question q2 = new Question()
            {
                Q = "What is Gabe's favorite espresso roast?",
                A = "Angel Wing",
                UserA = "Ghost Rider"
            };
            _testQuiz.Questions.Add(q2);

            // Act
            bool isCorrect = _testQuiz.CheckAnswer(_testQuiz.Questions.Last());

            //Assert
            Assert.False(isCorrect);
        }

        [Fact]
        public void CheckNumberQuestions()
        {
            //Counts number of questions initialized in Quiz.cs, not testing exclusive questions
            Assert.Equal(8, _testQuiz.Questions.Count());
        }
    }
}