﻿using Notes_Homework_11._1.Data;
using Notes_Homework_11._1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Notes_Homework_11._1.Controllers
{
    public class NoteController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoteController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            IEnumerable<Note> notes = _context.Notes;

            return View(notes); 
        }
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Add(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _context.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Note note)
        {
            if (ModelState.IsValid)
            {
                _context.Notes.Update(note);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(note);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var note = _context.Notes.Find(id);

            if (note == null)
            {
                return NotFound();
            }
            return View(note);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteNote(int? id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }
            _context.Notes.Remove(note);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
