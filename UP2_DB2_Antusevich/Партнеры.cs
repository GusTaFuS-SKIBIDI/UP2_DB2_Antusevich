//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace UP2_DB2_Antusevich
{
    using System;
    using System.Collections.Generic;
    
    public partial class Партнеры
    {
        public int ID_Партнера { get; set; }
        public string Название { get; set; }
        public string Контактное_Лицо { get; set; }
        public string Телефон { get; set; }
        public Nullable<int> ID_Производства { get; set; }
    
        public virtual Производство Производство { get; set; }
    }
}
