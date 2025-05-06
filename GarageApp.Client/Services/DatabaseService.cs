using System.Net;
using Blazored.LocalStorage;
using GarageApp.Shared.Features.ManageEquipment;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using Supabase.Functions;
using Supabase;
using Supabase.Gotrue;
using Supabase.Postgrest.Exceptions;
using Microsoft.Extensions.Logging;
using static Supabase.Postgrest.Constants;


namespace GarageApp.Client.Services
{
    public class DatabaseService
    {
        private readonly Supabase.Client _client;
        private readonly AuthenticationStateProvider _customAuthStateProvider;
        private readonly ILocalStorageService _localStorage;
        private readonly ILogger<DatabaseService> _logger;
        private readonly IDialogService _dialogService;

        public DatabaseService(
            Supabase.Client client,
            AuthenticationStateProvider customAuthStateProvider,
            ILocalStorageService localStorage,
            ILogger<DatabaseService> logger,
            IDialogService dialogService)
        {
            logger.LogInformation("------------------- CONSTRUCTOR -------------------");

            _client = client;
            _customAuthStateProvider = customAuthStateProvider;
            _localStorage = localStorage;
            _logger = logger;
            _dialogService = dialogService;
        }

        public async Task<IReadOnlyList<TModel>> From<TModel>() where TModel : BaseModelApp, new()
        {
            try
            {
                Console.WriteLine($"Запрос данных: {typeof(TModel).Name}");
                var modeledResponse = await _client.From<TModel>().Get();
                Console.WriteLine($"Получено записей: {modeledResponse.Models.Count}");
                _logger.LogDebug("???????");
                return modeledResponse.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка запроса: {ex.Message}");
                throw;
            }
        }


        public async Task<IReadOnlyList<TModel>> FromS<TModel>() where TModel : BaseModelApp, new()
        {
            try
            {
                Console.WriteLine($"Запрос данных: {typeof(TModel).Name}");
                var modeledResponse = await _client.Postgrest
                    .Table<TModel>()
                    .Select("*")
                    .Get();
                Console.WriteLine($"Получено записей: {modeledResponse.Models.Count}");
                _logger.LogDebug("???????");
                return modeledResponse.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка запроса: {ex.Message}");
                throw;
            }
        }

        public async Task<IReadOnlyList<TModel>> FromWithParametr<TModel>(int id, string inshuranceType) where TModel : BaseModelApp, new()
        {
            try
            {
                Console.WriteLine($"Запрос данных: {typeof(TModel).Name}");
                var modeledResponse = await _client.From<TModel>()
                    .Select("*")
                    .Filter("id", Operator.Equals, id)
                    .Filter("type", Operator.Equals,  inshuranceType)
                    .Order("id", Ordering.Descending)
                    .Limit(1)
                    .Get();
                Console.WriteLine($"Получено записей: {modeledResponse.Models.Count}");
                _logger.LogDebug("???????");
                return modeledResponse.Models;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка запроса: {ex.Message}");
                throw;
            }
        }
        public async Task<List<TModel>> Delete<TModel>(TModel item) where TModel : BaseModelApp, new()
        {
            var modeledResponse = await _client
                .From<TModel>()
                .Delete(item);
            return modeledResponse.Models;
        }

        public async Task<List<TModel>?> Insert<TModel>(TModel item) where TModel : BaseModelApp, new()
        {
            _logger.LogInformation("------------------- INSERT -------------------");
            Supabase.Postgrest.Responses.ModeledResponse<TModel> modeledResponse;
            try
            {
                modeledResponse = await _client
                    .From<TModel>()
                    .Insert(item);

                return modeledResponse.Models;
            }
            catch (PostgrestException ex)
            {
                if (ex.Response?.StatusCode == HttpStatusCode.Forbidden)
                    await _dialogService.ShowMessageBox(
                        "Warning",
                        "This database request was forbidden."
                    );
                else
                    await _dialogService.ShowMessageBox(
                        "Warning",
                        "This request was not completed because of some problem with the http request. \n "
                        + ex.Response?.RequestMessage
                    );
            }

            return null;
        }

    }
}
