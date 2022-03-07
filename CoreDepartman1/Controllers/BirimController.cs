using CoreDepartman1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDepartman1.Controllers
{
    [Authorize]
    public class BirimController : Controller
    {
        Context context = new Context();
        public IActionResult Index()
        {
            var degerler = context.Birims.ToList();
            return View(degerler);
        }
        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim d)
        {
            context.Birims.Add(d);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var dep = context.Birims.Find(id);
            context.Birims.Remove(dep);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimGetir(int id)
        {
            var birim = context.Birims.Find(id);
            return View("BirimGetir", birim);
        }
        public IActionResult BirimGuncelle(Birim b)
        {
            var dep = context.Birims.Find(b.BirimId);
            dep.BirimAd = b.BirimAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimDetay(int id)
        {
            var degerler = context.Personels.Where(x => x.BirimId == id).ToList();
            var brmad = context.Birims.Where(x => x.BirimId == id).
                Select(y => y.BirimAd).FirstOrDefault();
            ViewBag.brm = brmad;
            return View(degerler);
        }
    }
}