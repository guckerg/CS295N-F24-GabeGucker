using GGinfoSite.CafeQuiz;

namespace CafeChroniclesTests
{
    public class QuizTests
    {
        Quiz quiz = new Quiz();
        public QuizTests()
        {
            Question q1 = new Question()
            {
                Q = "What is Gabe's favorite coffee?",
                A = "Angel Wing",
                UserA = "Angel Wing"
            };
            Question q2 = new Question()
            {
                Q = "What is Gabe's favorite coffee?",
                A = "Angel Wing",
                UserA = "Humbler"
            };
            quiz.Questions.Add(q1);
            quiz.Questions.Add(q2);
        }

        [Fact]
        public void checkCorrectAnswer()
        {
            //Arrange - Set up in constructor
            //Act - executed in assert
            //Assert
            Assert.True(quiz.checkAnswer(quiz.Questions[0]));
        }

        [Fact]
        public void checkWrongAnswer()
        {
            //Arrange - Set up in constructor
            //Act - executed in assert
            //Assert
            Assert.False(quiz.checkAnswer(quiz.Questions[1]));
        }

        [Fact]
        public void checkNumberQuestions()
        {
            //Arrange - Set up in constructor
            //Act - executed in assert
            //Assert
            Assert.Equal(2, quiz.Questions.Count());
        }
    }
}