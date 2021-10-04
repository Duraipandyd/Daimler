using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Daimler.Models;
using Daimler.Services;

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

        public class BOERecordsList4ISC
        {
            public int Id { get; set; }
            public string Dprno { get; set; }
            public DateTime? DRPDate { get; set; }
            public decimal? DutyDPR { get; set; }
            public decimal? DutyISC { get; set; }
            public int BOERecords { get; set; }
            public int ISCRecords { get; set; }
            public List<BOERecordsDetails4ISC> boeRecordsDetails4ISC { get; set; }

        }

        public class BOERecordsDetails4ISC
        {
            public int Id { get; set; }
            public string BoeNo { get; set; }
            public decimal? BoeDuty { get; set; }
            public decimal? DutyValue { get; set; }
            public decimal? Fine { get; set; }
            public decimal? Penalty { get; set; }
            public decimal? Interest { get; set; }
            public int? CISISC { get; set; }
            public int? BOE { get; set; }
            public string RefNo { get; set; }
            public string InvoiceNo { get; set; }
            public string PortCode { get; set; }
            public string ISCRecordsAttachmentPath { get; set; }
            public string BOERecordsAttachmentPath { get; set; }


        }

        public class AttachmentDetails
        {
            public string FileName { get; set; }
            public string FileLocation { get; set; }
        }

        [HttpGet]
        public BOERecordsList4ISC GetISCRecords(int id)
        {

            var recordsList4ISC = new BOERecordsList4ISC();
            var BOERecordsDetails4ISC = new List<BOERecordsDetails4ISC>();
            var boeRecordCount = 0;
            var iscRecordCount = 0;

            recordsList4ISC = (from DutyPaymentRequestHeader in _context.DutyPaymentRequestHeader
                               where DutyPaymentRequestHeader.Id == id

                               select new BOERecordsList4ISC
                               {
                                   Id = DutyPaymentRequestHeader.Id,
                                   Dprno = DutyPaymentRequestHeader.Dprno,
                                   DRPDate = DutyPaymentRequestHeader.UploadedDate
                               }
                                 ).Distinct().FirstOrDefault();

            var RecordDetailsList = (from DutyPaymentRequestDetail in _context.DutyPaymentRequestDetail
                                     where DutyPaymentRequestDetail.HeaderId == id

                                     select new BOERecordsDetails4ISC
                                     {
                                         Id = DutyPaymentRequestDetail.Id,
                                         BoeNo = DutyPaymentRequestDetail.Boeno,
                                         BoeDuty = DutyPaymentRequestDetail.Boeduty,
                                         DutyValue = DutyPaymentRequestDetail.DutyValue,
                                         Fine = DutyPaymentRequestDetail.Fine,
                                         Interest = DutyPaymentRequestDetail.Interest,
                                         InvoiceNo = DutyPaymentRequestDetail.InvoiceNo,
                                         Penalty = DutyPaymentRequestDetail.Penalty,
                                         PortCode = DutyPaymentRequestDetail.PortCode,
                                         RefNo = DutyPaymentRequestDetail.RefNo,
                                         BOE = DutyPaymentRequestDetail.IscExcelAttachmentId,
                                         CISISC = DutyPaymentRequestDetail.IscExcelAttachmentId,
                                     }
                                 ).Distinct().ToList();

            foreach (var details4ISC in RecordDetailsList)
            {
                if (CommonFunction.NullToIntZero(details4ISC.BOE) != 0)
                {
                    var attachment = (from AttachmentFileList in _context.AttachmentFileList
                                      where AttachmentFileList.Id == details4ISC.BOE

                                      select new AttachmentDetails
                                      {
                                          FileLocation = AttachmentFileList.FileLocation,
                                          FileName = AttachmentFileList.FileName
                                      }).FirstOrDefault();
                    details4ISC.BOERecordsAttachmentPath = attachment.FileLocation + "/" + attachment.FileName;
                    boeRecordCount += 1;
                }

                if (CommonFunction.NullToIntZero(details4ISC.CISISC) != 0)
                {
                    var attachment = (from AttachmentFileList in _context.AttachmentFileList
                                      where AttachmentFileList.Id == details4ISC.CISISC

                                      select new AttachmentDetails
                                      {
                                          FileLocation = AttachmentFileList.FileLocation,
                                          FileName = AttachmentFileList.FileName
                                      }).FirstOrDefault();
                    details4ISC.ISCRecordsAttachmentPath = attachment.FileLocation + "/" + attachment.FileName;
                    iscRecordCount += 1;
                }
            }

            recordsList4ISC.BOERecords = boeRecordCount;
            recordsList4ISC.ISCRecords = iscRecordCount;

            return recordsList4ISC;

        }
    }
}
