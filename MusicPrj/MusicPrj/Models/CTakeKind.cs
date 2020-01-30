using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicPrj.Models
{
    public class CTakeKind
    {
        public IEnumerable<tProductKind> takeAllKind()
        {
            dbProjectMusicStoreEntities db = new dbProjectMusicStoreEntities();
            var result = db.tProductKinds.Select(p => p);
            return result;
        }
    }
}