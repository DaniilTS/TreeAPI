using Application.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Diagnostics;

namespace API.Filters
{
    public class ResponseOnExceptionFilter : IAsyncExceptionFilter
    {
        private readonly IJournalRepository _journalRepository;

        public ResponseOnExceptionFilter(IJournalRepository journalRepository)
        {
            _journalRepository = journalRepository;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            var traceId = Activity.Current?.Id ?? context.HttpContext?.TraceIdentifier;

            var errorMessage = $"Internal server error ID = {traceId}";
            if (context.Exception.GetType() == typeof(SecureException))
                errorMessage = context.Exception.Message;

            await AddJournalRow(context, traceId);

            context.Result = new ObjectResult(new
            {
                type = context.Exception.GetType().Name,
                id = traceId,
                data = new { message = errorMessage }
            })
            {
                StatusCode = 500
            };
        }

        private async Task AddJournalRow(ExceptionContext context, string traceId)
        {
            var request = context.HttpContext.Request;

            var journalRow = new Journal
            {
                Id = Guid.NewGuid(),
                EventId = traceId,
                Text = $"queryString: {request.GetDisplayUrl()}, body: {GetRequestBody(request)}, stackTrace: {context.Exception.StackTrace}",
                CreatedAt = DateTime.UtcNow
            };

            await _journalRepository.Create(journalRow);
        }

        private async Task<string> GetRequestBody(HttpRequest httpRequest)
        {
            httpRequest.EnableBuffering();
            var requestBody = await new StreamReader(httpRequest.Body).ReadToEndAsync();
            httpRequest.Body.Position = 0;

            return requestBody;
        }
    }
}