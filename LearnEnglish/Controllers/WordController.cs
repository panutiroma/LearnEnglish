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
            var title = collecion.Title;
            collecion.Title = char.ToUpper(title[0]) + title.Substring(1);
            if (!string.IsNullOrEmpty(generate))
            {
                ModelState.Clear();
                return View("Edit", collecion.EditWord(Models.Generator.Generate(collecion.Title)));
            }

            try
            {
                _wordRepository.Save(collecion);
                TempData["succes_message"] = string.Format($"Word \"{collecion.Title}\" has been saved");
            }
            catch (Exception e)
            {
                //  PRELUCRAREA EXCEPTIEI !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                //  mesaj in partea de sus
                TempData["error_message"] = string.Format(e.Message);
                return View();
            }

            return RedirectToAction("Index");
        }

        #endregion

        #region Delete

        public ActionResult Delete(long id)
        {
            Word w = _wordRepository.Get(id);
            return View(w);
        }

        [HttpPost]
        public ActionResult Delete(Word w)
        {
            try
            {
                _wordRepository.Delete(w);
                TempData["succes_message"] = string.Format($"Word \"{w.Title}\" has been deleted");
            }
            catch (Exception e)
            {
                TempData["error_message"] = string.Format($"Error! Word \"{w.Title}\" has not been deleted.\n\r{e.Message}");
                return View(w);
            }

            return RedirectToAction("Index");
        }

        #endregion
    }
}