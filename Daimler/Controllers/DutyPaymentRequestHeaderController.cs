using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Daimler.Models;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.HSSF.UserModel;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Cors;
using Newtonsoft.Json;

namespace Daimler.Controllers
{
    public class DutyPaymentRequestHeaderController : Controller
    {
        private readonly DaimlerContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DutyPaymentRequestHeaderController(DaimlerContext context)
        {
            _context = context;
        }

        public IActionResult ShowGrid()
        {
            return View();
        }

        public IActionResult LoadData()
        {
            try
            {
                var draw = HttpContext.Request.Form["draw"].FirstOrDefault();
                // Skiping number of Rows count
                var start = Request.Form["start"].FirstOrDefault();
                // Paging Length 10,20
                var length = Request.Form["length"].FirstOrDefault();
                // Sort Column Name
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                // Sort Column Direction ( asc ,desc)
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                // Search Value from (Search box)
                var searchValue = Request.Form["search[value]"].FirstOrDefault();

                //Paging Size (10,20,50,100)
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;

                // Getting all Customer data
                var customerData = (from tempcustomer in _context.DutyPaymentRequestHeader
                                    select tempcustomer);

                ////Sorting
                //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
                //{
                //    customerData = customerData.OrderBy(sortColumn + " " + sortColumnDirection);
                //}
                ////Search
                //if (!string.IsNullOrEmpty(searchValue))
                //{
                //    customerData = customerData.Where(m => m.Name == searchValue || m.Phoneno == searchValue || m.City == searchValue);
                //}

                //total number of rows count 
                recordsTotal = customerData.Count();
                //Paging 
                var data = customerData.Skip(skip).Take(pageSize).ToList();
                //Returning Json Data
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data });

            }
            catch (Exception)
            {
                throw;
            }

        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("ShowGrid", "DemoGrid");
                }

                return View("Edit");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            try
            {
                if (string.IsNullOrEmpty(id))
                {
                    return RedirectToAction("ShowGrid", "DemoGrid");
                }

                int result = 0;

                if (result > 0)
                {
                    return Json(data: true);
                }
                else
                {
                    return Json(data: false);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public class paymentlist
        {
            public int Id { get; set; }
            public string Dprno { get; set; }
            public string FileName { get; set; }
            public string Download { get; set; }
            public DateTime? UploadedDate { get; set; }
            public int? UploadedBy { get; set; }
            public string DocumentReference { get; set; }
            public string Status { get; set; }
        }
        [HttpGet]
        public IList<paymentlist> GetDutyPaymentRequestHeader()
        {
            var dutyPaymentRequestHeaders =  (from DutyPaymentRequestHeader in _context.DutyPaymentRequestHeader
                                                   select new paymentlist
                                                   {
                                                       Id = DutyPaymentRequestHeader.Id,
                                                       Dprno = DutyPaymentRequestHeader.Dprno,
                                                       FileName = DutyPaymentRequestHeader.FileName,
                                                       UploadedDate = DutyPaymentRequestHeader.UploadedDate,
                                                       UploadedBy = DutyPaymentRequestHeader.UploadedBy,
                                                       DocumentReference = DutyPaymentRequestHeader.DocumentReference,
                                                       Status = DutyPaymentRequestHeader.Status,
                                                       Download="assets/uploads/"+ DutyPaymentRequestHeader.FileName
                                                   }).ToList();
     

            return dutyPaymentRequestHeaders;
            //return await _context.DutyPaymentRequestHeader.ToListAsync();
        }

        public class ISClist
        {
            public int Id { get; set; }
            public string Dprno { get; set; }
            public DateTime? DRPDate { get; set; }
            public decimal? DutyDPR { get; set; }
            public decimal? DutyISC { get; set; }
            public int BOERecords { get; set; }
            public int ISCRecords { get; set; }
            public string Status { get; set; }
        }

        [HttpGet]
        public IList<ISClist> GetISCRecords()
        {

            var ISCRecordList = (from DutyPaymentRequestHeader in _context.DutyPaymentRequestHeader
                                 join DutyPaymentRequestDetail in _context.DutyPaymentRequestDetail on DutyPaymentRequestHeader.Id equals DutyPaymentRequestDetail.HeaderId
                                 where DutyPaymentRequestDetail.IscExcelAttachmentId == null && DutyPaymentRequestDetail.IscPdfAttachmentId == null

                                 select new ISClist
                                 {
                                     Id = DutyPaymentRequestHeader.Id,
                                     Dprno = DutyPaymentRequestHeader.Dprno,
                                     DRPDate = DutyPaymentRequestHeader.UploadedDate,
                                     Status = "Pending"
                                 }
                                 ).Distinct().ToList();
            foreach (var iscrecord in ISCRecordList)
            {
                var ISCDetailsList = (from DutyPaymentRequestDetail in _context.DutyPaymentRequestDetail
                                     where DutyPaymentRequestDetail.HeaderId == iscrecord.Id

                                     select new ISClist
                                     {
                                         Id = DutyPaymentRequestDetail.HeaderId,
                                         DutyDPR = DutyPaymentRequestDetail.DutyValue,
                                         DutyISC = DutyPaymentRequestDetail.Boeduty,
                                         Status= DutyPaymentRequestDetail.Boeno
                                     }
                                 ).ToList();
                iscrecord.DutyDPR = ISCDetailsList.Sum(x => x.DutyDPR);
                iscrecord.DutyISC = ISCDetailsList.Sum(x => x.DutyISC);
                iscrecord.BOERecords = ISCDetailsList.Count();
                var lstboids = ISCDetailsList.Select(y => y.Status).ToList();
                var ISCList = (from CHAISCDetail in _context.CHAISCDetail
                               where lstboids.Contains(CHAISCDetail.Beno)

                                      select new CHAISCDetail
                                      {
                                          Beno = CHAISCDetail.Beno

                                      }
                                 ).ToList();
                iscrecord.ISCRecords = ISCList.Count();
            }
                                 //).ToList().Distinct();
                                 //var ISCRecordList = (from DutyPaymentRequestHeader in _context.DutyPaymentRequestHeader
                                 //                     join DutyPaymentRequestDetail in _context.DutyPaymentRequestDetail on DutyPaymentRequestHeader.Id equals DutyPaymentRequestDetail.HeaderId
                                 //                     join CHAISCDetail in _context.CHAISCDetail on DutyPaymentRequestDetail.Boeno equals CHAISCDetail.Boeid into ps
                                 //                     from CHAISCDetail in ps.DefaultIfEmpty()
                                 //                     where DutyPaymentRequestDetail.IscExcelAttachmentId == null && DutyPaymentRequestDetail.IscPdfAttachmentId == null

                                 //                     group new { DutyPaymentRequestDetail, DutyPaymentRequestHeader  } by new
                                 //                     {
                                 //                         DutyPaymentRequestHeader.Id,
                                 //                         DutyPaymentRequestHeader.Dprno

                                 //                     } into g
                                 //                     select new ISClist()
                                 //                     {
                                 //                         Id = g.Key.Id,
                                 //                         Dprno = g.Key.Dprno,
                                 //                         DRPDate = g.Select(m => m.DutyPaymentRequestHeader.UploadedDate).FirstOrDefault(),
                                 //                         DutyDPR = g.Sum(x => Math.Round(Convert.ToDecimal(x.DutyPaymentRequestDetail.DutyValue), 2)),
                                 //                         DutyISC = g.Sum(x => Math.Round(Convert.ToDecimal(x.DutyPaymentRequestDetail.Boeduty), 2)),
                                 //                         BOERecords= g.Count(),
                                 //                         ISCRecords = g.Count(),
                                 //                         Status = "Pending"
                                 //                     }).ToList();


            return ISCRecordList;
            //return await _context.DutyPaymentRequestHeader.ToListAsync();
        }

        public class IDTlist
        {
            public int Id { get; set; }
            public string Dprno { get; set; }
            public DateTime? DRPDate { get; set; }
            public decimal? DutyDPR { get; set; }
            public decimal? DutyISC { get; set; }
            public decimal? DutyIDT { get; set; }
            public int BOERecords { get; set; }
            public int ISCRecords { get; set; }
            public int IDTRecords { get; set; }
            public string Status { get; set; }
        }


        [HttpGet]
        public IList<IDTlist> GetIDTRecords()
        {

            var IDTRecordList = (from DutyPaymentRequestHeader in _context.DutyPaymentRequestHeader
                                 join DutyPaymentRequestDetail in _context.DutyPaymentRequestDetail on DutyPaymentRequestHeader.Id equals DutyPaymentRequestDetail.HeaderId
                                 where DutyPaymentRequestDetail.IscExcelAttachmentId == null && DutyPaymentRequestDetail.IscPdfAttachmentId == null

                                 select new IDTlist
                                 {
                                     Id = DutyPaymentRequestHeader.Id,
                                     Dprno = DutyPaymentRequestHeader.Dprno,
                                     DRPDate = DutyPaymentRequestHeader.UploadedDate,
                                     Status = "Pending"
                                 }
                                 ).Distinct().ToList();
            foreach (var iscrecord in IDTRecordList)
            {
                var IDTDetailsList = (from DutyPaymentRequestDetail in _context.DutyPaymentRequestDetail
                                      where DutyPaymentRequestDetail.HeaderId == iscrecord.Id

                                      select new IDTlist
                                      {
                                          Id = DutyPaymentRequestDetail.HeaderId,
                                          DutyDPR = DutyPaymentRequestDetail.DutyValue,
                                          DutyISC = DutyPaymentRequestDetail.Boeduty,
                                          DutyIDT = DutyPaymentRequestDetail.Boeduty,
                                          Status = DutyPaymentRequestDetail.Boeno
                                      }
                                 ).ToList();
                iscrecord.DutyDPR = IDTDetailsList.Sum(x => x.DutyDPR);
                iscrecord.DutyISC = IDTDetailsList.Sum(x => x.DutyISC);
                iscrecord.DutyIDT = IDTDetailsList.Sum(x => x.DutyIDT);
                iscrecord.BOERecords = IDTDetailsList.Count();
                var lstboids = IDTDetailsList.Select(y => y.Status).ToList();
                var ISCList = (from CHAISCDetail in _context.CHAISCDetail
                               where lstboids.Contains(CHAISCDetail.Beno)

                               select new CHAISCDetail
                               {
                                   Beno = CHAISCDetail.Beno

                               }
                                 ).ToList();
                iscrecord.ISCRecords = ISCList.Count();

                var IDTList = (from CHADTDetail in _context.CHADTDetail
                               where lstboids.Contains(CHADTDetail.Beno)

                               select new CHADTDetail
                               {
                                   Beno = CHADTDetail.Beno

                               }
                                 ).ToList();
                iscrecord.IDTRecords = IDTList.Count();
            }
            

            return IDTRecordList;
           
        }
        // GET: DutyPaymentRequestHeader/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dutyPaymentRequestHeader = await _context.DutyPaymentRequestHeader
                .Include(d => d.UploadedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dutyPaymentRequestHeader == null)
            {
                return NotFound();
            }

            return View(dutyPaymentRequestHeader);
        }

      

        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            // Extract file name from whatever was posted by browser
            var fileName = System.IO.Path.GetFileName(file.FileName);

            // If file with same name exists delete it
            if (System.IO.File.Exists(fileName))
            {
                System.IO.File.Delete(fileName);
            }

            // Create new local file and copy contents of uploaded file
            using (var localFile = System.IO.File.OpenWrite(fileName))
            using (var uploadedFile = file.OpenReadStream())
            {
                uploadedFile.CopyTo(localFile);
            }

            ViewBag.Message = "File successfully uploaded";

            return View();
        }

        // POST: DutyPaymentRequestHeader/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DutyPaymentRequestHeader dutyPaymentRequestHeader)
        {

            if (ModelState.IsValid)
            {
                _context.Add(dutyPaymentRequestHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id"] = new SelectList(_context.Login, "Id", "Id", dutyPaymentRequestHeader.Id);
            return View(dutyPaymentRequestHeader);
        }

        // GET: DutyPaymentRequestHeader/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dutyPaymentRequestHeader = await _context.DutyPaymentRequestHeader.FindAsync(id);
            if (dutyPaymentRequestHeader == null)
            {
                return NotFound();
            }
            ViewData["Id"] = new SelectList(_context.Login, "Id", "Id", dutyPaymentRequestHeader.Id);
            return View(dutyPaymentRequestHeader);
        }

        // POST: DutyPaymentRequestHeader/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dprno,FileName,UploadedDate,UploadedBy,DocumentReference,Status")] DutyPaymentRequestHeader dutyPaymentRequestHeader)
        {
            if (id != dutyPaymentRequestHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dutyPaymentRequestHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DutyPaymentRequestHeaderExists(dutyPaymentRequestHeader.Id))
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
            ViewData["Id"] = new SelectList(_context.Login, "Id", "Id", dutyPaymentRequestHeader.Id);
            return View(dutyPaymentRequestHeader);
        }

        // GET: DutyPaymentRequestHeader/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dutyPaymentRequestHeader = await _context.DutyPaymentRequestHeader
                .Include(d => d.UploadedBy)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dutyPaymentRequestHeader == null)
            {
                return NotFound();
            }

            return View(dutyPaymentRequestHeader);
        }

        // POST: DutyPaymentRequestHeader/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dutyPaymentRequestHeader = await _context.DutyPaymentRequestHeader.FindAsync(id);
            var dutyPaymentRequestDetails =  _context.DutyPaymentRequestDetail.Where(x=> x.HeaderId==id).ToList();
            //dutyPaymentRequestHeader.DutyPaymentRequestDetails = dutyPaymentRequestDetails;
            foreach (var dutyPaymentRequestDetail in dutyPaymentRequestDetails)
            {
                _context.DutyPaymentRequestDetail.Remove(dutyPaymentRequestDetail);
            }
            _context.DutyPaymentRequestHeader.Remove(dutyPaymentRequestHeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DutyPaymentRequestHeaderExists(int id)
        {
            return _context.DutyPaymentRequestHeader.Any(e => e.Id == id);
        }
    }
}
