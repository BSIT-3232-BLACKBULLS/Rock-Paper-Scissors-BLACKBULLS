using Microsoft.AspNetCore.Mvc;

namespace RockPaperScissors.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Play(string playerChoice)
        {
            string computerChoice = GetComputerChoice();
            string result = GetGameResult(playerChoice, computerChoice);
            return Content(result);
        }

        private string GetComputerChoice()
        {
            string[] choices = { "rock", "paper", "scissors" };
            return choices[new System.Random().Next(choices.Length)];
        }

        private string GetGameResult(string playerChoice, string computerChoice)
        {
            if (playerChoice == computerChoice)
                return "It's a tie!";
            else if ((playerChoice == "rock" && computerChoice == "scissors") ||
                     (playerChoice == "paper" && computerChoice == "rock") ||
                     (playerChoice == "scissors" && computerChoice == "paper"))
                return "You win!";
            else
                return "Computer wins!";
        }
    }
}
