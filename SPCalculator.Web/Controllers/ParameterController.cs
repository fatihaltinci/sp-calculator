using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Parameters;
using SPCalculator.Service.Services.Abstractions;
using SPCalculator.Web.Messages;

namespace SPCalculator.Web.Controllers
{
    public class ParameterController : Controller
    {
        private readonly IParameterService parameterService;
        private readonly IValidator<Parameter> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;

        public ParameterController(IParameterService parameterService, IValidator<Parameter> validator, IMapper mapper, IToastNotification toastNotification)
        {
            this.parameterService = parameterService;
            this.validator = validator;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var parameters = await parameterService.GetParameters();
            return View(parameters);
        }

        public async Task<IActionResult> DeletedParameter()
        {
            var parameters = await parameterService.GetDeletedParametersAsync();
            return View(parameters);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(ParameterAddModel parameterAddModel)
        {
            var map = mapper.Map<Parameter>(parameterAddModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await parameterService.CreateParameterAsync(parameterAddModel); // başarılıysa eklemeyi yapsın
                toastNotification.AddSuccessToastMessage(Message.Function.Add(parameterAddModel.ParameterName)); // başarılıysa toast mesajı göstersin
                return RedirectToAction("Index", "Parameter"); // başarılıysa index sayfasına yönlendirsin
            }
            else
            {
                result.AddToModelState(this.ModelState); // başarısızsa tekrar view'e dönsün
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddParameterWithAjax([FromBody] ParameterAddModel parameterAddModel) // FromBody ile gelen parametreleri alıyoruz. Ajax (Asynchronous JavaScript and XML) ile sayfa yenilemeden veri alışverişi yapmamızı sağlar.
        {
            var map = mapper.Map<Parameter>(parameterAddModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await parameterService.CreateParameterAsync(parameterAddModel);
                return Json(new { success = true, message = Message.Parameter.Add(parameterAddModel.ParameterName) });
            }
            else
            {
                result.AddToModelState(this.ModelState);
                return Json(new { success = false, message = Message.Parameter.Add(parameterAddModel.ParameterName) });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id) // Guid id = Route'dan gelen id ile eşleşecek ve parametre bulunacak ve güncelleme için sprintUpdateModel'e maplenecek
        {
            var parameter = await parameterService.GetParameterAsync(id);
            var parameterUpdateModel = mapper.Map<ParameterUpdateModel>(parameter);

            return View(parameterUpdateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ParameterUpdateModel parameterUpdateModel)
        {
            var map = mapper.Map<Parameter>(parameterUpdateModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var parameterName = await parameterService.UpdateParameterAsync(parameterUpdateModel);
                toastNotification.AddSuccessToastMessage(Message.Parameter.Update(parameterName));
                return RedirectToAction("Index", "Parameter");
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            return View(parameterUpdateModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var parameterName = await parameterService.SafeDeleteParameterAsync(id);
            toastNotification.AddAlertToastMessage(Message.Parameter.Delete(parameterName));

            return RedirectToAction("Index", "Parameter");
        }

        public async Task<IActionResult> UndoDelete(Guid id)
        {
            var parameterName = await parameterService.UndoDeleteParameterAsync(id);
            toastNotification.AddSuccessToastMessage(Message.Parameter.UndoDelete(parameterName));

            return RedirectToAction("Index", "Parameter");
        }
    }
}
