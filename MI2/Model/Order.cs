//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MI2.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public int Id { get; set; }
        public int IdProduct { get; set; }
        public string Og { get; set; }
        public string Ot { get; set; }
        public string Ob { get; set; }
        public int IdUser { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
