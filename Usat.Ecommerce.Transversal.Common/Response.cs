﻿using FluentValidation.Results;

namespace Usat.Ecommerce.Transversal.Common
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public bool IsSucces { get; set; }
        public string Message { get; set; } = string.Empty;
        public IEnumerable<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();
    }
}
