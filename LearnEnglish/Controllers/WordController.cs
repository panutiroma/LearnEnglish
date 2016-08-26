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
        public ActionResult Edit(Word collecion)
        {
            try
            {
                _wordRepository.Save(collecion);
            }
            catch (Exception)
            {
                //  PRELUCRAREA EXCEPTIEI !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                return View();
            }
            return RedirectToAction("Index");
        }
        #endregion

        #region Generator

        public ActionResult Generator(string word)
        {
            if (string.IsNullOrEmpty(word))
                return View();
            
            return View("Edit", Models.Generator.Generate("word"));
        }

        #endregion
    }
}