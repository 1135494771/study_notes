using EFCoreConsoleApp.Moduls.Articles;
using EFCoreConsoleApp.Moduls.Comments;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleApp.Moduls.Comments
{
    //在一的那端关联多的那端配置
    public class CommentEntityConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("T_Comments");
            builder.HasKey(x => x.Id);
            //通过 HasOne 、 WithMany
            builder.HasOne<Article>(x=>x.TheArticle).WithMany(x=>x.comments).IsRequired();
        }
    }
}
