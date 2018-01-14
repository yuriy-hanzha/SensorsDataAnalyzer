using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SensorsDataAnalyzer.Data
{
    public class BaseEntity
    {
        private DateTime _addedDate;

        [Key, Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual int Id { get; set; }

        protected BaseEntity()
        {
            AddedDate = DateTime.UtcNow;
        }

        [DisplayName("Creation Date")]
        [Required]
        public DateTime AddedDate
        {
            get { return DateTime.SpecifyKind(_addedDate, DateTimeKind.Utc); }
            private set { _addedDate = value; }
        }
    }
}
