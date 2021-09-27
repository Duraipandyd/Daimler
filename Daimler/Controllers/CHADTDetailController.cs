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
    public class CHADTDetailController : Controller
    {
        private readonly DaimlerContext _context;

        public CHADTDetailController(DaimlerContext context)
        {
            _context = context;
        }

        // GET: CHADTDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.CHADTDetail.ToListAsync());
        }

        // GET: CHADTDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CHADTDetail = await _context.CHADTDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (CHADTDetail == null)
            {
                return NotFound();
            }

            return View(CHADTDetail);
        }

        // GET: CHADTDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CHADTDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Boeid,JobNo,Beno,Bedate,InvoiceNo,InvoiceDate,TotalnvoiceValue,TotalInoviceCurrency,TotalFreightValue,TotalFreightCurrency,TotalInsValue,TotalInsCurrency,MiscCharge,InvoiceMiscCurrency,ExchangeRate,CustomTariffHeading,CentralExciseTariffHeading,ProductDescription,Quantity,UnitofProductQuantity,UnitPrice,ProductAmount,Freight,Insurance,Cifvalue,Loading,BasicDutyRate,BasicDuty,AddlDutyExciseDutyRate,AddlDutyExciseDutyAmount,AddlDutySubSec5Rate,AddlDutySubSec5Amount,EducationCessRateExcise,EducationCessAmountExcise,SecondaryhigherEducationCessRateExcise,SecondaryhigherEducationCessAmountExcise,SocialWelfareSurchargeRateCustoms,SocialWelfareSurchargeAmountCustoms,SecondaryhigherEducationCessRateCustoms,SecondaryhigherEducationCessAmountCustoms,AssessableValue,TotalAssessable,TotalBasicDuty,TotalSurcharge,TotalCvd,TotalEducationCess,TotalEducationCessExcise,TotalSocialWelfareSurchargeCustoms,TotalSechigherEducationCess,TotalSechigherEducationCessExcise,TotalSechigherEducationCessCustoms,TotalAdditonalDutySubSec5,TotalDuty,SplExciseDutySchedIiRate,SplExciseDutySchedIiAmount,Model,CessdutyRate,Cessduty,ModeofTransport,Consignor,Igstrate,Igstamount,Sadrate,Sadamount,TotalSad,TaxCode")] CHADTDetail CHADTDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(CHADTDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(CHADTDetail);
        }

        // GET: CHADTDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CHADTDetail = await _context.CHADTDetail.FindAsync(id);
            if (CHADTDetail == null)
            {
                return NotFound();
            }
            return View(CHADTDetail);
        }

        // POST: CHADTDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Boeid,JobNo,Beno,Bedate,InvoiceNo,InvoiceDate,TotalnvoiceValue,TotalInoviceCurrency,TotalFreightValue,TotalFreightCurrency,TotalInsValue,TotalInsCurrency,MiscCharge,InvoiceMiscCurrency,ExchangeRate,CustomTariffHeading,CentralExciseTariffHeading,ProductDescription,Quantity,UnitofProductQuantity,UnitPrice,ProductAmount,Freight,Insurance,Cifvalue,Loading,BasicDutyRate,BasicDuty,AddlDutyExciseDutyRate,AddlDutyExciseDutyAmount,AddlDutySubSec5Rate,AddlDutySubSec5Amount,EducationCessRateExcise,EducationCessAmountExcise,SecondaryhigherEducationCessRateExcise,SecondaryhigherEducationCessAmountExcise,SocialWelfareSurchargeRateCustoms,SocialWelfareSurchargeAmountCustoms,SecondaryhigherEducationCessRateCustoms,SecondaryhigherEducationCessAmountCustoms,AssessableValue,TotalAssessable,TotalBasicDuty,TotalSurcharge,TotalCvd,TotalEducationCess,TotalEducationCessExcise,TotalSocialWelfareSurchargeCustoms,TotalSechigherEducationCess,TotalSechigherEducationCessExcise,TotalSechigherEducationCessCustoms,TotalAdditonalDutySubSec5,TotalDuty,SplExciseDutySchedIiRate,SplExciseDutySchedIiAmount,Model,CessdutyRate,Cessduty,ModeofTransport,Consignor,Igstrate,Igstamount,Sadrate,Sadamount,TotalSad,TaxCode")] CHADTDetail CHADTDetail )
        {
            if (id != CHADTDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(CHADTDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CHADTDetailExists(CHADTDetail.Id))
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
            return View(CHADTDetail);
        }

        // GET: CHADTDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var CHADTDetail = await _context.CHADTDetail
                .FirstOrDefaultAsync(m => m.Id == id);
            if (CHADTDetail == null)
            {
                return NotFound();
            }

            return View(CHADTDetail);
        }

        // POST: CHADTDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var CHADTDetail = await _context.CHADTDetail.FindAsync(id);
            _context.CHADTDetail.Remove(CHADTDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CHADTDetailExists(int id)
        {
            return _context.CHADTDetail.Any(e => e.Id == id);
        }
    }
}
