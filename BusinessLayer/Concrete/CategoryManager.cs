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
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categorydal;
        public CategoryManager(ICategoryDal categorydal)
        {
            _categorydal = categorydal;
        }

        public void Add(Category t)
        {
            _categorydal.Insert(t);
        }

      


    

        public void Delete(Category t)
        {
            _categorydal.Delete(t);
        }

        public Category GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetListAll()
        {
          return   _categorydal.GetListAll();
        }

        public void Update(Category t)
        {
            throw new NotImplementedException();
        }
    }
}
