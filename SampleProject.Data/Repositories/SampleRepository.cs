using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleProject.Data.Repositories
{
    /// <summary>
    /// Represents data layer for the Sample Models
    /// </summary>
    public class SampleRepository
    {
        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public SampleRepository() { }
        #endregion

        #region Public Instance Methods
        /// <summary>
        /// Retrieves all the Sample Models
        /// </summary>
        /// <param name="includeInactives">filters for inactives</param>
        /// <returns></returns>
        public IEnumerable<SampleModel> GetAll(bool includeInactives = false)
        {
            return SomePrivateMethodMockingDBCall();
        }
        /// <summary>
        /// Gets a single Sample Model
        /// </summary>
        /// <param name="id">Sample model id</param>
        /// <returns></returns>
        public SampleModel GetById(int id)
        {
            return GetAll().FirstOrDefault(sample => sample.Id == id);
        }
        /// <summary>
        /// Inserts new sample into the DB
        /// Right now we'll mock the autoincremented id
        /// </summary>
        /// <param name="sample">sample to insert</param>
        /// <returns></returns>
        public SampleModel Create(SampleModel sample)
        {
            sample.Id = GetAll().Count() + 1;
            return sample;
        }
        #endregion

        #region Private Instance Methods
        /// <summary>
        /// Method mocking db call to retrieve SampleModels
        /// </summary>
        /// <returns></returns>
        private List<SampleModel> SomePrivateMethodMockingDBCall()
        {
            return new List<SampleModel> {
                new SampleModel { Id = 1,  Name = "Sample 1", CreateDate = DateTime.Today, IsActive = true, RandomStatus = 0 },
                new SampleModel { Id = 2,  Name = "Sample 2", CreateDate = DateTime.Today, IsActive = true, RandomStatus = 1 },
                new SampleModel { Id = 3,  Name = "Sample 3", CreateDate = DateTime.Today, IsActive = false, RandomStatus = 0 },
                new SampleModel { Id = 4,  Name = "Sample 4", CreateDate = DateTime.Today, IsActive = true, RandomStatus = 1 },
                new SampleModel { Id = 5,  Name = "Sample 5", CreateDate = DateTime.Today, IsActive = false, RandomStatus = 2 }
            };
        }
        #endregion

        public SampleModel Update(SampleModel sample)
        {
            throw new NotImplementedException();
        }
    }
}
