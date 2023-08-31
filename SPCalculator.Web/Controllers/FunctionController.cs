using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Functions;
using SPCalculator.Service.Services.Abstractions;
using SPCalculator.Web.Messages;


namespace SPCalculator.Web.Controllers
{
    public class FunctionController : Controller
    {
        private readonly IFunctionService functionService;
        private readonly IValidator<Function> validator;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;

        public FunctionController(IFunctionService functionService, IValidator<Function> validator, IMapper mapper, IToastNotification toastNotification)
        {
            this.functionService = functionService;
            this.validator = validator;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var functions = await functionService.GetFunctions();
            return View(functions);
        }

        public async Task<IActionResult> DeletedFunction()
        {
            var functions = await functionService.GetDeletedFunctionsAsync();
            return View(functions);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(FunctionAddModel functionAddModel)
        {
            var map = mapper.Map<Function>(functionAddModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await functionService.CreateFunctionAsync(functionAddModel); // başarılıysa eklemeyi yapsın
                toastNotification.AddSuccessToastMessage(Message.Function.Add(functionAddModel.FunctionName)); // başarılıysa toast mesajı göstersin
                return RedirectToAction("Index", "Function"); // başarılıysa index sayfasına yönlendirsin
            }
            else
            {
                result.AddToModelState(this.ModelState); // başarısızsa tekrar view'e dönsün
                return View();
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddFunctionWithAjax([FromBody] FunctionAddModel functionAddModel) // FromBody ile gelen parametreleri alıyoruz. Ajax(Asynchronous JavaScript and XML) ile sayfa yenilemeden veri alışverişi yapmamızı sağlar.
        {
            var map = mapper.Map<Function>(functionAddModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                await functionService.CreateFunctionAsync(functionAddModel);
                toastNotification.AddSuccessToastMessage(Message.Function.Add(functionAddModel.FunctionName), new ToastrOptions { Title = "İşlem Başarılı" });

                return Json(Message.Function.Add(functionAddModel.FunctionName));
            }
            else
            {
                toastNotification.AddErrorToastMessage(result.Errors.First().ErrorMessage, new ToastrOptions { Title = "İşlem Başarısız" });
                return Json(result.Errors.First().ErrorMessage);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id) // Guid id = Route'dan gelen id ile eşleşecek ve fonksiyon bulunacak ve güncelleme için sprintUpdateModel'e maplenecek
        {
            var function = await functionService.GetFunctionAsync(id);
            var functionUpdateModel = mapper.Map<FunctionUpdateModel>(function);

            return View(functionUpdateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(FunctionUpdateModel functionUpdateModel)
        {
            var map = mapper.Map<Function>(functionUpdateModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var functionName = await functionService.UpdateFunctionAsync(functionUpdateModel);
                toastNotification.AddSuccessToastMessage(Message.Function.Update(functionName));
                return RedirectToAction("Index", "Function");
            }
            else
            {
                result.AddToModelState(this.ModelState);
            }

            return View(functionUpdateModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var functionName = await functionService.SafeDeleteFunctionAsync(id);
            toastNotification.AddAlertToastMessage(Message.Function.Delete(functionName));


            return RedirectToAction("Index", "Function");
        }

        public async Task<IActionResult> UndoDelete(Guid id)
        {
            var functionName = await functionService.UndoDeleteFunctionAsync(id);
            toastNotification.AddSuccessToastMessage(Message.Function.UndoDelete(functionName));

            return RedirectToAction("Index", "Function");
        }

    }
}
