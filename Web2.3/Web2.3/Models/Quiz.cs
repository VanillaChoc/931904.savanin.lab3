namespace Web2._3.Models
{
    public enum OperationType
    {
        Add, Sub, Mult, Div
    }

    public class Quiz
    {
        public List<Question> Questions = new();
        public List<int> UserAnswers = new();
        public int QuestionCounter;

        public Question CreateNewQuestion()
        {
            Question question = new Question();

            Questions.Add(question);
            Inc();

            return question;
        }

        public void AddAnswer(int answer)
        {
            UserAnswers.Add(answer);
        }

        public static string OperationToString(OperationType op)
        {
            return op switch
            {
                OperationType.Add => "+",
                OperationType.Sub => "-",
                OperationType.Mult => "*",
                OperationType.Div => "/",
                _ => "ERROR",
            };
        }

        public void Inc() => QuestionCounter++;

        public void Clear()
        {
            Questions.Clear();
            UserAnswers.Clear();
            QuestionCounter = 0;
        }

        public int GetCorrectAnswersAmount()
        {
            int counter = 0;
            for (int i = 0; i < QuestionCounter; i++)
            {
                if (Questions[i].Answer == UserAnswers[i]) counter++;
            }
            return counter;
        }

        public bool IsValid() => Questions.Count == UserAnswers.Count;
    }

    public class Question
    {
        public int Left;
        public int Right;
        public OperationType Operation;
        public int Answer;

        public Question()
        {
            Random random = new();
            Left = random.Next(0, 10);
            Right = random.Next(1, 10);
            Operation = (OperationType)random.Next(0, 4);

            calcAnswer();
        }

        private void calcAnswer()
        {
            switch (Operation)
            {
                case OperationType.Add:
                    Answer = Left + Right;
                    break;
                case OperationType.Sub:
                    Answer = Left - Right;
                    break;
                case OperationType.Mult:
                    Answer = Left * Right;
                    break;
                case OperationType.Div:
                    Answer = Left / Right;
                    break;
            }
        }

        public bool CheckAnswer(int num) => num == Answer;
    }
}
