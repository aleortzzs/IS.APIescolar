//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace cetys.APIs.Escolar.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class maestro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public maestro()
        {
            this.maestroMateria = new HashSet<maestroMateria>();
        }
    
        public int numEmpleado { get; set; }
        public string nombre { get; set; }
        public string direcc { get; set; }
        public string lugarNacimiento { get; set; }
        public Nullable<System.DateTime> fechaNacimiento { get; set; }
        public Nullable<bool> estatus { get; set; }
        public string idCampus { get; set; }
    
        public virtual campus campus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<maestroMateria> maestroMateria { get; set; }
    }
}