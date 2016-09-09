using System;
using System.ComponentModel.DataAnnotations;

namespace SampleProject.Models
{
    /// <summary>
    /// This is a sample class representing some sample item
    /// </summary>
    public class SampleModel
    {
        #region Public Instance Properties
        /// <summary>
        /// Item identifies
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Item name
        /// </summary>
        [Required(ErrorMessage="Name is required")]
        public string Name { get; set; }
        /// <summary>
        /// Determines if SampleModel is active or not
        /// </summary>
        public bool IsActive { get; set; }
        /// <summary>
        /// SampleModel status
        /// </summary>
        public int RandomStatus { get; set; }
        /// <summary>
        /// Created date
        /// </summary>
        public DateTime CreateDate { get; set; }
        #endregion
    }
}
