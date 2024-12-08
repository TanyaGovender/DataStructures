using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7321_POE
{
    public class Feedback
    {
        private int rating { get; set; }
        private string likes { get; set; }
        private string dislikes { get; set; }

        private string improvements { get; set; }

        public Feedback(int rating, string likes, string dislikes, string improvements)
        {
            rating = rating;
            this.likes = likes;
            this.dislikes = dislikes;
            this.improvements = improvements;
        }
    }
}
