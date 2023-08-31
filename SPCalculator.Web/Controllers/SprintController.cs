using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using MachineLearning;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using SPCalculator.Entity.Entities;
using SPCalculator.Entity.Models.Sprints;
using SPCalculator.Service.Services.Abstractions;
using SPCalculator.Web.Messages;

namespace SPCalculator.Web.Controllers
{
    public class SprintController : Controller
    {
        private readonly ISprintService sprintService;
        private readonly IFunctionService functionService;
        private readonly IParameterService parameterService;
        private readonly IMapper mapper;
        private readonly IValidator<Sprint> validator;
        private readonly IToastNotification toastNotification;

        public SprintController(ISprintService sprintService, IFunctionService functionService, IParameterService parameterService, IMapper mapper, IValidator<Sprint> validator, IToastNotification toastNotification)
        {
            this.sprintService = sprintService;
            this.functionService = functionService;
            this.parameterService = parameterService;
            this.mapper = mapper;
            this.validator = validator;
            this.toastNotification = toastNotification;
        }

        public async Task<IActionResult> Index()
        {
            var sprints = await sprintService.GetAllSprintsAsync();
            return View(sprints);
        }

        public async Task<IActionResult> DeletedSprint()
        {
            var sprints = await sprintService.GetAllDeletedSprintsAsync();
            return View(sprints);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var functions = await functionService.GetFunctions();
            var parameters = await parameterService.GetParameters();
            return View(new SprintAddModel { Functions = functions, Parameters = parameters});
        }

        [HttpPost]
        public async Task<IActionResult> Add(SprintAddModel sprintAddModel)
        {
            var map = mapper.Map<Sprint>(sprintAddModel);
            var result = await validator.ValidateAsync(map);

            if(result.IsValid)
            {
                await sprintService.CreateSprintAsync(sprintAddModel); // başarılıysa eklemeyi yapsın
                toastNotification.AddSuccessToastMessage(Message.Sprint.Add(sprintAddModel.SprintName)); // başarılıysa toast mesajı göstersin ve mesajda eklediği sprintin adı olsun
                return RedirectToAction("Index", "Sprint"); // başarılıysa sprint index sayfasına yönlendirsin
            }
            else
            {
                result.AddToModelState(this.ModelState); // başarısızsa tekrar view'e dönsün
            }

            var functions = await functionService.GetFunctions();
            var parameters = await parameterService.GetParameters();
            return View(new SprintAddModel { Functions = functions, Parameters = parameters });

        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id) // Guid id = Route'dan gelen id ile eşleşecek ve sprint bulunacak ve güncelleme için sprintUpdateModel'e maplenecek
        {
            var sprint = await sprintService.GetSprintAsync(id);
            var functions = await functionService.GetFunctions();
            var parameters = await parameterService.GetParameters();

            var sprintUpdateModel = mapper.Map<SprintUpdateModel>(sprint);
            sprintUpdateModel.Functions = functions;
            sprintUpdateModel.Parameters = parameters;


            return View(sprintUpdateModel);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SprintUpdateModel sprintUpdateModel)
        {
            var map = mapper.Map<Sprint>(sprintUpdateModel);
            var result = await validator.ValidateAsync(map);

            if (result.IsValid)
            {
                var sprintName = await sprintService.UpdateSprintAsync(sprintUpdateModel);
                toastNotification.AddSuccessToastMessage(Message.Sprint.Update(sprintName));
                return RedirectToAction("Index", "Sprint");
            }
            else
            {
                result.AddToModelState(this.ModelState);

            }

            var functions = await functionService.GetFunctions();
            var parameters = await parameterService.GetParameters();

            sprintUpdateModel.Functions = functions;
            sprintUpdateModel.Parameters = parameters;
            return View(sprintUpdateModel);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var sprintName = await sprintService.SafeDeleteSprintAsync(id);
            toastNotification.AddSuccessToastMessage(Message.Sprint.Delete(sprintName));

            return RedirectToAction("Index", "Sprint");
        }   

        public async Task<IActionResult> UndoDelete(Guid id)
        {
            var sprintName = await sprintService.UndoDeleteSprintAsync(id);
            toastNotification.AddSuccessToastMessage(Message.Sprint.UndoDelete(sprintName));

            return RedirectToAction("Index", "Sprint");
        }

        [HttpGet]
        public IActionResult Calculate(string selectedIds)
        {
            var model = new CalculateViewModel
            {
                SelectedIds = selectedIds
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Calculate(string calculateMethod, string selectedIds, string selectedNames)
        {
            if (calculateMethod == null)
            {
                // İlk kez hesaplama yöntemi seçimi yapılacak, seçilen sprint ID'lerini View'a gönder
                var model = new CalculateViewModel
                {
                    SelectedIds = selectedIds,
                    SelectedSprintNames = selectedNames
                };
                return View(model);
            }
            else if (calculateMethod == "İstatiksel")
            {
                var sprintIds = selectedIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(id => Guid.Parse(id))
                                           .ToArray();

                var totalPoints = await sprintService.CalculateTotalPointsAsync(sprintIds);


                var model = new CalculateViewModel
                {
                    SelectedIds = selectedIds,
                    SelectedSprintNames = selectedNames,
                    CalculateMethod = calculateMethod,
                    TotalPoints = totalPoints
                };

                return View(model);
            }
            else if (calculateMethod == "Yapay Zeka Tabanlı")
            {
                var sprintIds = selectedIds.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(id => Guid.Parse(id))
                                           .ToArray();

                var sprints = await sprintService.GetSprintDetailsAsync(sprintIds);

                // SprintDetailsModel nesnelerini Predictor sınıfının beklentisi olan bir veri tablosuna dönüştür
                List<List<string>> inputData = new List<List<string>>();

                foreach (var sprint in sprints)
                {
                    List<string> rowData = new List<string>
                    {
                        sprint.SprintName,
                        sprint.VersionInfo,
                        sprint.ItemNo,
                        sprint.DifficultyLevel,
                        sprint.FunctionName,
                        sprint.ParameterName,
                        sprint.ParameterDesc
                    };

                    inputData.Add(rowData);
                }

                // MachineLearning katmanındaki Predictor sınıfına tahmin için girdi olarak veri tablosunu gönder
                var predictor = new Predictor();
                string modelPath = "C:\\Users\\Fatih\\source\\repos\\SPCalculator\\MachineLearning\\Models\\egitilmis_model.pkl";  // Model dosya yolunu burada belirleyin
                predictor.LoadModel(modelPath);
                double predictions = predictor.Predict(inputData);

                ViewBag.Predictions = predictions;
                ViewBag.SelectedIds = selectedIds;
                ViewBag.SelectedSprintNames = selectedNames;
                ViewBag.CalculateMethod = calculateMethod;

                return View("Result");
            }

            return RedirectToAction("Calculate", new { selectedIds });
        }

        public IActionResult Result(string calculateMethod, string selectedIds, int totalPoints)
        {

            ViewBag.CalculateMethod = calculateMethod;
            ViewBag.selectedIds = selectedIds;
            ViewBag.TotalPoints = totalPoints;

            return View();
        }
    }
}
