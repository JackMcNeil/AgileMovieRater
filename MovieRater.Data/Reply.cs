using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Data
{
    public class Reply
    {
        public int ReplyId { get; set; }
        public int CommentId { get; set; }
        public string Text { get; set; }
        public Guid AuthorId { get; set; }
    }
}
