//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LabLINQ.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tanks
    {
        public Tanks()
        {
            this.Operations = new HashSet<Operations>();
        }
    
        public int TankID { get; set; }
        public string TankType { get; set; }
        public Nullable<float> TankVolume { get; set; }
        public Nullable<float> TankWeight { get; set; }
        public string TankMaterial { get; set; }
    
        public virtual ICollection<Operations> Operations { get; set; }
    }
}
