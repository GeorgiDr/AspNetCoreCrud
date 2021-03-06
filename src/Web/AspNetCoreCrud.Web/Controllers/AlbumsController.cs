﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspNetCoreCrud.Web.Data;
using AspNetCoreCrud.Web.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Net.Mime;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AspNetCoreCrud.Web.Models.ViewModel;

namespace AspNetCoreCrud.Web.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly ApplicationDbContext context;

        public AlbumsController(ApplicationDbContext context)
        {
            this.context = context;
          
        }

        // GET: Albums
        public async Task<IActionResult> Index()
        {
           
            return View(await context.Album.ToListAsync());
        }

        // GET: Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await context.Album
                .FirstOrDefaultAsync(m => m.ID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Albums/Create
        public IActionResult Create()
        {
            ViewModelCategoryAlbum s1 = new ViewModelCategoryAlbum();
            var item = context.Category.ToList();
            s1.Categories = item;
            return View(s1);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Artist,Name,Genre,ReleaseDate,Price,Rank")] Album album, IEnumerable<IFormFile> Image)
        {
 
            if (ModelState.IsValid)
            {
                //Upload FIle
                foreach (var item in Image)
            {
                if (item.Length > 0)
                {
                    using (var steam = new MemoryStream())
                    {
                        await item.CopyToAsync(steam);
                        album.Image = steam.ToArray();    
                       
                     }
                }
            }
                // End Upload File

                context.Add(album);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(album);
        }

        // GET: Albums/Edit/5
        public async Task<IActionResult> Edit(int? id, IEnumerable<IFormFile> Image)
        {
            //Upload FIle
            foreach (var item in Image)
            {
                if (item.Length > 0)
                {
                    using (var steam = new MemoryStream())
                    {
                        await item.CopyToAsync(steam);
                       

                    }
                }
            }
            // End Upload File
            if (id == null)
            {
                return NotFound();
            }

            var album = await context.Album.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Artist,Name,Genre,ReleaseDate,Price,Image")] Album album, IEnumerable<IFormFile> Image)
        { 

            if (id != album.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //Upload FIle
                    foreach (var item in Image)
                    {
                        if (item.Length > 0)
                        {
                            using (var steam = new MemoryStream())
                            {
                                await item.CopyToAsync(steam);
                                album.Image = steam.ToArray();

                            }
                        }
                    }
                    context.Update(album);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.ID))
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
            return View(album);
        }

        // GET: Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var album = await context.Album
                .FirstOrDefaultAsync(m => m.ID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var album = await context.Album.FindAsync(id);
            context.Album.Remove(album);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return context.Album.Any(e => e.ID == id);
        }


    }
}
