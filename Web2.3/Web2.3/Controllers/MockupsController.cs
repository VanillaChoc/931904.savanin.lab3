using Microsoft.AspNetCore.Mvc;
using Web2._3.Models;

namespace Web2._3.Controllers
{
    public class MockupsController : Controller
    {
        private static Quiz quiz = new();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quiz(int? Answer, string Action)
        {
            if (Answer != null)
            {
                quiz.AddAnswer((int)Answer);
            }

            if (Action == "Finish")
            {
                return RedirectToAction("QuizResult");
            }
            else if (Action != "Next")
            {
                quiz.Clear();
            }

            Question question = quiz.CreateNewQuestion();

            ViewData["Left"] = question.Left;
            ViewData["Right"] = question.Right;
            ViewData["Operation"] = Models.Quiz.OperationToString(question.Operation);

            return View();
        }
        public IActionResult QuizResult()
        {
            if (quiz.IsValid())
            {
                ViewData["QuizValid"] = true;

                ViewData["Questions"] = quiz.Questions;
                ViewData["Answers"] = quiz.UserAnswers;
                ViewData["CorrectAmount"] = quiz.GetCorrectAnswersAmount();
                ViewData["QuestionAmount"] = quiz.QuestionCounter;
            }
            else
            {
                ViewData["QuizValid"] = false;
            }

            return View();
        }
    }
}