using SampleProject.Business;
using SampleProject.Business.Exceptions;
using SampleProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SampleProject.Controllers
{
    /// <summary>
    /// Sample controller
    /// </summary>
    public class SampleController : Controller
    {
        #region Private Instance Properties
        private Sample _sampleBusiness;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SampleController()
        {
            _sampleBusiness = new Sample();
        }
        #endregion

        #region Public Action Results Methods
        /// <summary>
        /// Lists all the Samples
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var model = _sampleBusiness.GetAll();
            return View(model);
        }

        /// <summary>
        /// Shows Sample details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Details(int id)
        {
            var model = _sampleBusiness.GetById(id);
            return View(model);
        }

        /// <summary>
        /// View to create a new Sample
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var model = new SampleSaveViewModel();
            return View(model);
        }

        /// <summary>
        /// Edits a sample
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            var sampleToEdit = _sampleBusiness.GetById(id);
            var model = new SampleSaveViewModel(sampleToEdit);

            return View(model);
        }

        /// <summary>
        /// Saves a sample into database
        /// </summary>
        /// <param name="model">sample data</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Save(SampleSaveViewModel model)
        {
            var returnView = model.IsCreateForm ? "Create" : "Edit";

            try
            {
                if (ModelState.IsValid)
                {
                    if (model.IsCreateForm)
                    {
                        _sampleBusiness.Create(model.Sample);
                    }
                    else
                    {
                        _sampleBusiness.Update(model.Sample);
                    }
                }
                else
                {
                    return View(returnView, model);
                }
            }
            catch (SampleNameIsUsedException)
            {
                ModelState.AddModelError(string.Empty, "This name is already in use, please enter a different one");
                return View(returnView, model);
            }
            catch (ArgumentNullException)
            {
                ModelState.AddModelError(string.Empty, "There is no data to save");
                return View(returnView, model);
            }

            return RedirectToAction("Index");
            //Note: there is something to improve
        }
        #endregion
    }
}
