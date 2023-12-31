﻿using RegistrantApp.ClientApi.Controllers.Base;
using RegistrantApp.Shared.Dto.Contragents;
using RestSharp;

namespace RegistrantApp.ClientApi.Controllers;

public class Contragents : BControllerRest
{
    public Contragents(string connectionString) : base(connectionString)
    {
        routeController = "Contragents";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="token">Действующий токен с необходимами правами</param>
    /// <param name="index">Страница</param>
    /// <param name="recordsByPage">Кол-во записей на странцие</param>
    /// <param name="showDeleted">Показывать удаленных</param>
    /// <param name="search">Поиск</param>
    /// <returns>Объект ViewContragentPagination </returns>
    public async Task<RestResponse> GetAsync(string token, int index, int recordsByPage,
        bool showDeleted, string search)
    {
        var options = new RestRequest($"{route}/{routeController}/Get", Method.Get);
        options.AddHeader("token", token);
        options.AddParameter("index", index);
        options.AddParameter("recordsByPage", recordsByPage);
        options.AddParameter("showDeleted", showDeleted);
        options.AddParameter("search", search);
        return await client.ExecuteAsync(options);
    }
    
    /// <summary>
    /// Создание контрагента
    /// </summary>
    /// <param name="token">Действующий токен с необходимами правами</param>
    /// <param name="dto">Объект передачи для создания контрагента</param>
    /// <returns> Объект ViewContragent </returns>
    public async Task<RestResponse> CreateAsync(string token, dtoContragentCreate dto)
    {
        var options = new RestRequest($"{route}/{routeController}/Create", Method.Post);
        options.AddHeader("token", token);
        options.AddBody(dto);
        return await client.ExecuteAsync(options);
    }
    
    /// <summary>
    /// Обновление контрагента
    /// </summary>
    /// <param name="token">Действующий токен с необходимами правами</param>
    /// <param name="dto">Объект передачи для обновления контрагента</param>
    /// <returns> Объект ViewContragent </returns>
    public async Task<RestResponse> UpdateAsync(string token, dtoContragentUpdate dto)
    {
        var options = new RestRequest($"{route}/{routeController}/Update", Method.Put);
        options.AddHeader("token", token);
        options.AddBody(dto);
        return await client.ExecuteAsync(options);
    }
    
    /// <summary>
    /// Удаление контрагента
    /// </summary>
    /// <param name="token">Действующий токен с необходимами правами</param>
    /// <param name="idsContragents">Массив ID контрагентов для удаления</param>
    /// <returns>ОК - если данные удалены</returns>
    public async Task<RestResponse> DeleteAsync(string token, long[] idsContragents)
    {
        var options = new RestRequest($"{route}/{routeController}/Delete", Method.Delete);
        options.AddHeader("token", token);
        options.AddBody(idsContragents);
        return await client.ExecuteAsync(options);
    }
    
}