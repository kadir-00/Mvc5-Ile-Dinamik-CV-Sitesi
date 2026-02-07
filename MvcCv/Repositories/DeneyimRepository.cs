using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcCv.Repositories
{
    public class DeneyimRepository : GenericReporsitory<TblDeneyimlerim>
    {
        DbCvEntities db = new DbCvEntities();

    }
}