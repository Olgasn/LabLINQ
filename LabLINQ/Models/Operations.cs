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
    
    public partial class Operations
    {
        public int OperationID { get; set; }
        public Nullable<int> FuelID { get; set; }
        public Nullable<int> TankID { get; set; }
        public Nullable<float> Inc_Exp { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    
        public virtual Fuels Fuels { get; set; }
        public virtual Tanks Tanks { get; set; }
    }
}
