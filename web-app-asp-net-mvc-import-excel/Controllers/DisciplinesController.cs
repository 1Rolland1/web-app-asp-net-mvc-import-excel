﻿using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using web_app_asp_net_mvc_import_excel.Models;

namespace web_app_asp_net_mvc_import_excel.Controllers
{
    public class DisciplinesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new TimetableContext();
            var disciplines = db.Disciplines.ToList();

            return View(disciplines);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var discipline = new Discipline();
            return View(discipline);
        }

        [HttpPost]
        public ActionResult Create(Discipline model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var db = new TimetableContext();
            if (!ModelState.IsValid)
                return View(model);
            db.Disciplines.Add(model);
            db.SaveChanges();

            return RedirectPermanent("/Disciplines/Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var db = new TimetableContext();
            var discipline = db.Disciplines.FirstOrDefault(x => x.Id == id);
            if (discipline == null)
                return RedirectPermanent("/Disciplines/Index");

            db.Disciplines.Remove(discipline);
            db.SaveChanges();

            return RedirectPermanent("/Disciplines/Index");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var db = new TimetableContext();
            var discipline = db.Disciplines.FirstOrDefault(x => x.Id == id);
            if (discipline == null)
                return RedirectPermanent("/Disciplines/Index");

            return View(discipline);
        }

        [HttpPost]
        public ActionResult Edit(Discipline model)
        {
            var db = new TimetableContext();
            var discipline = db.Disciplines.FirstOrDefault(x => x.Id == model.Id);
            if (discipline == null)
                ModelState.AddModelError("Id", "Дисциплина не найдена");
            if (!ModelState.IsValid)
                return View(model);

            MappingDiscipline(model, discipline, db);

            db.Entry(discipline).State = EntityState.Modified;
            db.SaveChanges();

            return RedirectPermanent("/Disciplines/Index");
        }

        private void MappingDiscipline(Discipline sourse, Discipline destination, TimetableContext db)
        {
            destination.Name = sourse.Name;
            destination.DisciplineGoal = sourse.DisciplineGoal;
            destination.DisciplineObjectives = sourse.DisciplineObjectives;
            destination.MainSections = sourse.MainSections;
        }

    }
}