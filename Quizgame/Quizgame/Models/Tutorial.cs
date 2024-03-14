using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Quizgame.Models
{
    public class Tutorial
    {
        public int ArticleId { get; set; }
        public string? Language { get; set; }
        public string? Title { get; set; }
        [AllowHtml]
        [DataType(DataType.Text)]
        public string? Article { get; set; }
 
    }
}

     