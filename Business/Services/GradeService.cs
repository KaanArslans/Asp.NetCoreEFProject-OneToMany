using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Business.Models;
using DataAccess.Contexts;

namespace Business.Services
{
   
      


        public interface IGradeService
        {
            IQueryable<Business.Models.Grade> Query();
        }

        public class GradeService : IGradeService
        {
            private readonly Db _db;

            public GradeService(Db db)
            {
                _db = db;
            }

            public IQueryable<Business.Models.Grade> Query()
            {
                return _db.Grades.Select(a => new Business.Models.Grade()
                {
                    Id = a.Id,
                    Year = a.Year
                });
            }
        }
    }




