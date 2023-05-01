using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Domian.Repository;

namespace Shop.Domain.CommentAgg
{
    public interface ICommentRepository : IBaseRepository<Comment>
    {
        Task DeleteAndSave(Comment comment);
    }
}