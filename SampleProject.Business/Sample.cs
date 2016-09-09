using SampleProject.Business.Exceptions;
using SampleProject.Data.Repositories;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProject.Business
{
    /// <summary>
    /// This represents the business layer for the Sample Models
    /// </summary>
    public class Sample
    {
        private SampleRepository _sampleRepository;

        #region Constructors
        /// <summary>
        /// Default Constructor
        /// </summary>
        public Sample()
        {
            _sampleRepository = new SampleRepository();
        }
        #endregion

        #region Public Instance Methods
        /// <summary>
        /// Gets all the Sample Models
        /// </summary>
        /// <param name="includeInactives">determines if method retrieves inactive sample models</param>
        /// <returns></returns>
        public IEnumerable<SampleModel> GetAll(bool includeInactives = false)
        {
            return _sampleRepository.GetAll(includeInactives);
        }

        /// <summary>
        /// Gets sample model by id
        /// </summary>
        /// <param name="id">sample model id</param>
        /// <returns></returns>
        public SampleModel GetById(int id)
        {
            return _sampleRepository.GetById(id);
        }

        /// <summary>
        /// Saves a new sample into DB
        /// </summary>
        /// <param name="sample">Sample to insert</param>
        /// <returns></returns>
        public SampleModel Create(SampleModel sample)
        {
            if (sample == null)
            {
                throw new ArgumentNullException();
            }

            if (SampleNameIsUsed(sample.Id, sample.Name))
            {
                throw new SampleNameIsUsedException();
            }
                        
            return _sampleRepository.Create(sample);
        }

        /// <summary>
        /// Updates selected sample
        /// </summary>
        /// <param name="sampleModel">Sample to update</param>
        public SampleModel Update(SampleModel sample)
        {
            if (sample == null)
            {
                throw new ArgumentNullException();
            }

            if (SampleNameIsUsed(sample.Id, sample.Name))
            {
                throw new SampleNameIsUsedException();
            }

            return _sampleRepository.Update(sample);
        }

        /// <summary>
        /// Validates whether name is in use or not
        /// </summary>
        /// <param name="sampleName"></param>
        /// <returns></returns>
        private bool SampleNameIsUsed(int id, string sampleName)
        {
            return GetAll().Any(s => s.Name == sampleName && s.Id != id);
        }
        #endregion
    }
}
