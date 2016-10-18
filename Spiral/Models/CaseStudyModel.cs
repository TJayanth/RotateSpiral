using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Spiral.Models
{
    public class CaseStudyModel
    {
        #region Property Declaration
        /// <summary>
        /// Gets or sets the Input Array
        /// </summary>
        public int[][] inputArray { get; set; }

        /// <summary>
        /// Gets or sets the Output 1
        /// </summary>
        public int[][] outPut1 { get; set; }

        /// <summary>
        /// Gets or sets the Ourput 2
        /// </summary>
        public int[][] outPut2 { get; set; }
        
        /// <summary>
        /// Gets or sets the Generic Output after rotating rotationTimes
        /// </summary>
        public int[][] genericOutput { get; set; }

        /// <summary>
        /// Gets or sets the number of times the array is to be rotated
        /// </summary>
        [Display(Name="Number of Rotation")]
        [Required]
        public int rotationTimes { get; set; }
        #endregion
    }
}