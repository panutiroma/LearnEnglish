using Infrastructure;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain;
using LearnEnglish.Models.Dto;

namespace LearnEnglish.Controllers
{
    public class WordController : Controller
    {
        private readonly IWordRepository _wordRepository;

        public WordController()
        {
            _wordRepository = ServiceLocator.Get<IWordRepository>();
        }

        // GET: Word
        public ActionResult Index()
        {
            return View(_wordRepository.GetAll());
        }

        public ActionResult Add()
        {
            return View("Edit", new Word());
        }

        #region Edit

        public ActionResult Edit(long id)
        {
            return View(_wordRepository.Get(id));
        }

        [HttpPost]
        public ActionResult Edit(Word collecion, string generate)
        {
            if (!string.IsNullOrEmpty(generate))
            {
                ModelState.Clear();
                return View("Edit", collecion.EditWord(Models.Generator.Generate(collecion.Title)));
            }

            try
            {
                _wordRepository.Save(collecion);
            }
            catch (Exception)
            {
                //  PRELUCRAREA EXCEPTIEI !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //  mesaj in partea de sus
                return View();
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}