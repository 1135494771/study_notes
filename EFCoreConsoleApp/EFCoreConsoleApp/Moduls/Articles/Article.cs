using EFCoreConsoleApp.Moduls.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Moduls.Articles
{
    /// <summary>
    /// 文章类
    /// 一对多
    /// 一个文章对应多个评论内容
    /// </summary>
    public class Article
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        /// <summary>
        /// 关联实体类
        /// </summary>
        public List<Comment> comments { get; set; } = new List<Comment>();
    }
}
