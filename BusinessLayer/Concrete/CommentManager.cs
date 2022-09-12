using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            this._commentDal = commentDal;
        }

        public void Add(Comment t)
        {
            throw new NotImplementedException();
        }

        public void CommentAdd(Comment comment)
        {
            _commentDal.Insert(comment);
        }

        public void Delete(Comment t)
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetListAll(int id)
        {
            return _commentDal.GetListAll(x => x.BlogId == id);
        }

        public List<Comment> GetListAll()
        {
            return _commentDal.GetListAll();
        }

        public List<Comment> GetWithBlog()
        {
            return _commentDal.GetListWithBlog();
        }

        public void Update(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
