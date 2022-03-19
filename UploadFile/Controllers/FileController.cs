using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UploadFile.Data;
using UploadFile.Models;
using UploadFile.ViewModels;

namespace UploadFile.Controllers
{
    public class FileController : Controller
    {
        private readonly ApplicationDbContext context;

        public FileController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<IActionResult> Index()
        {
            var fileuploadViewModel = await LoadAllFiles();
            ViewBag.Message = TempData["Message"];
            return View(fileuploadViewModel);
        }

        private async Task<FileUploadViewModel> LoadAllFiles()
        {
            var viewModel = new FileUploadViewModel();
            viewModel.FilesOnDatabase = await context.FilesOnDatabase
                .ToListAsync();
            viewModel.FilesOnFileSystem = await context.FilesOnFileSystem
                .ToListAsync();
            return viewModel;
        }
    }
}
