using MustafinaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MustafinaWeb.Controllers
{
    public class HomeController : Controller
    {
        private NotesDBEntities db = new NotesDBEntities();

        [Authorize]
        public ActionResult Index()
        {           
            var userId = User.Identity.Name;
            var notes = (from note in db.Notes
                         where note.UserId == userId
                         select note).ToList();
            return View(notes);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                if (db.Notes.Any())
                    id = (from note in db.Notes
                          where note.UserId == User.Identity.Name
                          select note.NoteId).First();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var noteDetails = (from note in db.Notes
                                where note.NoteId == id
                                select note).First();
            return View(noteDetails);
        }
                
        public ActionResult Create()
        {
            Note note = new Note();
            return View(note);
        }


        [HttpPost]
        public ActionResult Create(Note note)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    note.UserId = User.Identity.Name;
                    note.Date = DateTime.Now;
                    db.Notes.Add(note);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("Была обнаружена следующая ошибка:\n", ex);
            }
            return View(note);
        }
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                if (db.Notes.Any())
                    id = (from note in db.Notes
                          where note.UserId == User.Identity.Name
                          select note.NoteId).First();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);               
            }
            var noteEdit = (from note in db.Notes
                                where note.NoteId == id
                                select note).First();
            return View(noteEdit);
        }
        
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var noteEdit = (from note in db.Notes
                             where note.NoteId == id
                             select note).First();
            try
            {
                UpdateModel(noteEdit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(noteEdit);
            }
        }
        
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                if (db.Notes.Any())
                    id = (from note in db.Notes
                          where note.UserId == User.Identity.Name
                          select note.NoteId).First();
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var noteDelete = (from note in db.Notes
                            where note.NoteId == id
                            select note).First();
            return View(noteDelete);
        }

        [HttpPost]
        public ActionResult Delete(int? id, FormCollection collection)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var noteDelete = (from note in db.Notes
                              where note.NoteId == id
                              select note).First();
            try
            {
                db.Notes.Remove(noteDelete);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(noteDelete);
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Это сайт для работы с заметками";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контактная информация";

            return View();
        }
    }
}