using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRDZSchool.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ITeacherRepository Teacher { get; }

        void Save();
    }
}
