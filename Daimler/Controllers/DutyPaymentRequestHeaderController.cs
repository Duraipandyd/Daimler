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
