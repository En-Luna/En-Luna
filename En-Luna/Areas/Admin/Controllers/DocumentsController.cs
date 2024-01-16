using AutoMapper;
using En_Luna.Data.Models;
using En_Luna.Data.Services;
using En_Luna.Extensions;
using En_Luna.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using X.PagedList;

namespace Jobbie.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DocumentsController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IDocumentService _documentService;

        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentsController"/> class.
        /// </summary>
        /// <param name="mapper"></param>
        /// <param name="service"></param>
        public DocumentsController(IMapper mapper, IDocumentService service)
        {
            _mapper = mapper;
            _documentService = service;
        }

        /// <summary>
        /// Indexes the specified page.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        public IActionResult Index(int? page)
        {
            IEnumerable<Document> documents = _documentService.List();

            IPagedList<DocumentViewModel> documentViewModels = documents
                .ToPagedList(page ?? 1, En_Luna.Constants.Constants.PageSize)
                .Map<Document, DocumentViewModel>(_mapper);

            DocumentIndexViewModel model = new DocumentIndexViewModel
            {
                Documents = documentViewModels
            };

            return View(model);
        }

        /// <summary>
        /// Edits the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            Document? document = id.HasValue
                ? _documentService.Get(x => x.Id == id.Value)
                : new Document();

            if (document == null)
            {
                return RedirectToAction("Index");
            }

            DocumentEditViewModel model = _mapper.Map<DocumentEditViewModel>(document);

            return View(model);
        }

        /// <summary>
        /// Edits the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(DocumentEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //InstantiateSelectLists(model);
                return View(model);
            }

            if (model.Id != 0)
            {
                Document? document = _documentService.Get(x => x.Id == model.Id);
                _mapper.Map(model, document);
                _documentService.Update(document);
            }
            else
            {
                Document document = _mapper.Map<Document>(model);
                _documentService.Create(document);
            }

            return RedirectToAction("Index");
        }

        public JsonResult Approve(int id)
        {
            Document? document = _documentService.Get(x => x.Id == id);

            if (document == null)
            {
                return Json(false);
            }

            _documentService.Approve(document);

            // todo notify user

            return Json(true);
        }

        public JsonResult Deny(int id)
        {
            Document? document = _documentService.Get(x => x.Id == id);

            if (document == null)
            {
                return Json(false);
            }

            _documentService.Deny(document);

            // todo notify user

            return Json(true);
        }

        public JsonResult Delete(int id)
        {
            Document? document = _documentService.Get(x => x.Id == id);

            if (document == null)
            {
                return Json(false);
            }

            _documentService.Delete(document);

            return Json(true);
        }
    }
}
