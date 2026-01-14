using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyWebSite.Pages
{
    public class IndexModel : PageModel
    {
        // PRIVATE STATIC: Само един генератор за целия сайт, скрит отвън.
        private static Random rng = new Random();

        // PUBLIC PROPERTIES: Тези променливи ще се виждат в твоя HTML файл.
        public string Message { get; set; } = "";
        public int PlayerScore { get; set; } = 0;
        public bool GameActive { get; set; } = false;

        // PUBLIC METHOD: Методът за теглене, който поиска.
        public int DrawCard()
        {
            return rng.Next(2, 12);
        }

        // Извиква се, когато страницата се зареди за първи път.
        public void OnGet()
        {
            Message = "Добре дошли в Blackjack! Натиснете Старт.";
        }

        // Извиква се от бутон "Start" в HTML.
        public void OnPostStart()
        {
            PlayerScore = DrawCard() + DrawCard();
            Message = $"Играта започна! Твоят резултат: {PlayerScore}";
            GameActive = true;
        }

        // Извиква се от бутон "Hit" в HTML.
        public void OnPostHit(int currentScore)
        {
            PlayerScore = currentScore + DrawCard();
            
            if (PlayerScore > 21)
            {
                Message = $"Резултат: {PlayerScore}. Ти загуби (Bust)!";
                GameActive = false;
            }
            else if (PlayerScore == 21)
            {
                Message = "Blackjack! Ти печелиш!";
                GameActive = false;
            }
            else
            {
                Message = $"Твоят нов резултат е: {PlayerScore}";
                GameActive = true;
            }
        }
    }
}