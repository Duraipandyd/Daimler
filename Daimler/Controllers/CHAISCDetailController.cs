using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Daimler.Models;

namespace Daimler.Controllers
{
    public class CHAISCDetailController : Controller
    {
        private readonly DaimlerContext _context;

        public CHAISCDetailController(DaimlerContext context)
        {
            _context = context;
        }

        // GET: CHAISCDetail
        public async Task<IActionResult> Index()
        {
            return View(await _context.CHAISCDetail.ToListAsync());
        }

        // GET: CHAISCDetail/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CHAISCDetail = await _context.CHAISCDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (CHAISCDetail == null)
            {
                return NotFound();
            }

            return View(CHAISCDetail);
        }

        // GET: CHAISCDetail/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CHAISCDetail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Boeid,JobNo,Beno,Bedate,InvoiceNo,InvoiceDate,TotalnvoiceValue,TotalInoviceCurrency,TotalFreightValue,TotalFreightCurrency,TotalInsValue,TotalInsCurrency,MiscCharge,InvoiceMiscCurrency,ExchangeRate,CustomTariffHeading,CentralExciseTariffHeading,ProductDescription,Quantity,UnitofProductQuantity,UnitPrice,ProductAmount,Freight,Insurance,Cifvalue,Loading,BasicDutyRate,BasicDuty,AddlDutyExciseDutyRate,AddlDutyExciseDutyAmount,AddlDutySubSec5Rate,AddlDutySubSec5Amount,EducationCessRateExcise,EducationCessAmountExcise,SecondaryhigherEducationCessRateExcise,SecondaryhigherEducationCessAmountExcise,SocialWelfareSurchargeRateCustoms,SocialWelfareSurchargeAmountCustoms,SecondaryhigherEducationCessRateCustoms,SecondaryhigherEducationCessAmountCustoms,AssessableValue,TotalAssessable,TotalBasicDuty,TotalSurcharge,TotalCvd,TotalEducationCess,TotalEducationCessExcise,TotalSocialWelfareSurchargeCustoms,TotalSechigherEducationCess,TotalSechigherEducationCessExcise,TotalSechigherEducationCessCustoms,TotalAdditonalDutySubSec5,TotalDuty,SplExciseDutySchedIiRate,SplExciseDutySchedIiAmount,Model,CessdutyRate,Cessduty,ModeofTransport,Consignor,Igstrate,Igstamount")] CHAISCDetail CHAISCDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(CHAISCDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(CHAISCDetail);
        }

        // GET: CHAISCDetail/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CHAISCDetail = await _context.CHAISCDetail.FindAsync(id);
            if (CHAISCDetail == null)
            {
                return NotFound();
            }
            return View(CHAISCDetail);
        }

        // POST: CHAISCDetail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Boeid,JobNo,Beno,Bedate,InvoiceNo,InvoiceDate,TotalnvoiceValue,TotalInoviceCurrency,TotalFreightValue,TotalFreightCurrency,TotalInsValue,TotalInsCurrency,MiscCharge,InvoiceMiscCurrency,ExchangeRate,CustomTariffHeading,CentralExciseTariffHeading,ProductDescription,Quantity,UnitofProductQuantity,UnitPrice,ProductAmount,Freight,Insurance,Cifvalue,Loading,BasicDutyRate,BasicDuty,AddlDutyExciseDutyRate,AddlDutyExciseDutyAmount,AddlDutySubSec5Rate,AddlDutySubSec5Amount,EducationCessRateExcise,EducationCessAmountExcise,SecondaryhigherEducationCessRateExcise,SecondaryhigherEducationCessAmountExcise,SocialWelfareSurchargeRateCustoms,SocialWelfareSurchargeAmountCustoms,SecondaryhigherEducationCessRateCustoms,SecondaryhigherEducationCessAmountCustoms,AssessableValue,TotalAssessable,TotalBasicDuty,TotalSurcharge,TotalCvd,TotalEducationCess,TotalEducationCessExcise,TotalSocialWelfareSurchargeCustoms,TotalSechigherEducationCess,TotalSechigherEducationCessExcise,TotalSechigherEducationCessCustoms,TotalAdditonalDutySubSec5,TotalDuty,SplExciseDutySchedIiRate,SplExciseDutySchedIiAmount,Model,CessdutyRate,Cessduty,ModeofTransport,Consignor,Igstrate,Igstamount")] CHAISCDetail CHAISCDetail)
        {
            if (id != CHAISCDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(CHAISCDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CHAISCDetailExists(CHAISCDetail.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(CHAISCDetail);
        }

        // GET: CHAISCDetail/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CHAISCDetail = await _context.CHAISCDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (CHAISCDetail == null)
            {
                return NotFound();
            }

            return View(CHAISCDetail);
        }

        // POST: CHAISCDetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CHAISCDetail = await _context.CHAISCDetail.FindAsync(id);
            _context.CHAISCDetail.Remove(CHAISCDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CHAISCDetailExists(int id)
        {
            return _context.CHAISCDetail.Any(e => e.Id == id);
        }
    }
}
