//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SpotifyRecordsApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Songs
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Songs()
        {
            this.Rankings = new HashSet<Rankings>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int AlbumId { get; set; }
    
        public virtual Albums Albums { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Rankings> Rankings { get; set; }
    }
}
