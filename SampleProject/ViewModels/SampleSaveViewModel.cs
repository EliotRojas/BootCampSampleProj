using SampleProject.Models;
using SampleProject.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SampleProject.ViewModels
{
    /// <summary>
    /// Represents all the necessary info to save a SampleModel
    /// </summary>
    public class SampleSaveViewModel
    {
        #region Public Instance Properties
        /// <summary>
        /// Determines form status
        /// </summary>
        public bool IsCreateForm { get; set; }
        /// <summary>
        /// Sample to save
        /// </summary>
        public SampleModel Sample { get; set; }
        /// <summary>
        /// Status list
        /// </summary>
        public IList<SelectListItem> StatusList { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor
        /// </summary>
        public SampleSaveViewModel()
        {
            Sample = new SampleModel();
            SetStatusList();
        }

        /// <summary>
        /// Constructor with sample object
        /// </summary>
        /// <param name="sample"></param>
        public SampleSaveViewModel(SampleModel sample) : this()
        {
            Sample = sample;
        }
        #endregion

        #region Private Instance Methods
        /// <summary>
        /// Sets status list
        /// </summary>
        private void SetStatusList()
        {
            StatusList = new List<SelectListItem>();
            var statusValues = Enum.GetValues(typeof(SampleStatus)).Cast<object>();
            statusValues.ToList().ForEach(status => StatusList.Add(new SelectListItem { Text = status.ToString(), Value = ((int)status).ToString() }));
        }
        #endregion
    }
}