using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MusicalInstrument.Entities;

namespace MusicalInstrument.Controllers
{
    [Authorize]
    public class MusicController : Controller
    {
        // GET: Music Instrument
        public ActionResult Index()
        {
            List<Music_Instrument> m;
            using (var r = new MusicEntities())
            {
                m = r.Music_Instruments.ToList();
            }
            return View(m);
            // return View();
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post()
        {
            var musicmodel = new Music_Instrument();
            TryUpdateModel(musicmodel);

            using (var r = new MusicEntities())
            {
                r.Music_Instruments.Add(musicmodel);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(string code)
        {
            var musicmodel = new Music_Instrument();
            TryUpdateModel(musicmodel);

            using (var r = new MusicEntities())
            {
                musicmodel = r.Music_Instruments.FirstOrDefault(x => x.InstrumentCode == code);
            }

            return View(musicmodel);
        }

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get(string code)
        {
            var musicmodel = new Music_Instrument();
            TryUpdateModel(musicmodel);

            using (var r = new MusicEntities())
            {
                musicmodel = r.Music_Instruments.Where(x => x.InstrumentCode == code).FirstOrDefault();
            }

            return View(musicmodel);
        }

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post(string code)
        {
            var musicmodel = new Music_Instrument();
            TryUpdateModel(musicmodel);

            using (var r = new MusicEntities())
            {
                var m = r.Music_Instruments.Where(x => x.InstrumentCode == code).FirstOrDefault();
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult Delete_Get(string code)
        {
            var musicmodel = new Music_Instrument();
            TryUpdateModel(musicmodel);

            using (var r = new MusicEntities())
            {
                musicmodel = r.Music_Instruments.FirstOrDefault(x => x.InstrumentCode == code);
            }

            return View(musicmodel);
        }
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult Delete_Post(string code)
        {
            var musicmodel = new Music_Instrument();
            TryUpdateModel(musicmodel);

            using (var r = new MusicEntities())
            {
                var m = r.Music_Instruments.Remove(r.Music_Instruments.FirstOrDefault(x => x.InstrumentCode == code));
                TryUpdateModel(m);
                r.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}