using DataAccessLayer.Abstract;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EfMessageRepository : GenericRepository<Message>, IMessageDal
    {
        public List<Message> GetListWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Messages.Include(x => x.Sender).Where(x => x.ReceiverId == id).ToList();
            }
        }
    }
}
