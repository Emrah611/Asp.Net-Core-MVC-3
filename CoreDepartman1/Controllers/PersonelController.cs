using CoreDepartman1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartman1.Controllers
{
    [Authorize]
    public class PersonelController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var degerler = context.Personels.Include(x => x.Birim).ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniPersonel()
        {
            List<SelectListItem> degerler = (from x in context.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text=x.BirimAd,
                                                 Value=x.BirimId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public IActionResult YeniPersonel(Personel p)
        {
            var personel = context.Birims.Where(x => x.BirimId == p.Birim.BirimId).FirstOrDefault();
            p.Birim = personel;
            context.Personels.Add(p);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PersonelSil(int id)
        {
            var dep = context.Personels.Find(id);
            context.Personels.Remove(dep);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult PersonelGetir(int id)
        {
            List<SelectListItem> degerler = (from x in context.Birims.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.BirimAd,
                                                 Value = x.BirimId.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            var personel = context.Personels.Find(id);
            return View("PersonelGetir", personel);
        }
        public IActionResult PersonelGuncelle(Personel p)
        {
            var dep = context.Personels.Find(p.PersonelId);
            dep.PersonelAD = p.PersonelAD;
            dep.PersonelSoyad = p.PersonelSoyad;
            dep.Sehir = p.Sehir;
            dep.BirimId = p.BirimId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
