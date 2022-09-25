using System;
using System.Collections.Generic;

namespace learn_migration.Infrastructure.DataModels
{
    public partial class TbGenero
    {
        public TbGenero()
        {
            TbInscritos = new HashSet<TbInscrito>();
        }

        public int Id { get; set; }
        public char Genero { get; set; }

        public virtual ICollection<TbInscrito> TbInscritos { get; set; }
    }
}
