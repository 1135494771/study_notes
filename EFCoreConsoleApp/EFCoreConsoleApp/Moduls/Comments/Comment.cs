using EFCoreConsoleApp.Moduls.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Moduls.Comments
{
    /// <summary>
    /// 评论类
    /// 一对多
    /// 一个评论对应一个文章
    /// </summary>
    public class Comment
    {
        public long Id { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// 关联实体类
        /// </summary>
        public Article TheArticle { get; set; }
    }
}
