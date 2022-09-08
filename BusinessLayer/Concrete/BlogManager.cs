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
    public class BlogManager : IBlogService
    {
        IBlogDal _blogdal;

        public BlogManager(IBlogDal blogdal)
        {
            _blogdal = blogdal;
        }

        public void Add(Blog blog)
        {
            _blogdal.Insert(blog);
        }

        public void Delete(Blog blog)
        {
            _blogdal.Delete(blog);
        }

        public Blog GetById(int id)
        {
            return _blogdal.GetById(id);
        }

        public List<Blog> GetListAll()
        {
           return  _blogdal.GetListAll();
        }
        public List<Blog> GetLast3Blog()
        {
            return _blogdal.GetListAll().Take(3).ToList();
        }
        public List<Blog> GetBlogById(int id)
        {
            return _blogdal.GetListAll(x => x.BlogId == id);
        }

        public List<Blog> GetWithCategory()
        {
           return _blogdal.GetListWithCategory();
        }

        public void Update(Blog blog)
        {
            _blogdal.Update(blog);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogdal.GetListAll(x => x.WriterId == id);
        }
        public List<Blog> GetListWriterCategory(int id)
        {
            return _blogdal.GetListWithCategoryByWriter(id);
        }
    }
}
